param()
$ErrorActionPreference = 'Stop'
Write-Host 'Removing safe temporary files...'
Remove-Item -Path $env:TEMP -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$env:SystemRoot\Temp" -Recurse -Force -ErrorAction SilentlyContinue
Write-Host 'Temporary file cleanup completed.'
