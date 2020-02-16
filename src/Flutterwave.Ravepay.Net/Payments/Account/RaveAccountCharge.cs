﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RaveAccountCharge : ChargeBase<RaveApiResponse<AccounResponseData>, AccounResponseData>
    {
        public RaveAccountCharge(RavePayConfig config) : base(config)
        {
        }

        public override async Task<RaveApiResponse<AccounResponseData>> Charge(IChargeParams chargeParams, bool isRecurring = false)
        {
            if (Config.PbfPubKey != chargeParams.PbfPubKey)
            {
                throw new ArgumentException("There is an issue with the public key provided. Please check that the public keys are consistent");
            }
            var encryptedKey = PaymentDataEncryption.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PaymentDataEncryption.EncryptData(encryptedKey, JsonConvert.SerializeObject(chargeParams));
            //var sampleJson = JsonConvert.SerializeObject(chargeParams);

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = chargeParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.CardCharge) { Content = content };
            var result = await ApiRequest.Request(requestMessage); // Todo: Check endpoints

            // try to get the auth mode used. expected values are: "PIN","VBVSECURECODE", "AVS_VBVSECURECODE"
            return result;
        }


    }
}
