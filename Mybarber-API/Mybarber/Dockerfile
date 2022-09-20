#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Mybarber/Mybarber.csproj", "Mybarber/"]
RUN dotnet restore "Mybarber/Mybarber.csproj"
COPY . .
WORKDIR "/src/Mybarber"
RUN dotnet build "Mybarber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mybarber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


CMD ASPNETCORE_URLS=http://*:443 dotnet Mybarber.dll

