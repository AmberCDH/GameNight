using Avondspel.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Avondspel.Infrastructure.Data
{
    public class AvondspelDbContext : DbContext
    {
        public AvondspelDbContext(DbContextOptions<AvondspelDbContext> options) : base(options)
        {

        }
        public DbSet<Bordspel> Bordspellen { get; set; }

        public DbSet<Gebruiker> Gebruiker { get; set; }

        public DbSet<BordspellenAvond> BordspellenAvond { get; set; }
        public DbSet<BordspellenLijst> BordspellenLijst { get; set; }
        public DbSet<Eten> Eten { get; set; }
    }
}
