using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    public class TransactionResponseData: PayResponseData
    {


        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("flwMeta")]
        public FlwMeta FlwMeta { get; set; }
    }
}
