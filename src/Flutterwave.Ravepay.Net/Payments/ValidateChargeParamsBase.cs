using System;
using System.Collections.Generic;
using System.Text;
using  Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public abstract class ValidateChargeParamsBase: IValidateChargeParams
    {
        protected ValidateChargeParamsBase(string pbfPubKey)
        {
            PbfPubKey = pbfPubKey;
        }

        
        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }
    }
}
