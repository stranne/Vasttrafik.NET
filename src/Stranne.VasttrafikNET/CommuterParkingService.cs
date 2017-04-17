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
        /// <param name="vtKey">Key to Västtrafik API</param>
        /// <param name="vtSecret">Secret to Västtrafik API</param>
        /// <param name="vtDeviceId">Device id, unique id/name per device</param>
        public CommuterParkingService(string vtKey, string vtSecret, string vtDeviceId = null)
        {
            CommuterParkingHandlingService = new CommuterParkingHandlingService(vtKey, vtSecret, vtDeviceId);

        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        public async Task<IEnumerable<ParkingArea>> GetParkingsAsync(ParkingOptions parkingOptions)
        {
            return await CommuterParkingHandlingService.GetAsync<IEnumerable<ParkingArea>>("/parkings", parkingOptions);
        }

        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        public IEnumerable<ParkingArea> GetParkings(ParkingOptions parkingOptions)
        {
            return GetParkingsAsync(parkingOptions).Result;
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
            return GetParkingsAsync(id).Result;
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
            return GetHistoricalAvailabilityAsync(id, from, to).Result;
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
            return GetAvailableCapacityAsync(id).Result;
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
            return GetParkingImageAsync(id, cameraId).Result;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            CommuterParkingHandlingService.Dispose();
        }
    }
}
