FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["*.sln", "./"]
COPY ["Application/Project.Wta.Getway.Api.csproj", "Application/"]

RUN dotnet restore "Application/Project.Wta.Getway.Api.csproj"
COPY . . 
WORKDIR "/src/Application"


RUN mv appsettings.Docker.json appsettings.json

RUN dotnet build "Project.Wta.Getway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.Wta.Getway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
ENTRYPOINT ["dotnet", "Project.Wta.Getway.Api.dll"]

