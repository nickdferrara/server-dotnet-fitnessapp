using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    /// <inheritdoc />
    public partial class MakeEntitiesOutOfList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Waitlist_WorkoutId",
                table: "Waitlist");

            migrationBuilder.DropIndex(
                name: "IX_Roster_WorkoutId",
                table: "Roster");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlist_WorkoutId",
                table: "Waitlist",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roster_WorkoutId",
                table: "Roster",
                column: "WorkoutId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Waitlist_WorkoutId",
                table: "Waitlist");

            migrationBuilder.DropIndex(
                name: "IX_Roster_WorkoutId",
                table: "Roster");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlist_WorkoutId",
                table: "Waitlist",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Roster_WorkoutId",
                table: "Roster",
                column: "WorkoutId");
        }
    }
}
