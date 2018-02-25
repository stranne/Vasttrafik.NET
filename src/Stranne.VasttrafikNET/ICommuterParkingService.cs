using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik commuter parking API
    /// </summary>
    public interface ICommuterParkingService
    {
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        Task<IEnumerable<ParkingArea>> GetParkingsAsync(ParkingOptions options);
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkings"]'/>
        IEnumerable<ParkingArea> GetParkings(ParkingOptions options);
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParking"]'/>
        Task<ParkingArea> GetParkingsAsync(int id);
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParking"]'/>
        ParkingArea GetParkings(int id);
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetHistoricalAvailability"]'/>
        Task<IEnumerable<HistoricalAvailability>> GetHistoricalAvailabilityAsync(int id, DateTimeOffset from, DateTimeOffset to);
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetHistoricalAvailability"]'/>
        IEnumerable<HistoricalAvailability> GetHistoricalAvailability(int id, DateTimeOffset from, DateTimeOffset to);
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetAvailableCapacity"]'/>
        Task<int?> GetAvailableCapacityAsync(int id);
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetAvailableCapacity"]'/>
        int? GetAvailableCapacity(int id);
        
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkingImage"]'/>
        Task<Stream> GetParkingImageAsync(int id, int cameraId);
        /// <include file='CommuterParkingDocs.xml' path='/Docs/Member[@name="GetParkingImage"]'/>
        Stream GetParkingImage(int id, int cameraId);
    }
}
