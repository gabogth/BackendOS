#Backend Nest
### Generar una migracion
cd nest.core.security
Para SQLServer
dotnet ef migrations add Init --project nest.core.driver.sqlserver --startup-project nest.core.security --context DbContextSqlServer -- connection=SqlServer

Para PostgreSql
dotnet ef migrations add Init --project nest.core.driver.postgres --startup-project nest.core.security --context DbContextPsSql -- connection=Npgsql

Para Mysql
dotnet ef migrations add Init --project nest.core.driver.mysql --startup-project nest.core.security --context DbContextMySql -- connection=MySql

### Iniciar servicios
Varios proyectos de inicio:
  - nest.core.gateway
  - nest.core.security
  - nest.core.logistica

### Verificar puertos del gateway
### Cada servicio tiene su propio swagger
  

##Iniciar base de datos 
docker pull mcr.microsoft.com/mssql/server
docker run --name sqlserverimage -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=4N&XY&d_0y6+" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker pull postgres
docker run --name postgresimage -e "POSTGRES_USER=postgres" -e "POSTGRES_PASSWORD=4N&XY&d_0y6+" -p 5431:5432 -d postgres
docker pull mysql
docker run --name mysqlimage -e "MYSQL_ROOT_PASSWORD=mysql" -p 3305:3306 -d mysql

