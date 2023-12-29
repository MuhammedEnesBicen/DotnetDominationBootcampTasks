using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4.Migrations
{
    public partial class WebUserBetweenOrderManyToManyJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderWebUser",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    WebUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWebUser", x => new { x.OrdersId, x.WebUsersId });
                    table.ForeignKey(
                        name: "FK_OrderWebUser_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWebUser_WebUsers_WebUsersId",
                        column: x => x.WebUsersId,
                        principalTable: "WebUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderWebUser_WebUsersId",
                table: "OrderWebUser",
                column: "WebUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWebUser");
        }
    }
}
