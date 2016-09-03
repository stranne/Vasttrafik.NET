using Stranne.VasttrafikNET.Models;
using Xunit.Abstractions;

namespace Stranne.VasttrafikNET.Tests
{
    public class CoordinateSerializeable : Coordinate, IXunitSerializable
    {
        public void Deserialize(IXunitSerializationInfo info)
        {
            Latitude = info.GetValue<double>("Latitude");
            Longitude = info.GetValue<double>("Longitude");
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("Latitude", Latitude);
            info.AddValue("Longitude", Longitude);
        }
    }
}
