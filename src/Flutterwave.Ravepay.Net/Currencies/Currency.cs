namespace Flutterwave.Ravepay.Net.Currencies
{
    public enum CurrencyType { Dollar, Naira, Euro, Pounds, Cedi, KenyanShilling };

    public class Currency
    {
        /// <summary>
        /// Instatiates a type of currency with the name and code
        /// </summary>
        /// <param name="name">the name of the currency e.g dollar</param>
        /// <param name="code">the code of the currency e.g "USD"</param>
        public Currency(string name, string code)
        {
            Name = name;
            Code = code;
        }
        /// <summary>
        /// Instatiates a type fo currency
        /// </summary>
        /// <param name="name">The name of the currency</param>
        /// <param name="currencyType">A value from the <see cref="CurrencyType"/>enum</param>
        public Currency(string name, CurrencyType currencyType)
        {
            Name = name;
            Code = CurrencyUtil.GetCurrencyString(currencyType);
        }
        /// <summary>
        /// Represents the name of the currency e.g Dollar
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the code of the currency e.g "USD"
        /// </summary>
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
                    return "GHS";
                case CurrencyType.KenyanShilling:
                    return "KES";
                default:
                    return "NGN";
            }
        }
    }
}
