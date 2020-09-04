# Basisimage und benenne es "base"
# In diesem Fall die Runtime für .NET Core 3.1-Anwendungen
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# Setze aktuelles Arbeitsverzeichnis
WORKDIR /app
# Dokumentiere den Port 80/TCP
EXPOSE 80

# Basisimage und bennene es "build"
# In diesem Fall das SDK für .NET Core 3.1-Anwendungen
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# Setze das aktuelle Arbeitsverzeichnis
WORKDIR /src/app
# Kopiere die Daten vom Host (src-Ordner) in meinen aktuellen Ordner
COPY ./src .
# Führe das Kommando dotnet restore "src.csproj" zur Buildzeit aus
RUN dotnet restore "src.csproj"
# Führe das Kommando dotnet build "src.csproj" -c Release -o /app/build zur Buildzeit aus
RUN dotnet build "src.csproj" -c Release -o /app/build

# Basisimage und benenne es "publish"
# In diesem Fall das build-Image mit den Daten
FROM build as publish
RUN dotnet publish "src.csproj" -c Release -o /app/publish

# Basisimage und benenne es "final"
# In diesem Fall das base-Image (.NET-Core-Runtime)
FROM base as final
WORKDIR /app
# Kopiere Daten aus dem Stage publish in mein aktuelles Image
COPY --from=publish /app/publish .
# ENTRYPOINT konfiguriert den Container als ausführbare Datei
ENTRYPOINT [ "dotnet", "src.dll" ]