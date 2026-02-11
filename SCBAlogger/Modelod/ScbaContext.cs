using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SCBAlogger.Model;

public partial class ScbaContext : DbContext
{
    public ScbaContext()
    {
    }

    public ScbaContext(DbContextOptions<ScbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=emv1\\sqlexpress;Database=SCBA;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateEmailed).HasColumnType("datetime");
            entity.Property(e => e.EventDate)
                .HasDefaultValueSql("(getdate())", "DF_Events_EventDate")
                .HasColumnType("datetime");
            entity.Property(e => e.ExcelFileName).HasMaxLength(80);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
