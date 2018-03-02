using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net
{
    internal class Enpoints
    {
        public const string ValidateCharge = "/flwv3-pug/getpaidx/api/validatecharge";
        public const string CardCharge = "flwv3-pug/getpaidx/api/charge";
        public const string Verify = "flwv3-pug/getpaidx/api/verify";
        public const string Xquery = "flwv3-pug/getpaidx/api/xrequery";
        public const string GetFees = "flwv3-pug/getpaidx/api/fee";
        public const string MakeRefund = "gpx/merchant/transactions/refund";
        public const string GetBankList =
            "flwv3-pug/getpaidx/api/flwpbf-banks.js?json=1";
    }
}
