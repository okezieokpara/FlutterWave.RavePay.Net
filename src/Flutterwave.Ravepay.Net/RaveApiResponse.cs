using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Flutterwave.Ravepay.Net
{

    public class RaveApiResponse<T> where T : class
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
            if (error.Error is JsonSerializationException) //This tries to cover up for what I percieve to be a bug in the RavePay API
            {
                Data = default(T);
                error.Handled = true;
                return;
            }
#if DEBUG
            error.Handled = false;
#else
            error.Handled = true;
#endif
        }
    }
}
