using System;
using System.Text;
using Flutterwave.Ravepay.Net.Currencies;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    /// <summary>
    /// The parameters needed to call the get fees endpoint
    /// </summary>
    public class GetFeesParams
    {
        public GetFeesParams(string pbfPubKey, decimal amount, CurrencyType currency)
        {
            PbfPubKey = pbfPubKey;
            Amount = amount;
            Currency = CurrencyUtil.GetCurrencyString(currency);
        }
        /// <summary>
        /// This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix ‘FLWPUBK’ and ends with suffix ‘X’
        /// </summary>
        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }

        /// <summary>
        /// This is the amount of the product or service to charged from the customer
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// This is the specified currency to charge the card in.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// This is an optional parameter to be used when the payment type is account payment. A value of 2 is to be passed to the endpoint.
        /// </summary>
        [JsonProperty("ptype")]
        public string Ptype { get; set; }

        /// <summary>
        /// This can be used only when the user has entered first 6digits of their card number, it also helps determine international fees on the transaction if the card being used is an international card
        /// </summary>
        [JsonProperty("card6")]
        public string Card6 { get; set; }
    }
}
