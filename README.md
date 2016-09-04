# Vasttrafik.NET

[![Build status](https://ci.appveyor.com/api/projects/status/k10x9ttx3dof7aqu?svg=true)](https://ci.appveyor.com/project/stranne/vasttrafik-net) [![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/stranne/Vasttrafik.NET/master/LICENSE)

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

Built with [.NET Standard Libraries 1.1](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) and support the following frameworks:

* .NET Core 1.0
* .NET Framework 4.5+
* Mono/Xamarin Platforms
* Universal Windows Platform 10.0
* Windows 8.0, 8.1
* Windows Phone 8.1

## Usage

In order to [get started](https://developer.vasttrafik.se/portal/#/guides/get-started) you first need to acquire a key and secret from Västtrafik in order to use there services.

DeviceId needs to be unique for each device. Only one token per DeviceId is allowed which can cause problems if used on multiple devices, like for example mobile devices or multiple servers. Using multiple unique DeviceId on same device can cause multiple and uneccessary authentications request to Västtrafik's servers. You decide the value yourself. By default a new guid will be used if nothing or null are specified.

### ASP.NET Core with Dependency Injection

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

    services.AddScoped<IJourneyPlannerService>(serviceProvider => new JourneyPlannerService(VtKey, VtSecret, VtDeviceId));
    services.AddScoped<ICommuterParkingService>(serviceProvider => new CommuterParkingService(VtKey, VtSecret, VtDeviceId));
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

### Using-statement

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

### ASP.NET Core: List departures on page

This example list departures in a table for a stop on a webpage. Consists of default MVC template project with the three files below, configuration for ``IJourneyPlannerService`` in ``Startup.cs`` and nuget dependency ìn ``project.json``.

Controllers/HomeController.cs

```cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET;
using Stranne.VasttrafikNET.Models;
using System.Linq;
using DepartureBoardExample.Models;

namespace DepartureBoardExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;

        public HomeController(IJourneyPlannerService journeyPlannerService)
        {
            _journeyPlannerService = journeyPlannerService;
        }

        public async Task<IActionResult> Index()
        {
            var departures = await _journeyPlannerService.GetDepartureBoardAsync(new BoardOptions
            {
                Id = "9021014001950000",
                TimeSpan = new TimeSpan(1, 0, 0),
                MaxDeparturesPerLine = 2
            });

            var departureEntries = departures
                .GroupBy(
                    departure =>
                        new
                        {
                            departure.ShortName,
                            departure.Direction,
                            Track = departure.RealtimeTrack ?? departure.Track
                        })
                .Select(departureGroup =>
                {
                    var departureList = departureGroup
                        .OrderBy(dg => dg.RealtimeDateTime ?? dg.DateTime)
                        .Take(2)
                        .ToArray();

                    var nextDeparture = departureList[0].Minutes;
                    var secondDeparture = departureList.Length >= 2
                        ? departureList[1].Minutes
                        : null as int?;

                    return new DepartureEntry
                    {
                        ShortName = departureGroup.Key.ShortName,
                        Direction = departureGroup.Key.Direction,
                        Track = departureGroup.Key.Track,
                        NextDeparture = nextDeparture,
                        SecondDeparture = secondDeparture
                    };
                })
                .ToList();

            var maxShortNameLength = departureEntries.Max(departureEntry => departureEntry.ShortName.Length);
            departureEntries = departureEntries
                .OrderBy(departureEntry => departureEntry.ShortName.PadLeft(maxShortNameLength, '0'))
                .ThenBy(departureEntry => departureEntry.Direction)
                .ThenBy(departureEntry => departureEntry.Track)
                .ToList();

            return View(departureEntries);
        }
    }
}
```

Models/DepartureEntry.cs

```cs
namespace DepartureBoardExample.Models
{
    public class DepartureEntry
    {
        public string ShortName { get; set; }
        public string Direction { get; set; }
        public string Track { get; set; }
        public int NextDeparture { get; set; }
        public int? SecondDeparture { get; set; }
    }
}
```

Views/Home/Home.cshtml

```cshtml
@using DepartureBoardExample.Models;

@model IEnumerable<DepartureEntry>

@{
    ViewData["Title"] = "Departures";
}

<table class="table table-striped">
    <thead>
        <tr>
            <th>Linje</th>
            <th>Destination</th>
            <th>Läge</th>
            <th>Avgår om</th>
            <th>Därefter om</th>
        </tr>
    </thead>
    <tbody>
    @foreach (var departureEntry in Model)
    {
        <tr>
            <td>@departureEntry.ShortName</td>
            <td>@departureEntry.Direction</td>
            <td>@departureEntry.Track</td>
            <td>@departureEntry.NextDeparture</td>
            <td>@departureEntry.SecondDeparture</td>
        </tr>
    }
    </tbody>
</table>
```

### Console program: Download Parking Image

This example download the latest camera image for a specified parking area into a specified path. Consists of a console project with the two files below.

To run you can for example use id 6090 and cameraId 1.

Program.cs

```cs
using System;
using System.IO;
using Stranne.VasttrafikNET;

namespace DownloadParkingCameraImage
{
    public class Program
    {
        private const string vtKey = "...";
        private const string vtSecret = "...";
        private const string vtDeviceId = "...";
        private const string imageFolder = "...";

        public static void Main(string[] args)
        {
            var id = int.Parse(args[0]);
            var cameraId = int.Parse(args[1]);

            var imagePath = $@"{imageFolder}Västtrafik_{DateTime.Now:yyyy-MM-dd_hh-mm}.gif";
            Console.WriteLine($"ImagePath: {imagePath}");

            using (var commuterParkingService = new CommuterParkingService(vtKey, vtSecret, vtDeviceId))
            {
                var stream = commuterParkingService.GetParkingImage(id, cameraId);
                using (var fileStream = File.Create(imagePath))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Done");
        }
    }
}
```

project.json

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "emitEntryPoint": true
  },

  "dependencies": {
    "Microsoft.NETCore.App": {
      "type": "platform",
      "version": "1.0.0"
    },
    "Stranne.VasttrafikNET": "1.0.0"
  },

  "frameworks": {
    "netcoreapp1.0": {
      "imports": "dnxcore50"
    }
  }
}
```

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