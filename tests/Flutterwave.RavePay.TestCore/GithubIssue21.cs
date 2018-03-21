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
            var raveConfig = new RavePayConfig("FLWPUBK-69dd4afe3cf6de390bf3c8f755244e24-X", "FLWSECK-d18452a2f01ad26305f7a2a5ffe24305-X", true);
            var cardCharge = new RaveCardCharge(raveConfig);

            var cardParams = new CardChargeParams("FLWPUBK-69dd4afe3cf6de390bf3c8f755244e24-X", "Okezie", "Okpara", "nokalara@mailinator.com",
                3500)
            { CardNo = "5399831125815419", Cvv = "892", Expirymonth = "04", Expiryyear = "19", TxRef = tranxRef }
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
