﻿namespace Stranne.VasttrafikNET.Service
{
    internal class JourneyPlannerHandlingService : BaseHandlingService
    {
        protected override string ApiPathUrl => "bin/rest.exe/v2";

        public JourneyPlannerHandlingService(string key, string secret, string deviceId) :
            base(key, secret, deviceId)
        {
        }
    }
}
