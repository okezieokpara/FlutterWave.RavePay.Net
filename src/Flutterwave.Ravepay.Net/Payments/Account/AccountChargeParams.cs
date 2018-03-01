using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Banks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class AccountChargeParams : ChargeParamsBase
    {


        public AccountChargeParams(string pbfPubKey, string firstName, string lastName, string email, string accountNumber, decimal amount, Bank bank) : base(pbfPubKey, firstName, lastName, email)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Accountbank = bank;
            PaymentType = "account";
        }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }


        /// <summary>
        /// This specifies that the payment method being used is for account payments
        /// </summary>
        [JsonProperty("payment_type")]
        public  string PaymentType { get; set; }

        [JsonProperty("accountbank")]
        public Bank Accountbank { get; set; }

        /// <summary>
        /// This requires that the customer date of birth is collected and passed in this format DDMMYYYY
        /// </summary>
        [JsonProperty("passcode")]
        public string Passcode { get; set; }


    }
}
