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
    internal class RavePayApiRequest : RavePayApiRequestBase<RaveApiResponse<PayResponseData>, PayResponseData>
    {

    }

    internal class RavePayApiRequest<T1, T2> : RavePayApiRequestBase<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : class
    {
        public RavePayApiRequest()
        {
            Config = new RavePayConfig(false);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public RavePayApiRequest(RavePayConfig config)
        {
            Config = config;
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       
    }
}
