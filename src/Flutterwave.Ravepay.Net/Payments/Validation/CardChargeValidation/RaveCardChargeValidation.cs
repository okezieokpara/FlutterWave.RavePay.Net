using System;
using System.Threading.Tasks;


namespace Flutterwave.Ravepay.Net.Payments
{
    public class RaveCardChargeValidation : ChargeValidationBase<CardValidateChargeResponseData>
    {
        public RaveCardChargeValidation(RavePayConfig config) : base(config)
        {
        }
    }
}
