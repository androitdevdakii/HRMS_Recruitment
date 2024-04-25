﻿// <auto-generated />
using System;
using HRMS_Recruitment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRMS_Recruitment.Migrations
{
    [DbContext(typeof(HRMS_RecruitmentContext))]
    [Migration("20240425125345_MakeJobPositionVacancyDatesNullable")]
    partial class MakeJobPositionVacancyDatesNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRMS_Recruitment.Models.JobDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobDepartment");
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobDepartmentId");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobPositionVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDirApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHrApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPostedOnWebsite")
                        .HasColumnType("bit");

                    b.Property<int>("JobPositionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PostingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JobPositionId");

                    b.ToTable("JobPositionVacancy");
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Desccription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobTask");
                });

            modelBuilder.Entity("JobPositionJobTask", b =>
                {
                    b.Property<int>("JobPositionsId")
                        .HasColumnType("int");

                    b.Property<int>("JobTasksId")
                        .HasColumnType("int");

                    b.HasKey("JobPositionsId", "JobTasksId");

                    b.HasIndex("JobTasksId");

                    b.ToTable("JobPositionJobTask");
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobPosition", b =>
                {
                    b.HasOne("HRMS_Recruitment.Models.JobDepartment", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("JobDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobPositionVacancy", b =>
                {
                    b.HasOne("HRMS_Recruitment.Models.JobPosition", "JobPosition")
                        .WithMany()
                        .HasForeignKey("JobPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosition");
                });

            modelBuilder.Entity("JobPositionJobTask", b =>
                {
                    b.HasOne("HRMS_Recruitment.Models.JobPosition", null)
                        .WithMany()
                        .HasForeignKey("JobPositionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRMS_Recruitment.Models.JobTask", null)
                        .WithMany()
                        .HasForeignKey("JobTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRMS_Recruitment.Models.JobDepartment", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}