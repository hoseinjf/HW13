using HW13.Config;
using HW13.Entity;
using HW13.Entity.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin", Role = EnumRole.Admin,CheckRole=true },
                new User { Id = 2, Username = "ali", Password = "123" , Role=EnumRole.Person, CheckRole = true }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title="Csharp 1",Author="jafary",Description="C# level 1"},
                new Book { Id = 2, Title = "Csharp 2", Author = "jafary", Description = "C# level 2" },
                new Book { Id = 3, Title = "ASP.NET", Author = "mansory", Description = "asp.net core" },
                new Book { Id = 4, Title = "SQL", Author = "rezaey", Description = "sql level 1" },
                new Book { Id = 5, Title = "ef core", Author = "mohamady", Description = "ef pro" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
