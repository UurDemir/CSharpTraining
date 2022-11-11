#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Firebrand.API/Firebrand.API.csproj", "Firebrand.API/"]
RUN dotnet restore "Firebrand.API/Firebrand.API.csproj"
COPY . .
WORKDIR "/src/Firebrand.API"
RUN dotnet build "Firebrand.API.csproj" -c Release -o /app/build
WORKDIR "/src/Firebrand.API"
RUN dotnet build "Firebrand.API.csproj" -c Release -o /app/build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Firebrand.API.dll"]

