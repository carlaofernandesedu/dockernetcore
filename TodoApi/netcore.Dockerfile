FROM microsoft/dotnet:sdk AS build-env
WORKDIR /var/app
COPY . ./
ENTRYPOINT dotnet run --server.urls="http://*:5000"
