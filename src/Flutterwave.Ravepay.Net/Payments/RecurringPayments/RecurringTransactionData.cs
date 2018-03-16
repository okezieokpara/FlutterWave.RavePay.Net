
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RecurringTransactionData
    {
        [JsonProperty("addon_id")]
        public long AddonId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }


        [JsonProperty("appfee")]
        public double AppFee { get; set; }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
