using System;
using System.Collections.Generic;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Flutterwave.Ravepay.Net
{
    public class VerifyTransactoinParams
    {
        public VerifyTransactoinParams()
        {
            Normalize = 1;
        }

        public VerifyTransactoinParams(string seckey)
        {
            Seckey = seckey;
            Normalize = 1;
        }
        public VerifyTransactoinParams(string seckey, string flwRef)
        {
            Seckey = seckey;
            FlwRef = flwRef;
            Normalize = 1;
        }

        /// <summary>
        /// 
        /// string
        /// This is the unique reference, unique to the particular transaction being carried out. e.g. “flw_ref”: “FLW-MOCK-6f52518a2ecca2b6b090f9593eb390ce”
        /// </summary>
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }

        /// <summary>
        /// This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix ‘FLWSECK’ and ends with suffix ‘X’.
        /// </summary>
        [JsonProperty("SECKEY")]
        public string Seckey { get; set; }

        /// <summary>
        /// This is used to get the response object in a normalize form, just pass the value "1".
        /// </summary>
        [JsonProperty("normalize ")]
        public int Normalize { get; set; }

        /// <summary>
        /// This is the merchant's unique reference. It can be passed instead of flw_ref
        /// </summary>
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        /// <summary>
        /// This retrieves the last transaction attempt linked to the txref
        /// </summary>
        [JsonProperty("last_attempt")]
        public string LastAttempt { get; set; }

        /// <summary>
        /// This retrieves only successful transaction attempts linked with the txref
        /// </summary>
        [JsonProperty("only_successful")]
        public string OnlySuccessful { get; set; }
    }
}
