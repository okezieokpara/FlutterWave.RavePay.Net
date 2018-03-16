
using Newtonsoft.Json;
namespace Flutterwave.Ravepay.Net.Payments
{
    public class AccountValidateChargeParams : ValidateChargeParamsBase
    {
        /// <summary>
        /// Creates an object of parameters for validating account payment
        /// </summary>
        /// <param name="pbfPubKey">This is a unique key generated for each button created on Rave’s dashboard.It starts with a prefix 'FLWPUBK' and ends with suffix ‘X’. </param>
        /// <param name="transactionReference">This is the unique reference/ flwRef, unique to the particular transaction being carried out. It is generated for every transaction. This can be retrieved from the account charge response</param>
        /// <param name="otp">this is the one time Pin sent to the customer’s phone and inputed by the customer for authentication. Test otp is 12345</param>
        public AccountValidateChargeParams(string pbfPubKey, string transactionReference, string otp) : base(pbfPubKey)
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
