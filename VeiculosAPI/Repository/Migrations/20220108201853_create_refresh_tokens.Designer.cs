﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeiculosAPI.Repository;

namespace VeiculosAPI.Migrations
{
    [DbContext(typeof(VeiculosDb))]
    [Migration("20220108201853_create_refresh_tokens")]
    partial class create_refresh_tokens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("VeiculosAPI.Repository.Models.Marca", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("logo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("marcas");
                });

            modelBuilder.Entity("VeiculosAPI.Repository.Models.Modelo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("FimFabricacao")
                        .HasColumnType("int")
                        .HasColumnName("fim_fabricacao");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imagem");

                    b.Property<int>("InicioFabricacao")
                        .HasColumnType("int")
                        .HasColumnName("inicio_fabricacao");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int")
                        .HasColumnName("marca_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("modelos");
                });

            modelBuilder.Entity("VeiculosAPI.Repository.Models.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<DateTime?>("EmailVerificadoEm")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("email_verificado_em");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("VeiculosAPI.Repository.Models.Modelo", b =>
                {
                    b.HasOne("VeiculosAPI.Repository.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("VeiculosAPI.Repository.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });
#pragma warning restore 612, 618
        }
    }
}
