# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo para dentro do cont�iner
COPY . .

# Restaura e publica o projeto principal
RUN dotnet restore "Auvo.GloboClima.API/Auvo.GloboClima.API.csproj"
RUN dotnet publish "Auvo.GloboClima.API/Auvo.GloboClima.API.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Definindo o ambiente
ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Auvo.GloboClima.API.dll"]