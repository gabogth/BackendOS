<#  run-migrations.ps1
    Ejecuta las migraciones y actualiza las bases
    Uso:
        pwsh run-migrations.ps1                # estando en la carpeta del .csproj
        pwsh run-migrations.ps1 -Path ./src    # opcional, cambia de ruta antes de correr
#>

param(
    [string]$Path = "."
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

Push-Location $Path   # entra al directorio del proyecto
$mig = "migration_{0}" -f (Get-Random -Min 10000000 -Max 99999999)
# Lista de pasos: texto antes de «dotnet» para mostrar y lista real de argumentos a dotnet
$steps = @(
    @{ msg = "Add SQL Server migration"; args = "ef migrations add $($mig) --context DbContextSqlServer -- connection=Connection_Tenant_1" },
    @{ msg = "Add PostgreSQL migration"; args = "ef migrations add $($mig) --context DbContextPsSql -- connection=Connection_Tenant_2" },
    @{ msg = "Add MySQL migration";  args = "ef migrations add $($mig) --context DbContextMySql -- connection=Connection_Tenant_3" }
)

foreach ($step in $steps) {
    Write-Host "==> $($step.msg)"
    
    # Llama a dotnet y espera (-Wait). Si algo falla, $process.ExitCode ≠ 0.
    $process = Start-Process "dotnet" -ArgumentList $step.args `
                               -NoNewWindow -Wait -PassThru
    
    if ($process.ExitCode -ne 0) {
        Write-Error "⛔  Falló «dotnet $($step.args)» (ExitCode $($process.ExitCode)). Abortando."
        exit $process.ExitCode
    }
}

Pop-Location
Write-Host "`n✔️  Migraciones y actualizaciones completadas sin errores."