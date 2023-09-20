using Microsoft.EntityFrameworkCore;

namespace IntroAPI.Models
{
    public class IntroContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public IntroContext(DbContextOptions<IntroContext> options) : base(options) { }

    }
}
