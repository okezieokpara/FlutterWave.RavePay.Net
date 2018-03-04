using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        [OnError]
        internal void OnError(StreamingContext streamingContext, ErrorContext error)
        {
            error.Handled = true;
        }
    }
}
