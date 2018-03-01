using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class CardValidateChargeParams : ValidateChargeParamsBase
    {
        public CardValidateChargeParams(string pbfPubKey, string transactionReference, string otp) : base(pbfPubKey)
        {
            TransactionReference = transactionReference;
            Otp = otp;
        }
        [JsonProperty("transaction_reference")]
        public string TransactionReference { get; set; }
        [JsonProperty("otp")]
        public string Otp { get; set; }

      
    }
}
