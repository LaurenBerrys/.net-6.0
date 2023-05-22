using Microsoft.EntityFrameworkCore.Migrations;

namespace EveroneAPI.Migrations
{
    public partial class CreateOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(20)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 30, nullable: false),
                    UserPwd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 30, nullable: true),
                    Bak = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoping");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
