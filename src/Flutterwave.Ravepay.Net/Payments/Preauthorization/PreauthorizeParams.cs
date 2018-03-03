using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class PreauthorizeParams: ChargeParamsBase
    {
        public PreauthorizeParams(string pbfPubKey, string firstName, string lastName, string email, decimal amount) : base(pbfPubKey, firstName, lastName, email)
        {
            Amount = amount;
        }

        public PreauthorizeParams(string pbfPubKey, string firstName, string lastName, string email, decimal amount, Card card): base(pbfPubKey, firstName, lastName, email)
        {
            ChargeType = "preauth";
            CardNo = card.CardNo;
            Cvv = card.Cvv;
            ExpiryMonth = card.Expirymonth;
            Expiryyear = card.Expiryyear;
            Amount = amount;
        }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("cardno")]
        public string CardNo { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("expirymonth")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("expiryyear")]
        public string Expiryyear { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
