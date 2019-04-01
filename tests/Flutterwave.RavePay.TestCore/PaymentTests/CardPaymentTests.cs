using System;
using System.Diagnostics;
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.TestCore.PaymentTests
{
    [TestClass]
    public class CardPaymentTests
    {
        [TestMethod]
        public void CardCharegLocalPin_Test()
        {
            // Arrange

            var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey, false);
            var cardCharge = new RaveCardCharge(raveConfig);

            var cardParams = new CardChargeParams(TestConsts.recurringPbKey, TestConsts.customerFirstName, TestConsts.customerLastName, TestConsts.customerEmail,
                3500)
            { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = Guid.NewGuid().ToString("N") }
            ;

            // Act
            var cha = cardCharge.Charge(cardParams).Result;


            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN") // Some payment cards my require further authentication i.e pin and OTP
            //https://developer.flutterwave.com/v2.0/reference#section-using-a-local-mastercardverve-ie-card-issued-in-nigeria
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(cardParams).Result; // Try to charge the card again
            }


            // Assert
            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            ValidateCardCharge(cha.Data.FlwRef);

        }

        [TestMethod]
        public void CardCharegIntl_Test()
        {
            // Arrange
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var cardCharge = new RaveCardCharge(raveConfig);

            var cardParams = new CardChargeParams(TestConsts.publicKey, TestConsts.customerFirstName,
                TestConsts.customerLastName, TestConsts.customerEmail,
                3500)
            {
                CardNo = TestConsts.testVisaIntlCardNo,
                Cvv = TestConsts.testVisaIntlCardCVV,
                Expirymonth = TestConsts.testVisaIntlExpiryMonth,
                Expiryyear = TestConsts.testVisaIntlExpiryYear,
                TxRef = Guid.NewGuid().ToString("N")
            };


            // Act
            var cha = cardCharge.Charge(cardParams).Result;


            Assert.AreEqual("AUTH_SUGGESTION", cha.Message);
            Assert.AreEqual("NOAUTH_INTERNATIONAL", cha.Data.SuggestedAuth);
            // When using an international card. https://developer.flutterwave.com/v2.0/reference#section-using-avs-address-verification-system-to-charge-an-international-card
            cardParams.BillingZip = "07205";
            cardParams.BillingCity = "Hillside";
            cardParams.BillingAddress = "470 Mundet PI";
            cardParams.BillingState = "NJ";
            cardParams.BillingCountry = "US";
            cha = cardCharge.Charge(cardParams).Result; // Try to charge the card again

            // Assert
            Assert.IsNotNull(cha.Data);
            if (cha.Data.AuthModelUsed == "VBVSECURECODE")
            {
                // In this case the API should return an "authUrl" which should be loaded in an iframe for the user to validate
                Assert.IsNotNull(cha.Data.AuthUrl);
                Assert.IsTrue(!string.IsNullOrEmpty(cha.Data.AuthUrl));
            }
            else
            {
                Assert.AreEqual("PIN", cha.Data.AuthModelUsed);
            }
            Assert.AreEqual("success", cha.Status);
            // ValidateCardCharge(cha.Data.FlwRef);
        }

        [TestMethod]
        public void CardCharegIntl3DSecure_Test()
        {
            //Based on  https://developer.flutterwave.com/v2.0/reference#section-using-avs-address-verification-system-to-charge-an-international-card

            // Arrange
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var cardCharge = new RaveCardCharge(raveConfig);

            var cardParams = new CardChargeParams(TestConsts.publicKey, TestConsts.customerFirstName, TestConsts.customerLastName,
               TestConsts.customerEmail,
                3500)
            {
                CardNo = TestConsts.testIntl3DCardNo,
                Cvv = TestConsts.testIntl3DCVV,
                Expirymonth = TestConsts.testIntl3DExpiryMonth,
                Expiryyear = TestConsts.testIntl3DExpiryYear,
                TxRef = Guid.NewGuid().ToString("N")
            };


            // Act
            var cha = cardCharge.Charge(cardParams).Result;
            Assert.AreEqual("AVS_VBVSECURECODE", cha.Data.SuggestedAuth);
            Assert.AreEqual("AUTH_SUGGESTION", cha.Message);


            // Validation phase
            cardParams.BillingZip = "07205";
            cardParams.BillingCity = "Hillside";
            cardParams.BillingAddress = "470 Mundet PI";
            cardParams.BillingState = "NJ";
            cardParams.BillingCountry = "US";
            cha = cardCharge.Charge(cardParams).Result; // Try to charge the card again

            // Assert
            Assert.AreEqual("02", cha.Data.ChargeResponseCode);
            if (cha.Data.AuthModelUsed == "VBVSECURECODE")
            {
                // In this case the API should return an "authUrl" which should be loaded in an iframe for the user to validate
                Assert.IsNotNull(cha.Data.AuthUrl);
                Assert.IsTrue(!string.IsNullOrEmpty(cha.Data.AuthUrl));
            }
            else
            {
                Assert.AreEqual("PIN", cha.Data.AuthModelUsed);
            }

            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success-pending-validation", cha.Status);
            Assert.AreEqual("card", cha.Data.PaymentType);
            // ValidateCardCharge(cha.Data.FlwRef);
        }

        [TestMethod]
        public void CardCharegVerve_Test()
        {

        }

        [TestMethod]
        public void CardCharegMasterCard_Test()
        {

        }

        [TestMethod]
        public void CardCharegInsuffient_Test()
        {

        }

        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey, false);
            var cardValidation = new RaveCardChargeValidation(raveConfig);
            var val = cardValidation.ValidateCharge(new CardValidateChargeParams(TestConsts.recurringPbKey, txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            Trace.WriteLine($"Message: {val.Data.TX.CardChargeToken.EmbedToken}");
            Assert.AreEqual("success", val.Status);
            Assert.IsFalse(string.IsNullOrEmpty(val.Data.TX.CardChargeToken.EmbedToken));
            Assert.IsFalse(string.IsNullOrEmpty(val.Data.TX.CardChargeToken.UserToken));

        }
    }
}
