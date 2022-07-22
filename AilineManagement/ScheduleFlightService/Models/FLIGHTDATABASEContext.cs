using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ScheduleFlightService.Models
{
    public partial class FLIGHTDATABASEContext : DbContext
    {
        public FLIGHTDATABASEContext()
        {
        }

        public FLIGHTDATABASEContext(DbContextOptions<FLIGHTDATABASEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineRegTb> AirlineRegTbs { get; set; }
        public virtual DbSet<BookingTb> BookingTbs { get; set; }
        public virtual DbSet<DiscountTb> DiscountTbs { get; set; }
        public virtual DbSet<InstrumentTb> InstrumentTbs { get; set; }
        public virtual DbSet<InventoryTb> InventoryTbs { get; set; }
        public virtual DbSet<LoginTb> LoginTbs { get; set; }
        public virtual DbSet<MealPlanTb> MealPlanTbs { get; set; }
        public virtual DbSet<ScheduleTb> ScheduleTbs { get; set; }
        public virtual DbSet<ScheduledDaysTb> ScheduledDaysTbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET338;Initial Catalog=FLIGHTDATABASE;User Id=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineRegTb>(entity =>
            {
                entity.ToTable("AirlineRegTB");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Caddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAddress");

                entity.Property(e => e.Cnum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CNum");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookingTb>(entity =>
            {
                entity.ToTable("BookingTB");

                entity.Property(e => e.BookedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Meal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Page).HasColumnName("PAge");

                entity.Property(e => e.Pgender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PGender");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PName");

                entity.Property(e => e.Pnr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeatNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.BookingTbs)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_BookingTB_BookingTB_Flight");
            });

            modelBuilder.Entity<DiscountTb>(entity =>
            {
                entity.ToTable("discountTB");

                entity.Property(e => e.CoupenCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountPrice)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InstrumentTb>(entity =>
            {
                entity.ToTable("InstrumentTB");

                entity.Property(e => e.InstrumentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InventoryTb>(entity =>
            {
                entity.ToTable("InventoryTB");

                entity.Property(e => e.BusinessCseat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BusinessCSeat");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IsACTIVE");

                entity.Property(e => e.NonBcseat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NonBCSeat");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.InventoryTbs)
                    .HasForeignKey(d => d.InstrumentId)
                    .HasConstraintName("FK_InventoryTB_InventoryTB_Instrument");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.InventoryTbs)
                    .HasForeignKey(d => d.MealId)
                    .HasConstraintName("FK_InventoryTB_InventoryTB_Meal");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.InventoryTbs)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK_InventoryTB_InventoryTB_Schedule");
            });

            modelBuilder.Entity<LoginTb>(entity =>
            {
                entity.ToTable("LoginTB");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MealPlanTb>(entity =>
            {
                entity.ToTable("MealPlanTB");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MealType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduleTb>(entity =>
            {
                entity.ToTable("ScheduleTB");

                entity.Property(e => e.BclassSeat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BClassSeat");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNum)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MealPlan)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NbclassSeat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NBClassSeat");

                entity.Property(e => e.NoOfRows)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SchDays)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduledDaysTb>(entity =>
            {
                entity.ToTable("ScheduledDaysTB");

                entity.Property(e => e.Days)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
