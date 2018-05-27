namespace Stranne.VasttrafikNET.Service
{
    internal class TrafficSituationsHandlingService : BaseHandlingService
    {
        protected override string ApiPathUrl => "ts/v1/traffic-situations";

        public TrafficSituationsHandlingService(string vtKey, string vtSecret, string vtDeviceId)
            : base(vtKey, vtSecret, vtDeviceId)
        {
        }
    }
}
