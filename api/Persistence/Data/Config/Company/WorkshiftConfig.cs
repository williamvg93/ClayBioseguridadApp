using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Company;

public class WorkshiftConfig : IEntityTypeConfiguration<Workshift>
{
    public void Configure(EntityTypeBuilder<Workshift> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("workshifts");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.ShiftEndTime)
            .HasColumnType("datetime")
            .HasColumnName("shiftEndTime");
        builder.Property(e => e.ShiftStartTime)
            .HasColumnType("datetime")
            .HasColumnName("shiftStartTime");
    }
}