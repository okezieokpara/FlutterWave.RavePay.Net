
using Newtonsoft.Json;
namespace Flutterwave.Ravepay.Net.Payments
{
  public  class AccountValidateChargeParams: ValidateChargeParamsBase
    {
        public AccountValidateChargeParams(string pbfPubKey, string transactionReference, string otp) : base(pbfPubKey)
        {
            TransactionReference = transactionReference;
            Otp = otp;
        }
        [JsonProperty("transactionreference")]
        public string TransactionReference { get; set; }
        [JsonProperty("otp")]
        public  string Otp { get; set; }

       
    }
}
