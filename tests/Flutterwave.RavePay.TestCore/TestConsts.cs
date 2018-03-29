using Microsoft.Extensions.Configuration;

namespace Flutterwave.RavePay.TestCore
{
    public class TestConsts
    {
        private static readonly IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();


        public static string publicKey = Config["PaymentButtons:0:publicKey"];//ConfigurationSettings.AppSettings.Get("publicKey");
        public static string secretKey = Config["PaymentButtons:0:secret"];

      

        public static string recurringPbKey = Config["PaymentButtons:1:publicKey"];
        public static string recurringScKey = Config["PaymentButtons:1:secret"];
        public static string tranxRef = "45495";

        public static string preauthPbkey = Config["PaymentButtons:2:publicKey"];
        public static string preauthSecretKey = Config["PaymentButtons:2:secret"];

        public static string testCardNo = Config["TestCards:DefaultTesCard:CardNo"];
        public static string testCVV = Config["TestCards:DefaultTesCard:CVV"];
        public static string testExpiryMonth = Config["TestCards:DefaultTesCard:ExpiryMonth"];
        public static string testExpiryYear = Config["TestCards:DefaultTesCard:ExpiryYear"];
        public static string testPin = Config["TestCards:DefaultTesCard:Pin"];
        public static string testOtp = Config["TestCards:DefaultTesCard:OTP"];



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
