#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SKY.Application/SKY.Application.csproj", "SKY.Application/"]
COPY ["SKY.Infra.CrossCutting/SKY.Infra.CrossCutting.csproj", "SKY.Infra.CrossCutting/"]
COPY ["SKY.Service/SKY.Service.csproj", "SKY.Service/"]
COPY ["SKY.Domain/SKY.Domain.csproj", "SKY.Domain/"]
COPY ["SKY.Infra.Shared/SKY.Infra.Shared.csproj", "SKY.Infra.Shared/"]
COPY ["SKY.Infra.Data/SKY.Infra.Data.csproj", "SKY.Infra.Data/"]
RUN dotnet restore "SKY.Application/SKY.Application.csproj"
COPY . .
WORKDIR "/src/SKY.Application"
RUN dotnet build "SKY.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SKY.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SKY.Application.dll"]