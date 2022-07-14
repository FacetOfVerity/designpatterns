FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusExample.EventsLoggingService.App/BusExample.EventsLoggingService.App.csproj", "BusExample.EventsLoggingService.App/"]
RUN dotnet restore "BusExample.EventsLoggingService.App/BusExample.EventsLoggingService.App.csproj"
COPY . .
WORKDIR "/src/BusExample.EventsLoggingService.App"
RUN dotnet build "BusExample.EventsLoggingService.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusExample.EventsLoggingService.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusExample.EventsLoggingService.App.dll"]
