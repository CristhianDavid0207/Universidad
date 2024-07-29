using Microsoft.EntityFrameworkCore;
using inscription.Models;

namespace inscription.Infraestructures.Contexts
{
    public class InscriptionsContext : DbContext
    {
        public InscriptionsContext(DbContextOptions<InscriptionsContext> options) : base(options)
        {

        }

        public DbSet<Career> Careers { get; set; }
        public DbSet<CareerHasSubject> CareerHasSubjects { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorHasUniversity> ProfessorHasUniversities { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectHasInscription> SubjectHasInscriptions { get; set; }
        public DbSet<SubjectHasProfessor> SubjectHasProfessors { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityDean> UniversityDeans { get; set; }
        public DbSet<UniversityHasCareer> UniversityHasCareers { get; set; }
        public DbSet<UniversityHasStudent> UniversityHasStudents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla intermedia entre Careers y Subjects
            modelBuilder.Entity<CareerHasSubject>()
                .HasKey(cs => new { cs.CareerId, cs.SubjectId });

            modelBuilder.Entity<CareerHasSubject>()
                .HasOne(cs => cs.Career)
                .WithMany(c => c.CareerHasSubject)
                .HasForeignKey(cs => cs.CareerId);

            modelBuilder.Entity<CareerHasSubject>()
                .HasOne(cs => cs.Subject)
                .WithMany(s => s.CareerHasSubject)
                .HasForeignKey(cs => cs.SubjectId);

            // Tabla intermedia entre Professors y Universities
            modelBuilder.Entity<ProfessorHasUniversity>()
                .HasKey(pu => new { pu.ProfessorId, pu.UniversityId });

            modelBuilder.Entity<ProfessorHasUniversity>()
                .HasOne(pu => pu.Professor)
                .WithMany(p => p.ProfessorHasUniversity)
                .HasForeignKey(pu => pu.ProfessorId);

            modelBuilder.Entity<ProfessorHasUniversity>()
                .HasOne(pu => pu.University)
                .WithMany(u => u.ProfessorHasUniversity)
                .HasForeignKey(pu => pu.UniversityId);

            // Tabla intermedia entre Subjects e Inscriptions
            modelBuilder.Entity<SubjectHasInscription>()
                .HasKey(si => new { si.SubjectId, si.InscriptionId });

            modelBuilder.Entity<SubjectHasInscription>()
                .HasOne(si => si.Subject)
                .WithMany(s => s.SubjectHasInscription)
                .HasForeignKey(si => si.SubjectId);

            modelBuilder.Entity<SubjectHasInscription>()
                .HasOne(si => si.Inscription)
                .WithMany(i => i.SubjectHasInscription)
                .HasForeignKey(si => si.InscriptionId);

            // Tabla intermedia entre Subjects y Professors
            modelBuilder.Entity<SubjectHasProfessor>()
                .HasKey(sp => new { sp.SubjectId, sp.ProfessorId });

            modelBuilder.Entity<SubjectHasProfessor>()
                .HasOne(sp => sp.Subject)
                .WithMany(s => s.SubjectHasProfessor)
                .HasForeignKey(sp => sp.SubjectId);

            modelBuilder.Entity<SubjectHasProfessor>()
                .HasOne(sp => sp.Professor)
                .WithMany(p => p.SubjectHasProfessor)
                .HasForeignKey(sp => sp.ProfessorId);

            // Tabla intermedia entre Universities y Careers
            modelBuilder.Entity<UniversityHasCareer>()
                .HasKey(uc => new { uc.UniversityId, uc.CareerId });

            modelBuilder.Entity<UniversityHasCareer>()
                .HasOne(uc => uc.University)
                .WithMany(u => u.UniversityHasCareer)
                .HasForeignKey(uc => uc.UniversityId);

            modelBuilder.Entity<UniversityHasCareer>()
                .HasOne(uc => uc.Career)
                .WithMany(c => c.UniversityHasCareer)
                .HasForeignKey(uc => uc.CareerId);

            // Tabla intermedia entre Universities y Students
            modelBuilder.Entity<UniversityHasStudent>()
                .HasKey(us => new { us.UniversityId, us.StudentId });

            modelBuilder.Entity<UniversityHasStudent>()
                .HasOne(us => us.University)
                .WithMany(u => u.UniversityHasStudent)
                .HasForeignKey(us => us.UniversityId);

            modelBuilder.Entity<UniversityHasStudent>()
                .HasOne(us => us.Student)
                .WithMany(s => s.UniversityHasStudent)
                .HasForeignKey(us => us.StudentId);

            // Llama al método OnModelCreating de la clase base para aplicar configuraciones base
            base.OnModelCreating(modelBuilder);
        }
    }
}
