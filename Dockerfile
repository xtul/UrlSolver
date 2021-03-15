#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["UrlSolver.csproj", ""]
RUN dotnet restore "./UrlSolver.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "UrlSolver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrlSolver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrlSolver.dll"]