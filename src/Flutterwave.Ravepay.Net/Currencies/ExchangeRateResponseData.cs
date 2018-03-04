using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Currencies
{
    public class ExchangeRateResponseData: PayResponseData
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty ("origincurrency")]
        public string OriginCurrency { get; set; }

        [JsonProperty("destinationcurrency")]
        public  string Destinationcurrency { get; set; }

        [JsonProperty("lastupdated")]
        public DateTime Lastupdated { get; set; }

        [JsonProperty("converted_amount")]
        public decimal ConvertedAmount { get; set; }

        [JsonProperty("original_amount")]
        public decimal OriginalAmount { get; set; }
    }
}
