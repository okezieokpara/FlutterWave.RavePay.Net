using System;

using Flutterwave.Ravepay.Net.Banks;

namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Represents a customer bank account
    /// </summary>
   public class BankAccount
    {
        public BankAccount(string accountName, string accountNumber, string bankName, string bankCode)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            BankName = bankName;
            BankCode = bankCode;
        }
        public BankAccount(string accountName, string accountNumber, Bank bank)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            BankName = bank.BankName;
            BankCode = bank.BankCode;
        }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
    }
}
