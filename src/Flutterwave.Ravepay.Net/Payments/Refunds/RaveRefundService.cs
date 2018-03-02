using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public static class RaveRefundService
    {
        private static readonly RavePayApiRequest<RaveApiResponse<RefundsResponseData>, RefundsResponseData> ApiRequest =
            new RavePayApiRequest<RaveApiResponse<RefundsResponseData>, RefundsResponseData>(new FlutterWaveRavePayConfig(false));

        public static async Task<RaveApiResponse<RefundsResponseData>> MakeRefund(RaveRefundParams refundParams)
        {
            var paramsBody = new StringContent(JsonConvert.SerializeObject(refundParams), Encoding.UTF8, "application/json");
            var body = JsonConvert.
            foreach (var VARIABLE in JsonConvert.SerializeObject(refundParams))
            {
                
            }
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.MakeRefund) { Content = paramsBody };
            return await ApiRequest.Request(httpMessage);
        }
    }
}
