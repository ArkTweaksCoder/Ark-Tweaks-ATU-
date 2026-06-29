param()
$ErrorActionPreference = 'Stop'
Write-Host 'Restoring Game Bar settings...'
Remove-Item -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\GameDVR' -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path 'HKCU:\Software\Microsoft\GameBar' -Recurse -Force -ErrorAction SilentlyContinue
Write-Host 'Game Bar settings restored.'
