FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cadastro.Parceiros.API/Cadastro.Parceiros.API.csproj", "Cadastro.Parceiros.API/"]
RUN dotnet restore "Cadastro.Parceiros.API\Cadastro.Parceiros.API.csproj"
COPY . .
WORKDIR "/src/Cadastro.Parceiros.API"
RUN dotnet build "Cadastro.Parceiros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cadastro.Parceiros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cadastro.Parceiros.API.dll"]
