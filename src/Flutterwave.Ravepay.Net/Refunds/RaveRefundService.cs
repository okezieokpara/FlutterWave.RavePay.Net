using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Refunds
{
    public static class RaveRefundService
    {
        private static readonly RavePayApiRequest<RaveApiResponse<RefundsResponseData>, RefundsResponseData> ApiRequest =
            new RavePayApiRequest<RaveApiResponse<RefundsResponseData>, RefundsResponseData>(new FlutterWaveRavePayConfig(false));

        public static async Task<RaveApiResponse<RefundsResponseData>> MakeRefund(RaveRefundParams refundParams)
        {
            var paramsBody = new StringContent(JsonConvert.SerializeObject(refundParams), Encoding.UTF8, "application/json");
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.MakeRefund) { Content = paramsBody };
            return await ApiRequest.Request(httpMessage);
        }
    }
}
