using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Authentication;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Name)
        .HasColumnName("name")
        .HasColumnType("varchar")
        .HasMaxLength(50);


        builder.Property(p => p.Password)
       .HasColumnName("password")
       .HasColumnType("varchar")
       .HasMaxLength(50)
       .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("email")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder
       .HasMany(p => p.Rols)
       .WithMany(r => r.Users)
       .UsingEntity<UserRol>(

           j => j
           .HasOne(pt => pt.Rols)
           .WithMany(t => t.UsersRols)
           .HasForeignKey(ut => ut.RolId),

           j => j
           .HasOne(et => et.Users)
           .WithMany(et => et.UsersRols)
           .HasForeignKey(el => el.UserId),

           j =>
           {
               j.ToTable("userRol");
               j.HasKey(t => new { t.UserId, t.RolId });

           });

        builder.HasMany(rf => rf.RefreshTokens)
        .WithOne(us => us.User)
        .HasForeignKey(fk => fk.UserId);
        /*         builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId); */
    }
}