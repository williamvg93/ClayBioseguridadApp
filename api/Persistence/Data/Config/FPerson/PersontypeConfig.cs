using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.FPerson;

public class PersontypeConfig : IEntityTypeConfiguration<Persontype>
{
    public void Configure(EntityTypeBuilder<Persontype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("persontype");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");
    }
}