using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PluralsightAndBooksManager.WebUI.Startup))]
namespace PluralsightAndBooksManager.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
