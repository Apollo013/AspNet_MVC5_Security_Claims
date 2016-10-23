# AspNet_MVC5_Security_Claims

(Under Development) A look at various claims features

---

Developed with Visual Studio 2015 Community

To run, launch the app using F5 and register a new user. Navigate to the Home page and then in Visual Studio, observe the output window in debug console.

---

###Techs
|Tech|
|----|
|C#|
|MVC5|

---

###Claims Transformation

The 'ClaimsTransformation' project is an MVC5 app that demonstrates how to transform the initial collectopn of default claims produced by the system, to include claims that we actually want.

The transformation is carried out using the ['ClaimsTransformationService'](https://github.com/Apollo013/AspNet_MVC5_Security_Claims/blob/master/ClaimsTransformation/ClaimsTransformation/ClaimsTransformationService.cs) class.

This is called by the ['ClaimsTransformationComponent'](https://github.com/Apollo013/AspNet_MVC5_Security_Claims/blob/master/ClaimsTransformation/Middleware/ClaimsTransformationComponent.cs) class which is hooked up to our OWIN middleware via the extension class ['AppBuilderExtensions'](https://github.com/Apollo013/AspNet_MVC5_Security_Claims/blob/master/ClaimsTransformation/Middleware/AppBuilderExtensions.cs).

The ['HomeController'](https://github.com/Apollo013/AspNet_MVC5_Security_Claims/blob/master/ClaimsTransformation/Controllers/HomeController.cs) contains code that will ultimatley print out the transformed collection of claims to the Debug 'Output' window.

---

###Claims Factory

Although not covered in this repository, we have previously covered creating a claims factory [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Claims/ApplicationClaimsFactory.cs) in the ['AspNet_WebApi2_Security_JWTAuthentication'](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication) project. This is then hooked into our Application User Manager [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Managers/ApplicationUserManager.cs)

---

### Custom Claims Attribute using 'AuthorizeAttribute'

Again, not covered in this repository, but we have previously covered creating one [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Attributes/AdminOnlyAttribute.cs). This attribute permits 'AdminOnly' claims and is applied at the 'Action' level, which can be seen [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.Core/Controllers/AccountsController.cs).

---

### Custom Claims Attribute using 'AuthorizationFilterAttribute'

We have previously covered creating one [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Attributes/ClaimsAuthorizationAttribute.cs). This attribute only permits access if the user has the 'FTE' claim (Full Time Employee) with a value of 1. This attribute is applied at the 'Action' level [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.Core/Controllers/OrdersController.cs). This claim was set using the claims factory mentioned above.

---

### Unpacking Claims

[Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.Core/Controllers/ClaimsController.cs) we unpack all the claims for a user within a controller action and return them to a view.

---

###Resources
|Title|Author|Website|
|-----|------|-------|
|[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)||MSDN|
|[Handling claims transformation in an OWIN middleware in .NET MVC](https://dotnetcodr.com/2015/10/19/handling-claims-transformation-in-an-owin-middleware-in-net-mvc-part-4/)|Andras Nemes| dotnetcodr|
