using System;
using System.Diagnostics;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]
    public class PreauthorizeTests
    {
        private const string txRef = "549494";
        private const string successfulFwRef = "FLW00920971";
        private const string unCapturedFwRef = "FLW00920978";
        [TestMethod]
        public void PreAuthCardChargeTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.preauthPbkey, TestConsts.preauthSecretKey, false);
            var preuthCard = new RavePreAuthCard(raveConfig);

            var card = new Card(TestConsts.preauthCardNo, TestConsts.preAuthExpiryMonth, TestConsts.preAuthExpiryYear,
                TestConsts.preauthCVV);
            var preauthResponse =
                preuthCard.Preauthorize(new PreauthorizeParams(raveConfig.PbfPubKey, "Alara", "Nok",
                    "nokalara@mailinator.com", 10000, card){TxRef = txRef }).Result;
           // Trace.WriteLine(JsonConvert.SerializeObject(preauthResponse.Data));
            Assert.IsNotNull(preauthResponse.Data);
            Assert.AreEqual(preauthResponse.Status, "success");

        }
        [TestMethod]
        public void PreAuthCaptureTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.preauthPbkey, TestConsts.preauthSecretKey, false);
            var preuthCard = new RavePreAuthCard(raveConfig);
            var captureResponse = preuthCard.Capture(successfulFwRef).Result;

          // Trace.WriteLine(JsonConvert.SerializeObject(captureResponse));
            Assert.IsNotNull(captureResponse.Data);
            Assert.AreEqual(captureResponse.Status, "success");
        }

        [TestMethod]
        public void PreAuthRefundTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.preauthPbkey, TestConsts.preauthSecretKey, false);
            var preuthCard = new RavePreAuthCard(raveConfig);
            var captureResponse = preuthCard.Refund(successfulFwRef).Result;

           // Trace.WriteLine(JsonConvert.SerializeObject(captureResponse));
            Assert.IsNotNull(captureResponse.Data);
            Assert.AreEqual(captureResponse.Status, "success");
        }

        [TestMethod]
        public void PreAuthVoidTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.preauthPbkey, TestConsts.preauthSecretKey, false);
            var preuthCard = new RavePreAuthCard(raveConfig);
            var captureResponse = preuthCard.Void(unCapturedFwRef).Result;

          //  Trace.WriteLine(JsonConvert.SerializeObject(captureResponse));
            Assert.IsNotNull(captureResponse.Data);
            Assert.AreEqual(captureResponse.Status, "success");
        }
    }
}
