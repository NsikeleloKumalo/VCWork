using Microsoft.EntityFrameworkCore;
using VarsityDatabase.Models;

namespace VarsityDatabase.Data
{
    public class DbContextData : DbContext
    {
        public DbContextData(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CampusModel> Campus { get; set; }
        public DbSet<LecturerModel> Lecturer{ get; set; }
        public DbSet<StudentModel> Students { get; set; }

    }
}
