#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["Character.API/Character.API.csproj", "Character.API/"]
COPY ["Character.Business/Character.Business.csproj", "Character.Business/"]
COPY ["Character.Repository/Character.Repository.csproj", "Character.Repository/"]
COPY ["Character.Shared/Character.Shared.csproj", "Character.Shared/"]
RUN dotnet restore "./Character.API/Character.API.csproj"
COPY . .
WORKDIR "/src/Character.API"
RUN dotnet build "./Character.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Character.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Character.API.dll"]