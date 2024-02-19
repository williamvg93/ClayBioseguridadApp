using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("department");

        builder.HasIndex(e => e.FkIdCountry, "fk_idCountry");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdCountry).HasColumnName("fkIdCountry");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasOne(d => d.FkIdCountryNavigation).WithMany(p => p.Departments)
            .HasForeignKey(d => d.FkIdCountry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idCountry");
    }
}