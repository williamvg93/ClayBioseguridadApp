using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Company;

public class ContractConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contract");

        builder.HasIndex(e => e.FkIdClient, "fk_idClientContract");

        builder.HasIndex(e => e.FkIdContractStatus, "fk_idContractStatus");

        builder.HasIndex(e => e.FkIdEmployee, "fk_idEmployeeContract");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.ContractEndDate)
            .HasColumnType("datetime")
            .HasColumnName("contractEndDate");
        builder.Property(e => e.ContractStartDate)
            .HasColumnType("datetime")
            .HasColumnName("contractStartDate");
        builder.Property(e => e.FkIdClient).HasColumnName("fkIdClient");
        builder.Property(e => e.FkIdContractStatus).HasColumnName("fkIdContractStatus");
        builder.Property(e => e.FkIdEmployee).HasColumnName("fkIdEmployee");

        builder.HasOne(d => d.FkIdClientNavigation).WithMany(p => p.ContractFkIdClientNavigations)
            .HasForeignKey(d => d.FkIdClient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idClientContract");

        builder.HasOne(d => d.FkIdContractStatusNavigation).WithMany(p => p.Contracts)
            .HasForeignKey(d => d.FkIdContractStatus)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idContractStatus");

        builder.HasOne(d => d.FkIdEmployeeNavigation).WithMany(p => p.ContractFkIdEmployeeNavigations)
            .HasForeignKey(d => d.FkIdEmployee)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idEmployeeContract");
    }
}