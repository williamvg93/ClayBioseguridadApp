using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("address");

        builder.HasIndex(e => e.FkIdAddressType, "fk_idAddressType");

        builder.HasIndex(e => e.FkIdPerson, "fk_idEmployee");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Address1)
            .IsRequired()
            .HasMaxLength(60)
            .HasColumnName("address");
        builder.Property(e => e.FkIdAddressType).HasColumnName("fkIdAddressType");
        builder.Property(e => e.FkIdPerson).HasColumnName("fkIdPerson");

        builder.HasOne(d => d.FkIdAddressTypeNavigation).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.FkIdAddressType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idAddressType");

        builder.HasOne(d => d.FkIdPersonNavigation).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.FkIdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idEmployee");
    }
}