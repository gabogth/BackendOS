@echo off
REM Ejecuta el .ps1 y deja la ventana abierta para ver resultados
powershell -NoProfile -ExecutionPolicy Bypass ^
          -File "%~dp0run-apply-migrations.ps1" %*
pause