FROM microsoft/dotnet:2.1-sdk AS build-base
WORKDIR /app

FROM build-base AS build-homes-england
WORKDIR /app/HomesEngland
COPY HomesEngland/*.csproj .
RUN dotnet restore
COPY HomesEngland/. .
RUN dotnet publish -c Release -o out

FROM build-homes-england as build-web-api
WORKDIR /app/WebApi
COPY WebApi/*.csproj .
RUN dotnet restore
COPY WebApi/. .
RUN dotnet publish -c Release -o out

FROM build-homes-england AS test-homes-england
WORKDIR /app/HomesEnglandTest
COPY HomesEnglandTest/. .
CMD ["dotnet", "test", "--logger:trx"]

FROM build-web-api as test-asset-register
WORKDIR /app/AcceptanceTest
COPY AcceptanceTest/. .
CMD ["dotnet", "test", "--logger:trx"]

FROM build-web-api as test-web-api
WORKDIR /app/WebApiTest
COPY WebApiTest/. .
CMD ["dotnet", "test", "--logger:trx"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build-web-api /app/WebApi/out ./
CMD ["dotnet", "web-api.dll"]
