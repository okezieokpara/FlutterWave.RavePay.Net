using Flutterwave.Ravepay.Net.Payments;
using Microsoft.Extensions.Configuration;

namespace Flutterwave.RavePay.TestCore.TestData
{
    public class SampleCards
    {
        private static readonly IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

        public static Card DefaultTestCard = new Card(_config["TestCards:DefaultTestCard:CardNo"], _config["TestCards:DefaultTestCard:ExpiryMonth"], _config["TestCards:DefaultTestCard:ExpiryYear"], _config["TestCards:DefaultTestCard:CVV"]);

        public static Card IntlVisaCard = new Card(_config["TestCards:VisaIntlCard:CardNo"], _config["TestCards:VisaIntlCard:ExpiryMonth"], _config["TestCards:VisaIntlCard:ExpiryYear"], _config["TestCards:VisaIntlCard:CVV"]);

        public static Card Visa3dSecure = new Card(_config["TestCards:Visa3dSecure:CardNo"], _config["TestCards:Visa3dSecure:ExpiryMonth"], _config["TestCards:Visa3dSecure:ExpiryYear"], _config["TestCards:Visa3dSecure:CVV"]);

        public static Card LocalVerve = new Card(_config["TestCards:Verve:CardNo"], _config["TestCards:Verve:ExpiryMonth"], _config["TestCards:Verve:ExpiryYear"], _config["TestCards:Verve:CVV"]);

    }
}
