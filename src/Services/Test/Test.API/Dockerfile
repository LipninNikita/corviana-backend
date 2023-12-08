#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Test/Test.API/Test.API.csproj", "src/Services/Test/Test.API/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMq/EventBusRabbitMq.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMq/"]
COPY ["src/Services/Common/Services.Common/Services.Common.csproj", "src/Services/Common/Services.Common/"]
RUN dotnet restore "src/Services/Test/Test.API/Test.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Test/Test.API"
RUN dotnet build "Test.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.API.dll"]