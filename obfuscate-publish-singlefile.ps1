param(
  [ValidateSet("Debug", "Release")]
  [string]$Configuration = "Release",

  [string]$RuntimeIdentifier = "win-x86"
)

$ErrorActionPreference = "Stop"

$projectPath = Join-Path $PSScriptRoot "KAI888\KAIMISSION.csproj"
$projectDir = Split-Path $projectPath -Parent
$obfuscateScript = Join-Path $PSScriptRoot "obfuscate.ps1"

[xml]$projectXml = Get-Content -Path $projectPath
$tfmNode = Select-Xml -Xml $projectXml -XPath "/Project/PropertyGroup/TargetFramework" | Select-Object -First 1
if ($null -eq $tfmNode -or [string]::IsNullOrWhiteSpace($tfmNode.Node.InnerText)) {
  throw "TargetFramework not found in: $projectPath"
}

$tfm = $tfmNode.Node.InnerText.Trim()
$platform = "x86"
$buildOutput = Join-Path $projectDir ("bin\" + $platform + "\" + $Configuration + "\" + $tfm)
$obfOutput = Join-Path $buildOutput "obfuscated"

if (!(Test-Path $obfuscateScript)) {
  throw "Obfuscate script not found: $obfuscateScript"
}

powershell -ExecutionPolicy Bypass -File $obfuscateScript -Configuration $Configuration | Out-Host
if ($LASTEXITCODE -ne 0) {
  throw "Obfuscation step failed with exit code $LASTEXITCODE"
}

if (!(Test-Path $obfOutput)) {
  throw "Obfuscated output not found: $obfOutput"
}

if ($tfm -like "net4*") {
  $publishDir = Join-Path $buildOutput "publish-obfuscated"
  if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
  }
  New-Item -ItemType Directory -Path $publishDir | Out-Null

  Get-ChildItem -Path $obfOutput -Force |
    ForEach-Object {
      Copy-Item -Path $_.FullName -Destination $publishDir -Recurse -Force
    }

  Write-Host ""
  Write-Host "TargetFramework $tfm does not support PublishSingleFile."
  Write-Host "Obfuscated package folder is ready at:"
  Write-Host $publishDir
  exit 0
}

$publishDir = Join-Path $buildOutput ($RuntimeIdentifier + "\publish-obfuscated-single")
$originalDll = Join-Path $buildOutput "KAIMISSION.dll"
$obfuscatedDll = Join-Path $obfOutput "KAIMISSION.dll"
$backupDll = Join-Path $buildOutput "KAIMISSION.dll.__bak_original"

if (!(Test-Path $originalDll)) {
  throw "Original build DLL not found: $originalDll"
}
if (!(Test-Path $obfuscatedDll)) {
  throw "Obfuscated DLL not found: $obfuscatedDll"
}

if (Test-Path $backupDll) {
  Remove-Item $backupDll -Force
}
Copy-Item -Path $originalDll -Destination $backupDll -Force

try {
  # Temporarily swap in obfuscated DLL so publish bundles it.
  Copy-Item -Path $obfuscatedDll -Destination $originalDll -Force

  if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
  }
  New-Item -ItemType Directory -Path $publishDir | Out-Null

  dotnet publish $projectPath -c $Configuration -r $RuntimeIdentifier --self-contained true -p:Platform=$platform -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:EnableCompressionInSingleFile=true -p:DebugType=None -p:DebugSymbols=false -p:NoBuild=true -p:PublishDir="$publishDir\" | Out-Host
  if ($LASTEXITCODE -ne 0) {
    throw "Publish step failed with exit code $LASTEXITCODE"
  }
}
finally {
  if (Test-Path $backupDll) {
    Copy-Item -Path $backupDll -Destination $originalDll -Force
    Remove-Item $backupDll -Force
  }
}

$outputExe = Join-Path $publishDir "KAIMISSION.exe"
if (!(Test-Path $outputExe)) {
  throw "Single-file exe not found: $outputExe"
}

Write-Host ""
Write-Host "Obfuscated single-file publish is ready at:"
Write-Host $outputExe

