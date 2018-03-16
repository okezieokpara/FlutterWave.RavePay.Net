using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    public static class RaveFeeService
    {
        private static readonly RavePayApiRequest<RaveApiResponse<RaveFeesData>, RaveFeesData> ApiRequest =
            new RavePayApiRequest<RaveApiResponse<RaveFeesData>, RaveFeesData>(new RavePayConfig(false));

        public static async Task<RaveApiResponse<RaveFeesData>> GetFees(GetFeesParams feesParams)
        {
            var paramsBody = new StringContent(JsonConvert.SerializeObject(feesParams), Encoding.UTF8, "application/json");
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.GetFees) { Content = paramsBody };
            return await ApiRequest.Request(httpMessage);
        }
    }
}
