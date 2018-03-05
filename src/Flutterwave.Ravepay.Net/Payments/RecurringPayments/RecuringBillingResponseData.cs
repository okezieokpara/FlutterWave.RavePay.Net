using System;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RecuringBillingResponseData : PayResponseData
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("retryTxId")]
        public string RetryTxId { get; set; }

        [JsonProperty("retries")]
        public long Retries { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("next_due")]
        public DateTime NextDue { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("stop")]
        public DateTime Stop { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public DateTime DeletedAt { get; set; }

        [JsonProperty("TransactionId")]
        public long TransactionId { get; set; }
    }
}
