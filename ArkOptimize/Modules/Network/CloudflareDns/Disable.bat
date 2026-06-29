@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Restoring DNS settings to automatic."
where netsh >nul 2>&1
if errorlevel 1 (
  call :log "netsh not found; skipping DNS rollback."
  exit /b 0
)

for %%I in ("Ethernet" "Wi-Fi" "Local Area Connection" "Wireless Network Connection" "Ethernet 2" "Ethernet 3" "Wi-Fi 2") do (
  netsh interface ip set dnsservers "%%~I" source=dhcp >nul 2>&1
  if not errorlevel 1 (
    call :log "DNS settings restored for interface %%~I."
    exit /b 0
  )
)

call :log "No supported network interface was found for the DNS rollback."
exit /b 0

:log
>> "%LOG_DIR%\dns.log" echo [%DATE% %TIME%] %*
exit /b 0
