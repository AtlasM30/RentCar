FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["RentCarApi/RentCarApi.csproj", "RentCarApi/"]
COPY ["RentCar.Application/RentCar.Application.csproj", "RentCar.Application/"]
COPY ["RentCar.Core/RentCar.Core.csproj", "RentCar.Core/"]
COPY ["RentCar.Infrastructure/RentCar.Infrastructure.csproj", "RentCar.Infrastructure/"]

RUN dotnet restore "RentCarApi/RentCarApi.csproj"

COPY . .

WORKDIR "/src/RentCarApi"

RUN dotnet publish "RentCarApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RentCarApi.dll"]