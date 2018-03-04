using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class RaveRefundParams
    {
        public RaveRefundParams(string @ref, string seckey)
        {
            Ref = @ref;
            Seckey = seckey;
        }

        protected RaveRefundParams()
        {
            
        }
        
        /// <summary>
        /// This is the flwRef returned in the charge response
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        /// This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix FLWSECK and ends with suffix X
        /// </summary>
        [JsonProperty("seckey")]
        public  string Seckey { get; set; }
    }
}
