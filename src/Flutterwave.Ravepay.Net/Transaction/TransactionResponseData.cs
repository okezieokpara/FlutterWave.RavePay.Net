using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    public class TransactionResponseData: PayResponseData
    {
        [JsonProperty("id")]
        public  long Id { get; set; }
        [JsonProperty("tx_ref")]
        public  string TxRef { get; set; }

        [JsonProperty("order_ref")]
        public string OrderRef { get; set; }

        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("flwMeta")]
        public FlwMeta FlwMeta { get; set; }
    }
}
