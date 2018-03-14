using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Currencies
{
    /// <summary>
    /// The Currentcy service
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public class RaveCurrencyService
    {
        public RaveCurrencyService(RavePayConfig config)
        {
            // Check for config.SecretKey;
            if (string.IsNullOrEmpty(config.SecretKey))
            {
                throw new ArgumentException("Config.SecretKey is required");
            }

            Config = config;
            ApiRequest = new RavePayApiRequest<RaveApiResponse<ExchangeRateResponseData>, ExchangeRateResponseData>(config);
        }
        private IRavePayApiRequest<RaveApiResponse<ExchangeRateResponseData>, ExchangeRateResponseData> ApiRequest { get; }
        private RavePayConfig Config { get; }

        /// <summary>
        /// Gets the exchange rate between two currencies
        /// </summary>
        /// <param name="originalCurrency">This is the currency to convert from</param>
        /// <param name="destCurrency">This is the currency to convert to</param>
        /// <param name="amount">This is the amount being converted, it is an optional field</param>
        /// <returns>Response with data of exchange rate</returns>
        public async Task<RaveApiResponse<ExchangeRateResponseData>> GetExchangeRate(CurrencyType originalCurrency, CurrencyType destCurrency, decimal amount)
        {
            var payload = new
            {
                SECKEY = Config.SecretKey,
                origin_currency = CurrencyUtil.GetCurrencyString(originalCurrency),
                destination_currency = CurrencyUtil.GetCurrencyString(destCurrency),
                amount
            };

            var requestBody = new HttpRequestMessage(HttpMethod.Post, Enpoints.ExchangeRates)
            {
                Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
            };
            return await ApiRequest.Request(requestBody);
        }
        /// <summary>
        ///  Gets the exchange rate between two currencies
        /// </summary>
        /// <param name="originalCurrency">his is the currency object to convert from</param>
        /// <param name="destCurrency">This is the currency object to convert to</param>
        /// <param name="amount">This is the amount being converted, it is an optional field</param>
        /// <returns>Response with data of exchange rate</returns>
        public async Task<RaveApiResponse<ExchangeRateResponseData>> GetExchangeRate(Currency originalCurrency, Currency destCurrency, decimal amount)
        {
            var payload = new
            {
                SECKEY = Config.SecretKey,
                origin_currency = originalCurrency.Code,
                destination_currency = destCurrency.Code,
                amount
            };

            var requestBody = new HttpRequestMessage(HttpMethod.Post, Enpoints.ExchangeRates)
            {
                Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
            };
            return await ApiRequest.Request(requestBody);
        }
    }
}
