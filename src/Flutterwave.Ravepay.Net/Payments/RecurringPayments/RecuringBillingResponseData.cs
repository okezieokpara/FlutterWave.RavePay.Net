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

        [JsonProperty("next_due", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime NextDue { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Start { get; set; }

        [JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Stop { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DeletedAt { get; set; }

        [JsonProperty("TransactionId")]
        public long TransactionId { get; set; }

        [JsonProperty("tx")]
        public RecurringTransactionData Tx { get; set; }
    }
}

