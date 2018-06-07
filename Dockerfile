FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /sln
COPY name-sorter.sln .
COPY src /sln/src
COPY test /sln/test
RUN dotnet restore
RUN dotnet build -c Release --no-restore

FROM build AS test
WORKDIR /sln/test
RUN dotnet test NameSorter.Tests/NameSorter.Tests.csproj -c Release --no-build --no-restore

FROM build AS publish
WORKDIR /sln/src
RUN dotnet publish NameSorter/NameSorter.csproj -c Release -o /app

FROM base AS final
VOLUME /output
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NameSorter.dll", "/output/unsorted-names-list.txt"]

