using System;
using Microsoft.Extensions.Configuration;

namespace Flutterwave.RavePay.TestCore
{
    public class TestConsts
    {
        private static readonly IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();


        //Customer info
        public static string customerFirstName = "CustFirstname";
        public static string customerLastName = "CustLastName";

        public static string customerEmail = "fluttertest@mailinator.com";


        public static string publicKey = Config["PaymentButtons:0:publicKey"];//ConfigurationSettings.AppSettings.Get("publicKey");
        public static string secretKey = Environment.GetEnvironmentVariable("secret");


        public static string recurringPbKey = Config["PaymentButtons:1:publicKey"];
        public static string recurringScKey = Environment.GetEnvironmentVariable("recurringScKey");
        public static string tranxRef = "45495";

        public static string preauthPbkey = Config["PaymentButtons:2:publicKey"];
        public static string preauthSecretKey = Environment.GetEnvironmentVariable("preauthSecretKey");

        public static string testCardNo = Config["TestCards:DefaultTesCard:CardNo"];
        public static string testCVV = Config["TestCards:DefaultTesCard:CVV"];
        public static string testExpiryMonth = Config["TestCards:DefaultTesCard:ExpiryMonth"];
        public static string testExpiryYear = Config["TestCards:DefaultTesCard:ExpiryYear"];
        public static string testPin = Config["TestCards:DefaultTesCard:Pin"];
        public static string testOtp = Config["TestCards:DefaultTesCard:OTP"];

        public static string testIntl3DCardNo = Config["TestCards:Mastcard3DSecure:CardNo"];
        public static string testIntl3DCVV = Config["TestCards:Mastcard3DSecure:CVV"];
        public static string testIntl3DExpiryMonth = Config["TestCards:Mastcard3DSecure:ExpiryMonth"];
        public static string testIntl3DExpiryYear = Config["TestCards:Mastcard3DSecure:ExpiryYear"];
        public static string testIntl3DPin = Config["TestCards:Mastcard3DSecure:Pin"];
        public static string testIntl3DOtp = Config["TestCards:Mastcard3DSecure:OTP"];

        public static string testNoauthVisaCardNo = Config["TestCards:NoauthVisaCard:CardNo"];
        public static string testNoauthVisaCardCVV = Config["TestCards:NoauthVisaCard:CVV"];
        public static string testNoauthVisaExpiryMonth = Config["TestCards:NoauthVisaCard:ExpiryMonth"];
        public static string testNoauthVisaExpiryYear = Config["TestCards:NoauthVisaCard:ExpiryYear"];
        public static string testNoauthVisaPin = Config["TestCards:NoauthVisaCard:Pin"];
        public static string testNoauthVisaOtp = Config["TestCards:NoauthVisaCard:OTP"];

        public static string testVisaIntlCardNo = Config["TestCards:VisaIntlCard:CardNo"];
        public static string testVisaIntlCardCVV = Config["TestCards:VisaIntlCard:CVV"];
        public static string testVisaIntlExpiryMonth = Config["TestCards:VisaIntlCard:ExpiryMonth"];
        public static string testVisaIntlExpiryYear = Config["TestCards:VisaIntlCard:ExpiryYear"];
        public static string testVisaIntlPin = Config["TestCards:VisaIntlCard:Pin"];
        public static string testVisaIntlOtp = Config["TestCards:VisaIntlCard:OTP"];


        public static string preauthCardNo = Config["TestCards:PreAuthCard:CardNo"];
        public static string preauthCVV = Config["TestCards:PreAuthCard:CVV"];
        public static string preAuthExpiryMonth = Config["TestCards:PreAuthCard:ExpiryMonth"];
        public static string preAuthExpiryYear = Config["TestCards:PreAuthCard:ExpiryYear"];
        public static string preauthPin = Config["TestCards:PreAuthCard:Pin"];
        public static string preAuthOtp = Config["TestCards:PreAuthCard:OTP"];


        public static string accessAccountNumber = Config["TestAccounts:0:AccountNumber"];
        public static string accessAccountOTP = Config["TestAccounts:0:OTP"];


    }
}
