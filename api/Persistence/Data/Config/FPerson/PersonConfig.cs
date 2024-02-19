using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.FPerson;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("person");

        builder.HasIndex(e => e.FkIdPersonCate, "fk_idPersonCate");

        builder.HasIndex(e => e.FkIdPersonType, "fk_idPersonType");

        builder.HasIndex(e => e.FkIdTown, "fk_idTown");

        builder.HasIndex(e => e.Idperson, "idperson").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.CreationDate)
            .HasColumnType("datetime")
            .HasColumnName("creationDate");
        builder.Property(e => e.FkIdPersonCate).HasColumnName("fkIdPersonCate");
        builder.Property(e => e.FkIdPersonType).HasColumnName("fkIdPersonType");
        builder.Property(e => e.FkIdTown).HasColumnName("fkIdTown");
        builder.Property(e => e.Idperson)
            .IsRequired()
            .HasMaxLength(15)
            .HasColumnName("idperson");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasOne(d => d.FkIdPersonCateNavigation).WithMany(p => p.People)
            .HasForeignKey(d => d.FkIdPersonCate)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idPersonCate");

        builder.HasOne(d => d.FkIdPersonTypeNavigation).WithMany(p => p.People)
            .HasForeignKey(d => d.FkIdPersonType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idPersonType");

        builder.HasOne(d => d.FkIdTownNavigation).WithMany(p => p.People)
            .HasForeignKey(d => d.FkIdTown)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idTown");
    }
}