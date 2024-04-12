FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ["api-ecommerce-maxima-tech.csproj", "./"]
RUN dotnet restore "api-ecommerce-maxima-tech.csproj"

COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "api-ecommerce-maxima-tech.dll"]
