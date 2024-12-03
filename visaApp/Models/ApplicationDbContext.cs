using Microsoft.EntityFrameworkCore;

namespace visaApp.Models
{ 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VizeBasvuru> VizeBasvurular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VizeBasvuru>()
                .ToTable("vize_basvuru");
        }
    }
}
