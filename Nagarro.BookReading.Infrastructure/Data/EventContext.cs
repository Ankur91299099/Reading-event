using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nagarro.BookReading.Core.Entities;

namespace Nagarro.BookReading.Infrastructure.Data
{
    public class EventContext : IdentityDbContext
    {
        public EventContext(
            DbContextOptions<EventContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "Admin", Name = "Admin" });



            var passHash = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "Admin",
                UserName = "Ankur",
                NormalizedUserName = "ANKUR",
                Email = "myadmin@bookevents.com",
                NormalizedEmail = " MYADMIN@BOOKEVENTS.COM",
                EmailConfirmed = true,
                PasswordHash = passHash.HashPassword(null, "password")
            });
        }
    }
}
