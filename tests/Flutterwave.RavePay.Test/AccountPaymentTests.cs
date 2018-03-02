using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Banks;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    /// <summary>
    /// Summary description for AccountPaymentTests
    /// </summary>
    [TestClass]
    public class AccountPaymentTests
    {
        private static readonly string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string accessAcountNumber = ConfigurationSettings.AppSettings.Get("accountNumber");
        private static string sampleOtp = ConfigurationSettings.AppSettings.Get("otp");
        private static string transRef = "Ref105";
        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetBanks() //Aka LordBanks
        {

            var banks = BankService.GetBankList().Result;
            foreach (var bank in banks)
            {
                Trace.WriteLine(bank.ToString());
            }
            Assert.IsNotNull(banks);
            Assert.IsInstanceOfType(banks, typeof(IEnumerable<Bank>));

        }

        [TestMethod]
        public void AccountChargeTest()
        {
            var acessBank = new Bank("ACCESS BANK NIGERIA", "044");
            var raveConfig = new FlutterWaveRavePayConfig(publicKey, secretKey, false);
            var accountCharge = new AccountCharge(raveConfig);

            var accountParams = new AccountChargeParams(publicKey, "Apara", "Emmanuel", "okpara.okezie@venturegardengroup.com", accessAcountNumber, 509, acessBank.BankCode, transRef);
            var chargeResponse = accountCharge.Charge(accountParams).Result;


            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
            ValidateCardCharge(chargeResponse.Data.FlwRef);
        }
        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new FlutterWaveRavePayConfig(publicKey, secretKey, false);
            var cardCharge = new AccountCharge(raveConfig);
            var val = cardCharge.ValidateCharge(new AccountValidateChargeParams(publicKey, txRef, sampleOtp)).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            Assert.AreEqual("success", val.Status);

        }

    }
}
