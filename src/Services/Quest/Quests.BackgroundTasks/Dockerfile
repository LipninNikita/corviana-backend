#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Quest/Quests.BackgroundTasks/Quest.BackgroundTasks.csproj", "src/Services/Quest/Quests.BackgroundTasks/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMq/EventBusRabbitMq.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMq/"]
RUN dotnet restore "src/Services/Quest/Quests.BackgroundTasks/Quest.BackgroundTasks.csproj"
COPY . .
WORKDIR "/src/src/Services/Quest/Quests.BackgroundTasks"
RUN dotnet build "Quest.BackgroundTasks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quest.BackgroundTasks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quest.BackgroundTasks.dll"]