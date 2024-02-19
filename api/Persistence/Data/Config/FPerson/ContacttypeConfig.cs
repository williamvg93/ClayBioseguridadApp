using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.FPerson;

public class ContacttypeConfig : IEntityTypeConfiguration<Contacttype>
{
    public void Configure(EntityTypeBuilder<Contacttype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contacttype");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");
    }
}