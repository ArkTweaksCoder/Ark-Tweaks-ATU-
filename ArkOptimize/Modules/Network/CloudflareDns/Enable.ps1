param()
$ErrorActionPreference = 'Stop'
Write-Host 'Applying Cloudflare DNS settings...'
$adapter = Get-NetAdapter | Select-Object -First 1 -ExpandProperty Name
if ($adapter) {
    Set-DnsClientServerAddress -InterfaceAlias $adapter -ServerAddresses ('1.1.1.1','1.0.0.1')
}
Write-Host 'Cloudflare DNS settings applied.'
