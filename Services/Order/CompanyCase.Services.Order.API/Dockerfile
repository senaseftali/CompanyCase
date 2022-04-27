FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Order/CompanyCase.Services.Order.API/CompanyCase.Services.Order.API.csproj", "Services/Order/CompanyCase.Services.Order.API/"]
COPY ["CompanyCase.Shared/CompanyCase.Shared.csproj", "CompanyCase.Shared/"]
RUN dotnet restore "Services/Order/CompanyCase.Services.Order.API/CompanyCase.Services.Order.API.csproj"
COPY . .
WORKDIR "/src/Services/Order/CompanyCase.Services.Order.API"
RUN dotnet build "CompanyCase.Services.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyCase.Services.Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyCase.Services.Order.API.dll"]