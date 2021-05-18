#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kocsistem.RabbitMQ.Payment.Api/Kocsistem.RabbitMQ.Payment.Api.csproj", "Kocsistem.RabbitMQ.Payment.Api/"]
COPY ["Kocsistem.RabbitMQ.Payment.Application/Kocsistem.RabbitMQ.Payment.Application.csproj", "Kocsistem.RabbitMQ.Payment.Application/"]
COPY ["Kocsistem.RabbitMQ.Payment.Domain/Kocsistem.RabbitMQ.Payment.Domain.csproj", "Kocsistem.RabbitMQ.Payment.Domain/"]
COPY ["Kocsistem.RabbitMQ.Domain.Core/Kocsistem.RabbitMQ.Domain.Core.csproj", "Kocsistem.RabbitMQ.Domain.Core/"]
COPY ["Kocsistem.RabbitMQ.Infras.IOC/Kocsistem.RabbitMQ.Infras.IOC.csproj", "Kocsistem.RabbitMQ.Infras.IOC/"]
COPY ["Kocsistem.RabbitMQ.Infras.Bus/Kocsistem.RabbitMQ.Infras.Bus.csproj", "Kocsistem.RabbitMQ.Infras.Bus/"]
COPY ["Kocsistem.RabbitMQ.Stock.Application/Kocsistem.RabbitMQ.Stock.Application.csproj", "Kocsistem.RabbitMQ.Stock.Application/"]
COPY ["Kocsistem.RabbitMQ.Stock.Domain/Kocsistem.RabbitMQ.Stock.Domain.csproj", "Kocsistem.RabbitMQ.Stock.Domain/"]
COPY ["Kocsistem.RabbitMQ.Stock.Data/Kocsistem.RabbitMQ.Stock.Data.csproj", "Kocsistem.RabbitMQ.Stock.Data/"]
COPY ["Kocsistem.RabbitMQ.Payment.Data/Kocsistem.RabbitMQ.Payment.Data.csproj", "Kocsistem.RabbitMQ.Payment.Data/"]
RUN dotnet restore "Kocsistem.RabbitMQ.Payment.Api/Kocsistem.RabbitMQ.Payment.Api.csproj"
COPY . .
WORKDIR "/src/Kocsistem.RabbitMQ.Payment.Api"
RUN dotnet build "Kocsistem.RabbitMQ.Payment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kocsistem.RabbitMQ.Payment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kocsistem.RabbitMQ.Payment.Api.dll"]
