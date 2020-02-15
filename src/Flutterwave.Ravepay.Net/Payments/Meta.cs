using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Provides a meta description for  a payment
    /// </summary>
    public class PaymentMetaData
    {
        public PaymentMetaData(string metaName, string metaValue)
        {
            MetaName = metaName;
            MetaValue = MetaValue;
        }

        [JsonProperty("metaname")]
        public string MetaName { get; set; }
        [JsonProperty("metavalue")]
        public string MetaValue { get; set; }
    }
}
