using Newtonsoft.Json;
using Stranne.VasttrafikNET.Attributes;
using Stranne.VasttrafikNET.Converters;

namespace Stranne.VasttrafikNET.Models
{
    internal class LiveMapOptions
    {
        [Parameter(required: true)]
        public double? Minx { get; set; }

        [Parameter(required: true)]
        public double? Maxx { get; set; }

        [Parameter(required: true)]
        public double? Miny { get; set; }

        [Parameter(required: true)]
        public double? Maxy { get; set; }

        [JsonConverter(typeof(YesNoJsonConverter))]
        [Parameter(required: true)]
        public bool? OnlyRealtime { get; set; }
    }
}
