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
        public const string StopRecurring = "merchant/subscriptions/stop";
        public const string ListRecurring = "merchant/subscriptions/list";
        public const string ExchangeRates = "flwv3-pug/getpaidx/api/forex";
        public const string TokenzeCharge = "flwv3-pug/getpaidx/api/tokenized/charge";
        public const string PreauthorizeCardCharge = "flwv3-pug/getpaidx/api/charge";
        public const string PreauthorizeCapture = "flwv3-pug/getpaidx/api/capture";
        public const string PreauthorizeReturnOrVoid = "flwv3-pug/getpaidx/api/refundorvoid";


        public const string GetBankList =
            "flwv3-pug/getpaidx/api/flwpbf-banks.js?json=1";
    }
}
