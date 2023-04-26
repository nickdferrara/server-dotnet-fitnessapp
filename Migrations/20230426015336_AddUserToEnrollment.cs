using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnrollmentId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnrollmentId",
                table: "Users",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enrollments_EnrollmentId",
                table: "Users",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enrollments_EnrollmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EnrollmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Users");
        }
    }
}
