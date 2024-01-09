using CarsApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarsApp.Data
{
	public class CarsAppContext : DbContext
    {

        public CarsAppContext(DbContextOptions<CarsAppContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}

