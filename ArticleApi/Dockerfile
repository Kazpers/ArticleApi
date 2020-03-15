#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ArticleApi/ArticleApi.csproj", "ArticleApi/"]
RUN dotnet restore "ArticleApi/ArticleApi.csproj"
COPY . .
WORKDIR "/src/ArticleApi"
RUN dotnet build "ArticleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArticleApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArticleApi.dll"]