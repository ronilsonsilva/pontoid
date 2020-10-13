using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoID.Data.Context.Migrations
{
    public partial class Migration_0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 429, DateTimeKind.Local).AddTicks(7322)),
                    Atualizado = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 440, DateTimeKind.Local).AddTicks(2800)),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 502, DateTimeKind.Local).AddTicks(7369)),
                    Atualizado = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 503, DateTimeKind.Local).AddTicks(1186)),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    CodigoINEP = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 532, DateTimeKind.Local).AddTicks(3066)),
                    Atualizado = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 532, DateTimeKind.Local).AddTicks(4403)),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    Descricao = table.Column<string>(maxLength: 4096, nullable: true),
                    Turno = table.Column<byte>(nullable: false),
                    EscolaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Escola_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 540, DateTimeKind.Local).AddTicks(5654)),
                    Atualizado = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 12, 19, 36, 28, 540, DateTimeKind.Local).AddTicks(6424)),
                    TurmaId = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_AlunoId",
                table: "AlunoTurma",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_TurmaId",
                table: "AlunoTurma",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_EscolaId",
                table: "Turma",
                column: "EscolaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
