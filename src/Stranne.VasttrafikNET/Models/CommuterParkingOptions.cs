using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Attributes;
using Stranne.VasttrafikNET.Converters;

namespace Stranne.VasttrafikNET.Models
{
    internal class CommuterParkingOptions
    {
        [Parameter(queryString: false)]
        public int Id { get; set; }

        [Parameter(queryString: false, order: 2)]
        public int? CameraId { get; set; }

        [JsonConverter(typeof(VtDateTimeLongJsonConverter))]
        [Parameter(queryString: false, order: 2)]
        public DateTimeOffset? From { get; set; }

        [JsonConverter(typeof(VtDateTimeLongJsonConverter))]
        [Parameter(queryString: false, order: 3)]
        public DateTimeOffset? To { get; set; }
    }
}
