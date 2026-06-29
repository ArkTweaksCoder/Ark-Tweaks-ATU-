param()
$ErrorActionPreference = 'Stop'
Write-Host 'Restoring balanced power plan settings...'
$null = powercfg /SETACTIVE SCHEME_BALANCED
Write-Host 'Balanced power plan restored.'
