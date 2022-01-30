using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;


namespace shop.Data
{
    public class shopDbContext : DbContext
    {
        public shopDbContext(DbContextOptions<shopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
