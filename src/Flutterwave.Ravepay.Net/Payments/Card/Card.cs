using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class Card
    {
        public string CardNo { get; set; }
        public string Expirymonth { get; set; }
        public  string Expiryyear { get; set; }
        public string Cvv { get; set; }
        public string Pin { get; set; }
    }
}
