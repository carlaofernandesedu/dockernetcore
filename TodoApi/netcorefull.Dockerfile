FROM microsoft/dotnet:sdk AS build-env
WORKDIR /var/app

#Copy csproj and restores as distinct layers 
#COPY .csproj ./
COPY . ./
ENTRYPOINT dotnet run --server.urls="http://*:5000"
#RUN dotnet restore 

#Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out

#Build runtime image 
#FROM microsoft/dotnet:aspnetcore-runtime
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet","todoapi.dll"]
