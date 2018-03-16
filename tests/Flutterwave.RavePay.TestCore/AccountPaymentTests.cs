using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Banks;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class AccountPaymentTests
    {

        private static string transRef = "Ref105";
        private static string sampleSuccessfulFwRef = "ACHG-1521196019857";

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
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var accountCharge = new RaveAccountCharge(raveConfig);

            var accountParams = new AccountChargeParams(TestConsts.publicKey, "Anonymous", "customer", "user@example.com", TestConsts.accessAccountNumber, 509, acessBank.BankCode, transRef);

            var chargeResponse = accountCharge.Charge(accountParams).Result;

            if (chargeResponse.Data.Status == "success-pending-validation")
            {
                //If it asks for otp. Do request again
                accountParams.Otp = TestConsts.accessAccountOTP;
                chargeResponse = accountCharge.Charge(accountParams).Result;
            }

            Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
            Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
            Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
            // ValidateCardCharge(chargeResponse.Data.FlwRef);
        }

        [TestMethod]
        public void ValidateAccountChargeTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var cardCharge = new RaveAccountCharge(raveConfig);
            var val = cardCharge.ValidateCharge(new AccountValidateChargeParams(TestConsts.publicKey, sampleSuccessfulFwRef, TestConsts.accessAccountOTP)).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            if (val.Status == "error")
            {
                var desiredResponses = new List<string> { "Transaction already complete", "TRANSACTION ALREADY VERIFIED" }; // These are also accepted values depending on whether the transaction has be verified before
                Assert.IsTrue(desiredResponses.Contains(val.Message));
            }
            else
            {
                Assert.IsNotNull(val.Data);
                Assert.AreEqual("success", val.Status);
                Assert.AreEqual("Charge Complete", val.Message);
            }



        }

    }
}
