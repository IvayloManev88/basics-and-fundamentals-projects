using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using P01_HospitalDatabase.Data.Models;
using static P01_HospitalDatabase.Data.ApplicationCommonConfiguration;


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
       
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientMedicament>()
              .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }
    }
}
