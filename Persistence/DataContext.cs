using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Activity> Activities { get; set; }
        public DbSet<Domain.ActivityAttendee> ActivityAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new {aa.AppUserId, aa.ActivityId}));

            builder.Entity<ActivityAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Activities)
                .HasForeignKey(u => u.AppUserId);

   
            builder.Entity<ActivityAttendee>()
                .HasOne(u => u.Activity)
                .WithMany(u => u.Attendees)
                .HasForeignKey(u => u.ActivityId);
        }
    }
}