using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net
{
   public class Transaction
    {
        public Transaction(FlutterWaveRavePayConfig config)
        {
            Config = config;
        }

        public FlutterWaveRavePayConfig Config { get; }

        public void TransactionVerification(VerifyTransactoinParams verifyParams)
        {

        }
        public void XqueryTransactionVeriication(VerifyTransactoinParams verifyParams)
        {

        }

      
    }
}
