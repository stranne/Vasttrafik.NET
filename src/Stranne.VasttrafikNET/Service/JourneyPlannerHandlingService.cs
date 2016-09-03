namespace Stranne.VasttrafikNET.Service
{
    internal class JourneyPlannerHandlingService : BaseHandlingService
    {
        protected override string ApiPathUrl => "bin/rest.exe/v2";

        public JourneyPlannerHandlingService(string vtKey, string vtSecret, string vtDeviceId) :
            base(vtKey, vtSecret, vtDeviceId)
        { }
    }
}
