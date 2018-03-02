using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RecurrentBilling
    {

        public RecurrentBilling(FlutterWaveRavePayConfig config)
        {
            ApiRequest = new RavePayApiRequest<RaveApiResponse<RecuringBillingResponseData>, RecuringBillingResponseData>(config);

        }

        private RavePayApiRequest<RaveApiResponse<RecuringBillingResponseData>, RecuringBillingResponseData> ApiRequest { get; }

        public async Task<RaveApiResponse<RecuringBillingResponseData>> StopRecurrentBilling(RecurringParams recurringParams)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.StopRecurring)
            {
                Content = new StringContent(JsonConvert.SerializeObject(recurringParams), Encoding.UTF8, "application/json")
            };

            var result = await ApiRequest.Request(httpMessage);
            return result;
        }

        public async Task<IEnumerable<RecuringBillingResponseData>> ListRecurrentBilling(RecurringParams recurringParams)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, Enpoints.StopRecurring)
            {
                Content = new StringContent(JsonConvert.SerializeObject(recurringParams), Encoding.UTF8, "application/json")
            };
            var result = await ApiRequest.Request<IEnumerable<RecuringBillingResponseData>>(httpMessage);
            return result;
        }

    }
}
