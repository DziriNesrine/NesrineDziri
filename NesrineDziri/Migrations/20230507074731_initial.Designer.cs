﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NesrineDziri.Data;

#nullable disable

namespace NesrineDziri.Migrations
{
    [DbContext(typeof(NesrineDziriContext))]
    [Migration("20230507074731_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NesrineDziri.Models.MakeUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Marque")
                        .HasColumnType("int");

                    b.Property<string>("MarqueUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Perfumery_StoreId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Perfumery_StoreId");

                    b.ToTable("MakeUp");
                });

            modelBuilder.Entity("NesrineDziri.Models.Perfumery_Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfumery_Store");
                });

            modelBuilder.Entity("NesrineDziri.Models.MakeUp", b =>
                {
                    b.HasOne("NesrineDziri.Models.Perfumery_Store", "Perfumery_Store")
                        .WithMany("MakeUps")
                        .HasForeignKey("Perfumery_StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfumery_Store");
                });

            modelBuilder.Entity("NesrineDziri.Models.Perfumery_Store", b =>
                {
                    b.Navigation("MakeUps");
                });
#pragma warning restore 612, 618
        }
    }
}
