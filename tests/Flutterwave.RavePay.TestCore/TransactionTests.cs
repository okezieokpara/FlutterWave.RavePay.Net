using Flutterwave.Ravepay.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class TransactionTests
    {
 
        private static string dummyTxRef = "FLW-MOCK-7b5cb8c21a96e5c6da4f85914f5b3c14";

        [TestMethod]
        public void VerifyTransaction()
        {
            var config = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.TransactionVerification(new VerifyTransactoinParams(TestConsts.secretKey, dummyTxRef)).Result;
            Assert.IsNotNull(response.Message);
            Assert.AreEqual(response.Status, "success");
        }
        [TestMethod]
        public void XqueryTransaction()
        {
            var config = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey);
            var trans = new RaveTransaction(config);

            var response = trans.XqueryTransactionVeriication(new VerifyTransactoinParams(TestConsts.secretKey, dummyTxRef)).Result;
            Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<TransactionResponseData>));
            Assert.IsNotNull(response);

            foreach (var res in response.Data)
            {
                Trace.WriteLine($"{res.Status} \t {res.TransactionType}");
            }

        }
    }
}
