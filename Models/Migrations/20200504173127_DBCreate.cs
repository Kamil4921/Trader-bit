using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class DBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Tid = table.Column<string>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Tid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
