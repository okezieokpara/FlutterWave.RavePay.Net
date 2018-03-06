using System;

namespace Flutterwave.Ravepay.Net
{
    public class RavePayConfig
    {
        public RavePayConfig(bool isLive)
        {
            IsLive = isLive;
        }

        /// <summary>
        /// Instansiate a new config object
        /// </summary>
        /// <param name="publicKey">PBFPubKey</param>
        /// <param name="secretKey">This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix FLWSECK and ends with suffix X</param>
        /// <param name="isLive">Toogle Test and live. Default is false</param>
        public RavePayConfig(string publicKey, string secretKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey">PBFPubKey</param>
        /// <param name="isLive">Toogle Test and live. Default is false</param>
        public RavePayConfig(string publicKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey">PBFPubKey</param>
        /// <param name="secretKey">This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix FLWSECK and ends with suffix X</param>
        public RavePayConfig(string publicKey, string secretKey)
        {
            IsLive = false;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }
        public bool IsLive { get; set; }
        public string PbfPubKey { get; set; }
        public string SecretKey { get; set; }
    }
}
