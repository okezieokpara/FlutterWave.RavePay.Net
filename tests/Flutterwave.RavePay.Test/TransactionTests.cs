using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]

    public class TransactionTests
    {
        private static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string dummyTxRef = "FLW-MOCK-51bd3522815efdbd9018ae1ec1345fc4";

        [TestMethod]
        public void VerifyTransaction()
        {
            var config = new FlutterWaveRavePayConfig(publicKey, secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.TransactionVerification(new VerifyTransactoinParams(secretKey, dummyTxRef)).Result;
            Assert.IsNotNull(response.Message);
            Assert.AreEqual(response.Status, "success");
        }
        [TestMethod]
        public void XqueryTransaction()
        {
            var config = new FlutterWaveRavePayConfig(publicKey, secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.XqueryTransactionVeriication(new VerifyTransactoinParams(secretKey, dummyTxRef)).Result;
            Assert.IsNotNull(response.Message);
            Assert.AreEqual(response.Status, "success");
        }
    }
}
