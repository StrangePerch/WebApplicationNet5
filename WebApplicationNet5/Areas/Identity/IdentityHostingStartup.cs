using Microsoft.AspNetCore.Hosting;
using WebApplicationNet5.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace WebApplicationNet5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}