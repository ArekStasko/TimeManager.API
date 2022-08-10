#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TimeManager.API/TimeManager.API.csproj", "TimeManager.API/"]
RUN dotnet restore "TimeManager.API/TimeManager.API.csproj"
COPY . .
WORKDIR "/src/TimeManager.API"
RUN dotnet build "TimeManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeManager.API.dll"]