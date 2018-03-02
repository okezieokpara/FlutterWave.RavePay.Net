using System;
using System.Configuration;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]
    public class RecurringBilingTests
    {
        private static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string dummyTxRef = "FLW-MOCK-51bd3522815efdbd9018ae1ec1345fc4";

        [TestMethod]
        public void StopRecurringBill()
        {
        }

        [TestMethod]
        public void ListRecurringBill()
        {
            var recurBilling = new RecurrentBilling(new FlutterWaveRavePayConfig(false));
            var list = recurBilling.ListRecurrentBilling(new RecurringParams(secretKey)).Result;
            Assert.IsNotNull(list);
        }
    }
}
