#Backend Nest
### Generar una migracion
cd nest.core.security
Para SQLServer
dotnet ef migrations add initial -o Migrations/SqlServer --context DbContextSqlServer -- connection=Connection_Tenant_1
dotnet ef database update --context DbContextSqlServer -- connection=Connection_Tenant_1
luego para futuras migraciones omitir -o osea:
dotnet ef migrations add migrations2 --context DbContextSqlServer -- connection=Connection_Tenant_1

Para PostgreSql
dotnet ef migrations add initial -o Migrations/PostgreSql --context DbContextPsSql -- connection=Connection_Tenant_2
dotnet ef database update --context DbContextPsSql -- connection=Connection_Tenant_2
luego para futuras migraciones omitir -o osea:
dotnet ef migrations add migrations2 --context DbContextPsSql -- connection=Connection_Tenant_2

Para Mysql
dotnet ef migrations add initial -o Migrations/Mysql --context DbContextMySql -- connection=Connection_Tenant_3
dotnet ef database update --context DbContextMySql -- connection=Connection_Tenant_3
luego para futuras migraciones omitir -o osea:
dotnet ef migrations add migrations2 --context DbContextMySql -- connection=Connection_Tenant_3
### Generar bbdd
```
cd nest.core.security
dotnet ef database update
```

### Iniciar servicios
Varios proyectos de inicio:
  - nest.core.gateway
  - nest.core.security
  - nest.core.logistica

### Verificar puertos del gateway
### Cada servicio tiene su propio swagger
  

##Iniciar base de datos 
docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=4N&XY&d_0y6+" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker pull postgres
docker run --name postgresimage -e "POSTGRES_USER=postgres" -e "POSTGRES_PASSWORD=4N&XY&d_0y6+" -p 5431:5432 -d postgres
docker pull mysql
docker run --name mysqlimage -e "MYSQL_ROOT_PASSWORD=mysql" -p 3305:3306 -d mysql
docker pull mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator
docker run -d --name cosmosimage -p 3051:8081 -p 8900-8902:8900-8902 -e AZURE_COSMOS_EMULATOR_PARTITION_COUNT=10 -e AZURE_COSMOS_EMULATOR_ENABLE_DATA_PERSISTENCE=true -v cosmosdata:/cosmos/appdata -d mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest

