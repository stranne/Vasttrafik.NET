namespace Stranne.VasttrafikNET.Service
{
    internal class CommuterParkingHandlingService : BaseHandlingService
    {
        protected override string ApiPathUrl => "spp/v2";

        public CommuterParkingHandlingService(string vtKey, string vtSecret, string vtDeviceId) :
            base(vtKey, vtSecret, vtDeviceId)
        { }
    }
}
