using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VeiculosAPI.Repository.Seeds;

namespace VeiculosAPI.Migrations
{
    public partial class create_marcas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", nullable: true, maxLength: 255).Annotation("MySql:CharSet", "utf8mb4"),
                    logo = table.Column<string>(type: "varchar(255)", nullable: true, maxLength: 255).Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_marcas", x => x.id); }).Annotation("MySql:CharSet", "utf8mb4");

            MarcasSeed.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "marcas");
        }
    }
}
