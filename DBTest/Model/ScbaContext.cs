using Microsoft.EntityFrameworkCore;

namespace DBTest.Model;

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

    public virtual DbSet<Jurisdiction> Jurisdictions { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Scan> Scans { get; set; }

    public virtual DbSet<ScannedTank> ScannedTanks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=EMV1\\SQLEXPRESS;Initial Catalog=SCBA;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Jurisdiction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Jurisdiction1)
                .HasMaxLength(25)
                .HasColumnName("Jurisdiction");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OperatorName).HasMaxLength(25);
        });

        modelBuilder.Entity<Scan>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Condition).HasMaxLength(10);
            entity.Property(e => e.HydrostatDate).HasMaxLength(4);
            entity.Property(e => e.SerialNumber).HasMaxLength(12);

            entity.HasOne(d => d.EventNavigation).WithMany(p => p.Scans)
                .HasForeignKey(d => d.Event)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scans_Events");

            entity.HasOne(d => d.JurisdictionNavigation).WithMany(p => p.Scans)
                .HasForeignKey(d => d.Jurisdiction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scans_Jurisdictions");

            entity.HasOne(d => d.OperatorNavigation).WithMany(p => p.Scans)
                .HasForeignKey(d => d.Operator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scans_Operators");
        });

        modelBuilder.Entity<ScannedTank>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ScannedTanks");

            entity.Property(e => e.Condition).HasMaxLength(10);
            entity.Property(e => e.HydrostatDate).HasMaxLength(4);
            entity.Property(e => e.Jurisdiction).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OperatorName).HasMaxLength(25);
            entity.Property(e => e.SerialNumber).HasMaxLength(12);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
