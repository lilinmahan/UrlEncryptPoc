using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UrlEncryptPoc.Startup))]
namespace UrlEncryptPoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
