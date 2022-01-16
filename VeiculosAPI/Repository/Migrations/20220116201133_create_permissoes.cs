using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using VeiculosAPI.Repository.Seeds;

namespace VeiculosAPI.Migrations
{
    public partial class create_permissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    tipo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false).Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_permissoes", x => x.id)).Annotation("MySql:CharSet", "utf8mb4");

            PermissoesSeed.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("permissoes");
        }
    }
}
