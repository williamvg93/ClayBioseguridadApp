using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class AddresstypeConfig : IEntityTypeConfiguration<Addresstype>
{
    public void Configure(EntityTypeBuilder<Addresstype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("addresstype");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");
    }
}