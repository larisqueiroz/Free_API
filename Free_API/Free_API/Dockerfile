
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Free_API.csproj", "."]
RUN dotnet restore "Free_API.csproj"

COPY . .

RUN dotnet build "Free_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Free_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Free_API.dll"]
