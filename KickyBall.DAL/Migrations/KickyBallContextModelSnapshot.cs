﻿// <auto-generated />
using System;
using KickyBall.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KickyBall.DAL.Migrations
{
    [DbContext(typeof(KickyBallContext))]
    partial class KickyBallContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KickyBall.DAL.Models.Direction", b =>
                {
                    b.Property<int>("DirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("DirectionId");

                    b.ToTable("Directions","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.FieldPosition", b =>
                {
                    b.Property<int>("FieldPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LeftFieldPositionId")
                        .HasColumnType("int");

                    b.Property<int?>("RightFieldPositionId")
                        .HasColumnType("int");

                    b.HasKey("FieldPositionId");

                    b.ToTable("FieldPositions","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Games","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.GoalAttempt", b =>
                {
                    b.Property<int>("GoalAttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ordinal")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<bool>("ScoredGoal")
                        .HasColumnType("bit");

                    b.HasKey("GoalAttemptId");

                    b.HasIndex("RoundId");

                    b.ToTable("GoalAttempts","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectionId")
                        .HasColumnType("int");

                    b.Property<int>("GoalAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("Ordinal")
                        .HasColumnType("int");

                    b.HasKey("MoveId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("GoalAttemptId");

                    b.ToTable("Moves","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Ordinal")
                        .HasColumnType("int");

                    b.Property<bool>("Practice")
                        .HasColumnType("bit");

                    b.Property<int>("SecondsRemaining")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users","KickyBall");
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Game", b =>
                {
                    b.HasOne("KickyBall.DAL.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KickyBall.DAL.Models.GoalAttempt", b =>
                {
                    b.HasOne("KickyBall.DAL.Models.Round", "Round")
                        .WithMany("GoalAttempts")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Move", b =>
                {
                    b.HasOne("KickyBall.DAL.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KickyBall.DAL.Models.GoalAttempt", "GoalAttempt")
                        .WithMany("Moves")
                        .HasForeignKey("GoalAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KickyBall.DAL.Models.Round", b =>
                {
                    b.HasOne("KickyBall.DAL.Models.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
