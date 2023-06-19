﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dvg.Data;

#nullable disable

namespace dvg.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230619095159_InitializeDesignerAndClient")]
    partial class InitializeDesignerAndClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesignerProject", b =>
                {
                    b.Property<Guid>("AttendeesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AttendeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("DesignerProject");
                });

            modelBuilder.Entity("dvg.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("049f949d-f3a5-4a16-b854-03adea220030"),
                            CreateDate = new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(453),
                            FirstName = "Alex",
                            LastName = "Freeman",
                            PhoneNumber = "+380939876532"
                        },
                        new
                        {
                            Id = new Guid("feb28f61-1c23-4d90-aeae-ce1e2f9b410f"),
                            CreateDate = new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(460),
                            FirstName = "Igor",
                            LastName = "Kowalski",
                            PhoneNumber = "+380631234567"
                        });
                });

            modelBuilder.Entity("dvg.Data.Entities.CustomTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Term")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("CustomTask");
                });

            modelBuilder.Entity("dvg.Data.Entities.Designer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomTaskId");

                    b.ToTable("Designers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb9b41ca-3134-4f9d-b70c-53527f4b7df4"),
                            CreateDate = new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(412),
                            FirstName = "Kate",
                            LastName = "Ivanka",
                            PhoneNumber = "+380991002030",
                            Position = 3
                        },
                        new
                        {
                            Id = new Guid("979f3bef-38be-4bf7-8d6b-19416b272264"),
                            CreateDate = new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(448),
                            FirstName = "Valeria",
                            LastName = "Wayne",
                            PhoneNumber = "+380661003040",
                            Position = 2
                        });
                });

            modelBuilder.Entity("dvg.Data.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Term")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("DesignerProject", b =>
                {
                    b.HasOne("dvg.Data.Entities.Designer", null)
                        .WithMany()
                        .HasForeignKey("AttendeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dvg.Data.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dvg.Data.Entities.Client", b =>
                {
                    b.HasOne("dvg.Data.Entities.Project", null)
                        .WithMany("Clients")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("dvg.Data.Entities.CustomTask", b =>
                {
                    b.HasOne("dvg.Data.Entities.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("dvg.Data.Entities.Designer", b =>
                {
                    b.HasOne("dvg.Data.Entities.CustomTask", null)
                        .WithMany("Attendees")
                        .HasForeignKey("CustomTaskId");
                });

            modelBuilder.Entity("dvg.Data.Entities.CustomTask", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("dvg.Data.Entities.Project", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
