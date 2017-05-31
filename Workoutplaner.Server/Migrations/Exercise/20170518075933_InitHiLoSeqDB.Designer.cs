using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Workoutplaner.Server.Context;

namespace Workoutplaner.Server.Migrations.Exercise
{
    [DbContext(typeof(ExerciseContext))]
    [Migration("20170518075933_InitHiLoSeqDB")]
    partial class InitHiLoSeqDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("Relational:Sequence:.HiLoSeq", "'HiLoSeq', '', '1000', '10', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Workoutplaner.Server.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "HiLoSeq")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("MuscleGroup");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Exercise");
                });

            modelBuilder.Entity("Workoutplaner.Server.Models.ExerciseItem", b =>
                {
                    b.HasBaseType("Workoutplaner.Server.Models.Exercise");

                    b.Property<int>("Reps");

                    b.Property<int>("SerialNumber");

                    b.ToTable("ExerciseItem");

                    b.HasDiscriminator().HasValue("ExerciseItem");
                });
        }
    }
}
