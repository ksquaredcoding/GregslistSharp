FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GregslistSharp.csproj", "./"]
RUN dotnet restore "GregslistSharp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GregslistSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GregslistSharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GregslistSharp.dll"]
