using Stranne.VasttrafikNET.Attributes;

namespace Stranne.VasttrafikNET.Models
{
    internal class LocationNearbyStopsOptions
    {
        [Parameter(required: true)]
        public Coordinate OriginCoordinate { get; set; }

        [Parameter]
        public int? MaxNo { get; set; } = null;

        [Parameter]
        public int? MaxDist { get; set; } = null;
    }
}
