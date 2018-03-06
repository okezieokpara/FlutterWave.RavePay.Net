using System;
using System.Collections.Generic;
using System.Text;
using  Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class CardResponseData: PayResponseData
    {
        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }
        [JsonProperty("authModelUsed")]
        public string AuthModelUsed { get; set; }

    }
}
