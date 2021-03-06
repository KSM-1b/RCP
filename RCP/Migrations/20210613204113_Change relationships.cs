using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.Migrations
{
    public partial class Changerelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Clients_ClientID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Workers_WorkerID",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerID",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Clients_ClientID",
                table: "Reports",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Workers_WorkerID",
                table: "Reports",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Clients_ClientID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Workers_WorkerID",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerID",
                table: "Reports",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Reports",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Clients_ClientID",
                table: "Reports",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Workers_WorkerID",
                table: "Reports",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
