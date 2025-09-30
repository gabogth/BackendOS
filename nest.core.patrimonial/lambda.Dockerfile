FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["nest.core.patrimonial/nest.core.patrimonial.csproj", "nest.core.patrimonial/"]
RUN dotnet restore "nest.core.patrimonial/nest.core.patrimonial.csproj"
COPY . .
WORKDIR /src/nest.core.patrimonial
RUN dotnet publish "nest.core.patrimonial.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:PublishReadyToRun=true

FROM public.ecr.aws/lambda/dotnet:9 AS final
WORKDIR /var/task
COPY --from=build /app/publish ./

CMD ["nest.core.patrimonial"]
