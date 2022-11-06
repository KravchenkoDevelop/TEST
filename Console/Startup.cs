using DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using BLL.Abstracts;
using BLL.Services;

namespace ConsoleApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }


        public void RegisterServices(IServiceCollection services)
        {
            //register db
            services.AddDbContext<EventsContext>(o => o.UseInMemoryDatabase("EventsDB"));

            //register services
            services.AddScoped<IEventService, EventService>();

            services.AddLogging();
        }
    }
}
