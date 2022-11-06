using BLL;
using ConsoleUI;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

public static class Program
{
    public static void Main(string[] args)
    {
        var services = RegisterServices();

        services.AddSingleton<Commander>();

        var provider = services.BuildServiceProvider();

        DataGenerator.Initialize(provider);

        var startup = provider.GetService<Commander>();
        startup.Greetings();
        startup.Listener();
    }
    private static IServiceCollection RegisterServices()
    {
        var services = new ServiceCollection();

        //register db
        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<EventsDBContext>(o => o.UseInMemoryDatabase("EventsDB"));

        //register services
        services.AddSingleton<IEventService, EventService>();

        return services;
    }
}