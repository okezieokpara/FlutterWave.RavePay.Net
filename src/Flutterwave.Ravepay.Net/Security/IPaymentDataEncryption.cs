using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.Security
{
   public interface IPaymentDataEncryption
    {
        /// <summary>
        /// Gets an encryption key from rave secret key.
        /// </summary>
        /// <param name="secretKey">The secret key generated from your rave dashboard</param>
        /// <returns>a string value encrypted</returns>
        string GetEncryptionKey(string secretKey);
        /// <summary>
        ///This is the encryption function that encrypts your payload by passing the stringified format and your encryption Key.
        /// </summary>
        /// <param name="encryptionKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        string EncryptData(string encryptionKey, string data);

        string DecryptData(string encryptedData, string encryptionKey);
    }
}
