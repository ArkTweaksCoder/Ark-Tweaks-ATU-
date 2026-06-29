@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Applying Ultimate Performance power settings."
where powercfg >nul 2>&1
if errorlevel 1 (
  call :log "powercfg not found; skipping power-plan changes."
  exit /b 0
)

powercfg /duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61 >nul 2>&1
powercfg /SETACTIVE e9a42b02-d5df-448d-aa00-03f14749eb61 >nul 2>&1
if errorlevel 1 (
  call :log "The Ultimate Performance scheme could not be activated."
  exit /b 1
)

powercfg /change monitor-timeout-ac 0 >nul 2>&1
powercfg /change monitor-timeout-dc 0 >nul 2>&1
powercfg /change standby-timeout-ac 0 >nul 2>&1
powercfg /change standby-timeout-dc 0 >nul 2>&1

call :log "Ultimate Performance settings applied."
exit /b 0

:log
>> "%LOG_DIR%\power-plan.log" echo [%DATE% %TIME%] %*
exit /b 0
