using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Flutterwave.Ravepay.Net.Payments
{
   public class RecurringParams
    {
        public RecurringParams(string seckey)
        {
            Seckey = seckey;
        }

        public RecurringParams(string seckey, string teTxId)
        {
            Seckey = seckey;
            TxId = teTxId;
        }

        public RecurringParams(string seckey, int id)
        {
            Id = id;
            Seckey = seckey;
        }

        public RecurringParams(long id, string seckey, string txId)
        {
            Id = id;
            Seckey = seckey;
            TxId = txId;
        }
        
        [JsonProperty("id")]
        public long Id { get ; set; }

        [JsonProperty("seckey")]
        public  string Seckey { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }
    }
}
