using System;
using System.Configuration;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Currencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]
    public class FeesTest
    {
        private static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string dummyTxRef = "FLW-MOCK-51bd3522815efdbd9018ae1ec1345fc4";

        [TestMethod]
        public void GetFeesTest()
        {
            var fees = RaveFeeService.GetFees(new GetFeesParams(publicKey, 5938, CurrencyType.Naira)).Result;


            Assert.IsNotNull(fees.Data);
            Assert.IsInstanceOfType(fees.Data.ChargeAmount, typeof(decimal));
            Assert.AreEqual(fees.Status, "success");

        }
    }
}
