using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CourseAdvisoryApplication.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CoursePrereq> CoursePrereq { get; set; }
        public virtual DbSet<Degree> Degree { get; set; }
        public virtual DbSet<DegreePathCourseComboMap> DegreePathCourseComboMap { get; set; }
        public virtual DbSet<DegreePathCourseMap> DegreePathCourseMap { get; set; }
        public virtual DbSet<Degreepath> Degreepath { get; set; }
        public virtual DbSet<DegreepathRule> DegreepathRule { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<SpecialtyCourseMap> SpecialtyCourseMap { get; set; }
        public virtual DbSet<Temp> Temp { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CourseAdvisoryAppDB_Prd;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseCredits).HasColumnName("Course_Credits");

                entity.Property(e => e.CourseName)
                    .HasColumnName("Course_Name")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CoursePrereq>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PrereqCourseId })
                    .HasName("PK__Course_P__C24B0523EAE8CE2B");

                entity.ToTable("Course_Prereq");

                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrereqCourseId)
                    .HasColumnName("Prereq_Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursePrereqCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course_Pr__Cours__7F2BE32F");

                entity.HasOne(d => d.PrereqCourse)
                    .WithMany(p => p.CoursePrereqPrereqCourse)
                    .HasForeignKey(d => d.PrereqCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course_Pr__Prere__00200768");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.Property(e => e.DegreeId)
                    .HasColumnName("Degree_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegreeName)
                    .HasColumnName("Degree_Name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Degree)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Degree__dep_id__5441852A");
            });

            modelBuilder.Entity<DegreePathCourseComboMap>(entity =>
            {
                entity.HasKey(e => new { e.DegreePathId, e.ComboId })
                    .HasName("PK__DegreePa__3936ECE3774A830E");

                entity.ToTable("DegreePath_CourseCombo_Map");

                entity.Property(e => e.DegreePathId).HasColumnName("DegreePath_id");

                entity.Property(e => e.ComboId)
                    .HasColumnName("Combo_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.DegreePathCourseComboMap)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__DegreePat__Cours__06CD04F7");

                entity.HasOne(d => d.DegreePath)
                    .WithMany(p => p.DegreePathCourseComboMap)
                    .HasForeignKey(d => d.DegreePathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DegreePat__Degre__05D8E0BE");
            });

            modelBuilder.Entity<DegreePathCourseMap>(entity =>
            {
                entity.HasKey(e => new { e.DegreePathId, e.CourseId })
                    .HasName("PK__DegreePa__B359BF9D09CA6C7F");

                entity.ToTable("DegreePath_Course_Map");

                entity.Property(e => e.DegreePathId).HasColumnName("DegreePath_id");

                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseCategory)
                    .HasColumnName("Course_Category")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MandatoryCourse10).HasColumnName("MandatoryCourse_1_0");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.DegreePathCourseMap)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DegreePat__Cours__7C4F7684");

                entity.HasOne(d => d.DegreePath)
                    .WithMany(p => p.DegreePathCourseMap)
                    .HasForeignKey(d => d.DegreePathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DegreePat__Degre__7B5B524B");
            });

            modelBuilder.Entity<Degreepath>(entity =>
            {
                entity.Property(e => e.DegreePathId)
                    .HasColumnName("DegreePath_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegreeId).HasColumnName("Degree_id");

                entity.Property(e => e.PathName)
                    .HasColumnName("Path_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PathNumber).HasColumnName("Path_number");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.Degreepath)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK__Degreepat__Degre__59063A47");
            });

            modelBuilder.Entity<DegreepathRule>(entity =>
            {
                entity.HasKey(e => e.RuleId)
                    .HasName("PK__Degreepa__70A80C76444435CA");

                entity.ToTable("Degreepath_Rule");

                entity.Property(e => e.RuleId)
                    .HasColumnName("Rule_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegreePathId).HasColumnName("DegreePath_id");

                entity.Property(e => e.RuleCategory)
                    .HasColumnName("Rule_Category")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RuleValue)
                    .HasColumnName("Rule_Value")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.DegreePath)
                    .WithMany(p => p.DegreepathRule)
                    .HasForeignKey(d => d.DegreePathId)
                    .HasConstraintName("FK__Degreepat__Degre__628FA481");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__0C2B452D38469D45");

                entity.Property(e => e.DepId)
                    .HasColumnName("Dep_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepName)
                    .HasColumnName("Dep_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK__Specialt__C1D7E375007CCBAA");

                entity.Property(e => e.SpecId)
                    .HasColumnName("Spec_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegreeId).HasColumnName("Degree_id");

                entity.Property(e => e.SpecialtyName)
                    .HasColumnName("Specialty_Name")
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.Specialty)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK__Specialty__Degre__73BA3083");
            });

            modelBuilder.Entity<SpecialtyCourseMap>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.CourseId })
                    .HasName("PK__Specialt__E2A9D3E93419C920");

                entity.ToTable("Specialty_Course_Map");

                entity.Property(e => e.SpecId).HasColumnName("Spec_id");

                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MandatoryCourse10).HasColumnName("MandatoryCourse_1_0");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.SpecialtyCourseMap)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specialty__Cours__778AC167");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecialtyCourseMap)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specialty__Spec___76969D2E");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.message);

                entity.ToTable("status");

                entity.Property(e => e.message)
                    .HasColumnName("message")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("temp");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__users__7C9273C5F0098887");

                entity.ToTable("users");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdvisorName)
                    .HasColumnName("Advisor_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Result");

                entity.Property(e => e.Course_ID)
                    .HasColumnName("Course_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.Course_Name)
                    .HasColumnName("Course_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.Course_Category)
                    .HasColumnName("Course_Category")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.Course_Credits)
                    .HasColumnName("Course_Credits")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.Student_Course_Completion_Status)
                    .HasColumnName("Student_Course_Completion_Status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.Course_Credits_Obtained)
                    .HasColumnName("Course_Credits_Obtained")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.PreReq_Course_ID)
                    .HasColumnName("PreReq_Course_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.ThesisOption_MandatoryCourse_YN)
                    .HasColumnName("ThesisOption_MandatoryCourse_YN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                    entity.Property(e => e.NonThesisOption_MandatoryCourse_YN)
                    .HasColumnName("NonThesisOption_MandatoryCourse_YN")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
