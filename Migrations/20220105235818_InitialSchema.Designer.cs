﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ecosystem_smart_home_rest_api;

#nullable disable

namespace EcosystemSmartHome.Migrations
{
    [DbContext(typeof(SmartHomeContext))]
    [Migration("20220105235818_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ecosystem_smart_home_rest_api.RoomInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Humidity")
                        .HasColumnType("double precision")
                        .HasColumnName("humidity");

                    b.Property<double>("QuantityCO")
                        .HasColumnType("double precision")
                        .HasColumnName("quantity_co");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision")
                        .HasColumnName("temperature");

                    b.HasKey("Id")
                        .HasName("pk_room_info");

                    b.ToTable("room_info", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
