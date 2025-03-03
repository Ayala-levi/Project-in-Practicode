# FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# ENV ASPNETCORE_URLS=http://+:80

# FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
# ARG configuration=Release
# WORKDIR /src
# COPY ["TodoApi.csproj", "./"]
# RUN dotnet restore "TodoApi.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "TodoApi.csproj" -c $configuration -o /app/build

# FROM build AS publish
# ARG configuration=Release
# RUN dotnet publish "TodoApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "TodoApi.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TodoApi.csproj", "./"]
RUN dotnet restore "TodoApi.csproj.user"
COPY . .
WORKDIR "/src"
RUN ls -la
RUN dotnet build "TodoApi.csproj" -c $configuration -o /app/build
RUN ls -la /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TodoApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false
RUN ls -la /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApi.dll"]