using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class RefundTests
    {
        private const string dummyTxRef = "FLW-MOCK-RECURR-dbc3ff3cf9eb17d6d18c0db9a43fab39";

        [TestMethod]
        public void MakeRefundTest()
        {
            var refundResponse = RaveRefundService.MakeRefund(new RaveRefundParams(dummyTxRef, TestConsts.secretKey)).Result;

            if (refundResponse.Status == "error")
            {
                // In a case whereby the transaction was already refunded or cannot be refunded
                Assert.AreEqual(refundResponse.Message, "Transaction already refunded. Please contact support");
            }
            else
            {
                Assert.IsNotNull(refundResponse.Data);
                Assert.AreEqual(refundResponse.Status, "success");
                Assert.AreEqual(refundResponse.Data.Status, "completed");
                Assert.AreEqual(refundResponse.Data.Message, "Refunded");
            }
            

        }
    }
}
