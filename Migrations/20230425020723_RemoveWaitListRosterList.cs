using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWaitListRosterList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roster_RosterId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Waitlist_WaitlistId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roster");

            migrationBuilder.DropTable(
                name: "Waitlist");

            migrationBuilder.DropIndex(
                name: "IX_Users_RosterId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WaitlistId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WaitlistId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RosterId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WaitlistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roster",
                columns: table => new
                {
                    RosterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roster", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_Roster_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Waitlist",
                columns: table => new
                {
                    WaitlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitlist", x => x.WaitlistId);
                    table.ForeignKey(
                        name: "FK_Waitlist_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RosterId",
                table: "Users",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WaitlistId",
                table: "Users",
                column: "WaitlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Roster_WorkoutId",
                table: "Roster",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Waitlist_WorkoutId",
                table: "Waitlist",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roster_RosterId",
                table: "Users",
                column: "RosterId",
                principalTable: "Roster",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Waitlist_WaitlistId",
                table: "Users",
                column: "WaitlistId",
                principalTable: "Waitlist",
                principalColumn: "WaitlistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
