using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Domain.Entities.Company;
using Domain.Entities.FPerson;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Persitence.Data;

public partial class ApiClayBioContext : DbContext
{
    public ApiClayBioContext()
    {
    }

    public ApiClayBioContext(DbContextOptions<ApiClayBioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Addresstype> Addresstypes { get; set; }

    public virtual DbSet<Contacttype> Contacttypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Contractstatus> Contractstatuses { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Personcategory> Personcategories { get; set; }

    public virtual DbSet<Personcontact> Personcontacts { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<Shiftscheduling> Shiftschedulings { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<Workshift> Workshifts { get; set; }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("server=localhost;database=claybiosecurity;user=root;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql")); */

    /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");


            modelBuilder.Entity<Workshift>(entity =>
            {

            });

            OnModelCreatingPartial(modelBuilder);
        } */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    /* partial void OnModelCreatingPartial(ModelBuilder modelBuilder); */
}
