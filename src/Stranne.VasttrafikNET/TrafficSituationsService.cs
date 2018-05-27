using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.Service;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik traffic situations.
    /// </summary>
    public class TrafficSituationsService : ITrafficSituationsService, IDisposable
    {
        internal TrafficSituationsHandlingService TrafficSituationsHandlingService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficSituationsService"/>.
        /// </summary>
        /// <param name="key">Key to Västtrafik API</param>
        /// <param name="secret">Secret to Västtrafik API</param>
        /// <param name="deviceId">Device id, unique id/name per device</param>
        public TrafficSituationsService(string key, string secret, string deviceId = null)
        {
            TrafficSituationsHandlingService = new TrafficSituationsHandlingService(key, secret, deviceId);
        }

        /// <inheritdoc />
        public Task<TrafficSituationApiModel> ForStationNumberAsync(string stationNumber)
        {
            return TrafficSituationsHandlingService.GetAsync<TrafficSituationApiModel>($"/{stationNumber}");
        }

        /// <inheritdoc />
        public TrafficSituationApiModel ForStationNumber(string stationNumber)
        {
            return ForStationNumberAsync(stationNumber).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrafficSituationApiModel>> ForStopPointAsync(string stopPointGid)
        {
            return TrafficSituationsHandlingService.GetAsync<IEnumerable<TrafficSituationApiModel>>($"/stoppoint/{stopPointGid}");
        }

        /// <inheritdoc />
        public IEnumerable<TrafficSituationApiModel> ForStopPoint(string stopPointGid)
        {
            return ForStopPointAsync(stopPointGid).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrafficSituationApiModel>> AllAsync()
        {
            return TrafficSituationsHandlingService.GetAsync<IEnumerable<TrafficSituationApiModel>>("");
        }

        /// <inheritdoc />
        public IEnumerable<TrafficSituationApiModel> All()
        {
            return AllAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrafficSituationApiModel>> ForLineAsync(string lineGid)
        {
            return TrafficSituationsHandlingService.GetAsync<IEnumerable<TrafficSituationApiModel>>($"/line/{lineGid}");
        }

        /// <inheritdoc />
        public IEnumerable<TrafficSituationApiModel> ForLine(string lineGid)
        {
            return ForLineAsync(lineGid).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrafficSituationApiModel>> ForJourneyAsync(string journeyGid)
        {
            return TrafficSituationsHandlingService.GetAsync<IEnumerable<TrafficSituationApiModel>>($"/journey/{journeyGid}");
        }

        /// <inheritdoc />
        public IEnumerable<TrafficSituationApiModel> ForJourney(string journeyGid)
        {
            return ForJourneyAsync(journeyGid).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrafficSituationApiModel>> ForStopAreaAsync(string stopAreaGid)
        {
            return TrafficSituationsHandlingService.GetAsync<IEnumerable<TrafficSituationApiModel>>($"/stoparea/{stopAreaGid}");
        }

        /// <inheritdoc />
        public IEnumerable<TrafficSituationApiModel> ForStopArea(string stopAreaGid)
        {
            return ForStopAreaAsync(stopAreaGid).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            TrafficSituationsHandlingService.Dispose();
        }
    }
}
