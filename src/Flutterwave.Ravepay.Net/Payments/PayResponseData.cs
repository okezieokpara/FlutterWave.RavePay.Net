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

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("AccountId")]
        public  long AccountId { get; set; }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }

        [JsonProperty("chargeResponseCode")]
        public string ChargeResponseCode { get; set; }

        [JsonProperty("chargeResponseMessage")]
        public string ChargeResponseMessage { get; set; }

        [JsonProperty("flwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("customerId")]
        public long CustomerId { get; set; }


        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set;  }

        [JsonProperty("authurl")]
        public string Authurl { get; set; }

    }
}
