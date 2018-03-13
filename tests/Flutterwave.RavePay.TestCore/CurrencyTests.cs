using Flutterwave.Ravepay.Net;
using Flutterwave.Ravepay.Net.Currencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flutterwave.RavePay.TestCore
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void ExchangeRateTest()
        {
            var payConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var currencyService = new RaveCurrencyService(payConfig);
            var res = currencyService.GetExchangeRate(CurrencyType.Dollar, CurrencyType.Naira, 1000).Result;

            Assert.IsNotNull(res.Data);
            Assert.AreEqual(res.Status, "success");

        }
    }
}
