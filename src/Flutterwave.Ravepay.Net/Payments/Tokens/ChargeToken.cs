using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class RaveChargeToken
    {
        [JsonProperty("embed_token")]
        public string EmbedToken { get; set; }
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
    }
}
