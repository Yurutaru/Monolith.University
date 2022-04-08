#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Monolith.University.API/Monolith.University.API.csproj", "Monolith.University.API/"]
RUN dotnet restore "Monolith.University.API/Monolith.University.API.csproj"
COPY . .
WORKDIR "/src/Monolith.University.API"
RUN dotnet build "Monolith.University.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monolith.University.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monolith.University.API.dll"]