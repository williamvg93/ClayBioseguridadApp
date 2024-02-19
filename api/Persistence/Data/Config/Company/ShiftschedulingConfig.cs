using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Company;

public class ShiftschedulingConfig : IEntityTypeConfiguration<Shiftscheduling>
{
    public void Configure(EntityTypeBuilder<Shiftscheduling> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("shiftscheduling");

        builder.HasIndex(e => e.FkIdContract, "fk_idContract");

        builder.HasIndex(e => e.FkIdPerson, "fk_idEmploShiftSche");

        builder.HasIndex(e => e.FkIdWorkShifts, "fk_idWorkShifts");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdContract).HasColumnName("fkIdContract");
        builder.Property(e => e.FkIdPerson).HasColumnName("fkIdPerson");
        builder.Property(e => e.FkIdWorkShifts).HasColumnName("fkIdWorkShifts");

        builder.HasOne(d => d.FkIdContractNavigation).WithMany(p => p.Shiftschedulings)
            .HasForeignKey(d => d.FkIdContract)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idContract");

        builder.HasOne(d => d.FkIdPersonNavigation).WithMany(p => p.Shiftschedulings)
            .HasForeignKey(d => d.FkIdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idEmploShiftSche");

        builder.HasOne(d => d.FkIdWorkShiftsNavigation).WithMany(p => p.Shiftschedulings)
            .HasForeignKey(d => d.FkIdWorkShifts)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idWorkShifts");
    }
}