using System.Collections.Generic;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik traffic situations.
    /// </summary>
    public interface ITrafficSituationsService
    {
        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStationNumber"]'/>
        Task<TrafficSituationApiModel> ForStationNumberAsync(string stationNumber);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStationNumber"]'/>
        TrafficSituationApiModel ForStationNumber(string stationNumber);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStopPoint"]'/>
        Task<IEnumerable<TrafficSituationApiModel>> ForStopPointAsync(string stopPointGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStopPoint"]'/>
        IEnumerable<TrafficSituationApiModel> ForStopPoint(string stopPointGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="All"]'/>
        Task<IEnumerable<TrafficSituationApiModel>> AllAsync();

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="All"]'/>
        IEnumerable<TrafficSituationApiModel> All();

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForLine"]'/>
        Task<IEnumerable<TrafficSituationApiModel>> ForLineAsync(string lineGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForLine"]'/>
        IEnumerable<TrafficSituationApiModel> ForLine(string lineGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForJourney"]'/>
        Task<IEnumerable<TrafficSituationApiModel>> ForJourneyAsync(string journeyGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForJourney"]'/>
        IEnumerable<TrafficSituationApiModel> ForJourney(string journeyGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStopArea"]'/>
        Task<IEnumerable<TrafficSituationApiModel>> ForStopAreaAsync(string stopPointGid);

        /// <include file='TrafficSituationsDocs.xml' path='/Docs/Member[@name="ForStopArea"]'/>
        IEnumerable<TrafficSituationApiModel> ForStopArea(string stopPointGid);
    }
}
