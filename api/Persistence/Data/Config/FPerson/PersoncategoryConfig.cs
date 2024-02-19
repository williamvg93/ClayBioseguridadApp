using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.FPerson;

public class PersoncategoryConfig : IEntityTypeConfiguration<Personcategory>
{
    public void Configure(EntityTypeBuilder<Personcategory> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("personcategory");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");
    }
}