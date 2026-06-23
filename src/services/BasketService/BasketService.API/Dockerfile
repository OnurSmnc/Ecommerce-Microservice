FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/services/BasketService/BasketService.API/BasketService.API.csproj", "src/services/BasketService/BasketService.API/"]

# COPY ["src/services/BasketService/BasketService.Infrastructure/BasketService.Infrastructure.csproj", "src/services/BasketService/BasketService.Infrastructure/"]

# NuGet paketlerini geri yüklüyoruz
RUN dotnet restore "./src/services/BasketService/BasketService.API/BasketService.API.csproj"

# Kalan tüm kaynak kodları Docker içerisine kopyalıyoruz
COPY . .
WORKDIR "/src/src/services/BasketService/BasketService.API"

# Projeyi derliyoruz
RUN dotnet build "./BasketService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BasketService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.API.dll"]