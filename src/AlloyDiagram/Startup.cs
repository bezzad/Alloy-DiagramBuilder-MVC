using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlloyDiagram.Startup))]
namespace AlloyDiagram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
