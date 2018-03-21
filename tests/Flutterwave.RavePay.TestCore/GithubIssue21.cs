using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class GithubIssue21
    {
        private static string tranxRef = Guid.NewGuid().ToString("N");
        [TestMethod]
        public void GithubIssue21CardTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey, true);
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
        }
    }
}
