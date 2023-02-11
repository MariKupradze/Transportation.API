namespace Transportation.API.Context
{
    using Microsoft.EntityFrameworkCore;
    using Transportation.API.Models;

    public sealed class TransportContext : DbContext
    {
        public DbSet<Car> Car { get; set; }

        public TransportContext(DbContextOptions<TransportContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
