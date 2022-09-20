using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mybarber.Migrations
{
    public partial class BarbeariaStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Barbearias",
                columns: table => new
                {
                    IdBarbearia = table.Column<Guid>(nullable: false),
                    NomeBarbearia = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Route = table.Column<string>(nullable: true),
                    LandingPage = table.Column<bool>(nullable: false),
                    Ativa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearias", x => x.IdBarbearia);
                });

            migrationBuilder.CreateTable(
                name: "BarbeiroImagens",
                columns: table => new
                {
                    IdBarbeiroImagem = table.Column<Guid>(nullable: false),
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
                    IdImagemServico = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoImagens", x => x.IdImagemServico);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    IdContato = table.Column<Guid>(nullable: false),
                    Celulares = table.Column<List<string>>(nullable: true),
                    Telefones = table.Column<List<string>>(nullable: true),
                    Emails = table.Column<List<string>>(nullable: true),
                    Instagrams = table.Column<List<string>>(nullable: true),
                    Outros = table.Column<List<string>>(nullable: true),
                    BarbeariasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_Contatos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioFuncionamento",
                columns: table => new
                {
                    IdHorarioFuncionamento = table.Column<Guid>(nullable: false),
                    Funcionamento = table.Column<List<string>>(nullable: true),
                    BarbeariasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFuncionamento", x => x.IdHorarioFuncionamento);
                    table.ForeignKey(
                        name: "FK_HorarioFuncionamento_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    IdTema = table.Column<Guid>(nullable: false),
                    CorPrimaria = table.Column<string>(nullable: true),
                    CorSecundaria = table.Column<string>(nullable: true),
                    CorTernaria = table.Column<string>(nullable: true),
                    CorQuartenaria = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.IdTema);
                    table.ForeignKey(
                        name: "FK_Temas_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<Guid>(nullable: false)
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
                    IdBarbeiro = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    NameBarbeiro = table.Column<string>(nullable: false),
                    BarbeariasId = table.Column<Guid>(nullable: false),
                    BarbeiroImagemId = table.Column<Guid>(nullable: false)
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
                    IdServico = table.Column<Guid>(nullable: false),
                    NomeServico = table.Column<string>(nullable: false),
                    TempoServico = table.Column<DateTime>(nullable: false),
                    PrecoServico = table.Column<float>(nullable: false),
                    ServicoImagemId = table.Column<Guid>(nullable: false),
                    BarbeariasId = table.Column<Guid>(nullable: false)
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
                    IdAgendas = table.Column<Guid>(nullable: false),
                    Segunda = table.Column<List<float>>(nullable: true),
                    Terca = table.Column<List<float>>(nullable: true),
                    Quarta = table.Column<List<float>>(nullable: true),
                    Quinta = table.Column<List<float>>(nullable: true),
                    Sexta = table.Column<List<float>>(nullable: true),
                    Sabado = table.Column<List<float>>(nullable: true),
                    Domingo = table.Column<List<float>>(nullable: true),
                    BarbeirosId = table.Column<Guid>(nullable: false),
                    BarbeariasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgendas);
                    table.ForeignKey(
                        name: "FK_Agendas_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
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
                    IdAgendamento = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Contato = table.Column<string>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    ServicosId = table.Column<Guid>(nullable: false),
                    BarbeirosId = table.Column<Guid>(nullable: false),
                    BarbeariasId = table.Column<Guid>(nullable: false)
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
                    ServicosId = table.Column<Guid>(nullable: false),
                    BarbeirosId = table.Column<Guid>(nullable: false),
                    BarbeariasId = table.Column<Guid>(nullable: false)
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
                name: "IX_Agendas_BarbeariasId",
                table: "Agendas",
                column: "BarbeariasId");

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
                name: "IX_Contatos_BarbeariasId",
                table: "Contatos",
                column: "BarbeariasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_BarbeariasId",
                table: "Enderecos",
                column: "BarbeariasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionamento_BarbeariasId",
                table: "HorarioFuncionamento",
                column: "BarbeariasId",
                unique: true);

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
                name: "IX_Temas_BarbeariasId",
                table: "Temas",
                column: "BarbeariasId",
                unique: true);

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
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "HorarioFuncionamento");

            migrationBuilder.DropTable(
                name: "ServicosBarbeiros");

            migrationBuilder.DropTable(
                name: "Temas");

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
