@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Applying Cloudflare DNS settings."
where netsh >nul 2>&1
if errorlevel 1 (
  call :log "netsh not found; skipping DNS changes."
  exit /b 0
)

for %%I in ("Ethernet" "Wi-Fi" "Local Area Connection" "Wireless Network Connection" "Ethernet 2" "Ethernet 3" "Wi-Fi 2") do (
  netsh interface ip set dnsservers "%%~I" static 1.1.1.1 primary validate=no >nul 2>&1
  if not errorlevel 1 (
    netsh interface ip add dnsservers "%%~I" 1.0.0.1 index=2 validate=no >nul 2>&1
    call :log "Cloudflare DNS settings applied to interface %%~I."
    exit /b 0
  )
)

call :log "No supported network interface was found for the DNS change."
exit /b 0

:log
>> "%LOG_DIR%\dns.log" echo [%DATE% %TIME%] %*
exit /b 0
