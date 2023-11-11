using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_dotnet_fitnessapp.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationToWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinuteDuration",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinuteDuration",
                table: "Workouts");
        }
    }
}
