using CLDVWebOne.Models;
using Microsoft.EntityFrameworkCore;

namespace CLDVWebOne.Data
{
    public class DBContextDatabase : DbContext
    {
        public DBContextDatabase(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CustomerModel> Customer { get; set; }
    }
}
