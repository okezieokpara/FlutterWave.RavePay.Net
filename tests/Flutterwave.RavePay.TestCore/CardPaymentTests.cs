using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class CardPaymentTests
    {
        private static string tranxRef = "454839";
        [TestMethod]
        public void CardPaymentTest()
        {
            // Arrange


            var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey ,false);
            var cardCharge = new RaveCardCharge(raveConfig);

            var cardParams = new CardChargeParams(TestConsts.recurringPbKey, "Okezie", "Okpara", "nokalara@mailinator.com",
                3500)
            { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef }
            ;
            var cha = cardCharge.Charge(cardParams).Result;


            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(cardParams).Result;
            }


            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            ValidateCardCharge(cha.Data.FlwRef);

        }
        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey, false);
            var cardCharge = new RaveCardCharge(raveConfig);
            var val = cardCharge.ValidateCharge(new CardValidateChargeParams(TestConsts.recurringPbKey, txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            Assert.AreEqual("success", val.Status);

        }
    }
}
