param()
$ErrorActionPreference = 'Stop'
Write-Host 'Switching to the High Performance power plan...'
$null = powercfg /SETACTIVE SCHEME_MIN
Write-Host 'High Performance plan active.'
