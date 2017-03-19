namespace _04_resource_licenses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
            : base("name=StudentsSystemContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Homework)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.Course_Id);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Resources)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.Course_Id);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentCourses").MapLeftKey("Course_Id"));

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Homework)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.Student_Id);
        }
    }
}
