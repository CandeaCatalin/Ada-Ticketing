#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BegaAir.TicketsManagementMicroservice.REST/BegaAir.TicketsManagementMicroservice.REST.csproj", "BegaAir.TicketsManagementMicroservice.REST/"]
COPY ["BegaAir.TicketsManagementMicroservice.DI/BegaAir.TicketsManagementMicroservice.DI.csproj", "BegaAir.TicketsManagementMicroservice.DI/"]
COPY ["BegaAir.TicketsManagementMicroservice.BussinessLogic/BegaAir.TicketsManagementMicroservice.BussinessLogic.csproj", "BegaAir.TicketsManagementMicroservice.BussinessLogic/"]
COPY ["BegaAir.TicketsManagementMicroservice.Repository/BegaAir.TicketsManagementMicroservice.Repository.csproj", "BegaAir.TicketsManagementMicroservice.Repository/"]
COPY ["BegaAir.TicketsManagementMicroservice.Services/BegaAir.TicketsManagementMicroservice.Services.csproj", "BegaAir.TicketsManagementMicroservice.Services/"]
COPY ["BegaAir.TicketsManagementMicroservice.DataAccess/BegaAir.TicketsManagementMicroservice.DataAccess.csproj", "BegaAir.TicketsManagementMicroservice.DataAccess/"]
RUN dotnet restore "BegaAir.TicketsManagementMicroservice.REST/BegaAir.TicketsManagementMicroservice.REST.csproj"
COPY . .
WORKDIR "/src/BegaAir.TicketsManagementMicroservice.REST"
RUN dotnet build "BegaAir.TicketsManagementMicroservice.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BegaAir.TicketsManagementMicroservice.REST.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BegaAir.TicketsManagementMicroservice.REST.dll"]