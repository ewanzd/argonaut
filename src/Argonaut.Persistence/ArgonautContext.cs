using Argonaut.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Argonaut.Persistence
{
    public class ArgonautContext : DbContext
    {
        public DbSet<PointOfInterestDal> PointOfInterests { get; set; }

        public ArgonautContext(DbContextOptions<ArgonautContext> options) : base(options)
        {
            
        }
    }
}
