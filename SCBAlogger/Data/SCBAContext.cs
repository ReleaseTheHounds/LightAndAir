using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCBAlogger.Model;
using SCBAlogger.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SCBAlogger.Data;

public partial class SCBAContext : DbContext
{
    public SCBAContext()
    {
    }

    public SCBAContext(DbContextOptions<SCBAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compressor> Compressors { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Jurisdiction> Jurisdictions { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Scan> Scans { get; set; }

    public virtual DbSet<ScannedTank> ScannedTanks { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SCBA;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compressor>(entity =>
        {
            entity.ToTable("Compressor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Compressor1)
                .HasMaxLength(25)
                .HasColumnName("Compressor");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateEmailed).HasColumnType("datetime");
            entity.Property(e => e.EventDate)
                .HasDefaultValueSql("(getdate())", "DF_Events_EventDate")
                .HasColumnType("datetime");
            entity.Property(e => e.ExcelFileName).HasMaxLength(80);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CompressorNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Compressor)
                .HasConstraintName("FK_Events_Compressor");
        });

        modelBuilder.Entity<Jurisdiction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("Name");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .HasComment("Is the operator currently active")
                .HasDefaultValue(true, "DF_Operators_isActive")
                .HasColumnName("isActive");
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

            entity.Property(e => e.Compressor).HasMaxLength(25);
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

    // ------------------------------------------------------------
    //  Helper: Execute Stored Procedure and return DbDataReader
    // ------------------------------------------------------------
    private async Task<DbDataReader> ExecuteStoredProcedureAsync(
        string procedureName,
        params SqlParameter[] parameters)
    {
        await Database.OpenConnectionAsync();

        var cmd = Database.GetDbConnection().CreateCommand();
        cmd.CommandText = procedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        foreach (var p in parameters)
            cmd.Parameters.Add(p);

        return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
    }

    // ------------------------------------------------------------
    //  GetEventScans
    //  Returns: CylinderId, SerialNumber, Pressure, Condition, Timestamp
    // ------------------------------------------------------------
    public async Task<List<EventScanDto>> GetEventScansAsync(int eventId)
    {
        var list = new List<EventScanDto>();

        await using var reader = await ExecuteStoredProcedureAsync(
            "dbo.GetEventScans",
            new SqlParameter("@EventId", eventId)
        );

        while (await reader.ReadAsync())
        {
            list.Add(new EventScanDto
            {
                SerialNumber = reader.GetString(0),
                HydroStatDate = reader.GetString(1),
                Pressure = reader.GetInt32(2),
                Condition = reader.GetString(3),
                Jurisdiction = reader.GetString(4),
                Operator = reader.GetString(5)
              
            });
        }

        return list;
    }

    /// <summary>
    /// Returns a list of disticnt  Jurisdiction Values for an Evnt
    /// </summary>
    /// <param name="eventID"></param>
    /// <returns>Distinct list of jurisdictions</returns>
    public async Task<List<Jurisdiction>> GetDistictJurisdictions(int eventId)
    {
        var list = new List<Jurisdiction>();
        await using var reader = await ExecuteStoredProcedureAsync(
            "dbo.SelectUniqueJurisdicionsFromEvent",
            new SqlParameter("@EventId", eventId));

        //while (await reader.ReadAsync())
        //{
        //    int JurisdictionID = reader.GetInt32(0);
        //    string JurisdictionName = Jurisdictions.Where(j => ID == Jurisdiction).Select(j => j.Name).FirstOrDefault;
           

        //}


        return list;

    }


    // ------------------------------------------------------------
    //  GetUnprocessedEvents
    //  Returns: EventId, EventName, EventDate, Jurisdiction
    // ------------------------------------------------------------
    public async Task<List<UnprocessedEventDto>> GetUnprocessedEventsAsync()
    {
        var list = new List<UnprocessedEventDto>();

        await using var reader = await ExecuteStoredProcedureAsync(
            "dbo.GetUnprocessedEvents"
        );

        while (await reader.ReadAsync())
        {
            list.Add(new UnprocessedEventDto
            {
                EventId = reader.GetInt32(0),
                EventName = reader.GetString(1),
                Compressor = reader.GetString(2),
                EventDate = reader.GetDateTime(3)
            });
        }

        return list;
    }

    // ------------------------------------------------------------
    //  MarkCompressorState
    //  Parameters: @EventId, @State
    //  No result set
    // ------------------------------------------------------------
    public async Task MarkCompressorStateAsync(int eventId, string state)
    {
        await using var _ = await ExecuteStoredProcedureAsync(
            "dbo.MarkCompressorState",
            new SqlParameter("@EventId", eventId),
            new SqlParameter("@State", state)
        );
    }

    // ------------------------------------------------------------
    //  MarkOperatorState
    //  Parameters: @OperatorId, @State
    //  No result set
    // ------------------------------------------------------------
    public async Task MarkOperatorStateAsync(int operatorId, string state)
    {
        await using var _ = await ExecuteStoredProcedureAsync(
            "dbo.MarkOperatorState",
            new SqlParameter("@OperatorId", operatorId),
            new SqlParameter("@State", state)
        );
    }
    // ------------------------------------------------------------
    //  ViewScannedTanks
    //  Returns: CylinderId, SerialNumber, HydroDate, Owner
    // ------------------------------------------------------------
    public async Task<List<CylinderDto>> ViewScannedTanksAsync(int eventId)
    {
        var list = new List<CylinderDto>();

        await using var reader = await ExecuteStoredProcedureAsync(
            "dbo.ViewScannedTanks",
            new SqlParameter("@EventId", eventId)
        );

        while (await reader.ReadAsync())
        {
            list.Add(new CylinderDto
            {
                CylinderId = reader.GetInt32(0),
                SerialNumber = reader.GetString(1),
                HydroDate = reader.GetDateTime(2),
                Owner = reader.GetString(3)
            });
        }

        return list;
    }
}

