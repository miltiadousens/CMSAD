FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projektfilerne kopieres først, så pakker kun hentes igen, når de ændrer sig
COPY Employees.API/Employees.API.csproj Employees.API/
COPY Employees.Application/Employees.Application.csproj Employees.Application/
COPY Employees.Domain/Employees.Domain.csproj Employees.Domain/
COPY Employees.Facade/Employees.Facade.csproj Employees.Facade/
COPY Employees.Infrastructure/Employees.Infrastructure.csproj Employees.Infrastructure/
RUN dotnet restore Employees.API/Employees.API.csproj

# Derefter kopieres koden, som bygges og publiceres
COPY . .
RUN dotnet publish Employees.API/Employees.API.csproj -c $BUILD_CONFIGURATION -o /app/publish --no-restore /p:UseAppHost=false

# Det færdige image indeholder kun runtime og den publicerede app
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
COPY --from=build /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "Employees.API.dll"]