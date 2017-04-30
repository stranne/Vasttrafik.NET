# ASP.NET Core RESTful API

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/stranne/Vasttrafik.NET/master/LICENSE)


This is an example project based on VasttrafikNET showing how to create a REST-ful API that wrapps Västtrafik's API.

## Usage

### Configure

You will need a key and secret from Västtrafik in order to be able to use the API. They can be acquired [here](https://developer.vasttrafik.se/portal/#/guides/get-started).

Add them to ``appsettings.json`` file or as environment variables in the system with the name ``VtKey`` and ``VtSecret``.


### Build

To build the console application [dotnet sdk](https://www.microsoft.com/net/download/core#/sdk) needs to be installed on the device.

Navigate to the folder of the project is, i.e. ends with ...\Vasttrafik.NET\src\Examples\Stranne.VasttrafikNET.Examples.DownloadParkingImage and run the following commands in a terminal, or build it with Visual Studio.

```cmd
dotnet restore
dotnet build
```

### Run

Open a terminal at the root of the project folder and run the following command. A swagger ui is accessible at the path ``swagger``, i.e. ``http://localhost:5000/swagger``.


```cmd
dotnet run
```