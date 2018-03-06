FlutterWave.RavePay.Net
=======================

A .NET library for Flutterwave Ravepay payment gateway. This library provides a
wrapper to the [Flutterwave RavePay API
​](https://flutterwavedevelopers.readme.io/doc)

Get the package from
[Nuget](https://www.nuget.org/packages/Flutterwave.Ravepay.Net/).

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Install-Package Flutterwave.Ravepay.Net -IncludePrerelease
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

<https://ci.appveyor.com/project/okezieokpara/flutterwave-ravepay-net/branch/mast>

The following services can be carried out with this library:

1.  Card Charge

2.  Account Charge

3.  Transaction Validation

 

### Card Charge

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

### Account Charge

To successfully charge an account, first you need the account details.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Setup the RavePay Config
var raveConfig = new RavePayConfig(publicKey, false);
            var accountCharge = new RaveAccountCharge(raveConfig);

    var accountParams = new AccountChargeParams(publicKey, "Anonymous", "customer", "user@example.com", 0690000031, 509, acessBank.BankCode, <sample-txRef>);

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
to the user. The `AccountValidateInstructions `object holds the instructions you
must display to the user. Here is an example response you will typically get:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);//"Please validate with the OTP sent to your mobile or email"
    Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);// This is usually : ["OTP"]
   Trace.WriteLine(chargeResponse.Data.ValidateInstruction); //"Please dial *901*4*1# to get your OTP. Enter the OTP gotten in the field below"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
