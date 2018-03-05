using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net.Payments;

namespace Flutterwave.Ravepay.Net
{

    internal interface IRavePayApiRequest<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : class 
    {
        Task<T1> Request(HttpRequestMessage requestBody);
        Task<T0> Request<T0>(HttpRequestMessage requestBody);
    }
}
