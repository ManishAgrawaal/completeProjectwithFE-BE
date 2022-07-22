using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirlineServices.Models
{
    public partial class airlinedbContext : DbContext
    {
        public airlinedbContext()
        {
        }

        public airlinedbContext(DbContextOptions<airlinedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineRegTb> AirlineRegTbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:airlinesolution.database.windows.net,1433;Initial Catalog=airlinedb;Persist Security Info=False;User ID=airline;Password=Manish@8687;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineRegTb>(entity =>
            {
                entity.ToTable("AirlineRegTB");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Caddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAddress");

                entity.Property(e => e.Cnum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CNum");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
