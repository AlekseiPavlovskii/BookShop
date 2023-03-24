using DatabaseProvider.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
