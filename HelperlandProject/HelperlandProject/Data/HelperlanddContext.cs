using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HelperlandProject.Models;

#nullable disable

namespace HelperlandProject.Data
{
    public partial class HelperlanddContext : DbContext
    {
        public HelperlanddContext()
        {
        }

        public HelperlanddContext(DbContextOptions<HelperlanddContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ayy> Ayys { get; set; }
        public virtual DbSet<Contactu> Contactus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-H353LBS; database=Helperlandd; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ayy>(entity =>
            {
                entity.ToTable("ayy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("firstName");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.ContactusId)
                    .HasName("PK__contactu__E7F1FC0DF5C2E6F3");

                entity.ToTable("contactus");

                entity.Property(e => e.ContactusId).HasColumnName("contactusID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mobileNo");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("msg");

                entity.Property(e => e.SubjectType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("subjectType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
