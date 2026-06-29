@echo off
setlocal EnableExtensions

set "LOG_DIR=%LOCALAPPDATA%\ArkSuite\Logs"
set "BACKUP_DIR=%LOCALAPPDATA%\ArkSuite\Backups\GameBar"
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%" >nul 2>&1
if not exist "%BACKUP_DIR%" mkdir "%BACKUP_DIR%" >nul 2>&1

call :log "Disabling Xbox Game Bar and Game DVR-related features."
if not exist "%BACKUP_DIR%\gamebar_dvr.reg" reg export "HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR" "%BACKUP_DIR%\gamebar_dvr.reg" /y >nul 2>&1
if not exist "%BACKUP_DIR%\gamebar.reg" reg export "HKCU\Software\Microsoft\GameBar" "%BACKUP_DIR%\gamebar.reg" /y >nul 2>&1

reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR" /v "AppCaptureEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR" /v "HistoricalCaptureEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR" /v "AudioCaptureEnabled" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\Software\Microsoft\GameBar" /v "AllowAutoGameMode" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\Software\Microsoft\GameBar" /v "ShowStartupTab" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\Software\Microsoft\GameBar" /v "AutoGameModeEnabled" /t REG_DWORD /d 0 /f >nul 2>&1

call :log "Game Bar-related settings disabled."
exit /b 0

:log
>> "%LOG_DIR%\gamebar.log" echo [%DATE% %TIME%] %*
exit /b 0
