﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    public class CardChargeParams : ChargeParamsBase
    {
        public CardChargeParams(string pbfPubKey, string firstName, string lastName, string email, decimal amount) : base(pbfPubKey, firstName, lastName, email)
        {
            Amount = amount;
        }

        public CardChargeParams(string pbfPubKey, string firstName, string lastName, string email, decimal amount, Card card) : base(pbfPubKey, firstName, lastName, email)
        {
            Amount = amount;
            CardNo = card.CardNo;
            Cvv = card.Cvv;
            Expirymonth = card.Expirymonth;
            Expiryyear = card.Expiryyear;
            Pin = card.Pin;
            BillingCity = card.BillingCity;
            BillingAddress = card.BillingAddress;
            BillingCountry = card.BillingCountry;
            BillingState = card.BillingState;
            BillingZip = card.BillingZip;
        }
        /// <summary>
        /// This is the number on the cardholders card. E.g. 5399 6701 2349 0229.
        /// </summary>
        [JsonProperty("cardno")]
        public string CardNo { get; set; }
        /// <summary>
        /// This is the 3-digit number at the back of the card.
        /// </summary>
        [JsonProperty("cvv")]
        public string Cvv { get; set; }
        /// <summary>
        /// This is the month of card expiration as written on a cardholder’s card. Format is ‘MM’.
        /// </summary>
        [JsonProperty("expirymonth")]
        public string Expirymonth { get; set; }
        /// <summary>
        /// This is the year of card expiration on as written on a cardholder’s card. Format is ‘YY’.
        /// </summary>
        [JsonProperty("expiryyear")]
        public string Expiryyear { get; set; }

        /// <summary>
        /// This is the pin issued to the customer for his card.
        /// (Used only for transactions that require PIN)
        /// </summary>
        [JsonProperty("pin")]
        public string Pin { get; set; }

        /// <summary>
        /// this is an identifier to show that the suggested authentication model is being used.
        /// (Default value: PIN)
        /// </summary>
        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }


        /// <summary>
        /// 		
        /// IP - Internet Protocol. This represents the current IP address of the customer carrying out the transaction.
        /// </summary>
        [JsonProperty("IP")]
        public string Ip { get; set; }

        /// <summary>
        /// This is a url you provide, we redirect to it after the customer completes payment and append the response to it as query parameters
        /// (It is used when a visa card is charged )
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// This identifies that you are making a preauthorised payment request call to the charge endpoint by passing the value preauth. It should be built with your payment request only when carrying out a preauthorised transaction.
        /// </summary>
        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }

        /// <summary>
        /// This is the zip code or postal card registered with the card, customers can easily find this on their bank statement.
        /// </summary>
        [JsonProperty("billingzip")]
        public string BillingZip { get; set; }

        /// <summary>
        /// This is the city registered with the card, it makes up part of the address the customer used for their card. Customers can easily find this on their bank statement.
        /// </summary>
        [JsonProperty("billingcity")]
        public string BillingCity { get; set; }

        /// <summary>
        /// This is the house/building address registered with the card. Customers can easily find this on their bank statement.
        /// </summary>
        [JsonProperty("billingaddress")]
        public string BillingAddress { get; set; }

        /// <summary>
        /// This is the state registered with the card. Customers can easily find this on their bank statement.
        /// </summary>
        [JsonProperty("billingstate")]
        public string BillingState { get; set; }
        /// <summary>
        /// billingcountry
        /// </summary>
        [JsonProperty("billingcountry")]
        public string BillingCountry { get; set; }

    }
}
