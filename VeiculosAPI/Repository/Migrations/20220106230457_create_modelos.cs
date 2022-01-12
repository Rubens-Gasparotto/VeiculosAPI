using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VeiculosAPI.Repository.Seeds;

namespace VeiculosAPI.Migrations
{
    public partial class create_modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    inicio_fabricacao = table.Column<int>(type: "int", nullable: false),
                    fim_fabricacao = table.Column<int>(type: "int", nullable: true),
                    imagem = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    marca_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.id);
                    table.ForeignKey("marca_foreign_key", x => x.marca_id, "marcas", "id", "veiculos", ReferentialAction.NoAction, ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            ModelosSeed.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "modelos");
        }
    }
}
