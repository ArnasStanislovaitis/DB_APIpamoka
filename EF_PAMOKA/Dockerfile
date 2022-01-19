#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EF_PAMOKA/EF_PAMOKA.csproj", "EF_PAMOKA/"]
RUN dotnet restore "EF_PAMOKA/EF_PAMOKA.csproj"
COPY . .
WORKDIR "/src/EF_PAMOKA"
RUN dotnet build "EF_PAMOKA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EF_PAMOKA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet EF_PAMOKA.dll