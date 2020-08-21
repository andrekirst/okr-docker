FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src/app
COPY ./src .
RUN dotnet restore "src.csproj"
RUN dotnet build "src.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "src.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "src.dll" ]