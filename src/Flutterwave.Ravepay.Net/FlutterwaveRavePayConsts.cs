namespace Flutterwave.Ravepay.Net
{
    internal class FlutterwaveRavePayConsts
    {
        public const string SanboxUrl = "http://ravesandboxapi.flutterwave.com"; // Its important for me to make this non-http so I can intercept the response for debuggin purposes.
        public const string LiveUrl = "https://api.ravepay.co";
    }
}
