param(
  [ValidateSet("Debug", "Release")]
  [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"

$projectPath = Join-Path $PSScriptRoot "KAI888\KAIMISSION.csproj"
$projectDir = Split-Path $projectPath -Parent
$configPath = Join-Path $projectDir "obfuscar.xml"

[xml]$projectXml = Get-Content -Path $projectPath
$tfmNode = Select-Xml -Xml $projectXml -XPath "/Project/PropertyGroup/TargetFramework" | Select-Object -First 1
if ($null -eq $tfmNode -or [string]::IsNullOrWhiteSpace($tfmNode.Node.InnerText)) {
  throw "TargetFramework not found in: $projectPath"
}

$tfm = $tfmNode.Node.InnerText.Trim()
$platform = "x86"
$buildOutput = Join-Path $projectDir ("bin\" + $platform + "\" + $Configuration + "\" + $tfm)
$obfOutput = Join-Path $buildOutput "obfuscated"

if (!(Test-Path $configPath)) {
  throw "Obfuscator config not found: $configPath"
}

dotnet tool restore | Out-Host
dotnet build $projectPath -c $Configuration -p:Platform=$platform | Out-Host

if (!(Test-Path $buildOutput)) {
  throw "Build output not found: $buildOutput"
}

if (Test-Path $obfOutput) {
  Remove-Item $obfOutput -Recurse -Force
}
New-Item -ItemType Directory -Path $obfOutput | Out-Null

Get-ChildItem -Path $buildOutput -Force |
  Where-Object { $_.Name -ne "obfuscated" } |
  ForEach-Object {
    Copy-Item -Path $_.FullName -Destination $obfOutput -Recurse -Force
  }

Push-Location $projectDir
try {
  dotnet tool run obfuscar.console "obfuscar.xml" | Out-Host
  if ($LASTEXITCODE -ne 0) {
    throw "Obfuscation failed with exit code $LASTEXITCODE"
  }
}
finally {
  Pop-Location
}

Write-Host ""
Write-Host "Obfuscated build is ready at:"
Write-Host $obfOutput

