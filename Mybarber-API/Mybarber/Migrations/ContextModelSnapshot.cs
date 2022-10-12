﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mybarber.Persistencia;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mybarber.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Mybarber.Models.Agendamentos", b =>
                {
                    b.Property<Guid>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeirosId")
                        .HasColumnType("uuid");

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

                    b.Property<Guid>("ServicosId")
                        .HasColumnType("uuid");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeirosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Mybarber.Models.Agendas", b =>
                {
                    b.Property<Guid>("IdAgendas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeirosId")
                        .HasColumnType("uuid");

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

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeirosId")
                        .IsUnique();

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Mybarber.Models.Banner", b =>
                {
                    b.Property<Guid>("IdBanner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Mobile")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdBanner");

                    b.HasIndex("BarbeariasId");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("Mybarber.Models.Barbearias", b =>
                {
                    b.Property<Guid>("IdBarbearia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativa")
                        .HasColumnType("boolean");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("FuncaoAgendamento")
                        .HasColumnType("boolean");

                    b.Property<string>("NomeBarbearia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Route")
                        .HasColumnType("text");

                    b.HasKey("IdBarbearia");

                    b.ToTable("Barbearias");
                });

            modelBuilder.Entity("Mybarber.Models.BarbeiroImagens", b =>
                {
                    b.Property<Guid>("IdBarbeiroImagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeirosId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdBarbeiroImagem");

                    b.HasIndex("BarbeirosId")
                        .IsUnique();

                    b.ToTable("BarbeiroImagens");
                });

            modelBuilder.Entity("Mybarber.Models.Barbeiros", b =>
                {
                    b.Property<Guid>("IdBarbeiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("NameBarbeiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("IdBarbeiro");

                    b.HasIndex("BarbeariasId");

                    b.ToTable("Barbeiros");
                });

            modelBuilder.Entity("Mybarber.Models.Contatos", b =>
                {
                    b.Property<Guid>("IdContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Celulares")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Emails")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Instagrams")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Outros")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Telefones")
                        .HasColumnType("text[]");

                    b.HasKey("IdContato");

                    b.HasIndex("BarbeariasId")
                        .IsUnique();

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Mybarber.Models.Enderecos", b =>
                {
                    b.Property<Guid>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<string>("CEP")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.HasKey("IdEndereco");

                    b.HasIndex("BarbeariasId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Mybarber.Models.HorarioFuncionamento", b =>
                {
                    b.Property<Guid>("IdHorarioFuncionamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Funcionamento")
                        .HasColumnType("text[]");

                    b.HasKey("IdHorarioFuncionamento");

                    b.HasIndex("BarbeariasId")
                        .IsUnique();

                    b.ToTable("HorarioFuncionamento");
                });

            modelBuilder.Entity("Mybarber.Models.LandingPageImages", b =>
                {
                    b.Property<Guid>("IdLandingPageImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<string>("Especificacao")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumeroImagem")
                        .HasColumnType("integer");

                    b.Property<string>("Posicao")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdLandingPageImage");

                    b.HasIndex("BarbeariasId");

                    b.ToTable("LandingPageImages");
                });

            modelBuilder.Entity("Mybarber.Models.ServicoImagens", b =>
                {
                    b.Property<Guid>("IdImagemServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("ServicosId")
                        .HasColumnType("uuid");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("IdImagemServico");

                    b.HasIndex("ServicosId")
                        .IsUnique();

                    b.ToTable("ServicoImagens");
                });

            modelBuilder.Entity("Mybarber.Models.Servicos", b =>
                {
                    b.Property<Guid>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<string>("NomeServico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("PrecoServico")
                        .HasColumnType("real");

                    b.Property<DateTime>("TempoServico")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdServico");

                    b.HasIndex("BarbeariasId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Mybarber.Models.ServicosBarbeiros", b =>
                {
                    b.Property<Guid>("ServicosId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeirosId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.HasKey("ServicosId", "BarbeirosId");

                    b.HasIndex("BarbeariasId");

                    b.HasIndex("BarbeirosId");

                    b.ToTable("ServicosBarbeiros");
                });

            modelBuilder.Entity("Mybarber.Models.Temas", b =>
                {
                    b.Property<Guid>("IdTema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

                    b.Property<string>("CorPrimaria")
                        .HasColumnType("text");

                    b.Property<string>("CorQuartenaria")
                        .HasColumnType("text");

                    b.Property<string>("CorSecundaria")
                        .HasColumnType("text");

                    b.Property<string>("CorTernaria")
                        .HasColumnType("text");

                    b.HasKey("IdTema");

                    b.HasIndex("BarbeariasId")
                        .IsUnique();

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("Mybarber.Models.Users", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BarbeariasId")
                        .HasColumnType("uuid");

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
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany()
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mybarber.Models.Barbeiros", "Barbeiros")
                        .WithOne("Agendas")
                        .HasForeignKey("Mybarber.Models.Agendas", "BarbeirosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Banner", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("Banner")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.BarbeiroImagens", b =>
                {
                    b.HasOne("Mybarber.Models.Barbeiros", "Barbeiros")
                        .WithOne("BarbeiroImagem")
                        .HasForeignKey("Mybarber.Models.BarbeiroImagens", "BarbeirosId")
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
                });

            modelBuilder.Entity("Mybarber.Models.Contatos", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithOne("Contatos")
                        .HasForeignKey("Mybarber.Models.Contatos", "BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.Enderecos", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithOne("Enderecos")
                        .HasForeignKey("Mybarber.Models.Enderecos", "BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.HorarioFuncionamento", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithOne("HorarioFuncionamento")
                        .HasForeignKey("Mybarber.Models.HorarioFuncionamento", "BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.LandingPageImages", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithMany("LandingPageImages")
                        .HasForeignKey("BarbeariasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mybarber.Models.ServicoImagens", b =>
                {
                    b.HasOne("Mybarber.Models.Servicos", "Servicos")
                        .WithOne("ServicoImagem")
                        .HasForeignKey("Mybarber.Models.ServicoImagens", "ServicosId")
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

            modelBuilder.Entity("Mybarber.Models.Temas", b =>
                {
                    b.HasOne("Mybarber.Models.Barbearias", "Barbearias")
                        .WithOne("Temas")
                        .HasForeignKey("Mybarber.Models.Temas", "BarbeariasId")
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
