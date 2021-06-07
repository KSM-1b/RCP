using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.Migrations
{
    public partial class AddingTableUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Workers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserID",
                table: "Workers",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_UserID",
                table: "Workers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_UserID",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Workers_UserID",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Workers");
        }
    }
}
