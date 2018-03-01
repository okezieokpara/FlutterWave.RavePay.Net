using System;
using System.Collections.Generic;
using System.Text;
using  Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public abstract class PayResponseData
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public  string Message { get; set; }
    }
}
