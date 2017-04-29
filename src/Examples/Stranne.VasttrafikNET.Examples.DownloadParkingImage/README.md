# Download image console example

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/stranne/Vasttrafik.NET/master/LICENSE)


This is an example project based on VasttrafikNET showing how to download the latest camera image for a specified parking area into a specified path with a console application.

## Usage

### Build

To build the console application [dotnet sdk](https://www.microsoft.com/net/download/core#/sdk) needs to be installed on the device.

Navigate to the folder of the project is, i.e. ends with ...\Vasttrafik.NET\src\Examples\Stranne.VasttrafikNET.Examples.DownloadParkingImage and run the following commands in a terminal, or build it with Visual Studio.

```cmd
dotnet restore
dotnet build
```

### Run

To run the console application [dotnet runtime](https://www.microsoft.com/net/download/core#/runtime) or sdk needs to be installed on the device.

Open a terminal where the ``Stranne.VasttrafikNET.Examples.DownloadParkingImage.dll`` file is located and run with the line below where brackets has been replaced with valid parameters.


```cmd
dotnet Stranne.VasttrafikNET.Examples.DownloadParkingImage.dll {Parking id, ex 6090} {Camera id, ex 1} {Västtrafik Key} {Västtrafik Secret} {Download directory, optional}
```

Get Västtrafik key and secret [here](https://developer.vasttrafik.se/portal/#/guides/get-started).