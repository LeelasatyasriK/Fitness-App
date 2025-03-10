﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApiProject.Data;

#nullable disable

namespace MyWebApiProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240219073104_UpdateGoals")]
    partial class UpdateGoals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExercisesGoals", b =>
                {
                    b.Property<int>("exercisesExerciseID")
                        .HasColumnType("int");

                    b.Property<int>("goalsGoalID")
                        .HasColumnType("int");

                    b.HasKey("exercisesExerciseID", "goalsGoalID");

                    b.HasIndex("goalsGoalID");

                    b.ToTable("ExercisesGoals");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Exercises", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseID"));

                    b.Property<int>("CaloriesBurnedPerMinute")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutID")
                        .HasColumnType("int");

                    b.HasKey("ExerciseID");

                    b.HasIndex("WorkoutID");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Goals", b =>
                {
                    b.Property<int>("GoalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoalID"));

                    b.Property<string>("GoalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("TargetDate")
                        .HasColumnType("date");

                    b.HasKey("GoalID");

                    b.ToTable("goals");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Progress", b =>
                {
                    b.Property<int>("ProgressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressID"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("GoalID")
                        .HasColumnType("int");

                    b.Property<decimal>("ProgressValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProgressID");

                    b.HasIndex("GoalID")
                        .IsUnique();

                    b.ToTable("progress");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Workouts", b =>
                {
                    b.Property<int>("WorkoutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutID"));

                    b.Property<int>("CaloriesBurned")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("WorkoutID");

                    b.ToTable("workouts");
                });

            modelBuilder.Entity("ExercisesGoals", b =>
                {
                    b.HasOne("MyWebApiProject.Models.Exercises", null)
                        .WithMany()
                        .HasForeignKey("exercisesExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiProject.Models.Goals", null)
                        .WithMany()
                        .HasForeignKey("goalsGoalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWebApiProject.Models.Exercises", b =>
                {
                    b.HasOne("MyWebApiProject.Models.Workouts", "workout")
                        .WithMany("exercise")
                        .HasForeignKey("WorkoutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("workout");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Progress", b =>
                {
                    b.HasOne("MyWebApiProject.Models.Goals", "goal")
                        .WithOne("progress")
                        .HasForeignKey("MyWebApiProject.Models.Progress", "GoalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("goal");
                });

            modelBuilder.Entity("MyWebApiProject.Models.Goals", b =>
                {
                    b.Navigation("progress")
                        .IsRequired();
                });

            modelBuilder.Entity("MyWebApiProject.Models.Workouts", b =>
                {
                    b.Navigation("exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
