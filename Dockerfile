FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app
COPY sorted-names.txt .

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /sln
COPY src /sln/src
WORKDIR /sln/src/NameSorter
RUN dotnet restore NameSorter.csproj
RUN dotnet build NameSorter.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NameSorter.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NameSorter.dll"]