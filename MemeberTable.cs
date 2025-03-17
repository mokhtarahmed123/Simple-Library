using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library.Model
{
    internal class MemeberTable : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m=>m.MemberID);
            builder.Property(m=>m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m=>m.Email).IsRequired().HasMaxLength(100);


        }
    }
}
