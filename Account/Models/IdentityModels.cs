﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Account.Models
{
    // 您可將更多屬性新增至 ApplicationUser 類別，藉此為使用者新增設定檔資料，如需深入了解，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityUser> ActivityUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>()
                        .HasKey(a => a.Id);

            modelBuilder.Entity<ActivityUser>()
                        .HasKey(au => new { au.ActivityId, au.UserId });

            modelBuilder.Entity<ActivityUser>()
                        .HasRequired(au => au.Activity)
                        .WithMany(a => a.ActivityUsers)
                        .HasForeignKey(au => au.ActivityId);

            modelBuilder.Entity<ActivityUser>()
                        .HasRequired(au => au.User)
                        .WithMany()
                        .HasForeignKey(au => au.UserId);
        }
    }
}