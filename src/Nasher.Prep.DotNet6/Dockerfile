FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nasher.Prep.DotNet6/Nasher.Prep.DotNet6.csproj", "Nasher.Prep.DotNet6/"]
RUN dotnet restore "Nasher.Prep.DotNet6/Nasher.Prep.DotNet6.csproj"
COPY . .
WORKDIR "/src/Nasher.Prep.DotNet6"
RUN dotnet build "Nasher.Prep.DotNet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nasher.Prep.DotNet6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nasher.Prep.DotNet6.dll"]
