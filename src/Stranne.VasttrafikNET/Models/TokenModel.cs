using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Models
{
    internal class Token
    {
        private DateTimeOffset _createDate = DateTimeOffset.Now;

        [JsonProperty("Expires_In")]
        public int ExpiresIn { get; set; }

        [JsonProperty("Access_Token")]
        public string AccessToken { get; set; }
        
        public bool IsValid() => _createDate.AddSeconds(ExpiresIn) < DateTimeOffset.Now;
    }
}
