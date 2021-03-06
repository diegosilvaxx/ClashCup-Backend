#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/DevIO.Api/DevIO.Api.csproj", "src/DevIO.Api/"]
COPY ["src/DevIO.Data/DevIO.Data.csproj", "src/DevIO.Data/"]
COPY ["src/DevIO.Business/DevIO.Business.csproj", "src/DevIO.Business/"]
RUN dotnet restore "src/DevIO.Api/DevIO.Api.csproj"
COPY . .
WORKDIR "/src/src/DevIO.Api"
RUN dotnet build "DevIO.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevIO.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevIO.Api.dll"]