using LocationsDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsDatabase.Data
{
    public class DbContextData : DbContext
    {
        public DbContextData(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LocationModel> Location { get; set; }
    }
}
