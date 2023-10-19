using MarketDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketDatabase.Data
{
    public class MarketContextData : DbContext
    {
        public MarketContextData(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerModel> Customer { get; set; }

        public DbSet<StoreModel> Store { get; set; }

        public DbSet<OwnerModel> Owner { get; set; }
    }
}
