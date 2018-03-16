
using Newtonsoft.Json;
namespace Flutterwave.Ravepay.Net.Payments
{
    public enum RecurringIntervals { Daily, Weekly, Monthly, Quarterly, Bianually, Anually }

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

        public RecurringParams(string seckey, long id)
        {
            Id = id;
            Seckey = seckey;
        }

        public RecurringParams(long id, string seckey, string txId, RecurringIntervals interval)
        {
            Id = id;
            Seckey = seckey;
            TxId = txId;
            ChargeType = GetRecurringInterval(interval);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("seckey")]
        public string Seckey { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("recurring_stop")]
        public string RecurringStop { get; set; }


        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        internal static string GetRecurringInterval(RecurringIntervals recurringIntervals)
        {
            switch (recurringIntervals)
            {
                case RecurringIntervals.Daily:
                    return "recurring-daily";
                case RecurringIntervals.Weekly:
                    return "recurring-weekly";
                case RecurringIntervals.Monthly:
                    return "recurring-monthly";
                case RecurringIntervals.Quarterly:
                    return "recurring-quarterly";
                case RecurringIntervals.Bianually:
                    return "recurring-bianually";
                case RecurringIntervals.Anually:
                    return "recurring-anually";
                default:
                    return "recurring-daily";
            }
        }
    }
}
