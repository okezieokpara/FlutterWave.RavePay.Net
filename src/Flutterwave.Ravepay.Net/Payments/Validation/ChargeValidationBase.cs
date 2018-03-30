using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Base class for charge validation
    /// </summary>
    public abstract class ChargeValidationBase<T> : IChargeValidation<T> where T : ValidateChargeResponseDataBase
    {
        protected ChargeValidationBase(RavePayConfig config)
        {
            Config = config;
            ApiRequest = new RavePayApiRequest<RaveApiResponse<T>, T>(config);
        }
        protected internal RavePayConfig Config { get; }
        internal IRavePayApiRequest<RaveApiResponse<T>, T> ApiRequest { get; }

        public virtual async Task<RaveApiResponse<T>> ValidateCharge(IValidateChargeParams validateChargeParams)
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
