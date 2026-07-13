FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["nest.core.iclock/nest.core.iclock.csproj", "nest.core.iclock/"]
RUN dotnet restore "nest.core.iclock/nest.core.iclock.csproj"
COPY . .
WORKDIR /src/nest.core.iclock
RUN dotnet publish "nest.core.iclock.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:PublishReadyToRun=true

FROM public.ecr.aws/lambda/dotnet:9 AS final
WORKDIR /var/task
COPY --from=build /app/publish ./

CMD ["nest.core.iclock"]