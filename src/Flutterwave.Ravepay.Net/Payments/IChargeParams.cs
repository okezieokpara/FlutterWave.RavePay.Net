using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.Payments
{
    public interface IChargeParams
    {
        string PbfPubKey { get; set; }
        string Currency { get; set; }
        string Country { get; set; }
        decimal Amount { get; set; }
        string TxRef { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
