#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ApiGateways/Web.Bff/Web.Bff.ApiGateway/Web.Bff.ApiGateway.csproj", "src/ApiGateways/Web.Bff/Web.Bff.ApiGateway/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMq/EventBusRabbitMq.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMq/"]
COPY ["src/Services/Common/Services.Common/Services.Common.csproj", "src/Services/Common/Services.Common/"]
RUN dotnet restore "src/ApiGateways/Web.Bff/Web.Bff.ApiGateway/Web.Bff.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Web.Bff/Web.Bff.ApiGateway"
RUN dotnet build "Web.Bff.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Bff.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Bff.ApiGateway.dll"]