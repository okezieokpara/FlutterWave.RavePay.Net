using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.Payments
{
   public class CardChargeResponse<T>: RaveApiResponse<T> where T: CardResponseData
    {
        public override T Data { get; set; }
    }

}
