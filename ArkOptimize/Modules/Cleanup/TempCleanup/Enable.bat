@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Starting temporary file cleanup."

for %%F in ("%TEMP%\*") do if exist "%%~fF" del /f /q "%%~fF"
for /d %%D in ("%TEMP%\*") do if exist "%%~fD" rd /s /q "%%~fD"
for %%F in ("%SystemRoot%\Temp\*") do if exist "%%~fF" del /f /q "%%~fF"
for /d %%D in ("%SystemRoot%\Temp\*") do if exist "%%~fD" rd /s /q "%%~fD"

call :log "Temporary file cleanup completed."
exit /b 0

:log
>> "%LOG_DIR%\temp-cleanup.log" echo [%DATE% %TIME%] %*
exit /b 0
