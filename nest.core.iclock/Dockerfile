FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nest.core.iclock/nest.core.iclock.csproj", "nest.core.iclock/"]
RUN dotnet restore "nest.core.iclock/nest.core.iclock.csproj"
COPY . .
WORKDIR "/src/nest.core.iclock"
RUN dotnet build "nest.core.iclock.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "nest.core.iclock.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nest.core.iclock.dll"]
