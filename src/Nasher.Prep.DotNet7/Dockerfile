FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Nasher.Prep/Nasher.Prep.DotNet7.csproj", "Nasher.Prep/"]
RUN dotnet restore "Nasher.Prep/Nasher.Prep.DotNet7.csproj"
COPY . .
WORKDIR "/src/Nasher.Prep"
RUN dotnet build "Nasher.Prep.DotNet7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nasher.Prep.DotNet7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nasher.Prep.DotNet7.dll"]
