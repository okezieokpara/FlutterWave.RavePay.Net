﻿using Flutterwave.Ravepay.Net;
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
            Assert.AreEqual(res.Message, "Rate Fetched");

        }
        [TestMethod]
        public void ExchangeRateTestDollarEuro()
        {
            var payConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var currencyService = new RaveCurrencyService(payConfig);
            var res = currencyService.GetExchangeRate(CurrencyType.Dollar, CurrencyType.Euro, 1000).Result;

            Assert.IsNotNull(res.Data);
            Assert.AreEqual(res.Status, "success");
            Assert.AreEqual(res.Message, "Rate Fetched");

        }

        [TestMethod]
        public void ExchangeRateTestPoundsEuro()
        {
            var payConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var currencyService = new RaveCurrencyService(payConfig);
            var res = currencyService.GetExchangeRate(CurrencyType.Pounds, CurrencyType.Euro, 500).Result;

            Assert.IsNotNull(res.Data);
            Assert.AreEqual(res.Status, "success");
            Assert.AreEqual(res.Message, "Rate Fetched");

        }
        [TestMethod]
        public void ExchangeRateTestNairaEuro()
        {
            var naira = new Currency("Naira", "NGN");
            var pounds = new Currency("Pounds Sterling", CurrencyType.Pounds);
            var payConfig = new RavePayConfig(TestConsts.publicKey, TestConsts.secretKey, false);
            var currencyService = new RaveCurrencyService(payConfig);
            var res = currencyService.GetExchangeRate(pounds, naira, 2500).Result;

            Assert.IsNotNull(res.Data);
            Assert.AreEqual(res.Status, "success");
            Assert.AreEqual(res.Message, "Rate Fetched");

        }
    }
}
