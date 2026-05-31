FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/services/ApiGateaway/Ecommerce.ApiGateaway/Ecommerce.ApiGateaway.csproj", "src/services/ApiGateaway/Ecommerce.ApiGateaway/"]
RUN dotnet restore "src/services/ApiGateaway/Ecommerce.ApiGateaway/Ecommerce.ApiGateaway.csproj"

COPY . .

WORKDIR "/src/src/services/ApiGateaway/Ecommerce.ApiGateaway"
RUN dotnet build "Ecommerce.ApiGateaway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.ApiGateaway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.ApiGateaway.dll"]