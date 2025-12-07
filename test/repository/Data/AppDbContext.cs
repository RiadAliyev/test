using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TourActivity> TourActivities { get; set; }
    }
}
