using Microsoft.EntityFrameworkCore;

namespace EbolaApp.App_Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
            }
        }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        private readonly IConfiguration _configuration;
    }
}
