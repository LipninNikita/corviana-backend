#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Statistic/Statistic.API/Statistic.API.csproj", "src/Services/Statistic/Statistic.API/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMq/EventBusRabbitMq.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMq/"]
COPY ["src/Services/Common/Services.Common/Services.Common.csproj", "src/Services/Common/Services.Common/"]
RUN dotnet restore "./src/Services/Statistic/Statistic.API/Statistic.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Statistic/Statistic.API"
RUN dotnet build "./Statistic.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Statistic.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Statistic.API.dll"]