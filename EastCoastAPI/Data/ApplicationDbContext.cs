using Azure;
using EastCoastEducation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EastCoastEducation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCompetence> TeachersCompetences { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Student and course relationship...according to tutorial 1-----------
            //modelBuilder.Entity<StudentCourse>()
            //    .HasKey(sc => new { sc.CourseId, sc.StudentId });

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(s => s.Student)
            //    .WithMany(sc => sc.StudentCourses)
            //    .HasForeignKey(s => s.StudentId);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(s => s.Course)
            //    .WithMany(sc => sc.StudentCourses)
            //    .HasForeignKey(c => c.CourseId);
            ////----------------------------------------------------------

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Students)
                .UsingEntity(
                    "StudentCourse",
            l => l.HasOne(typeof(Course)).WithMany().HasForeignKey("CoursesId").HasPrincipalKey(nameof(Course.CourseId)),
            r => r.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentsId").HasPrincipalKey(nameof(Student.StudentId)),
            j => j.HasKey("StudentsId", "CoursesId"));

            //modelBuilder.Entity<Admin>()
            //    .HasKey(sc => new {sc.AdminId});

            ////Teacher and Competence relationship...according to tutorial 1--------------
            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasKey(tc => new { tc.TeacherId, tc.CompetenceId });

            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasOne(t => t.Teacher)
            //    .WithMany(tc => tc.TeacherCompetences)
            //    .HasForeignKey(t => t.TeacherId);

            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasOne(t => t.Competence)
            //    .WithMany(tc => tc.TeacherCompetences)
            //    .HasForeignKey(c => c.CompetenceId);
            ////---------------------------------------------------------------------

            modelBuilder.Entity<TeacherCompetence>()
                .HasKey(tc => new { tc.TeacherId, tc.CompetenceId });

            modelBuilder.Entity<Teacher>()
                .HasMany(f => f.Competences)
                .WithMany(f => f.Teachers)
                .UsingEntity(
                    "TeacherCompetence",
                        l => l.HasOne(typeof(Competence)).WithMany().HasForeignKey("CompetencesId").HasPrincipalKey(nameof(Competence.CompetenceId)),
            r => r.HasOne(typeof(Teacher)).WithMany().HasForeignKey("TeachersId").HasPrincipalKey(nameof(Teacher.TeacherId)),
            j => j.HasKey("TeachersId", "CompetencesId"));

            //modelBuilder.Entity<Course>()
            //    .HasOne(e => e.Teacher)
            //    .WithMany(e => e.Courses)
            //    .HasForeignKey(e => e.TeacherId)
            //    .IsRequired(false);
        }         
    }
}
