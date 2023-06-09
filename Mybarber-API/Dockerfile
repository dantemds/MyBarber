
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


# Copia os arquivos do projeto e restaura as dependências
COPY COPY ["*.sln", "."]
COPY ["Mybarber/Mybarber.csproj", "Mybarber/"]
COPY ["Infraestrutura/Infraestrutura.csproj", "Infraestrutura/"]
COPY ["Dominio/Dominio.csproj", "Dominio/"]
COPY ["Application/Aplicacao.csproj", "Application/"]
COPY ["Application/Aplicacao.csproj", "Application/"]
RUN dotnet restore
# Copia todos os arquivos do projeto para o diretório de trabalho
COPY . .
# Publica os projetos em um diretório de saída
RUN dotnet build "Mybarber.csproj" -c Release -o /app/build

# Define a imagem base para executar o aplicativo publicado
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:3000 dotnet Mybarber.dll

