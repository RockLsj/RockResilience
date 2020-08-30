﻿// <auto-generated />
using Business.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business.Api.Migrations
{
    [DbContext(typeof(RockResilienceContext))]
    partial class RockResilienceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Domain.Entities.ConsumeDetailTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsumeType")
                        .HasColumnType("int");

                    b.Property<int>("PeopleTestId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PeopleTestId")
                        .IsUnique();

                    b.ToTable("ConsumeDetailTests");
                });

            modelBuilder.Entity("Business.Domain.Entities.CourseTest3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseTest3");
                });

            modelBuilder.Entity("Business.Domain.Entities.DeveloperTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Followers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DeveloperTests");
                });

            modelBuilder.Entity("Business.Domain.Entities.GradeTest2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GradeTest2s");
                });

            modelBuilder.Entity("Business.Domain.Entities.PeopleTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeopleTests");
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentCourse3", b =>
                {
                    b.Property<int>("StudentTest3Id")
                        .HasColumnType("int");

                    b.Property<int>("CourseTest3Id")
                        .HasColumnType("int");

                    b.HasKey("StudentTest3Id", "CourseTest3Id");

                    b.HasIndex("CourseTest3Id");

                    b.ToTable("StudentCourse3");
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roll")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("StudentTests");
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentTest2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeTest2Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeTest2Id");

                    b.ToTable("StudentTest2s");
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentTest3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudentTest3");
                });

            modelBuilder.Entity("Business.Domain.Entities.ConsumeDetailTest", b =>
                {
                    b.HasOne("Business.Domain.Entities.PeopleTest", "PeopleTest")
                        .WithOne("ConsumeDetailTest")
                        .HasForeignKey("Business.Domain.Entities.ConsumeDetailTest", "PeopleTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentCourse3", b =>
                {
                    b.HasOne("Business.Domain.Entities.CourseTest3", "CourseTest3")
                        .WithMany("StudentCourse3s")
                        .HasForeignKey("CourseTest3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Business.Domain.Entities.StudentTest3", "StudentTest3")
                        .WithMany("StudentCourse3s")
                        .HasForeignKey("StudentTest3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Domain.Entities.StudentTest2", b =>
                {
                    b.HasOne("Business.Domain.Entities.GradeTest2", "GradeTest2")
                        .WithMany("StudentTest2s")
                        .HasForeignKey("GradeTest2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
