using System;
using System.Threading.Tasks;

namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Validation charge interface
    /// </summary>
    public interface IChargeValidation<T> where T: ValidateChargeResponseDataBase
    {
        /// <summary>
        /// The main validation method
        /// </summary>
        /// <param name="validateChargeParams"></param>
        /// <returns></returns>
        Task<RaveApiResponse<T>> ValidateCharge(IValidateChargeParams validateChargeParams);
    }
}
