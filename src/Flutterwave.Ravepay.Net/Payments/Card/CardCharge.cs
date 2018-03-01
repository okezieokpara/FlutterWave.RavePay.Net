﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net.Currencies;
using Newtonsoft.Json;
using System.Reflection;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class CardCharge : ChargeBase<RaveApiResponse<CardResponseData>, CardResponseData>
    {
        public CardCharge(FlutterWaveRavePayConfig config) : base(config)
        {
        }

        public override async Task<RaveApiResponse<CardResponseData>> Charge(IChargeParams chargeParams, bool isRecurring = false)
        {
            var encryptedKey = PaymentDataEncryption.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PaymentDataEncryption.EncryptData(encryptedKey, JsonConvert.SerializeObject(chargeParams));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = chargeParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.CardCharge) { Content = content };
            var result = await ApiRequest.Request(requestMessage); // Todo: Check endpoints

            // try to get the auth mode used. expected values are: "PIN","VBVSECURECODE", "AVS_VBVSECURECODE"
            return result;
        }

        public override async Task<RaveApiResponse<CardResponseData>> ValidateCharge(IValidateChargeParams chargeParams, bool isRecurring = false)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(chargeParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.ValidateCharge) {Content = requestBody};
            var result = await ApiRequest.Request(requestMessage);
            return result;
        }
    }
}
