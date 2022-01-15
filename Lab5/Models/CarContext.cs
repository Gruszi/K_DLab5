using Microsoft.EntityFrameworkCore;

namespace K_DLab5.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }
        public DbSet<Car> CarItems { get; set; }
    }
}
