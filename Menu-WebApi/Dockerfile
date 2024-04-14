FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y curl
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Menu-WebApi/Menu-WebApi.csproj", "Menu-WebApi/"]
COPY ["Application/Application.csproj", "Application/"]
RUN dotnet restore "Menu-WebApi/Menu-WebApi.csproj"
COPY . .
WORKDIR "/src/Menu-WebApi"
RUN dotnet build "Menu-WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Menu-WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Menu-WebApi.dll"]
