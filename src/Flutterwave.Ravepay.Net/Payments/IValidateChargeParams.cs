using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.Payments
{
    public interface IValidateChargeParams
    {
        string PbfPubKey { get; set; }
    }
}
