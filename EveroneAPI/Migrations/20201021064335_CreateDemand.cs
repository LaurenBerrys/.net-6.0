using Microsoft.EntityFrameworkCore.Migrations;

namespace EveroneAPI.Migrations
{
    public partial class CreateDemand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demand",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    datatime = table.Column<decimal>(nullable: true),
                    theme = table.Column<string>(nullable: true),
                    Tranprice = table.Column<string>(nullable: true),
                    imagesrc = table.Column<string>(nullable: true),
                    Transactor = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: true),
                    price = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demand", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demand");
        }
    }
}
