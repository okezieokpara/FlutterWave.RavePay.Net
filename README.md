FlutterWave.RavePay.Net
=======================

A .NET library for Flutterwave Ravepay payment gateway. This library provides a
wrapper to the [Flutterwave RavePay API
​](https://flutterwavedevelopers.readme.io/doc)

Get the package from
[Nuget](https://www.nuget.org/packages/Flutterwave.Ravepay.Net/).

[![Build status](https://ci.appveyor.com/api/projects/status/yucwggjvtk3s8p9c/branch/master?svg=true)](https://ci.appveyor.com/project/okezieokpara/flutterwave-ravepay-net/branch/master)

[![codecov](https://codecov.io/gh/okezieokpara/FlutterWave.RavePay.Net/branch/master/graph/badge.svg)](https://codecov.io/gh/okezieokpara/FlutterWave.RavePay.Net)


~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Install-Package Flutterwave.Ravepay.Net -IncludePrerelease
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

###  Breaking changes

The charge validation feature has been moved their different specialised classes
`RaveAccountChargeValidation`and `RaveCardChargeValidation`

And to they are used like so:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var raveConfig = new RavePayConfig(TestConsts.recurringPbKey, TestConsts.recurringScKey, false);
var cardValidation = new RaveCardChargeValidation(raveConfig);
var val = cardValidation.ValidateCharge(new CardValidateChargeParams(TestConsts.recurringPbKey, txRef, "12345")).Result;
// You can query their results now
Trace.WriteLine($"Status: {val.Status}"); // Should be "success"
Trace.WriteLine($"Message: {val.Message}");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Also every card charge validation request now returns a token. This token can be
used to charge the card subsequently without using the full card details.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Trace.WriteLine(val.Data.TX.CardChargeToken.EmbedToken));
Trace.WriteLine(val.Data.TX.CardChargeToken.UserToken));
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The following services can be carried out with this library:

1.  [Card Charge](#card-charge)

2.  [Account Charge](#account-charge)

3.  [Banks](#banks)

4.  [Fees](#feessee-doc)

5.  [Currency](#currency)

6.  [Transaction Verification](#transaction-verification-see-doc)

7.  [Preauthorized Transaction](#preauthorized-transaction)

8.  Tokenized charge

Card Charge
-----------

To successfully charge a user credit card, first make sure you have the
`PBFPubKey`that you got from the checkout button on your RavePay dashboard. Then
you use the `RaveCardCharge`class like so:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var raveConfig = new RavePayConfig(<your-PBFPubKey>, false);
// The second(boolean) paramater toggles between live and test mode. The default value is false

var cardCharge = new RaveCardCharge(raveConfig);
   var cardParams = new CardChargeParams(recurringPbKey, "Okezie", "Okpara", "rave-test-card@mailinator.com",
                4556)
            {
                CardNo = "5438898014560229",
                Cvv = "789",
                Expirymonth = "09",
                Expiryyear = "19",
                TxRef = tranxRef
            };

// Alternatively you can create an instance of a card object.
 var debitCard = new Card("5438898014560229", "09", "19", "780");
//And use it like so:

  var cardParams = new CardChargeParams(recurringPbKey, "Okezie", "Okpara", "test-card@mailinator.com",
                4556, debitCard)
            {
                TxRef = tranxRef
            };

// And to make a charge request.
var chargeResponse = await cardCharge.Charge(cardParams);
// Then you can query the charge response. Especially to find the 'Suggested Auth' Property:
 if (chargeResponse .Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";

                // Since the suggested auth was 'pin' we make a second request. Sending the pin and otp.
                chargeResponse = cardCharge.Charge(cardParams).Result;
            }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

After each transaction it is a nice idea to validate the status of the
transaction. For this purpose we will validate our last transaction. To validate
a transaction, you need the `txRef` value and `otp`of that transaction. Here is
an example:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var raveConfig = new RavePayConfig(recurringPbKey, false);
var cardCharge = new RaveCardCharge(raveConfig);
var verifyResponse = await cardCharge.ValidateCharge(new CardValidateChargeParams(recurringPbKey, txRef, "12345"));
// You can now query the response message and status of the transaction
Trace.WriteLine($"Status: {verifyResponse.Status}");
Trace.WriteLine($"Message: {verifyResponse.Message}");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Account Charge
--------------

To successfully charge an account, first you need the account details.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Setup the RavePay Config
var raveConfig = new RavePayConfig(publicKey, false);
            var accountCharge = new RaveAccountCharge(raveConfig);

var accountParams = new AccountChargeParams(publicKey, "Anonymous", "customer", "user@example.com", 0690000031, 509,
 acessBank.BankCode, <sample-txRef>);

 var chargeResponse = await accountCharge.Charge(accountParams);
// Now check the response recieved from the API. Especially the validation status
 if (chargeResponse.Data.Status == "success-pending-validation")
            {
// This usually means the user needs to validate the transaction with an OTP
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Requests to the account charge endpoint usually instructs the user on the next
steps to take to complete the transaction. You can find the instructions by
check the `chargeResponse.Data.ValidateInstructions` property and displaying it
to the user. The `AccountValidateInstructions`object holds the instructions you
must display to the user. Here is an example response you will typically get:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
//"Please validate with the OTP sent to your mobile or email"
Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
// This is usually : ["OTP"]
Trace.WriteLine(chargeResponse.Data.ValidateInstruction); 
//"Please dial *901*4*1# to get your OTP. Enter the OTP gotten in the field below"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

You can also validate an an account charge. You need the `flwRef` value that you
recieved from the transaction you want to validate, you also need an OTP. Here
is a sample:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   var raveConfig = new RavePayConfig(publicKey, secretKey, false);
   var cardCharge = new RaveAccountCharge(raveConfig);
   var val = await cardCharge.ValidateCharge(new AccountValidateChargeParams(publicKey, flwRef, sampleOtp));
// You can now check the response status
    Trace.WriteLine($"Status: {val.Status}");
    Trace.WriteLine($"Message: {val.Message}");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Banks
-----

With the Flutterwave RavePay API, you can query the list of supported banks by
using the `BankService`class:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var banks = await BankService.GetBankList();
foreach (var bank in banks)
       {
           Trace.WriteLine(bank.ToString());
            //Returns
            //Bank name: ACCESS BANK NIGERIA     Bank Code: 044  InternetBanking: False
            //Bank name: ECOBANK NIGERIA PLC     Bank Code: 050  InternetBanking: False
            //Bank name: STERLING BANK PLC   Bank Code: 232  InternetBanking: False
            // Bank name: ZENITH BANK PLC    Bank Code: 057  InternetBanking: False
            // Bank name: FIRST CITY MONUMENT BANK PLC  Bank Code: 214  InternetBanking: False
            // Bank name: SKYE BANK PLC      Bank Code: 076  InternetBanking: False
            // Bank name: FSDH Merchant Bank Limited     Bank Code: 601  InternetBanking: False
       }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Fees([See doc](https://flutterwavedevelopers.readme.io/v1.0/reference#get-fees))
--------------------------------------------------------------------------------

The RavePay API allows you to get the fees associated with each payments. To get
the fees, you use the `RaveFeeService`static class:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var fees = await RaveFeeService.GetFees(new GetFeesParams(publicKey, 5938, CurrencyType.Naira));
Trace.WriteLine(fees.Data.ChargeAmount); // The charge amount
Trace.WriteLine(fees.Status) // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Currency
--------

The Flutterwave currently supports multiple currencies including: Dollar, Naira,
Euro, Pounds, Cedi, KenyanShilling.

This API has a `Currency`class which represents a currency object and has two
properties: `Name`i.e the name of the currency e.g Dollar and `code`i.e the
three-letter currency code e.g NGN.

You can either instantiate the directly or use a value from the
`CurrencyType`enum like so:

`var naira = new Currency("Naira", "NGN"); // Instatiates a currency object to
naira`

`var pounds = CurrencyType.Pounds // sets the currency using the CurrencyType
enum`

 

### Exchange rates ([See doc](https://flutterwavedevelopers.readme.io/v1.0/reference#ratesforexinput))

With *RavePay API* you can check the exchange rate between two currencies. This
library provides an easy way to query exchange rates via the
`RaveCurrencyService`class. To use this, you will provide the source currency,
the destination currency and the amount you want to exchange. For example:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var payConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);;
 var currencyService = new RaveCurrencyService(payConfig);
 var res = currencyService.GetExchangeRate(CurrencyType.Dollar, CurrencyType.Naira, 1000).Result;

  // And you can query the result

var data = res.Data // Contains the data returned from the API
Trace.WriteLine(res.Status); // Should be "success"
Trace.WriteLine(res.Message); // "Rate Fetched"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

 

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var naira = new Currency("Naira", "NGN");
 var pounds = new Currency("Pounds Sterling", CurrencyType.Pounds);
 var payConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);
 var currencyService = new RaveCurrencyService(payConfig);
 var res = currencyService.GetExchangeRate(pounds, naira, 2500).Result;

  // And you can query the result

var data = res.Data // Contains the data returned from the API
Trace.WriteLine(res.Status); // Should be "success"
Trace.WriteLine(res.Message); // "Rate Fetched"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

 

 

Transaction Verification ([See doc](https://flutterwavedevelopers.readme.io/v1.0/reference#transaction-status-check))
---------------------------------------------------------------------------------------------------------------------

After each payment transaction you can very that the transaction was successful.
Some things that should be verified are:

1.  Verify the transaction reference.

2.  Verify the status of the transaction to be a success.

3.  Verify that a charge response `chargeResponse`found in
    `response.data.flwMeta` has the value 00 or 0

4.  Verify that the currency is the expected currency to accept payments in.

5.  Most importantly verify the amount paid to be equal to or at least greater
    than the amount of the value to be given

To verify a transaction, you will need the `flwRef`value generated by the
gateway and received from each payment transaction.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    var config = new RavePayConfig(publicKey, secretKey);
            var trans = new RaveTransaction(config);
    var response await = trans.TransactionVerification(new VerifyTransactoinParams(secretKey, dummyTxRef));
    Trace.WriteLine(response.Status); // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

### Xrequery Transaction verification

You require the `txref` value to do an Xrequery transaction verification.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var config = new RavePayConfig(publicKey, secretKey);
 var trans = new RaveTransaction(config);
var response = await trans.XqueryTransactionVeriication(new VerifyTransactoinParams(secretKey, dummyTxRef));
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The result of this query is an`IEnumerable<TransactionResponseData>`which
contains a list transaction details.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 foreach (var res in response.Data)
     {
        Trace.WriteLine($"{res.Status} \t {res.TransactionType}");
     }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Preauthorized Transaction
-------------------------

Preauthorized transactions allow merchants to preauthorize a card with a
specific amount. This amount is reserved and the merchant can later `capture`,
`void`or`refund` the amount. We use the `RavePreAuthCard`class to make
preauthorize payments

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var raveConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);
 var preuthCard = new RavePreAuthCard(raveConfig);

 var card = new Card(<card-number>, <card-expiry-month>, <card-expiry-month>,
                <card-cvv>);
  var preauthResponse = await
                preuthCard.Preauthorize(new PreauthorizeParams(raveConfig.PbfPubKey, "FirstName", "LastName",
                    "user-email@email.com", 10000, card){TxRef = txRef });
// Examine the response
Trace.WriteLine(preauthResponse.Status); // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

### Preauthorize Capture

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var raveConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);
 var preuthCard = new RavePreAuthCard(raveConfig);
 var captureResponse = await preuthCard.Capture(<FwRef-of-successful-preauth-transaction>);
 Trace.WriteLine(captureResponse.Status); // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

### Preauthorize Refund

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var raveConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);
 var preuthCard = new RavePreAuthCard(raveConfig);
 var captureResponse = await preuthCard.Refund(successfulFwRef);
//Now read the response
 Trace.WriteLine(captureResponse.Status); // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

### Preauthorize Void

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 var raveConfig = new RavePayConfig(<your-public-key>, <your-secret-key>, false);
 var preuthCard = new RavePreAuthCard(raveConfig);
 var captureResponse = await preuthCard.Void(unCapturedFwRef);
 // Read the response
 Trace.WriteLine(captureResponse.Status) // Should be "success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Checksum
--------

A security checksum is used to validate request parameters sent to the server.
To generate a checksum from request parameters use the `CheckSum` static class.
This requires your Public and secret key

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   var checkSumValue = CheckSum.CreateCheckSum(new CardChargeParams(<your-public-key>, "Firstname",
                "Lastname", "user-email@email.com",
                4556.000m)
            {
                CardNo = "5438898014560229",
                Cvv = "789",
                Expirymonth = "09",
                Expiryyear = "19",
                TxRef = <txref-value>
            }, <your-secret-key>);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Tokenized charge
----------------

With Tokenized charge you can charge a card without re-entering the card details
if you have charged the card before. When the validate a card charge can examine
the response for its `CardChargeToken `property which is of type
`RaveChargeToken `this contains two properties `EmbedToken `and `UserToken`. You
should save this token and use it for subsequent charges to that card for that
particular use. One important caveat is that the customer email should be same
for subsequent charges to that card.

Here is an example:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var raveConfig = new RavePayConfig(<your-public-key>, <your-secret-key>);
var tokenCharge = new RaveTokenCharge(raveConfig);

var tokenChargeParams =
                new RaveTokenChargeParams(<your-secret-key>, "Okezie", "Okpara", "customer@email.com", <unique-txRef>, 500)
                {
                    Token = embedToken, // This corressponds to the EmbedToken you got from an earlier charge
                    Narration = "Pay him",
                    Ip = getCurrentIpAddress()
                };

var response = tokenCharge.Charge(tokenChargeParams).Result;


Trace.WriteLine(response.Status); // should be "success"
Trace.WriteLine(response.Message); // should be "Charge success"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Every successful token charge request also return a new token that can be used
for subsequent token charge. You can examine the `CardChargeToken `property of
the Token charge response:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Trace.WriteLine(response.Data.CardChargeToken.EmbedToken);
Trace.WriteLine(response.Data.CardChargeToken.UserToken);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
