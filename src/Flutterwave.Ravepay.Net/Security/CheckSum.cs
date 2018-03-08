using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Flutterwave.Ravepay.Net.Reflection;

namespace Flutterwave.Ravepay.Net.Security
{
    public static class CheckSum
    {
        public static string CreateCheckSum(object payParams, string secretKey)
        {
            var inputTypeInfo = payParams.GetType().GetTypeInfo();
            var props = inputTypeInfo.GetProperties();

            var propNames = props.Select(prop => prop.Name).ToList();

            propNames.Sort();
            if (propNames.Contains("PbfPubKey"))
            {
                propNames.Remove("PbfPubKey");
                propNames.Insert(0, "PbfPubKey"); // this feels weird to me
            }

            var hashString = "";

            foreach (var propName in propNames)
            {
                hashString = hashString + SanitizeNumbers(ReflectionUtil.GetObjectPropValues(payParams, propName));
            }

            return Hashing.GenerateSHA256String(hashString + secretKey);
        }

        private static string SanitizeNumbers(string inputStr)
        {
            if (decimal.TryParse(inputStr, out var sample))
            {

                var result = string.Format("{0:G29}", decimal.Parse(inputStr));
                return result;
            }

            return inputStr;
        }
    }
}
