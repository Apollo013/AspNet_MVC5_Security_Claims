using ClaimsTransformation.ClaimsTransformation;
using ClaimsTransformation.Middleware;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClaimsTransformation.Startup))]
namespace ClaimsTransformation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseClaimsTransformationComponent(new ClaimsTransformationService()); // Poor mans Dependency Injection
        }
    }
}
