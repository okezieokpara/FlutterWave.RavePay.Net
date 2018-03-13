using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class RecurringBilingTests
    {
        private static string dummyTxRef = "FLW-MOCK-51bd3522815efdbd9018ae1ec1345fc4";
        private static string successfulPreauthTransx = "FLW-MOCK-110fc59d2d64cfb7bf0f99b8b1aeba5f";
        private static long sampleRecurringId = 70777;

        [TestMethod]
        public void StopRecurringBill()
        {
            var recurBilling = new RecurrentBilling(new RavePayConfig(false));
            var response = recurBilling.StopRecurrentBilling(new RecurringParams(TestConsts.recurringScKey, sampleRecurringId)).Result;
            if (response.Status == "error")
            {
                // In cases where the transaction has already been stopped
                Assert.AreEqual(response.Message, "This transaction is already stopped");
            }
            else
            {
                Assert.AreEqual(response.Status, "success");
                Assert.IsNotNull(response.Data);
            }

        }

        [TestMethod]
        public void ListRecurringBill()
        {
            var recurBilling = new RecurrentBilling(new RavePayConfig(false));
            var list = recurBilling.ListRecurrentBilling(new RecurringParams(TestConsts.recurringScKey)).Result;

            Assert.AreEqual(list.Status, "success");
            Assert.IsNotNull(list.Data);
        }

        [TestMethod]
        public void ListRecurringMultipleBill()
        {
            var recurBilling = new RecurrentBilling(new RavePayConfig(false));
            var list = recurBilling.ListRecurrentBilling(new RecurringParams(TestConsts.recurringScKey)).Result;

            Assert.AreEqual(list.Status, "success");
            Assert.IsNotNull(list.Data);
        }
    }
}
