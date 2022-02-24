#Dokcer is like a virtual OS and like our CI/CD build agent, we have to specify what it needs to be able to run our application
#From docker instructions grabs images from image registry and use it as our environment for this virtual OS
from mcr.microsoft.com/dotnet/sdk:latest as build

#workdir docker instructions sets our working directory for this virtual OS
workdir /app

#Copy docker instructions lets us copy files from our computer and paste it on the virtual OS
copy *.sln ./
copy StoreApi/*.csproj StoreApi/
copy StoreAppBL/*.csproj StoreAppBL/
copy StoreAppDL/*.csproj StoreAppDL/
copy StoreAppModel/*.csproj StoreAppModel/
copy StoreUnitTest/*.csproj StoreUnitTest/

#Copy the rest our source code from our projects
copy . ./

#Creating our publish folder by running CLI command
run dotnet publish -c Release -o publish

#After building and publishing our application we need to set our environment to runtime 
from mcr.microsoft.com/dotnet/aspnet:latest as runtime

workdir /app
copy --from=build app/publish ./

#CMD to set that pokeapi.dll assembly will be our entrypoint
cmd ["dotnet", "StoreApi.dll"]

#Expose to port 80
expose 80