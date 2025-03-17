using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Simple_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library
{
    internal class MemberContext:DbContext
    {
        public DbSet<Member> MembersTable { get; set; }
        public DbSet<Book>BooksTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =LAPTOP-EJKLVEC8 ; database = Member; TrustServerCertificate = true; Trusted_Connection = true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemeberTable());
            modelBuilder.ApplyConfiguration(new BookTable());
            base.OnModelCreating(modelBuilder);
        }

    }
}
