using CarsApp.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsApp.Data
{
	public class CarsAppContext : IdentityDbContext<ApplicationUser>
    {
		public CarsAppContext(DbContextOptions<CarsAppContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}

