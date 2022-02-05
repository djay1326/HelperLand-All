using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HelperlandProject.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual DbSet<Ayy> Ayy { get; set; }
        public virtual DbSet<Contactu> Contactus { get; set; }
        public virtual DbSet<Userr> Userr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-H353LBS; database=Helperlandd; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ayy>(entity =>
            {
                entity.ToTable("ayy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.ToTable("contactus");

                entity.Property(e => e.ContactusId).HasColumnName("contactusID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasColumnName("msg")
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectType)
                    .IsRequired()
                    .HasColumnName("subjectType")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("userr");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
