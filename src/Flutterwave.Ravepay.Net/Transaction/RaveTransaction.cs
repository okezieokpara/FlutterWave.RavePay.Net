using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net
{
    public class RaveTransaction
    {
        public RaveTransaction(RavePayConfig config)
        {
            Config = config;
            ApiRequest = new RavePayApiRequest<RaveApiResponse<TransactionResponseData>, TransactionResponseData>(config);
        }

        public RavePayConfig Config { get; }
        private IRavePayApiRequest<RaveApiResponse<TransactionResponseData>, TransactionResponseData> ApiRequest { get; }

        /// <summary>
        /// Verifies a charge transaction by calling th verify endpoint with the details of the transation e.g txRef and or the flwRef
        /// </summary>
        /// <param name="verifyParams">An object containing the transaction details  e.g txRef and or the flwRef</param>
        /// <returns></returns>
        public async Task<RaveApiResponse<TransactionResponseData>> VerifyTransaction(VerifyTransactoinParams verifyParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(verifyParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.Verify) { Content = requestBody };
            var result = await ApiRequest.Request(requestMessage);
            return result;
        }

        public async Task<RaveApiResponse<IEnumerable<TransactionResponseData>>> XqueryTransactionVeriication(VerifyTransactoinParams verifyParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(verifyParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.Xquery) { Content = requestBody };

            var privateRequest = new RavePayApiRequest<RaveApiResponse<IEnumerable<TransactionResponseData>>, IEnumerable<TransactionResponseData>>(Config);

            var result = await privateRequest.Request(requestMessage);
            return result;
        }


    }
}
