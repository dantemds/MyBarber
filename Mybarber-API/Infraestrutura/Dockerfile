#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Infraestrutura/Infraestrutura.csproj", "Infraestrutura/"]
RUN dotnet restore "Infraestrutura/Infraestrutura.csproj"
COPY . .
WORKDIR "/src/Infraestrutura"
RUN dotnet build "Infraestrutura.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Infraestrutura.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infraestrutura.dll"]