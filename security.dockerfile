FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG ConnectionStrings__DefaultConnection
ARG ASPNETCORE_ENVIRONMENT

WORKDIR /src
COPY ["./nest.core.security/nest.core.security.csproj", "nest.core.security/"]
RUN dotnet restore "./nest.core.security/nest.core.security.csproj"
COPY . .
WORKDIR "/src/nest.core.security"
RUN dotnet build "./nest.core.security.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./nest.core.security.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet-ef database update

ENTRYPOINT ["dotnet", "dotnet ef database update", "nest.core.security.dll"]