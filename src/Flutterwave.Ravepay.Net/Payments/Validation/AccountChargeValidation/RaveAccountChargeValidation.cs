using System;
using System.Threading.Tasks;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class RaveAccountChargeValidation: ChargeValidationBase<AccountValidateChargeResponseData>
    {
       

        public RaveAccountChargeValidation(RavePayConfig config) : base(config)
        {
        }
    }
}
