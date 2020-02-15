using System;
using System.Collections.Generic;
using System.Text;

namespace Flutterwave.Ravepay.Net.RaveResponse
{
    /// <summary>
    /// Represents the basic data object returned from all API requests
    /// </summary>
    public interface IResponseData
    {
        /// <summary>
        /// Response code returned from the API e.g NO TX
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Message describing the response from API e.g 'No transaction found'
        /// </summary>
        string Message { get; set; }
    }
}
