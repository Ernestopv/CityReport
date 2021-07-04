#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
# Fetch and install Node 14. Make sure to include the --yes parameter 
# to automatically accept prompts during install, or it'll fail.
RUN curl --silent --location https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ["CityReport/CityReport.csproj", "CityReport/"]
COPY ["CityReport.Models/CityReport.Models.csproj", "CityReport.Models/"]
RUN dotnet restore "CityReport/CityReport.csproj"
COPY . .
WORKDIR "/src/CityReport"
RUN dotnet build "CityReport.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CityReport.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CityReport.dll"]