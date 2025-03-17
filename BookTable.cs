using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library.Model
{
    internal class BookTable : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(m=>m.BookID);
            builder.Property(m=>m.Author).IsRequired().HasMaxLength(100);
            builder.Property(m=>m.Title).IsRequired().HasMaxLength(100); 
            builder.Property(m=>m.ISBN).IsRequired().HasMaxLength(100);
           //builder.HasOne(b => b.Member)
           //    .WithMany(b => b.Books)
           //    .HasForeignKey(b => b.MemberID)  
           //    .OnDelete(DeleteBehavior.SetNull);  // When member is deleted, book remains
        }
    }
}
