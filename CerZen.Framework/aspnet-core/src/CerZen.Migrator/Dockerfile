#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CerZen.Migrator/CerZen.Migrator.csproj", "src/CerZen.Migrator/"]
COPY ["src/CerZen.EntityFrameworkCore/CerZen.EntityFrameworkCore.csproj", "src/CerZen.EntityFrameworkCore/"]
COPY ["src/CerZen.Core/CerZen.Core.csproj", "src/CerZen.Core/"]
COPY ["src/CerZen.Core.Shared/CerZen.Core.Shared.csproj", "src/CerZen.Core.Shared/"]
RUN dotnet restore "src/CerZen.Migrator/CerZen.Migrator.csproj"
COPY . .
WORKDIR "/src/src/CerZen.Migrator"
RUN dotnet build "CerZen.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CerZen.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CerZen.Migrator.dll", "-s"]
