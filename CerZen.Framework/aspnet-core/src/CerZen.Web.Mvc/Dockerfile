#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CerZen.Web.Mvc/CerZen.Web.Mvc.csproj", "src/CerZen.Web.Mvc/"]
COPY ["src/CerZen.Web.Core/CerZen.Web.Core.csproj", "src/CerZen.Web.Core/"]
COPY ["src/CerZen.Application/CerZen.Application.csproj", "src/CerZen.Application/"]
COPY ["src/CerZen.Application.Shared/CerZen.Application.Shared.csproj", "src/CerZen.Application.Shared/"]
COPY ["src/CerZen.Core.Shared/CerZen.Core.Shared.csproj", "src/CerZen.Core.Shared/"]
COPY ["src/CerZen.Core/CerZen.Core.csproj", "src/CerZen.Core/"]
COPY ["src/CerZen.EntityFrameworkCore/CerZen.EntityFrameworkCore.csproj", "src/CerZen.EntityFrameworkCore/"]
COPY ["src/CerZen.GraphQL/CerZen.GraphQL.csproj", "src/CerZen.GraphQL/"]
RUN dotnet restore "src/CerZen.Web.Mvc/CerZen.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/CerZen.Web.Mvc"
RUN dotnet build "CerZen.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CerZen.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CerZen.Web.Mvc.dll"]
