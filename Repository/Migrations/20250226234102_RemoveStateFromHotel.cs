using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStateFromHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Hotels");

            migrationBuilder.Sql("ALTER TABLE \"Reservations\" ALTER COLUMN \"Status\" TYPE integer USING \"Status\"::integer;");


            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Guests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Guests");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
