﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Visitas_Renso_Soriano.Data;

#nullable disable

namespace Registro_Visitas_Renso_Soriano.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220519054757_MigrationInitial")]
    partial class MigrationInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.Changes", b =>
                {
                    b.Property<int>("IdChanges")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdChanges"), 1L, 1);

                    b.Property<string>("ChangesNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdChanges");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.Events", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.EventsAssignation", b =>
                {
                    b.Property<int>("IdEventsAssignation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEventsAssignation"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("IdEventsAssignation");

                    b.HasIndex("EventId");

                    b.HasIndex("VisitorId");

                    b.ToTable("EventsAssignations");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.Visitors", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitorId"), 1L, 1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Last_Date_Register")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.VisitsHistory", b =>
                {
                    b.Property<int>("VisitsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitsId"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDeparture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateIncome")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("VisitsId");

                    b.HasIndex("VisitorId");

                    b.ToTable("VisitsHistories");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.EventsAssignation", b =>
                {
                    b.HasOne("Registro_Visitas_Renso_Soriano.Data.Events", "Events")
                        .WithMany("EventsAssignations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Visitas_Renso_Soriano.Data.Visitors", "Visitors")
                        .WithMany("EventsAssignations")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.VisitsHistory", b =>
                {
                    b.HasOne("Registro_Visitas_Renso_Soriano.Data.Visitors", "Visitors")
                        .WithMany("VisitsHistorys")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.Events", b =>
                {
                    b.Navigation("EventsAssignations");
                });

            modelBuilder.Entity("Registro_Visitas_Renso_Soriano.Data.Visitors", b =>
                {
                    b.Navigation("EventsAssignations");

                    b.Navigation("VisitsHistorys");
                });
#pragma warning restore 612, 618
        }
    }
}
