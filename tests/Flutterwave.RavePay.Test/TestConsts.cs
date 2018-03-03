using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.RavePay.Test
{
    /// <summary>
    /// I am currently migrating everyone to use this class
    /// </summary>
    public class TestConsts
    {
        public static string publicKey = ConfigurationSettings.AppSettings.Get("publicKey");
        public static string secretKey = ConfigurationSettings.AppSettings.Get("secretKey");

        public static string recurringPbKey = ConfigurationSettings.AppSettings.Get("recurringPbKey");
        public static string recurringScKey = ConfigurationSettings.AppSettings.Get("recurringScKey");
        public static string tranxRef = "45495";

        public static  string testCardNo = ConfigurationSettings.AppSettings.Get("testCardNo");
        public static  string testCVV = ConfigurationSettings.AppSettings.Get("testCVV");
        public static  string testExpiryMonth = ConfigurationSettings.AppSettings.Get("testExpiryMonth");
        public static  string testExpiryYear = ConfigurationSettings.AppSettings.Get("testExpiryYear");

        public static  string testPin = ConfigurationSettings.AppSettings.Get("testPin");
        public static  string testOtp = ConfigurationSettings.AppSettings.Get("testOtp");




        public static string preauthCardNo = ConfigurationSettings.AppSettings.Get("preauthCardNo");
        public static string preauthCVV = ConfigurationSettings.AppSettings.Get("preauthCVV");
        public static string preAuthExpiryMonth = ConfigurationSettings.AppSettings.Get("preAuthExpiryMonth");
        public static string preAuthExpiryYear = ConfigurationSettings.AppSettings.Get("preAuthExpiryYear");

        public static string preauthPin = ConfigurationSettings.AppSettings.Get("preauthPin");
        public static string preAuthOtp = ConfigurationSettings.AppSettings.Get("preAuthOtp");

        public static  string preauthPbkey = ConfigurationSettings.AppSettings.Get("preauthPbkey");
        public static  string preauthSecretKey = ConfigurationSettings.AppSettings.Get("preauthSecretKey");


    }
}
