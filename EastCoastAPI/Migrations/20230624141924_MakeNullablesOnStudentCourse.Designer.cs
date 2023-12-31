﻿// <auto-generated />
using System;
using EastCoastEducation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EastCoastEducation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230624141924_MakeNullablesOnStudentCourse")]
    partial class MakeNullablesOnStudentCourse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("EastCoastEducation.Model.Competence", b =>
                {
                    b.Property<int>("CompetenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompetenceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CompetenceId");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseLength")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("CourseNumber", "CourseTitle")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EastCoastEducation.Model.StudentCourse", b =>
                {
                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Competence")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EastCoastEducation.Model.TeacherCompetence", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompetenceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "CompetenceId");

                    b.HasIndex("CompetenceId");

                    b.ToTable("TeachersCompetences");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoursesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentsId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("TeacherCompetence", b =>
                {
                    b.Property<int>("TeachersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompetencesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeachersId", "CompetencesId");

                    b.HasIndex("CompetencesId");

                    b.ToTable("TeacherCompetence");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Course", b =>
                {
                    b.HasOne("EastCoastEducation.Model.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EastCoastEducation.Model.StudentCourse", b =>
                {
                    b.HasOne("EastCoastEducation.Model.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EastCoastEducation.Model.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EastCoastEducation.Model.TeacherCompetence", b =>
                {
                    b.HasOne("EastCoastEducation.Model.Competence", "Competence")
                        .WithMany("TeacherCompetences")
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EastCoastEducation.Model.Teacher", "Teacher")
                        .WithMany("TeacherCompetences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competence");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentCourse", b =>
                {
                    b.HasOne("EastCoastEducation.Model.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EastCoastEducation.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherCompetence", b =>
                {
                    b.HasOne("EastCoastEducation.Model.Competence", null)
                        .WithMany()
                        .HasForeignKey("CompetencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EastCoastEducation.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EastCoastEducation.Model.Competence", b =>
                {
                    b.Navigation("TeacherCompetences");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("EastCoastEducation.Model.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("TeacherCompetences");
                });
#pragma warning restore 612, 618
        }
    }
}
