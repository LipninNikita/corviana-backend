#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Quest/Quest.API/Quest.API.csproj", "src/Services/Quest/Quest.API/"]
RUN dotnet restore "src/Services/Quest/Quest.API/Quest.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Quest/Quest.API"
RUN dotnet build "Quest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quest.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quest.API.dll"]