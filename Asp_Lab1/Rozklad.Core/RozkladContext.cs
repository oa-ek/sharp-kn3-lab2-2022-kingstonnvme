using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rozklad.Core
{
    public class RozkladContext : IdentityDbContext<User>
    {
        public RozkladContext(DbContextOptions<RozkladContext> options)
            : base(options)
        {

        }

        public DbSet<BusShedule> BusShedules { get; set; }
        
        public DbSet<BusRoute> BusRoutes { get; set; }

        public DbSet<Carrier> Carriers { get; set; }
    }
}