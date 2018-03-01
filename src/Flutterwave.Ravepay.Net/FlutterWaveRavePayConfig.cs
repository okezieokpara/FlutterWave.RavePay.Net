using System;

namespace Flutterwave.Ravepay.Net
{
    public class FlutterWaveRavePayConfig
    {
        public FlutterWaveRavePayConfig(bool isLive)
        {
            IsLive = isLive;
        }

        public FlutterWaveRavePayConfig(string apiKey, string secretKey, bool isLive)
        {
            IsLive = isLive;
            ApiKey = apiKey;
            SecretKey = secretKey;
        }

        public FlutterWaveRavePayConfig(string apiKey, string secretKey)
        {
            IsLive = false;
            ApiKey = apiKey;
            SecretKey = secretKey;
        }
        public  bool IsLive { get; set; }
        public  string ApiKey { get; set; }
        public  string SecretKey { get; set; }
    }
}
