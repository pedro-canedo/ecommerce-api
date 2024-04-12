# Usar o SDK do .NET Core para o estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ["webservice-ecoomerce-maxima-tech.csproj", "./"]
RUN dotnet restore "webservice-ecoomerce-maxima-tech.csproj"

COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:80


ENTRYPOINT ["dotnet", "webservice-ecoomerce-maxima-tech.dll"]
