using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Banks
{
    public class Bank
    {
        public Bank()
        {

        }
        public Bank(string bankName, string bankCode, bool internetBanking)
        {
            BankName = bankName;
            BankCode = bankCode;
            InternetBanking = internetBanking;
        }

        public Bank(string bankName, string bankCode)
        {
            BankName = bankName;
            BankCode = bankCode;
            InternetBanking = false;
        }



        [JsonProperty("bankname")]
        public string BankName { get; set; }
        [JsonProperty("bankcode")]
        public string BankCode { get; set; }
        [JsonProperty("internetbanking")]
        public bool InternetBanking { get; set; }

        public override string ToString()
        {
            return $"Bank name: {BankName} \t Bank Code: {BankCode} \t InternetBanking: {InternetBanking}";
        }
    }
}
