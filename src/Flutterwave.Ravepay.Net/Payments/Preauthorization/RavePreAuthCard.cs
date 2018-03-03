using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net.Security;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RavePreAuthCard
    {
        public RavePreAuthCard(RavePayConfig config)
        {
            if (string.IsNullOrEmpty(config.SecretKey))
            {
                throw new ArgumentException("The SecretKey Fieid is required");
            }
            Config = config;
            PaymentDataEncryption = new RaveEncryption(); // Sets to the default encryption
            ApiRequest = new RavePayApiRequest<RaveApiResponse<PreauthoriseResponseData>, PreauthoriseResponseData>(config);
        }
        private RavePayConfig Config { get; }
        private IPaymentDataEncryption PaymentDataEncryption { get; }
        private IRavePayApiRequest<RaveApiResponse<PreauthoriseResponseData>, PreauthoriseResponseData> ApiRequest { get; }



        public async Task<RaveApiResponse<PreauthoriseResponseData>> Preauthorize(PreauthorizeParams preauthParams)
        {
            var encryptedKey = PaymentDataEncryption.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PaymentDataEncryption.EncryptData(encryptedKey, JsonConvert.SerializeObject(preauthParams));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = preauthParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.PreauthorizeCardCharge) { Content = content };

            return await ApiRequest.Request(requestMessage);
            ;
        }



        public async Task<RaveApiResponse<PreauthoriseResponseData>> Capture(string flwRef)
        {
            var payload = new { flwRef, SECKEY = Config.SecretKey };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.PreauthorizeCapture) { Content = content };
            return await ApiRequest.Request(requestMessage);
        }

        public async Task<RaveApiResponse<PreauthoriseResponseData>> Void(string flwRef)
        {
            var payload = new { @ref = flwRef, action = "void", SECKEY = Config.SecretKey };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.PreauthorizeReturnOrVoid) { Content = content };
            return await ApiRequest.Request(requestMessage);

        }

        public async Task<RaveApiResponse<PreauthoriseResponseData>> Refund(string flwRef)
        {
            var payload = new { @ref = flwRef, action = "refund", SECKEY = Config.SecretKey };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.PreauthorizeReturnOrVoid) { Content = content };
            return await ApiRequest.Request(requestMessage);
        }
    }
}
