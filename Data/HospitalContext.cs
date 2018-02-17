using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            builder.Entity<Visitation>(entity =>
            {
                entity.ToTable("Visitations");

                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.VisitationId).HasColumnName("VisitationID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Visitations_Patients");

                
            });

            builder.Entity<Medicament>(entity =>
            {
                entity.ToTable("Medicaments");

                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.MedicamentId).HasColumnName("MedicamentID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });

            builder.Entity<Diagnose>(entity =>
            {
                entity.ToTable("Diagnoses");

                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.DiagnoseId).HasColumnName("DiagnoseID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Diagnoses_Patients");
            });

            builder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(t => new { t.PatientId, t.MedicamentId });

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientMedicament_Patients");

                entity.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientMedicament_Medicaments");
            });

            builder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");

                entity.HasKey(d => d.DoctorId);

                entity.Property(d => d.DoctorId).HasColumnName("DoctorId");

                entity.Property(d => d.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(d => d.Specialty)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.HasMany(e => e.Visitations)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey(e => e.VisitationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
