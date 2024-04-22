using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolAPI.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-JUANQUIR\\SQLEXPRESS;Database=TbtGlobal; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.HasIndex(e => e.Name, "UQ__Class__737584F6C568F6E5")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Clase sin descripción')");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.HasIndex(e => e.Code, "UQ__Grade__A25C5AA7BB7CBA7B")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Credits)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Observations)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Sin observación de agenda')");

                entity.Property(e => e.ScheduleDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleClass");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleStudent");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Phone, "UQ__Student__5C7E359EC5353C85")
                    .IsUnique();

                entity.Property(e => e.Adress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Sin Dirección')");

                entity.Property(e => e.Document)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGradeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdGrade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
