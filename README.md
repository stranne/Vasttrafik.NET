# Vasttrafik.NET

[![Build status](https://ci.appveyor.com/api/projects/status/k10x9ttx3dof7aqu?svg=true)](https://ci.appveyor.com/project/stranne/vasttrafik-net)
[![NuGet](https://img.shields.io/nuget/v/Stranne.VasttrafikNET.svg?maxAge=2592000)](https://www.nuget.org/packages/Stranne.VasttrafikNET)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/stranne/Vasttrafik.NET/master/LICENSE)

Library to acquire real-time information from Västtrafik’s APIs built on .NET Core.

## Features

### [Journey Planner](https://developer.vasttrafik.se/portal/#/api/Reseplaneraren/v2/landerss)

* Arrival board
* Departure board
* Geometry
* Journey details
* Live map
* Locations
  * nearby address
  * nearby stops
  * get all stops
  * by name
* System information
* Trip

### [Commuter Parking](https://developer.vasttrafik.se/portal/#/api/SPP/v2/landerss)

* Search parking areas
* Get parking area
* Historical availability
* Current available capacity
* Parking image

## Supported frameworks

Built with [.NET Standard Libraries 1.3](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) and support the following frameworks:

* .NET Core 1.0
* .NET Framework 4.6+
* Mono/Xamarin Platforms
    * Currently a breaking issue with Android on Xamarin
* Universal Windows Platform 10.0

## Get started

### Install

Install library from [NuGet](https://www.nuget.org/packages/Stranne.VasttrafikNET/).

Package Manager Console command:

```cmd
Install-Package Stranne.VasttrafikNET
```

### Acquiring credentials

In order to [get started](https://developer.vasttrafik.se/portal/#/guides/get-started) you need to acquire a key and secret from Västtrafik in order to use their services.

### Usage

DeviceId needs to be unique for each device. Only one token per DeviceId is allowed which can cause problems if used on multiple devices, like for example mobile devices or multiple servers if the device id is the same. Using multiple unique DeviceId on same device can cause multiple and uneccessary authentications request to Västtrafik's servers. You decide the value yourself. By default a new guid will be used if nothing or null are specified. Default will create a new token each time the service is instantiated and can lead to extra token request if the service is always created for the request, for example if the service is configured as scope in a DI.

Use a using statement or a DI engine to make sure dispose is called. This will dispose the HttpClient inside the library.

#### ASP.NET Core with Dependency Injection

Register the service/services that are needed.

Startup.cs

```cs
using Stranne.VasttrafikNET;
...

private const string VtKey = "...";
private const string VtSecret = "...";
private const string VtDeviceId = "...";

...

// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddScoped<Foo>();
    ...

    services.AddSingleton<IJourneyPlannerService>(serviceProvider => new JourneyPlannerService(VtKey, VtSecret, VtDeviceId));
    services.AddSingleton<ICommuterParkingService>(serviceProvider => new CommuterParkingService(VtKey, VtSecret, VtDeviceId));
}

...
```

Inject the requested service and use.

Foo.cs

```cs
using Stranne.VasttrafikNET;
using Stranne.VasttrafikNET.Models;

public class Foo {
    private readonly IJourneyPlannerService _journeyPlannerService;

    public Foo(IJourneyPlannerService journeyPlannerService) {
        _journeyPlannerService = journeyPlannerService;
    }

    public async Task Bar() {
        var departures = await _journeyPlannerService.GetDepartureBoardAsync(new BoardOptions
        {
            Id = "0000000800000022"
        });

        ...
    }
}
```

#### Using-statement

```cs
using Stranne.VasttrafikNET;
using Stranne.VasttrafikNET.Models;

private const string VtKey = "...";
private const string VtSecret = "...";
private const string VtDeviceId = "...";

...

public async Task Bar() {
    using(var journeyPlannerService = new JourneyPlannerService(VtKey, VtSecret, VtDeviceId)) {
        var departures = await journeyPlannerService.GetDepartureBoardAsync(new BoardOptions
        {
            Id = "0000000800000022"
        }));

        ...
    }
}

...
```

## Examples

Check out one of the following examples on how this library can be implemented and what it can do.

* [ASP.NET Core RESTful API](src/Examples/Stranne.VasttrafikNET.Examples.Api/README.md)
* [.NET Console Download Parking Image](src/Examples/Stranne.VasttrafikNET.Examples.DownloadParkingImage/README.md)

## Exceptions

The following exceptions are located under the namespace ``Stranne.VasttrafikNET.Exceptions``.

### AuthenticationException
Represents errors that occur on failed authentication with Västtrafik's servers. Verify key and secret are correct and that they have access to the API in question.
### MissingRequiredParameterException
Represents errors that occur when preparing message for Västtrafik's servers with a request that missing required parameters
### NetworkException
Represents errors that occur during communicating with Västtrafik's servers
### ServerException
Represents errors that occur on Västtrafik's servers