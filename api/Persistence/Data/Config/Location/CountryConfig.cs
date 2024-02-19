using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("country");

        builder.HasIndex(e => e.Name, "name").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");
    }
}