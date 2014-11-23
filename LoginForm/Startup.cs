using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginForm.Startup))]
namespace LoginForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
