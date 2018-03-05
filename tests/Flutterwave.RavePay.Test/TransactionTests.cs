using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
        private static string dummyTxRef = "FLW-MOCK-7b5cb8c21a96e5c6da4f85914f5b3c14";

        [TestMethod]
        public void VerifyTransaction()
        {
            var config = new RavePayConfig(publicKey, secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.TransactionVerification(new VerifyTransactoinParams(secretKey, dummyTxRef)).Result;
            Assert.IsNotNull(response.Message);
            Assert.AreEqual(response.Status, "success");
        }
        [TestMethod]
        public void XqueryTransaction()
        {
            var config = new RavePayConfig(publicKey, secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.XqueryTransactionVeriication(new VerifyTransactoinParams(secretKey, dummyTxRef)).Result;
            Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<TransactionResponseData>));
            Assert.IsNotNull(response);

            foreach (var res in response.Data)
            {
                Trace.WriteLine($"{res.Status} \t {res.TransactionType}");
            }

        }
    }
}
