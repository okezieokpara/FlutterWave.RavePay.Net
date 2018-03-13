using Flutterwave.Ravepay.Net.Payments;
using Flutterwave.Ravepay.Net.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class CheckSumTests
    {
        [TestMethod]
        public void CheckSumTest()
        {
            var checkSumValue = CheckSum.CreateCheckSum(new CardChargeParams(TestConsts.recurringPbKey, "Okezie",
                "Okpara", "nokalara@mailinator.com",
                4556.000m)
            {
                CardNo = "5438898014560229",
                Cvv = "789",
                Expirymonth = "09",
                Expiryyear = "19",
                TxRef = TestConsts.tranxRef
            }, TestConsts.recurringScKey);

            Trace.WriteLine(checkSumValue);

            Assert.IsNotNull(checkSumValue);
        }
    }
}
