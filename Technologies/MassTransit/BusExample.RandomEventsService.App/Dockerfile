FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BusExample.RandomEventsService.App/BusExample.RandomEventsService.App.csproj", "BusExample.RandomEventsService.App/"]
RUN dotnet restore "BusExample.RandomEventsService.App/BusExample.RandomEventsService.App.csproj"
COPY . .
WORKDIR "/src/BusExample.RandomEventsService.App"
RUN dotnet build "BusExample.RandomEventsService.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusExample.RandomEventsService.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusExample.RandomEventsService.App.dll"]
