
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Sockets;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class TokenChargeTests
    {
        private const string embedToken = "flw-t0-a79b7702151ddd49125d33d0ee2de0b2-m03k";

        [TestMethod]
        public void TokenChargeTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey);
            var tokenCharge = new RaveTokenCharge(raveConfig);

            var tokenChargeParams =
                new RaveTokenChargeParams(TestConsts.secretKey, "Okezie", "Okpara", "nokalara@mailinator.com", Guid.NewGuid().ToString("N"), 500m)
                {
                    Token = embedToken,
                    Narration = "Pay him",
                    Ip = getCurrentIpAddress()
                };
            var response = tokenCharge.Charge(tokenChargeParams).Result;

            if (response.Status == "error")
            {
                Assert.AreEqual(response.Data.Code, "That token has expired");
                Assert.IsTrue(response.Data.IsError);
            }
            else
            {
                Assert.IsNotNull(response.Data);
                Assert.AreEqual(response.Status, "success");
                Assert.AreEqual(response.Message, "Charge success");
            }


        }
        private string getCurrentIpAddress()
        {
            var Ip = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in Ip.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
