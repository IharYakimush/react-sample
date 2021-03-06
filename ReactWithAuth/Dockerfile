#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV DEBIAN_FRONTEND noninteractive
RUN apt-get update -y              && \
    apt-get install nodejs npm -y  && \
    npm install npm@latest -g
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ReactWithAuth/ReactWithAuth.csproj", "ReactWithAuth/"]
COPY ["Identity/Identity.csproj", "Identity/"]
RUN dotnet restore "ReactWithAuth/ReactWithAuth.csproj"
COPY . .
WORKDIR "/src/ReactWithAuth"
RUN dotnet build "ReactWithAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReactWithAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReactWithAuth.dll"]