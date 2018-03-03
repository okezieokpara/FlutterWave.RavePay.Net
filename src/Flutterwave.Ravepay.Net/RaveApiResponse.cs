using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    
   public class RaveApiResponse<T> where T: class 
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public virtual T Data { get; set; }
    }
}
