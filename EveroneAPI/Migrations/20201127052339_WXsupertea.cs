using Microsoft.EntityFrameworkCore.Migrations;

namespace EveroneAPI.Migrations
{
    public partial class WXsupertea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Sugarcontent = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    temperature = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WXuser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 30, nullable: false),
                    phone = table.Column<int>(type: "int", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WXuser", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropTable(
                name: "WXuser");
        }
    }
}
