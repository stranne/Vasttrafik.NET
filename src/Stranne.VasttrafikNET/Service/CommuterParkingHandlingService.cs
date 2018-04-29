namespace Stranne.VasttrafikNET.Service
{
    internal class CommuterParkingHandlingService : BaseHandlingService
    {
        protected override string ApiPathUrl => "spp/v3";

        public CommuterParkingHandlingService(string key, string secret, string deviceId) :
            base(key, secret, deviceId)
        {
        }
    }
}
