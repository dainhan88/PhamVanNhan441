using Microsoft.EntityFrameworkCore.Migrations;

namespace PhamVanNhan441.Migrations
{
    public partial class createtableandVIETHOA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyPVN441",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPVN441", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "PVN0441",
                columns: table => new
                {
                    PVNID = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PVNName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PVNGender = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVN0441", x => x.PVNID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyPVN441");

            migrationBuilder.DropTable(
                name: "PVN0441");
        }
    }
}
