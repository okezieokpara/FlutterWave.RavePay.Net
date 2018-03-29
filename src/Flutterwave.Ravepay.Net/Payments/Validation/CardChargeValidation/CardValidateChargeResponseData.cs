using System;
using Newtonsoft.Json;


namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Represents the response data returned for each card charge validation request
    /// </summary>
    public class CardValidateChargeResponseData : ValidateChargeResponseDataBase
    {
        /// <summary>
        /// Represents the token return for a succussful card charge.
        /// This is important as it is used to make future tokenized payment requests
        /// </summary>
        [JsonProperty("chargeToken")]
        public RaveChargeToken CardChargeToken { get; set; }

        [JsonProperty("tx")]
        public PayResponseData TX { get; set; }
        [JsonProperty("CardValidationData")]
        public CardValidationData Data { get; set; }

        public class CardValidationData
        {
            [JsonProperty("responsecode")]
            public string Responsecode { get; set; }

            [JsonProperty("responsemessage")]
            public string Responsemessage { get; set; }
        }
    }
}
