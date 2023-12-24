using Microsoft.EntityFrameworkCore;
using ONLINE_EXAM_FCI.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ONLINE_EXAM_FCI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        // public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            modelBuilder.Entity<User>().Property(u => u.RoleID).HasColumnName("RoleID");

            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    RoleID = 0,
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    Password = EncryptPassword("admin"),
                    PasswordConfirmed = EncryptPassword("admin"),
                    photo = "admin-photo-url",
                },
                new User
                {
                    Id = 2,
                    RoleID = 1, // Assuming role ID 1 is for students
                    UserName = "Doctor",
                    Email = "Doctor@gmail.com",
                    Password = EncryptPassword("doctor"),
                    PasswordConfirmed = EncryptPassword("doctor"),
                    photo = "student-photo-url",
                }
            );
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}