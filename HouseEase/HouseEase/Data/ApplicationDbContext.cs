using HouseEase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseEase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Fuclty> Fuclties { get; set; }
        public DbSet<Laundry> Laundries { get; set; }
        public DbSet<Leese> Leeses { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UsersLundries> UsersLundries { get; set; }
        public DbSet<UsersMaintenance> UsersMaintenances { get; set; }
        public DbSet<UserUnits> UserUnits { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Governurate> Governurates { get; set; }
    }
}