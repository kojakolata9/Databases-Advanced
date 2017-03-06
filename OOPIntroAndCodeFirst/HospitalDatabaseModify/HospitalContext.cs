namespace HospitalDatabaseModify
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>()
                .HasMany(e => e.Patients)
                .WithMany(e => e.Diagnoses)
                .Map(m => m.ToTable("PatientDiagnoses").MapLeftKey("Diagnose_DiagnoseId"));

            modelBuilder.Entity<Medicine>()
                .HasMany(e => e.Patients)
                .WithMany(e => e.Medicines)
                .Map(m => m.ToTable("MedicinePatients"));

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Visitations)
                .WithMany(e => e.Patients)
                .Map(m => m.ToTable("VisitationPatients"));
        }
    }
}
