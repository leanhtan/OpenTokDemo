using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTokService.Models
{
    public class SessionModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sessionId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string apiKey { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string token { get; set; }
    }
}