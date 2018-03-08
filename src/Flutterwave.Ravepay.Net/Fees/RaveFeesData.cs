using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Flutterwave.Ravepay.Net
{
    public class RaveFeesData : PayResponseData
    {
        /// <summary>
        /// This the total amount to be charged, total amount = amount + fee
        /// </summary>
        [JsonProperty("charge_amount")]
        public decimal ChargeAmount { get; set; }

        /// <summary>
        /// This is a cumulative of the merchantfee (if applicable) + ravefee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// This is the merchant fee on the transaction, it is applicable when using a subdomain. Subdomains allow you white-label rave, and offer it as a customised service to your merchant, we allow you set a markup fee on it and earn transaction fees. In this scenario the merchant-fee would be the subdomain markup fee if applicable.
        /// </summary>
        [JsonProperty("merchantfee")]
        public decimal MerchantFee { get; set; }
        /// <summary>
        /// This is the fee charged per transaction by rave.
        /// </summary>
        [JsonProperty("ravefee")]
        public decimal RaveFee { get; set; }
    }
}
