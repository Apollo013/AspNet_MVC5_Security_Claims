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

###ClaimsTransformation Project

This is an MVC5 app that demonstrates how to transform the initial collectopn of default claims produced by the system, to include claims that we actually want.

The transformation is carried out using the 'ClaimsTransformationService' class.

This is called by the 'ClaimsTransformationComponent' class which is hooked up to OWIN via the extension class 'AppBuilderExtensions'.

The 'HomeController' contains code that will ultimatley print out the transformed collection of claims to the Debug 'Output' window.

---

###Resources
|Title|Author|Website|
|-----|------|-------|
|[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)||MSDN|
|[Handling claims transformation in an OWIN middleware in .NET MVC](https://dotnetcodr.com/2015/10/19/handling-claims-transformation-in-an-owin-middleware-in-net-mvc-part-4/)|Andras Nemes| dotnetcodr|
