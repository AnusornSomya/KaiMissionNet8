Release (Normal)
dotnet build .\KAI888\KAIMISSION.csproj -c Release -p:Platform=x86

Run (Normal)
.\KAI888\bin\x86\Release\net48\KAIMISSION.exe

Release (Obfuscate)
powershell -ExecutionPolicy Bypass -File .\obfuscate.ps1 -Configuration Release

Run (Obfuscated)
.\KAI888\bin\x86\Release\net48\obfuscated\KAIMISSION.exe

Single-file package (Win7/8.1)
powershell -ExecutionPolicy Bypass -File .\package-win7-singlefile.ps1 -Configuration Release -OutputName "KAIMISSION.exe"
