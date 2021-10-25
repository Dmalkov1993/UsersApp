using Microsoft.EntityFrameworkCore;
using UsersApp.DAL.Entities;

namespace UsersApp.DAL
{
    public class UsersAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public UsersAppDbContext(DbContextOptions<UsersAppDbContext> options) : base(options)
        {
        }
    }
}
