using CLDVTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace CLDVTwo.Data
{
    public class DbContextData : DbContext
    {
        public DbContextData(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CarModel> Car { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
