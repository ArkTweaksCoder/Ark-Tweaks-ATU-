param()
$ErrorActionPreference = 'Stop'
Write-Host 'Restoring the balanced power plan...'
$null = powercfg /SETACTIVE SCHEME_BALANCED
Write-Host 'Balanced power plan active.'
