#Backend Nest
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
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=sa" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

