FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY tparf.Api/tparf.Api.csproj tparf.Api/
COPY tparf.Models/tparf.Models.csproj tparf.Models/
COPY . .

RUN dotnet restore tparf.Api/tparf.Api.csproj

WORKDIR /src/tparf.Api
RUN dotnet build tparf.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish tparf.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tparf.Api.dll"]