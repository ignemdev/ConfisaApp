using ConfisaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfisaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Oficial> Oficiales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { 
                Id = "1", 
                Name = "Admin", 
                NormalizedName = "Admin".ToUpper() 
            });
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    Email = "ignaciomp.dev@gmail.com",
                    NormalizedEmail = "ignaciomp.dev@gmail.com".ToUpper(),
                    UserName = "ignaciomp.dev@gmail.com",
                    NormalizedUserName = "ignaciomp.dev@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "confisa@admin1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "1"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
