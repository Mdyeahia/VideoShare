using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoShare.Startup))]
namespace VideoShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
