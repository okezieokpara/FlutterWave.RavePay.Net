namespace Flutterwave.Ravepay.Net.Currencies
{
    public enum CurrencyType { Dollar, Naira, Euro, Pounds, Cedi };

    public class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    internal static class CurrencyUtil
    {
        internal static string GetCurrencyString(CurrencyType currency)
        {
            switch (currency)
            {
                case CurrencyType.Dollar:
                    return "USD";
                case CurrencyType.Euro:
                    return "EUR";
                case CurrencyType.Pounds:
                    return "GBP";
                case CurrencyType.Naira:
                    return "NGN";
                case CurrencyType.Cedi:
                    return "CDI";
                default:
                    return "NGN";
            }
        }
    }
}
