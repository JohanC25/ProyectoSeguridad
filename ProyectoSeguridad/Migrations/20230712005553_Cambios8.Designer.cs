﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSeguridad.Data;

#nullable disable

namespace ProyectoSeguridad.Migrations
{
    [DbContext(typeof(ProyectoSeguridadContext))]
    [Migration("20230712005553_Cambios8")]
    partial class Cambios8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectoSeguridad.Models.Activo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clas_conf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clas_disp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clas_int")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("confidencialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("costoActivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("disponibilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("integridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valor")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Activo");
                });

            modelBuilder.Entity("ProyectoSeguridad.Models.Amenaza", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcionAmenaza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreAmenaza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valor")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Amenaza");
                });

            modelBuilder.Entity("ProyectoSeguridad.Models.Calculos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("ActivoValor")
                        .HasColumnType("int");

                    b.Property<int>("AmenazaValor")
                        .HasColumnType("int");

                    b.Property<int>("VulnerabilidadValor")
                        .HasColumnType("int");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.Property<int>("valorActivo")
                        .HasColumnType("int");

                    b.Property<int>("valorAmenaza")
                        .HasColumnType("int");

                    b.Property<float>("valorVulnerabilidad")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Calculos");
                });

            modelBuilder.Entity("ProyectoSeguridad.Models.Control", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("ActivoId")
                        .HasColumnType("int");

                    b.Property<string>("descripcionControl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("efectividad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreControl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Control");
                });

            modelBuilder.Entity("ProyectoSeguridad.Models.Frecuencia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("actividad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("frecuencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Frecuencia");
                });

            modelBuilder.Entity("ProyectoSeguridad.Models.Vulnerabilidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<decimal>("cvss")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("descripcionVulnerabilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreVulnerabilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Vulnerabilidad");
                });
#pragma warning restore 612, 618
        }
    }
}
