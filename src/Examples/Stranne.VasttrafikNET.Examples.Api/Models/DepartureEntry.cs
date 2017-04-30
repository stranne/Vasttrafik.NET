namespace Stranne.VasttrafikNET.Examples.Api.Models
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
