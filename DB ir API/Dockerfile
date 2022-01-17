#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DB ir API/DB ir API.csproj", "DB ir API/"]
RUN dotnet restore "DB ir API/DB ir API.csproj"
COPY . .
WORKDIR "/src/DB ir API"
RUN dotnet build "DB ir API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DB ir API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DB ir API.dll"]