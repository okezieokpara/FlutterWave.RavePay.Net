using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RefundsResponseData : PayResponseData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("AmountRefunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("walletId")]
        public long WalletId { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("FlwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("TransactionId")]
        public long TransactionId { get; set; }


        [JsonProperty("status")]
        public  string Status { get; set; }

        [JsonProperty("updatedAt")]
        public  DateTime UpdatedAt { get; set; }

    }
}
