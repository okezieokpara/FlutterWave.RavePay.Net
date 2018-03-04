using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net.Payments;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    internal abstract class RavePayApiRequestBase<T1, T2> : IRavePayApiRequest<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : PayResponseData
    {
        protected RavePayApiRequestBase()
        {
            Config = new RavePayConfig(false);
            HttpClient = new HttpClient()
            {
                BaseAddress = Config.IsLive
                    ? new Uri(FlutterwaveRavePayConsts.LiveUrl)
                    : new Uri(FlutterwaveRavePayConsts.SanboxUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected RavePayApiRequestBase(RavePayConfig config)
        {
            Config = config;
            HttpClient = new HttpClient()
            {
                BaseAddress = Config.IsLive
                    ? new Uri(FlutterwaveRavePayConsts.LiveUrl)
                    : new Uri(FlutterwaveRavePayConsts.SanboxUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public HttpClient HttpClient { get; }
        public RavePayConfig Config { get; set; }

        public virtual async Task<T1> Request(HttpRequestMessage requestBody)
        {
            var httpResponse = await HttpClient.SendAsync(requestBody);
            T1 response;
            if (httpResponse.IsSuccessStatusCode)
            {
                response =
                    JsonConvert.DeserializeObject<T1>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                response = await ExamineFailedRespone(httpResponse);
            }
            // Todo: If request fails find out the type of failure
            return response;
        }
        public async Task<T0> Request<T0>(HttpRequestMessage requestBody)
        {
            var httpResponse = await HttpClient.SendAsync(requestBody);
            var response = JsonConvert.DeserializeObject<T0>(await httpResponse.Content.ReadAsStringAsync());
            return response;
        }

        private static async Task<T1> ExamineFailedRespone(HttpResponseMessage httpResponse)
        {
            return JsonConvert.DeserializeObject<T1>(await httpResponse.Content.ReadAsStringAsync()); // Todo: This is a placeholder
        }
    }
}

