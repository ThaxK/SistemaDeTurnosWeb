FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SistemaDeTurnosWeb.csproj", "."]
RUN dotnet restore "SistemaDeTurnosWeb.csproj"
COPY . .
RUN dotnet build "SistemaDeTurnosWeb.csproj" -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaDeTurnosWeb.csproj" -c Release --no-restore -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaDeTurnosWeb.dll"]
