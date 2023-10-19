using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class CompanyDatabase : DbContext
    {
        public CompanyDatabase(DbContextOptions options) : base(options)
        {

        }

        public DbSet <EmployeeModel> Employee { get; set; }

        public DbSet <CustomerModel> Customer { get; set; } 
        public DbSet  <StoreModel>  Store { get; set; }


    }
}
