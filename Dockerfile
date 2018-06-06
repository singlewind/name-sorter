FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app
COPY sorted-names.txt .

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/ .
RUN dotnet restore name-sorter/name-sorter.csproj
WORKDIR /src/name-sorter
RUN dotnet build name-sorter.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish name-sorter.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "name-sorter.dll"]