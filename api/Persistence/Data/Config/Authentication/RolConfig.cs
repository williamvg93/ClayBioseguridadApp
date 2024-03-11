using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Authentication;

public class RolConfig : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("rol");

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Name)
        .HasColumnName("Name")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();
    }
}