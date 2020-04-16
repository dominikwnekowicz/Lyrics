using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lyrics.Startup))]
namespace Lyrics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
