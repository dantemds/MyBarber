using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mybarber.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbearias",
                columns: table => new
                {
                    IdBarbearia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeBarbearia = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearias", x => x.IdBarbearia);
                });

            migrationBuilder.CreateTable(
                name: "BarbeiroImagens",
                columns: table => new
                {
                    IdBarbeiroImagem = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarbeiroImagens", x => x.IdBarbeiroImagem);
                });

            migrationBuilder.CreateTable(
                name: "ServicoImagens",
                columns: table => new
                {
                    IdImagemServico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoImagens", x => x.IdImagemServico);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barbeiros",
                columns: table => new
                {
                    IdBarbeiro = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    NameBarbeiro = table.Column<string>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false),
                    BarbeiroImagemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiros", x => x.IdBarbeiro);
                    table.ForeignKey(
                        name: "FK_Barbeiros_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barbeiros_BarbeiroImagens_BarbeiroImagemId",
                        column: x => x.BarbeiroImagemId,
                        principalTable: "BarbeiroImagens",
                        principalColumn: "IdBarbeiroImagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeServico = table.Column<string>(nullable: false),
                    TempoServico = table.Column<DateTime>(nullable: false),
                    PrecoServico = table.Column<float>(nullable: false),
                    ServicoImagemId = table.Column<int>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicos_ServicoImagens_ServicoImagemId",
                        column: x => x.ServicoImagemId,
                        principalTable: "ServicoImagens",
                        principalColumn: "IdImagemServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    IdAgendas = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Segunda = table.Column<List<float>>(nullable: true),
                    Terca = table.Column<List<float>>(nullable: true),
                    Quarta = table.Column<List<float>>(nullable: true),
                    Quinta = table.Column<List<float>>(nullable: true),
                    Sexta = table.Column<List<float>>(nullable: true),
                    Sabado = table.Column<List<float>>(nullable: true),
                    Domingo = table.Column<List<float>>(nullable: true),
                    BarbeirosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgendas);
                    table.ForeignKey(
                        name: "FK_Agendas_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Contato = table.Column<string>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    ServicosId = table.Column<int>(nullable: false),
                    BarbeirosId = table.Column<int>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicosBarbeiros",
                columns: table => new
                {
                    ServicosId = table.Column<int>(nullable: false),
                    BarbeirosId = table.Column<int>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosBarbeiros", x => new { x.ServicosId, x.BarbeirosId });
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeariasId",
                table: "Agendamentos",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeirosId",
                table: "Agendamentos",
                column: "BarbeirosId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicosId",
                table: "Agendamentos",
                column: "ServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_BarbeirosId",
                table: "Agendas",
                column: "BarbeirosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_BarbeariasId",
                table: "Barbeiros",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_BarbeiroImagemId",
                table: "Barbeiros",
                column: "BarbeiroImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BarbeariasId",
                table: "Servicos",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ServicoImagemId",
                table: "Servicos",
                column: "ServicoImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeariasId",
                table: "ServicosBarbeiros",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeirosId",
                table: "ServicosBarbeiros",
                column: "BarbeirosId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BarbeariasId",
                table: "Users",
                column: "BarbeariasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "ServicosBarbeiros");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Barbeiros");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "BarbeiroImagens");

            migrationBuilder.DropTable(
                name: "Barbearias");

            migrationBuilder.DropTable(
                name: "ServicoImagens");
        }
    }
}
