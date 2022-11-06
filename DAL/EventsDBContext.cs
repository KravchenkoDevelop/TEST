using DM;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EventsDBContext : DbContext
    {
        public EventsDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EventModel> Events { get; set; }
    }
}
