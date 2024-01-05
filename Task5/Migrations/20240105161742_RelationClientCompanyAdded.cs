using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task5.Migrations
{
    public partial class RelationClientCompanyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompanyId",
                table: "Client",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Company_CompanyId",
                table: "Client",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Company_CompanyId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CompanyId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Client");
        }
    }
}
