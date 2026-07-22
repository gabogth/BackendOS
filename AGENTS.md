# BackendOS — Guía para el Agente

## ⚠️ Seguridad
- **`.env` contiene credenciales reales de AWS y tokens de Pulumi — NUNCA committear ni exponer.**
- `appsettings.json` contiene contraseñas reales de BD, credenciales SMTP y claves JWT.
- `connectionstring.txt` es un placeholder, ignorado.

## Arquitectura

Monorepo **Clean Architecture** (`.NET 9`, `nest.sln`):
- `nest.core.gateway` — Ocelot API Gateway (puerto 5128), enruta a 13 servicios (puertos 8381–8393)
- `nest.core.{servicio}` — 13 microservicios ASP.NET Core Web API
- `nest.core.dominio` — capa de dominio compartida
- `nest.core.aplicacion.{servicio}` — capa de aplicación por servicio
- `nest.core.infraestructura.{servicio}` — capa de infraestructura por servicio
- `nest.core.driver.{postgres|mysql|sqlserver}` — assemblies de proveedores EF Core
- `nest.core.aplication.auth` — helpers de autenticación compartidos (`DbContextSelector`, `MigrationService`, `MigrationResolver`)
- `nest.iac.generalinfra` / `nest.iac.servicesinfra` — Pulumi IaC (AWS)
- `nest.core.view.security` — frontend Angular

Todos los `Program.cs` de servicios son casi idénticos (CORS, Swagger+JWT, health checks `/health/live`, `ErrorHandlingMiddleware`). Solo `nest.core.security` ejecuta migraciones EF al iniciar mediante `MigrationResolver.ExecuteMigration`.

## Comandos Clave

```powershell
# Compilar toda la solución
dotnet build nest.sln

# Ejecutar con múltiples proyectos de inicio (VS: configurar gateway + security + logistica)
dotnet run --project nest.core.gateway
dotnet run --project nest.core.security
dotnet run --project nest.core.logistica

# Migraciones EF (ejecutar desde el directorio del servicio, ej. nest.core.security)
dotnet ef migrations add Init --project nest.core.driver.postgres --startup-project nest.core.security --context DbContextPsSql --connection=Npgsql
dotnet ef migrations add Init --project nest.core.driver.sqlserver --startup-project nest.core.security --context DbContextSqlServer --connection=SqlServer
dotnet ef migrations add Init --project nest.core.driver.mysql --startup-project nest.core.security --context DbContextMySql --connection=MySql
```

El script auxiliar `migrar-pg.ps1` envuelve el comando de migración para PostgreSQL (ejecutar desde el directorio del servicio).

## Mapa de Rutas del Gateway (ocelot.json)

| Servicio | Ruta Upstream | Puerto |
|---|---|---|
| logistica | `/logistica/{url}` | 8381 |
| security | `/security/{url}` | 8382 |
| rrhh | `/rrhh/{url}` | 8383 |
| corporativo | `/corporativo/{url}` | 8384 |
| legal | `/legal/{url}` | 8385 |
| general | `/general/{url}` | 8386 |
| costos | `/costos/{url}` | 8387 |
| finanzas | `/finanzas/{url}` | 8388 |
| contabilidad | `/contabilidad/{url}` | 8389 |
| mantto | `/mantto/{url}` | 8390 |
| patrimonial | `/patrimonial/{url}` | 8391 |
| datasource | `/datasource/{url}` | 8392 |
| iclock | `/iclock/{url}` | 8393 |

## Proveedor Multi-BD

Todos los servicios usan `DbContextSelector.SelectProvider(builder, ...)` de `nest.core.aplication.auth`. Lee la sección `Connections` de `appsettings.json` (claves: `SqlServer`, `Npgsql`, `MySql`). El servicio security es especial — pasa `!MigrationService.IsMigration()` como segundo argumento para controlar la selección del proveedor durante las migraciones.

## Despliegue

- **Docker**: Cada servicio tiene su propio `Dockerfile` (aspnet:9.0 multi-stage) + `lambda.Dockerfile` para AWS Lambda
- **Despliegue Lambda**: `uploadimage.ps1` construye+pushea a ECR y actualiza el código de la función Lambda
- **IaC**: `docker-compose.yml` ejecuta postgres + el contenedor Pulumi servicesiac
- **Variable de entorno Lambda**: `IS_LAMBDA` activa `AddAWSLambdaHosting`
- **BASE_URL** controla `app.UsePathBase` para despliegues con prefijo de ruta

## Infraestructura

- Base de datos: AWS RDS PostgreSQL (`nest-generalinfra-instance.cibyifu5bsuf.us-east-1.rds.amazonaws.com`)
- Stacks Pulumi: `gabogth/nest-generalinfra/dev`, `gabogth/nest-servicesinfra/dev`
- Redis: opcional, configurado mediante `RedisConfig.Enabled` (deshabilitado por defecto)

## Frontend

`nest.core.view.security` es una app Angular (ver su `package.json` y `.gitignore`).

## Pruebas

**No existen proyectos de prueba**. Cualquier adición debe seguir las convenciones de Clean Architecture.

## Convenciones

- Patrón Controlador → Servicio de Aplicación → Dominio → Infraestructura
- Todos los controladores retornan `LoadResult` de DevExtreme mediante `DataSourceLoader.Load()`
- El título de Swagger se deriva del tercer segmento del nombre del ensamblado (`nest.core.xxx` → `Xxx Api`)
- `appsettings.Development.json` es idéntico en todos los servicios (solo logging)
- `appsettings.Production.json` sobrescribe con la cadena de conexión de producción de RDS
- `GlobalUsings.cs` en cada proyecto para namespaces comunes
- `Nullable` está **deshabilitado** en todos los proyectos
