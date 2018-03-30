using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class RaveAccountChargeValidation: ChargeValidationBase<AccountValidateChargeResponseData>
    {
       

        public RaveAccountChargeValidation(RavePayConfig config) : base(config)
        {
        }
        public override async Task<RaveApiResponse<AccountValidateChargeResponseData>> ValidateCharge(IValidateChargeParams validateChargeParams)
        {

            var requestBody = new StringContent(JsonConvert.SerializeObject(validateChargeParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.ValidateCharge) { Content = requestBody };
            var result = await ApiRequest.Request(requestMessage);
            return result;
        }
    }
}
