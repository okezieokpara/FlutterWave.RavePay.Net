namespace Flutterwave.Ravepay.Net.Currencies
{
    public enum CurrencyType { Dollar, Naira, Euro, Pounds, Cedi };
    public class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
