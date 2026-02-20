param(
  [ValidateSet("Debug", "Release")]
  [string]$Configuration = "Release",

  [string]$OutputName = "KAIMISSION.exe"
)

$ErrorActionPreference = "Stop"

$projectPath = Join-Path $PSScriptRoot "KAI888\KAIMISSION.csproj"
$projectDir = Split-Path $projectPath -Parent
$orchestrator = Join-Path $PSScriptRoot "obfuscate-publish-singlefile.ps1"

if (!(Test-Path $orchestrator)) {
  throw "Script not found: $orchestrator"
}

[xml]$projectXml = Get-Content -Path $projectPath
$tfmNode = Select-Xml -Xml $projectXml -XPath "/Project/PropertyGroup/TargetFramework" | Select-Object -First 1
if ($null -eq $tfmNode -or [string]::IsNullOrWhiteSpace($tfmNode.Node.InnerText)) {
  throw "TargetFramework not found in: $projectPath"
}
$tfm = $tfmNode.Node.InnerText.Trim()
if (!($tfm -like "net4*")) {
  throw "This packer is intended for .NET Framework targets. Current target: $tfm"
}

powershell -ExecutionPolicy Bypass -File $orchestrator -Configuration $Configuration | Out-Host
if ($LASTEXITCODE -ne 0) {
  throw "Prepare step failed with exit code $LASTEXITCODE"
}

$platform = "x86"
$buildOutput = Join-Path $projectDir ("bin\" + $platform + "\" + $Configuration + "\" + $tfm)
$sourceDir = Join-Path $buildOutput "publish-obfuscated"
$singleDir = Join-Path $buildOutput "single-package"
if (!(Test-Path $sourceDir)) {
  throw "Source folder not found: $sourceDir"
}
if (!(Test-Path $singleDir)) {
  New-Item -ItemType Directory -Path $singleDir | Out-Null
}

$payloadWorkDir = Join-Path $env:TEMP ("kaimission_payload_" + [Guid]::NewGuid().ToString("N"))
New-Item -ItemType Directory -Path $payloadWorkDir | Out-Null

$payloadFiles = Get-ChildItem -Path $sourceDir -File |
  Where-Object { $_.Name -notlike "*.pdb" -and $_.Name -ne "Mapping.txt" }

if ($payloadFiles.Count -eq 0) {
  throw "No payload files found in: $sourceDir"
}

foreach ($f in $payloadFiles) {
  Copy-Item -Path $f.FullName -Destination (Join-Path $payloadWorkDir $f.Name) -Force
}

$payloadZip = Join-Path $env:TEMP ("kaimission_payload_" + [Guid]::NewGuid().ToString("N") + ".zip")
if (Test-Path $payloadZip) {
  Remove-Item $payloadZip -Force
}

Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($payloadWorkDir, $payloadZip, [System.IO.Compression.CompressionLevel]::Optimal, $false)

$launcherCs = Join-Path $env:TEMP ("kaimission_launcher_" + [Guid]::NewGuid().ToString("N") + ".cs")
$launcherCode = @'
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    private static int Main(string[] args)
    {
        try
        {
            string launcherPath = Assembly.GetExecutingAssembly().Location;
            string tempRoot = Path.Combine(Path.GetTempPath(), "KAIMISSION_SFX");
            string packageDir = Path.Combine(tempRoot, "pkg_" + GetStableId(launcherPath));
            string marker = Path.Combine(packageDir, ".ready");

            if (!File.Exists(marker))
            {
                if (Directory.Exists(packageDir))
                {
                    try { Directory.Delete(packageDir, true); } catch { }
                }

                Directory.CreateDirectory(packageDir);

                using (Stream payload = Assembly.GetExecutingAssembly().GetManifestResourceStream("KAIMISSIONPayload.zip"))
                {
                    if (payload == null)
                    {
                        throw new InvalidOperationException("Embedded payload not found.");
                    }

                    using (var archive = new ZipArchive(payload, ZipArchiveMode.Read))
                    {
                        archive.ExtractToDirectory(packageDir);
                    }
                }

                File.WriteAllText(marker, DateTime.UtcNow.ToString("O"));
            }

            string targetExe = Path.Combine(packageDir, "KAIMISSION.exe");
            if (!File.Exists(targetExe))
            {
                throw new FileNotFoundException("Target executable not found.", targetExe);
            }

            var psi = new ProcessStartInfo
            {
                FileName = targetExe,
                WorkingDirectory = packageDir,
                Arguments = BuildArguments(args),
                UseShellExecute = false
            };
            psi.EnvironmentVariables["KAIMISSION_HOST_EXE"] = launcherPath;

            using (Process p = Process.Start(psi))
            {
                if (p == null)
                {
                    return 1;
                }

                p.WaitForExit();
                return p.ExitCode;
            }
        }
        catch (Exception ex)
        {
            try
            {
                MessageBox.Show("Launcher error: " + ex.Message, "KAIMISSION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }

            return 1;
        }
    }

    private static string GetStableId(string launcherPath)
    {
        var fi = new FileInfo(launcherPath);
        return fi.Length.ToString("X") + "_" + fi.LastWriteTimeUtc.Ticks.ToString("X");
    }

    private static string BuildArguments(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            return string.Empty;
        }

        return string.Join(" ", args.Select(Quote));
    }

    private static string Quote(string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            return "\"\"";
        }

        bool needsQuotes = arg.Any(char.IsWhiteSpace) || arg.Contains("\"");
        if (!needsQuotes)
        {
            return arg;
        }

        return "\"" + arg.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
    }
}
'@

Set-Content -Path $launcherCs -Value $launcherCode -Encoding UTF8

$outputExe = Join-Path $singleDir $OutputName
if (Test-Path $outputExe) {
  Remove-Item $outputExe -Force
}

$cscPath = Join-Path $env:WINDIR "Microsoft.NET\Framework\v4.0.30319\csc.exe"
if (!(Test-Path $cscPath)) {
  throw "csc.exe not found: $cscPath"
}

$iconPath = Join-Path $projectDir "KAIMISSION.ico"
$cscArgs = @(
  "/nologo",
  "/target:winexe",
  "/platform:x86",
  "/optimize+",
  "/out:$outputExe",
  "/resource:$payloadZip,KAIMISSIONPayload.zip",
  "/reference:System.IO.Compression.dll",
  "/reference:System.IO.Compression.FileSystem.dll",
  "/reference:System.Windows.Forms.dll"
)
if (Test-Path $iconPath) {
  $cscArgs += "/win32icon:$iconPath"
}
$cscArgs += $launcherCs

& $cscPath @cscArgs
if ($LASTEXITCODE -ne 0) {
  throw "Launcher compile failed with exit code $LASTEXITCODE"
}

if (!(Test-Path $outputExe)) {
  throw "Single package was not created: $outputExe"
}

try {
  Remove-Item $launcherCs -Force
  Remove-Item $payloadZip -Force
  Remove-Item $payloadWorkDir -Recurse -Force
}
catch {
}

Write-Host ""
Write-Host "Single package for Win7/8.1 is ready at:"
Write-Host $outputExe



