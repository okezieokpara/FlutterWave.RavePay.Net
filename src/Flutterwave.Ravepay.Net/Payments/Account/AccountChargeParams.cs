using System;
using System.Collections.Generic;
using System.Text;
using Flutterwave.Ravepay.Net.Banks;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class AccountChargeParams : ChargeParamsBase
    {


        public AccountChargeParams(string pbfPubKey, string firstName, string lastName, string email, string accountNumber, decimal amount, string bank, string txRef) : base(pbfPubKey, firstName, lastName, email)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Accountbank = bank;
            PaymentType = "account";
            TxRef = txRef;
        }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }


        /// <summary>
        /// This specifies that the payment method being used is for account payments
        /// </summary>
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("accountbank")]
        public string Accountbank { get; set; }

        /// <summary>
        /// This is required for Zenith bank account payments, you are required to collect the customer's date of birth and pass it in this format DDMMYYYY.
        /// This requires that the customer date of birth is collected and passed in this format DDMMYYYY
        /// </summary>
        [JsonProperty("passcode")]
        public string Passcode { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }

        /// <summary>
        /// This is the customer's bvn number.
        /// </summary>
        /// <remarks>(Required for UBA account payment option)</remarks>
        [JsonProperty("bvn")]
        public string Bvn { get; set; }
    }
}
