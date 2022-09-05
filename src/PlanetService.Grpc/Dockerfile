#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PlanetService.Grpc/PlanetService.Grpc.csproj", "src/PlanetService.Grpc/"]
COPY ["src/PlanetService.DataAccess/PlanetService.DataAccess.csproj", "src/PlanetService.DataAccess/"]
COPY ["src/PlanetService.BusinessLogic/PlanetService.BusinessLogic.csproj", "src/PlanetService.BusinessLogic/"]
RUN dotnet restore "src/PlanetService.Grpc/PlanetService.Grpc.csproj"
COPY . .
WORKDIR "/src/src/PlanetService.Grpc"
RUN dotnet build "PlanetService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlanetService.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlanetService.Grpc.dll"]