using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Banks;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.TestCore.PaymentTests
{
    [TestClass]
    public class AccountPaymentTests
    {

        private static string transRef = "Ref105";
        private static string sampleSuccessfulFwRef = "ACHG-1521196019857";

        [TestMethod]
        public async Task GetDebitBanks() //Aka LordBanks
        {

            var banks = await BankService.GetBankDebitDirectList();
            foreach (var bank in banks)
            {
                Trace.WriteLine(bank.ToString());
            }
            Assert.IsNotNull(banks);
            Assert.IsInstanceOfType(banks, typeof(IEnumerable<Bank>));

        }


        [TestMethod]
        public async Task GetTransferbanks()
        {
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var result = await BankService.GetBankTransferList("NG", raveConfig);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RaveApiResponse<BankTransferListResponse>));
            Assert.AreEqual("success", result.Status);
        }


        [TestMethod]
        public async Task AccountChargeTest()
        {
            var acessBank = new Bank("ACCESS BANK NIGERIA", "044");
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var accountCharge = new RaveAccountCharge(raveConfig);

            var txref = Guid.NewGuid().ToString("N");


            var accountParams = new AccountChargeParams(TestConsts.publicKey, "Anonymous", "Customer", "user@example.com", TestConsts.accessAccountNumber, 509, acessBank.BankCode, txref);

            var chargeResponse = await accountCharge.Charge(accountParams);

            //Assert
            Assert.AreEqual("success-pending-validation", chargeResponse.Data.Status);

            if (chargeResponse.Data.Status == "success-pending-validation")
            {
                //If it asks for otp. Do request again
                accountParams.Otp = TestConsts.accessAccountOTP;
                chargeResponse = await accountCharge.Charge(accountParams);
            }

            Trace.WriteLine($"ValidateInstructions: { chargeResponse.Data.ValidateInstructions.Instruction}");
            Trace.WriteLine($"ValidateInstructions.Valparams: { chargeResponse.Data.ValidateInstructions.Valparams}");

            Trace.WriteLine($"ValidateInstruction: {chargeResponse.Data.ValidateInstruction}");

            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
            await VerifyAccountCharge(txref);
        }

        [TestMethod]
        public async Task ValidateAccountChargeTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var accountValidate = new RaveAccountChargeValidation(raveConfig);
            var val = await accountValidate.ValidateCharge(new AccountValidateChargeParams(TestConsts.publicKey, sampleSuccessfulFwRef, TestConsts.accessAccountOTP));

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

        public async Task VerifyAccountCharge(string txRef)
        {

            var raveTransaction = new RaveTransaction(new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false));

            var transVerify = await raveTransaction.VerifyTransaction(new VerifyTransactoinParams(TestConsts.secretKey, txRef));


            Assert.AreEqual("success", transVerify.Status);
            Assert.AreEqual("success-pending-validation", transVerify.Data.Status);





        }


    }
}
