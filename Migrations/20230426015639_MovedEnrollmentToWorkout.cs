using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    /// <inheritdoc />
    public partial class MovedEnrollmentToWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enrollments_EnrollmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Enrollments_EnrollmentId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_EnrollmentId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                table: "Users",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EnrollmentId",
                table: "Users",
                newName: "IX_Users_WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Workouts_WorkoutId",
                table: "Users",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Workouts_WorkoutId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "Users",
                newName: "EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_WorkoutId",
                table: "Users",
                newName: "IX_Users_EnrollmentId");

            migrationBuilder.AddColumn<Guid>(
                name: "EnrollmentId",
                table: "Workouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_EnrollmentId",
                table: "Workouts",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enrollments_EnrollmentId",
                table: "Users",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Enrollments_EnrollmentId",
                table: "Workouts",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
