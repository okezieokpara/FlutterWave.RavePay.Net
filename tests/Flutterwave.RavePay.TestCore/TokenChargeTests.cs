
using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class TokenChargeTests
    {
        private const string embedToken = "flw-t0-ac54953e73277d649f0ae8cf09e0d7de-m03k";
        private const string sampleTxRef = "kjd393";

        [TestMethod]
        public void TokenChargeTest()
        {
            var raveConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey);
            var tokenCharge = new RaveTokenCharge(raveConfig);
            var tokenChargeParams =
                new RaveTokenChargeParams("Okezie", "Okpara", "okeziestanley@yahoo.com", sampleTxRef, 500m)
                {
                    Token = embedToken,
                    Narration = "Pay him"
                };
            var response = tokenCharge.Charge(tokenChargeParams).Result;

            Assert.IsNotNull(response.Data);
            Assert.AreEqual(response.Status, "success");
            Assert.AreEqual(response.Status, "V-COMP");
        }
    }
}
