using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL.EF
{
    public class OSNContext
        : DbContext
    {
        public DbSet<OSN> Osns { get; set; }
        public DbSet<Street> Streets { get; set; }

        public OSNContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}