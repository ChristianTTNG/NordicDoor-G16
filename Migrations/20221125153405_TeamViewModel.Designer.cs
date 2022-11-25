﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NordicDoorTestingrep.Data;

#nullable disable

namespace NordicDoorTestingrep.Migrations
{
    [DbContext(typeof(NordicDoorTestingrepContext))]
    [Migration("20221125153405_TeamViewModel")]
    partial class TeamViewModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NordicDoorTestingrep.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("SugID")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SugID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Suggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuggestionId"), 1L, 1);

                    b.Property<DateTime>("CompletedOrDueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("JDISug")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResponsibleEmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("SugCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SugCreatorID")
                        .HasColumnType("int");

                    b.Property<string>("SugDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SugStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<float>("progress")
                        .HasColumnType("real");

                    b.HasKey("SuggestionId");

                    b.HasIndex("ResponsibleEmployeeID");

                    b.HasIndex("SugCreatorID");

                    b.HasIndex("TeamID");

                    b.ToTable("Suggestion");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.SugImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SugID")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("SugID");

                    b.ToTable("SugImage");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.TeamMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamMembership");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Comment", b =>
                {
                    b.HasOne("NordicDoorTestingrep.Models.Employee", "Employee")
                        .WithMany("Comments")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NordicDoorTestingrep.Models.Suggestion", "Suggestion")
                        .WithMany("Comments")
                        .HasForeignKey("SugID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Suggestion");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Suggestion", b =>
                {
                    b.HasOne("NordicDoorTestingrep.Models.Employee", "ResponsibleEmployee")
                        .WithMany("ResponsibleEmpCon")
                        .HasForeignKey("ResponsibleEmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NordicDoorTestingrep.Models.Employee", "SugCreator")
                        .WithMany("SugCreatorCon")
                        .HasForeignKey("SugCreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NordicDoorTestingrep.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsibleEmployee");

                    b.Navigation("SugCreator");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.SugImage", b =>
                {
                    b.HasOne("NordicDoorTestingrep.Models.Suggestion", "Suggestion")
                        .WithMany()
                        .HasForeignKey("SugID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suggestion");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.TeamMembership", b =>
                {
                    b.HasOne("NordicDoorTestingrep.Models.Employee", "Employee")
                        .WithMany("Teams")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NordicDoorTestingrep.Models.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Employee", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ResponsibleEmpCon");

                    b.Navigation("SugCreatorCon");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Suggestion", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("NordicDoorTestingrep.Models.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
