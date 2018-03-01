using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Ravepay.Net.Banks
{
   public static class BankService
   {
       private static readonly RavePayApiRequest RavePayRequest = new RavePayApiRequest();

        public static async Task<IEnumerable<Bank>> GetBankList()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Enpoints.GetBankList);
          return  await RavePayRequest.Request<IEnumerable<Bank>>(requestMessage);
        }
    }
}
