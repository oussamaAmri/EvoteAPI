using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvoteDall.Entities;

public partial class EvoteDbContext : DbContext
{
    public EvoteDbContext()
    {
    }

    public EvoteDbContext(DbContextOptions<EvoteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryEntities> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntities>(entity =>
        {
            entity.HasKey(e => e.Idc).HasName("PK__Categori__C4971C2BE3CA6C6F");

            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.DescC)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NomC)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
