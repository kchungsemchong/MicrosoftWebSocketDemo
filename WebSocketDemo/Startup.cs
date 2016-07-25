using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSocketDemo.Startup))]
namespace WebSocketDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
