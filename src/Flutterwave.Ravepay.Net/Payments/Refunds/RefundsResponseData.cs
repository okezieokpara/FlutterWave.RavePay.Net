using System;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RefundsResponseData : PayResponseData
    {

        [JsonProperty("AmountRefunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("walletId")]
        public long WalletId { get; set; }

     
        [JsonProperty("TransactionId")]
        public long TransactionId { get; set; }


        [JsonProperty("status")]
        public string Status { get; set; }
   

    }
}
