using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutterwave.Ravepay.Net.Banks
{
    public class BankTransfer
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }


    public class BankTransferToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }


    public class BankTransferListResponse : RaveApiResponse<List<BankTransfer>>
    {
        public BankTransferToken Token { get; set; }
    }
}
