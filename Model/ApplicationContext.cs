using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event_User>().HasOne(p => p.Event).WithMany(p => p.EventUsers)
                .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<Event_User>().HasOne(p => p.User).WithMany(p => p.EventUsers)
                .HasForeignKey(p => p.UserId);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Event_User> EventUsers { get; set; }
    }
}
