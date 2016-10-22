# AspNet_MVC5_Security_Claims

(Under Development) A look at various claims features

---

Developed with Visual Studio 2015 Community

---

###Techs
|Tech|
|----|
|C#|

---

###Claims Transformation

The 'ClaimsTransformation' project is an MVC5 app that demonstrates how to transform the initial collectopn of default claims produced by the system, to include claims that we actually want.

The transformation is carried out using the 'ClaimsTransformationService' class.

This is called by the 'ClaimsTransformationComponent' class which is hooked up to our OWIN middleware via the extension class 'AppBuilderExtensions'.

The 'HomeController' contains code that will ultimatley print out the transformed collection of claims to the Debug 'Output' window.

---

###Claims Factory
Although not covered in this repository, we have previously covered creating a claims factory [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Claims/ApplicationClaimsFactory.cs) in the ['AspNet_WebApi2_Security_JWTAuthentication'](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication) project. This is then hooked into our Application User Manager [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Managers/ApplicationUserManager.cs)

---

### Custom Claims Attribute using 'AuthorizeAttribute'

Again not covered in this repository, we have previously covered creating one [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.AuthServer/Identity/Attributes/AdminOnlyAttribute.cs). This attribute permits 'AdminOnly' claims and is applied at the 'Action' level, which can be seen [Here](https://github.com/Apollo013/AspNet_WebApi2_Security_JWTAuthentication/blob/master/WebApi2_Owin_OAuthAccessTokensAndClaims.Core/Controllers/AccountsController.cs).

---

###Resources
|Title|Author|Website|
|-----|------|-------|
|[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)||MSDN|
|[Handling claims transformation in an OWIN middleware in .NET MVC](https://dotnetcodr.com/2015/10/19/handling-claims-transformation-in-an-owin-middleware-in-net-mvc-part-4/)|Andras Nemes| dotnetcodr|
