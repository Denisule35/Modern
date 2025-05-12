using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Modern.Model
{
    internal class Bazadateconnect:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source = DataFile.db");


        }

        public DbSet<User> Users { get; set; }

        public DbSet<Oameni> Oameni { get; set; }
    }
}
