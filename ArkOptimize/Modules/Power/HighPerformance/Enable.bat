@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Switching to the High Performance power plan."
where powercfg >nul 2>&1
if errorlevel 1 (
  call :log "powercfg not found; skipping power-plan changes."
  exit /b 0
)

powercfg /SETACTIVE SCHEME_MIN >nul 2>&1
if errorlevel 1 (
  call :log "Failed to switch to the High Performance power plan."
  exit /b 1
)

powercfg /change monitor-timeout-ac 0 >nul 2>&1
powercfg /change monitor-timeout-dc 0 >nul 2>&1
powercfg /change standby-timeout-ac 0 >nul 2>&1
powercfg /change standby-timeout-dc 0 >nul 2>&1

call :log "High Performance plan active."
exit /b 0

:log
>> "%LOG_DIR%\power-plan.log" echo [%DATE% %TIME%] %*
exit /b 0
