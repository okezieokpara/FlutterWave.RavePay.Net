using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class AccounResponseData : PayResponseData
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("validateInstruction")]
        public string ValidateInstruction { get; set; }


        [JsonProperty("validateInstructions")]

        public AccountValidateInstructions ValidateInstructions { get; set; }

        public class AccountValidateInstructions
        {
            [JsonProperty("valparams")]
            public string[] Valparams { get; set; }
            [JsonProperty("instruction")]
            public string Instruction { get; set; }
        }
    }
}
