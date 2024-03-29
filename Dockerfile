FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/BlazorGameTemplate.Server.csproj", "Server/"]
COPY ["Client/BlazorGameTemplate.Client.csproj", "Client/"]
COPY ["Shared/BlazorGameTemplate.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/BlazorGameTemplate.Server.csproj" --locked-mode
COPY . .

WORKDIR "/src/Client"
RUN dotnet tool install -g Microsoft.Web.LibraryManager.CLI
ENV PATH="$PATH:/root/.dotnet/tools"
RUN libman restore

WORKDIR "/src/Server"
RUN dotnet build "BlazorGameTemplate.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorGameTemplate.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorGameTemplate.Server.dll"]