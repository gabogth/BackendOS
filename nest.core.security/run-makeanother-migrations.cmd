@echo off
REM Ejecuta el .ps1 y deja la ventana abierta para ver resultados
powershell -NoProfile -ExecutionPolicy Bypass ^
          -File "%~dp0run-makeanother-migrations.ps1" %*
pause