using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Service;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik commuter parking API
    /// </summary>
    public class CommuterParkingService : ICommuterParkingService, IDisposable
    {
        internal CommuterParkingHandlingService CommuterParkingHandlingService { get; }

        /// <summary>
        /// Initializes a new instance of the Commuter Parking Service
        /// </summary>
        /// <param name="key">Key to Västtrafik API</param>
        /// <param name="secret">Secret to Västtrafik API</param>
        /// <param name="deviceId">Device id, unique id/name per device</param>
        public CommuterParkingService(string key, string secret, string deviceId = null)
        {
            CommuterParkingHandlingService = new CommuterParkingHandlingService(key, secret, deviceId);
        }

        /// <inheritdoc />
        public async Task<DateTimeOffset?> GetForecastFullTimeAsync(int id, DateTimeOffset date)
        {
            var options = new CommuterParkingOptions
            {
                Id = id,
                Date = date
            };
            return await CommuterParkingHandlingService.GetAsync<DateTimeOffset?>("/forecastFullTime", options);
        }

        /// <inheritdoc />
        public DateTimeOffset? GetForecastFullTime(int id, DateTimeOffset date)
        {
            return GetForecastFullTimeAsync(id, date).GetAwaiter().GetResult();
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        public async Task<IEnumerable<ParkingArea>> GetParkingsAsync(ParkingOptions options)
        {
            return await CommuterParkingHandlingService.GetAsync<IEnumerable<ParkingArea>>("/parkings", options);
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        public IEnumerable<ParkingArea> GetParkings(ParkingOptions options)
        {
            return GetParkingsAsync(options).GetAwaiter().GetResult();
        }
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParking"]'/>
        public async Task<ParkingArea> GetParkingsAsync(int id)
        {
            var options = new CommuterParkingOptions
            {
                Id = id
            };
            return (await CommuterParkingHandlingService.GetAsync<IEnumerable<ParkingArea>>("/parkings", options)).Single();
        }
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParking"]'/>
        public ParkingArea GetParkings(int id)
        {
            return GetParkingsAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<int?> GetForecastAvailabilityAsync(int id, DateTimeOffset timestamp)
        {
            var options = new CommuterParkingOptions
            {
                Id = id,
                Timestamp = timestamp
            };
            return await CommuterParkingHandlingService.GetAsync<int>("/forecastAvailability", options);
        }
        
        /// <inheritdoc />
        public int? GetForecastAvailability(int id, DateTimeOffset timestamp)
        {
            return GetForecastAvailabilityAsync(id, timestamp).GetAwaiter().GetResult();
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetHistoricalAvailability"]'/>
        public async Task<IEnumerable<HistoricalAvailability>> GetHistoricalAvailabilityAsync(int id, DateTimeOffset from, DateTimeOffset to)
        {
            var options = new CommuterParkingOptions
            {
                Id = id,
                From = from,
                To = to
            };
            return await CommuterParkingHandlingService.GetAsync<IEnumerable<HistoricalAvailability>>("/historicalAvailability", options);
        }
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetHistoricalAvailability"]'/>
        public IEnumerable<HistoricalAvailability> GetHistoricalAvailability(int id, DateTimeOffset from, DateTimeOffset to)
        {
            return GetHistoricalAvailabilityAsync(id, from, to).GetAwaiter().GetResult();
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetAvailableCapacity"]'/>
        public async Task<int> GetAvailableCapacityAsync(int id)
        {
            var options = new CommuterParkingOptions
            {
                Id = id
            };
            return await CommuterParkingHandlingService.GetAsync<int>("/availableCapacity", options);
        }
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetAvailableCapacity"]'/>
        public int GetAvailableCapacity(int id)
        {
            return GetAvailableCapacityAsync(id).GetAwaiter().GetResult();
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkingImage"]'/>
        public async Task<Stream> GetParkingImageAsync(int id, int cameraId)
        {
            var options = new CommuterParkingOptions
            {
                Id = id,
                CameraId = cameraId
            };
            return await CommuterParkingHandlingService.GetAsync<Stream>("/parkingImages", options);
        }
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkingImage"]'/>
        public Stream GetParkingImage(int id, int cameraId)
        {
            return GetParkingImageAsync(id, cameraId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            CommuterParkingHandlingService.Dispose();
        }
    }
}
