using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net.Reflection;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class RecurrentBilling
    {

        public RecurrentBilling(RavePayConfig config)
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

        public async Task<RaveApiResponse<IEnumerable<RecuringBillingResponseData>>> ListRecurrentBilling(RecurringParams recurringParams)
        {
            var requestUrl = Enpoints.ListRecurring + ReflectionUtil.RequestQueryBuilder(recurringParams);
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
           
            var result = await ApiRequest.Request<RaveApiResponse<IEnumerable<RecuringBillingResponseData>>>(httpMessage);
            return result;
        }

    }
}
