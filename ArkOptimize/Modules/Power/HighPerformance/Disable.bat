@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Restoring the balanced power plan."
where powercfg >nul 2>&1
if errorlevel 1 (
  call :log "powercfg not found; skipping power-plan rollback."
  exit /b 0
)

powercfg /SETACTIVE SCHEME_BALANCED >nul 2>&1
if errorlevel 1 (
  call :log "Failed to restore the balanced power plan."
  exit /b 1
)

call :log "Balanced power plan active."
exit /b 0

:log
>> "%LOG_DIR%\power-plan.log" echo [%DATE% %TIME%] %*
exit /b 0
