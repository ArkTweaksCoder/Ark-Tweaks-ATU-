param()
$ErrorActionPreference = 'Stop'
Write-Host 'Restoring automatic DNS settings...'
$adapter = Get-NetAdapter | Select-Object -First 1 -ExpandProperty Name
if ($adapter) {
    Set-DnsClientServerAddress -InterfaceAlias $adapter -ResetServerAddresses
}
Write-Host 'DNS settings restored to automatic.'
