FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nest.core.patrimonial/nest.core.patrimonial.csproj", "nest.core.patrimonial/"]
RUN dotnet restore "nest.core.patrimonial/nest.core.patrimonial.csproj"
COPY . .
WORKDIR "/src/nest.core.patrimonial"
RUN dotnet build "nest.core.patrimonial.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "nest.core.patrimonial.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nest.core.patrimonial.dll"]
