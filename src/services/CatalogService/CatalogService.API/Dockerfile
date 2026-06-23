FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/shared/Shared.Common.csproj", "src/shared/"]
COPY ["src/services/CatalogService/CatalogService.API/CatalogService.API.csproj", "src/services/CatalogService/CatalogService.API/"]
COPY ["src/services/CatalogService/CatalogService.Application/CatalogService.Application.csproj", "src/services/CatalogService/CatalogService.Application/"]
COPY ["src/services/CatalogService/CatalogService.Domain/CatalogService.Domain.csproj", "src/services/CatalogService/CatalogService.Domain/"]
COPY ["src/services/CatalogService/CatalogService.Infrastructure/CatalogService.Infrastructure.csproj", "src/services/CatalogService/CatalogService.Infrastructure/"]
COPY ["src/services/CatalogService/CatalogService.Mapper/CatalogService.Mapper.csproj", "src/services/CatalogService/CatalogService.Mapper/"]

RUN dotnet restore "src/services/CatalogService/CatalogService.API/CatalogService.API.csproj"

COPY . .

WORKDIR "/src/src/services/CatalogService/CatalogService.API"
RUN dotnet build "CatalogService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.API.dll"]