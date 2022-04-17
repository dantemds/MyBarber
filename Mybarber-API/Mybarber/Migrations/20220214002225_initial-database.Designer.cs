﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mybarber.Persistencia;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mybarber.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220214002225_initial-database")]
    partial class initialdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Mybarber.Models.Agendamentos", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BarbeariasId")
                        .HasColumnType("integer");

                    b.Property<int>("BarbeirosId")
                        .HasColumnType("integer");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.Property<int>("ServicosId")
                        .HasColumnType("integer");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeirosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Mybarber.Models.Agendas", b =>
                {
                    b.Property<int>("IdAgendas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BarbeirosId")
                        .HasColumnType("integer");

                    b.Property<List<float>>("Domingo")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Quarta")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Quinta")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Sabado")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Segunda")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Sexta")
                        .HasColumnType("real[]");

                    b.Property<List<float>>("Terca")
                        .HasColumnType("real[]");

                    b.HasKey("IdAgendas");

                    b.HasIndex("BarbeirosId")
                        .IsUnique();

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Mybarber.Models.Barbearias", b =>
                {
                    b.Property<int>("IdBarbearia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeBarbearia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdBarbearia");

                    b.ToTable("Barbearias");
                });

            modelBuilder.Entity("Mybarber.Models.BarbeiroImagens", b =>
                {
                    b.Property<int>("IdBarbeiroImagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdBarbeiroImagem");

                    b.ToTable("BarbeiroImagens");
                });

            modelBuilder.Entity("Mybarber.Models.Barbeiros", b =>
                {
                    b.Property<int>("IdBarbeiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BarbeariasId")
                        .HasColumnType("integer");

                    b.Property<int>("BarbeiroImagemId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("NameBarbeiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("IdBarbeiro");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeiroImagemId");

                    b.ToTable("Barbeiros");
                });

            modelBuilder.Entity("Mybarber.Models.ServicoImagens", b =>
                {
                    b.Property<int>("IdImagemServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdImagemServico");

                    b.ToTable("ServicoImagens");
                });

            modelBuilder.Entity("Mybarber.Models.Servicos", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BarbeariasId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeServico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("PrecoServico")
                        .HasColumnType("real");

                    b.Property<int>("ServicoImagemId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TempoServico")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdServico");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("ServicoImagemId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Mybarber.Models.ServicosBarbeiros", b =>
                {
                    b.Property<int>("ServicosId")
                        .HasColumnType("integer");

                    b.Property<int>("BarbeirosId")
                        .HasColumnType("integer");

                    b.Property<int>("BarbeariasId")
                        .HasColumnType("integer");

                    b.HasKey("ServicosId", "BarbeirosId");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeirosId");

                    b.ToTable("ServicosBarbeiros");
                });

            modelBuilder.Entity("Mybarber.Models.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BarbeariasId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.HasIndex("BarbeariasId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mybarber.Models.Agendamentos", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("Agendamentos")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.Barbeiros", "Barbeiros")
                        .WithMany()
                        .HasForeignKey("BarbeirosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.Servicos", "Servicos")
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Agendas", b =>
                {
                    b.HasOne("Mybarber.Models.Barbeiros", "Barbeiros")
                        .WithOne("Agendas")
                        .HasForeignKey("Mybarber.Models.Agendas", "BarbeirosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Barbeiros", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("Barbeiros")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.BarbeiroImagens", "BarbeiroImagem")
                        .WithMany("Barbeiros")
                        .HasForeignKey("BarbeiroImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Servicos", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("Servicos")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.ServicoImagens", "ServicoImagem")
                        .WithMany("Servicos")
                        .HasForeignKey("ServicoImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.ServicosBarbeiros", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("ServicosBarbeiros")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.Barbeiros", "Barbeiros")
                        .WithMany("ServicosBarbeiros")
                        .HasForeignKey("BarbeirosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.Servicos", "Servicos")
                        .WithMany("ServicosBarbeiros")
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Users", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("Users")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
