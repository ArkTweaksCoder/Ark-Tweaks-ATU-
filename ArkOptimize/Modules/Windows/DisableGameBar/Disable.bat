@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
set "BACKUP_DIR=%LOCALAPPDATA%\ArkSuite\Backups\GameBar"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1

call :log "Restoring Game Bar-related settings."
if exist "%BACKUP_DIR%\gamebar_dvr.reg" (
  reg import "%BACKUP_DIR%\gamebar_dvr.reg" >nul 2>&1
) else (
  reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR" /f >nul 2>&1
)

if exist "%BACKUP_DIR%\gamebar.reg" (
  reg import "%BACKUP_DIR%\gamebar.reg" >nul 2>&1
) else (
  reg delete "HKCU\Software\Microsoft\GameBar" /f >nul 2>&1
)

call :log "Game Bar-related settings restored."
exit /b 0

:log
>> "%LOG_DIR%\gamebar.log" echo [%DATE% %TIME%] %*
exit /b 0
