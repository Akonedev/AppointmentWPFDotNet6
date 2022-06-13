using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppointmentWPFDotNet6.Models;

namespace AppointmentWPFDotNet6.Data
{
    public partial class AppointmentWPFContext : DbContext
    {
        public AppointmentWPFContext()
        {
        }

        public AppointmentWPFContext(DbContextOptions<AppointmentWPFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Broker> Brokers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9UHQOE3\\SQLEXPRESS;Database=AppointmentWPF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(e => e.IdBroker, "IX_appointments_idBroker");

                entity.HasIndex(e => e.IdCustomer, "IX_appointments_idCustomer");

                entity.Property(e => e.DateHour).HasColumnType("datetime");

                entity.Property(e => e.IdBroker).HasColumnName("idBroker");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.Subject).HasColumnType("text");

                entity.HasOne(d => d.IdBrokerNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdBroker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_brokers0_FK");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_customers_FK");
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
