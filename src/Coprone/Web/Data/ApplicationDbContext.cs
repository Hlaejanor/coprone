using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Data.Entities.StackeholderEntities;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public const int DefaultStringMaxLength = 255;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Release> Release { get; set; }
        public DbSet<Stakeholder> Stakeholder { get; set; }
    }
}
