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
#pragma warning restore 612, 618
        }
    }
}
