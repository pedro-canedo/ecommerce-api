# Usar o SDK do .NET Core para o estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY webservice-ecommerce-maxima-tech.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "webservice-ecommerce-maxima-tech.dll"]
