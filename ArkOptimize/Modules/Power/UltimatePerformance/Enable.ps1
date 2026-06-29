param()
$ErrorActionPreference = 'Stop'
Write-Host 'Applying safe Ultimate Performance power plan settings...'
$null = powercfg /SETACTIVE SCHEME_MIN
Write-Host 'Ultimate Performance settings applied.'
