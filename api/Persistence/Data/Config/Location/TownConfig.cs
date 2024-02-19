using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class TownConfig : IEntityTypeConfiguration<Town>
{
    public void Configure(EntityTypeBuilder<Town> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("town");

        builder.HasIndex(e => e.FkIdDepartment, "fk_idDepartment");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdDepartment).HasColumnName("fkIdDepartment");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasOne(d => d.FkIdDepartmentNavigation).WithMany(p => p.Towns)
            .HasForeignKey(d => d.FkIdDepartment)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idDepartment");
    }
}