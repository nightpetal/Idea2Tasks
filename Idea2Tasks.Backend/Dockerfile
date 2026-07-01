FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Idea2Tasks.Backend/Idea2Tasks.Backend.csproj", "Idea2Tasks.Backend/"]
RUN dotnet restore "Idea2Tasks.Backend/Idea2Tasks.Backend.csproj"
COPY . .
WORKDIR "/src/Idea2Tasks.Backend"
RUN dotnet build "Idea2Tasks.Backend.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Idea2Tasks.Backend.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Idea2Tasks.Backend.dll"]
