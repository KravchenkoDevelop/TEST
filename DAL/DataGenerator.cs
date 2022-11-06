using DM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider provider)
        {
            using (var context = new EventsDBContext(provider.GetRequiredService<DbContextOptions<EventsDBContext>>()))
            {

                context.Events.AddRange(

                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #1",
                        Description = "some description",
                        DateStart = DateTime.Today.AddHours(14),
                        EventLengh = 1,
                        IsDeleted = false,
                    },
                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #1.1",
                        Description = "some description",
                        DateStart = DateTime.Today.AddDays(-1).AddHours(15),
                        EventLengh = 2,
                        IsDeleted=true,
                    },
                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #2",
                        Description = "some description",
                        DateStart = DateTime.Today.AddDays(-2).AddHours(12),
                        EventLengh = 2,
                        IsDeleted = false,
                    },
                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #3",
                        Description = "some description",
                        DateStart = DateTime.Today.AddDays(-3).AddHours(12),
                        EventLengh = 1,
                        IsDeleted = false,
                    },
                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #4",
                        Description = "some description",
                        DateStart = DateTime.Today.AddDays(-1).AddHours(13),
                        EventLengh = 1,
                        IsDeleted = false,
                    },
                    new EventModel
                    {
                        Id = Guid.NewGuid(),
                        Header = "header #5",
                        Description = "some description",
                        DateStart = DateTime.Today.AddDays(-1).AddHours(15),
                        EventLengh = 2,
                        IsDeleted = false,
                    });

                context.SaveChanges();
            }

        }
    }
}
