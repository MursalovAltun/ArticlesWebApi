# Articles WEB API using .NET Core 3.1

**Articles WEB API** is the server side application for Articles project.
Created for manage Categories and Articles.

## 🔨 Getting started
Project targets **.NET Standard 2.0** and **.NET Core 3.1** at minimum.

## How to run locally?
### Requirements:
- [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [PostgreSQL](https://www.postgresql.org/download/)

Open the <PathToProjectRoot>/Common/Common.WebApiCore/appsettings.Development.json file, and change Default value of the ConnectionStrings section, to your connection to PostgreSQL.

Download as zip or clone this repository using git clone https://github.com/MursalovAltun/ArticlesWebApi.git
```shell
$ dotnet restore
$ dotnet build
$ dotnet run --project Common/Common.WebApiCore
```
Open https://localhost:5001/swagger/ in your browser and you will see the Swagger UI to use API.

# Thanks for reading ❤️
