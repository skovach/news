# Use the .NET SDK 8 as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY News.Api/News.Api.csproj ./News.Api/
COPY News.Application/News.Application.csproj ./News.Application/
COPY News.Persistence/News.Persistence.csproj ./News.Persistence/
COPY News.Domain/News.Domain.csproj ./News.Domain/
COPY News.Infrastructure/News.Infrastructure.csproj ./News.Infrastructure/
RUN dotnet restore

# Copy everything else and build
COPY News.Api/. ./News.Api/
COPY News.Application/. ./News.Application/
COPY News.Persistence/. ./News.Persistence/
COPY News.Domain/. ./News.Domain/
COPY News.Infrastructure/. ./News.Infrastructure/
WORKDIR /app/News.Api
RUN dotnet publish -c Release -o out

# Build runtime image using .NET runtime 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/News.Api/out .
ENTRYPOINT ["dotnet", "News.Api.dll"]
