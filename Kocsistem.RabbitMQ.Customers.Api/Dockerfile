#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kocsistem.RabbitMQ.Customers.Api/Kocsistem.RabbitMQ.Customers.Api.csproj", "Kocsistem.RabbitMQ.Customers.Api/"]
RUN dotnet restore "Kocsistem.RabbitMQ.Customers.Api/Kocsistem.RabbitMQ.Customers.Api.csproj"
COPY . .
WORKDIR "/src/Kocsistem.RabbitMQ.Customers.Api"
RUN dotnet build "Kocsistem.RabbitMQ.Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kocsistem.RabbitMQ.Customers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kocsistem.RabbitMQ.Customers.Api.dll"]