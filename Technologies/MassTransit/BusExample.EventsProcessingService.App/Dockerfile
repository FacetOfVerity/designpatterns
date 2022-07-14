FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusExample.EventsProcessingService.App/BusExample.EventsProcessingService.App.csproj", "BusExample.EventsProcessingService.App/"]
RUN dotnet restore "BusExample.EventsProcessingService.App/BusExample.EventsProcessingService.App.csproj"
COPY . .
WORKDIR "/src/BusExample.EventsProcessingService.App"
RUN dotnet build "BusExample.EventsProcessingService.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusExample.EventsProcessingService.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusExample.EventsProcessingService.App.dll"]
