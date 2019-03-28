using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flutterwave.Ravepay.Net.Banks
{
    public static class BankService
    {
        private static readonly RavePayApiRequest RavePayRequest = new RavePayApiRequest();

        public static async Task<IEnumerable<Bank>> GetBankDebitDirectList()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Enpoints.GetDirectBankDebitList);
            return await RavePayRequest.Request<IEnumerable<Bank>>(requestMessage);
        }

        /// <summary>
        /// Gets the bank transfer list.
        /// </summary>
        /// <returns>The bank transfer list.</returns>
        /// <param name="country">The Country To Get Bank List From Within Africa ex NG,GH,KE,UG,TZ.</param>
        public static async Task<BankTransferListResponse> GetBankTransferList(string country,RavePayConfig config)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Enpoints.GetBankTransferList}{country}?public_key={config.PbfPubKey}");
            return await RavePayRequest.Request<BankTransferListResponse>(requestMessage);
        }
    }
}
