using System;
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


        /// <summary>
        /// This is the response code of the transaction, it typically tells you when a transaction is successful with a response code 00 or when the transaction requires validation 02
        /// </summary>
        /// <remarks>This applies to international mastercard using 3D Secure</remarks>

        [JsonProperty("chargeResponseCode")]
        public string ChargeResponseCode { get; set; }

        /// <summary>
        /// This is the response message and it can be shown to the customer to show what needs to be done next.
        /// </summary>
        /// <remarks>This applies to international mastercard using 3D Secure</remarks>
        [JsonProperty("chargeResponseMessage")]
        public string ChargeResponseMessage { get; set; }

        [JsonProperty("paymentType")]
        public  string PaymentType { get; set; }

        [JsonProperty("flwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("customerId")]
        public long CustomerId { get; set; }


        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set;  }

        [JsonProperty("authurl")]
        public string Authurl { get; set; }

        [JsonProperty("is_live")]
        public bool IsLive { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }


        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }


        [JsonProperty("deletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public  DateTime DeletedAt { get; set; }

    }
}
