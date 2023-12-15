using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Identity.Models.published_data;
using Identity.Models.Announcement_data;
using Identity.Models.NTAstory_data;
using Identity.Models.Meeting_data;
using System.Reflection.Emit;

namespace Identity.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AdminAnnouncement> AdminAnnouncements { get; set; }
        public DbSet<EmployeeAnnouncement> EmployeeAnnouncements { get; set; }
        public DbSet<HrAnnouncement> HrAnnouncements { get; set; }
        public DbSet<AnnouncementHistory> AnnouncementsHistory { get; set; }


        public DbSet<NTAstory> NTAstories { get; set; }
        public DbSet<AdminNTAstory> AdminNTAstories { get; set; }
        public DbSet<UserNTAstory> UserNTAstories { get; set; }
        public DbSet<HrNTAstory> HrNTAstories { get; set; }

        public DbSet<NTAstoryHistory> NTAstoriesHistory { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);

           

          

        }



        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                 new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }

                );
        }

    }
}
