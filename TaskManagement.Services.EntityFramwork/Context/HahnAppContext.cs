using Hahn.ticket.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Services.EntityFramwork.Context
{
    public class HahnAppContext: DbContext
    {
        private readonly DbContextOptions<HahnAppContext> _options;

        public HahnAppContext(DbContextOptions<HahnAppContext> options)
            : base(options)
        {
            _options = options;
        }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
