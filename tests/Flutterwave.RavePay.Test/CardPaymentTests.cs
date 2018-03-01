using System;
using System.Configuration;
using System.Diagnostics;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.Test
{
    [TestClass]
    public class CardPaymentTests
    {
        private static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        private static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");
        private static string tranxRef = "1234";
        [TestMethod]
        public void CardPaymentTest()
        {
            // Arrange



            var raveConfig = new FlutterWaveRavePayConfig(publicKey, secretKey, false);
            var cardCharge = new CardCharge(raveConfig);

            var cha = cardCharge.Charge(new CardChargeParams(publicKey, "Okezie", "Okpara", "okeziestanley@gmail.com",
                    4556)
            { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = "1234" }).Result;


            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cha = cardCharge.Charge(new CardChargeParams(publicKey, "Apara", "Emmanuel", "okeziestanley@gmail.com",
                        5000)
                    { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef, Pin = "3310"}).Result;
            }


            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            ValidateCardCharge(cha.Data.FlwRef);

        }
        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new FlutterWaveRavePayConfig(publicKey, secretKey, false);
            var cardCharge = new CardCharge(raveConfig);
            var val = cardCharge.ValidateCharge(new CardValidateChargeParams(publicKey, txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            Assert.AreEqual("success", val.Status);

        }
    }
}
