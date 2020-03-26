using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MadPay724.Data.Models;

namespace MadPay724.Data.DatabaseContext
{
    class MadPayDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J74AS06\MSSQLSERVER17; Initial Catalog=MadPay724Db; Integrated Security=True;MultipleActiveResultSets=True;");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
    }
}
