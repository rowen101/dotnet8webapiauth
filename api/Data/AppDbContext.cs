using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using api.Migrations;


namespace api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
      public AppDbContext(DbContextOptions options) : base(options)
      { 

      }
      public DbSet<Stock> Stocks { get; set; }
      public DbSet<Comment> Comments {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
          base.OnModelCreating(builder);

          List<IdentityRole> roles = new List<IdentityRole>
          {
            new IdentityRole
            {
              Name = "Admin",
              NormalizedName = "ADMIN"
            },
             new IdentityRole
            {
              Name = "User",
              NormalizedName = "USER"
            },
          };
         builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}