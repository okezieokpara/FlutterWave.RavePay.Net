using System;
using System.Configuration;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]
    public class RefundTests
    {
        private static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string dummyTxRef = "FLW-MOCK-4844faec5b9a59fb835f3c5b73c2605f";

        [TestMethod]
        public void MakeRefundTest()
        {
            var refundResponse = RaveRefundService.MakeRefund(new RaveRefundParams(dummyTxRef, secretKey)).Result;
            Assert.IsNotNull(refundResponse.Data);
            Assert.AreEqual(refundResponse.Data.Status, "success");
            Assert.AreEqual(refundResponse.Data.Message, "Refunded");

        }
    }
}
