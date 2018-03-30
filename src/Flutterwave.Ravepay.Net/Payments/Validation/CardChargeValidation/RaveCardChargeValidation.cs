using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Flutterwave.Ravepay.Net.Payments
{
    public class RaveCardChargeValidation : ChargeValidationBase<CardValidateChargeResponseData>
    {
        public RaveCardChargeValidation(RavePayConfig config) : base(config)
        {
        }

        //public override async Task<RaveApiResponse<CardValidateChargeResponseData>> ValidateCharge(IValidateChargeParams validateChargeParams)
        //{

        //    var requestBody = new StringContent(JsonConvert.SerializeObject(validateChargeParams), Encoding.UTF8,
        //        "application/json");

        //    var requestMessage =
        //        new HttpRequestMessage(HttpMethod.Post, Enpoints.ValidateCharge) { Content = requestBody };
        //    var result = await ApiRequest.Request(requestMessage);
        //    return result;
        //}
    }
}
