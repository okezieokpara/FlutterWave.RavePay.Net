
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class RaveTokenCharge: ChargeBase<RaveApiResponse<TokenChargeResponseData>, TokenChargeResponseData>
    {
        public RaveTokenCharge(RavePayConfig config) : base(config)
        {
        }

        public override async Task<RaveApiResponse<TokenChargeResponseData>> Charge(IChargeParams chargeParams, bool isRecurring = false)
        {
            var content = new StringContent(JsonConvert.SerializeObject(chargeParams), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Enpoints.TokenizeCharge) { Content = content };
            var result = await ApiRequest.Request(requestMessage);
            return result;
        }
    }
}
