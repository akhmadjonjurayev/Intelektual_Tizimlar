using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelektual_Tizimlar_Amaliyot.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "intelekt");

            migrationBuilder.CreateTable(
                name: "Agreements",
                schema: "intelekt",
                columns: table => new
                {
                    AgreementId = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
                });

            migrationBuilder.CreateTable(
                name: "Atributes",
                schema: "intelekt",
                columns: table => new
                {
                    AtributeId = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    AtributeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributes", x => x.AtributeId);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                schema: "intelekt",
                columns: table => new
                {
                    ConditionId = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ConditionValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Situations",
                schema: "intelekt",
                columns: table => new
                {
                    SituationId = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    AgreementId = table.Column<Guid>(nullable: false),
                    ConditionId = table.Column<Guid>(nullable: false),
                    AtributeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situations", x => x.SituationId);
                    table.ForeignKey(
                        name: "FK_Situations_Atributes_AgreementId",
                        column: x => x.AgreementId,
                        principalSchema: "intelekt",
                        principalTable: "Atributes",
                        principalColumn: "AtributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Situations_Agreements_AtributeId",
                        column: x => x.AtributeId,
                        principalSchema: "intelekt",
                        principalTable: "Agreements",
                        principalColumn: "AgreementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Situations_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "intelekt",
                        principalTable: "Conditions",
                        principalColumn: "ConditionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Situations_AgreementId",
                schema: "intelekt",
                table: "Situations",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Situations_AtributeId",
                schema: "intelekt",
                table: "Situations",
                column: "AtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Situations_ConditionId",
                schema: "intelekt",
                table: "Situations",
                column: "ConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Situations",
                schema: "intelekt");

            migrationBuilder.DropTable(
                name: "Atributes",
                schema: "intelekt");

            migrationBuilder.DropTable(
                name: "Agreements",
                schema: "intelekt");

            migrationBuilder.DropTable(
                name: "Conditions",
                schema: "intelekt");
        }
    }
}
