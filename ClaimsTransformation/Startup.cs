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
        }
    }
}
