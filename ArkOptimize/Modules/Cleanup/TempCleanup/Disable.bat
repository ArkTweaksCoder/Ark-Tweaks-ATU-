@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Temporary cleanup rollback requested; re-creating temp folders."
if not exist "%TEMP%" mkdir "%TEMP%" >nul 2>&1
if not exist "%SystemRoot%\Temp" mkdir "%SystemRoot%\Temp" >nul 2>&1

call :log "Temporary cleanup rollback completed."
exit /b 0

:log
>> "%LOG_DIR%\temp-cleanup.log" echo [%DATE% %TIME%] %*
exit /b 0
