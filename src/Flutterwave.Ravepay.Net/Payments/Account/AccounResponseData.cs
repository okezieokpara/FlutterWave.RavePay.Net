using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class AccounResponseData: PayResponseData
    {
        [JsonProperty("flwRef")]
        public string FlwRef { get; set; }
    }
}
