#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Product/CompanyCase.Services.Product.API/CompanyCase.Services.Product.API.csproj", "Services/Product/CompanyCase.Services.Product.API/"]
COPY ["CompanyCase.Shared/CompanyCase.Shared.csproj", "CompanyCase.Shared/"]
RUN dotnet restore "Services/Product/CompanyCase.Services.Product.API/CompanyCase.Services.Product.API.csproj"
COPY . .
WORKDIR "/src/Services/Product/CompanyCase.Services.Product.API"
RUN dotnet build "CompanyCase.Services.Product.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyCase.Services.Product.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyCase.Services.Product.API.dll"]