﻿// <auto-generated />
using System;
using Customer.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Customer.Repository.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Customer.Domain.Account.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Customer.Domain.Cadastro.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Customer.Domain.Account.Usuario", b =>
                {
                    b.OwnsOne("Customer.Domain.Account.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("Customer.Domain.Account.ValueObject.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("Customer.Domain.Cadastro.Cliente", b =>
                {
                    b.HasOne("Customer.Domain.Account.Usuario", "Usuario")
                        .WithMany("Clientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Customer.Domain.Cadastro.ValueObject.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("Customer.Domain.Cadastro.ValueObject.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NomeEndereco")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Customer.Domain.Account.Usuario", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
