using Argonaut.Core;
using Argonaut.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Argonaut.Persistence
{
    public class ArgonautContext : DbContext, ISaveService
    {
        public DbSet<PointOfInterestEntity> PointOfInterests { get; set; }

        public ArgonautContext(DbContextOptions<ArgonautContext> options) : base(options) { }
    }
}
