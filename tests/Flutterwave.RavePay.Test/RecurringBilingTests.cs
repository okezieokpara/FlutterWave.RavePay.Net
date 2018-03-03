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
        private static string recurringPbKey = ConfigurationSettings.AppSettings.Get("recurringPbKey");
        private static string recurringScKey = ConfigurationSettings.AppSettings.Get("recurringScKey");
        private static string dummyTxRef = "FLW-MOCK-51bd3522815efdbd9018ae1ec1345fc4";
        private static string successfulPreauthTransx = "FLW-MOCK-110fc59d2d64cfb7bf0f99b8b1aeba5f";

        [TestMethod]
        public void StopRecurringBill()
        {
        }

        [TestMethod]
        public void ListRecurringBill()
        {
            var recurBilling = new RecurrentBilling(new RavePayConfig(false));
            var list = recurBilling.ListRecurrentBilling(new RecurringParams(recurringScKey)).Result;

            Assert.AreEqual(list.Status, "success");
            Assert.IsNotNull(list.Data);
        }

        [TestMethod]
        public void ListRecurringMultipleBill()
        {
            var recurBilling = new RecurrentBilling(new RavePayConfig(false));
            var list = recurBilling.ListRecurrentBilling(new RecurringParams(recurringScKey)).Result;

            Assert.AreEqual(list.Status, "success");
            Assert.IsNotNull(list.Data);
        }
    }
}
