using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STYRKEGamesMovieDatabase.Startup))]
namespace STYRKEGamesMovieDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
