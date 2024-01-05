using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task5.Migrations
{
    public partial class ReservationTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservatedTime",
                table: "Reservation",
                newName: "ReservationEndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationEndDate",
                table: "Reservation",
                newName: "ReservatedTime");
        }
    }
}
