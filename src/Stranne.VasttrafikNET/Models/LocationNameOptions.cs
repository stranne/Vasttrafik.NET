using Stranne.VasttrafikNET.Attributes;

namespace Stranne.VasttrafikNET.Models
{
    internal class LocationNameOptions
    {
        [Parameter(required: true)]
        public string Input { get; set; }
    }
}
