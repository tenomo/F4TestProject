#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/server/F4TestProject.API/F4TestProject.API.csproj", "src/server/F4TestProject.API/"]
RUN dotnet restore "src/server/F4TestProject.API/F4TestProject.API.csproj"
COPY . .
WORKDIR "/src/src/server/F4TestProject.API"
RUN dotnet build "F4TestProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "F4TestProject.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "F4TestProject.API.dll"]