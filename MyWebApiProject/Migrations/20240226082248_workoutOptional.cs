using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class workoutOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_workouts_WorkoutID",
                table: "exercises");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutID",
                table: "exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_workouts_WorkoutID",
                table: "exercises",
                column: "WorkoutID",
                principalTable: "workouts",
                principalColumn: "WorkoutID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_workouts_WorkoutID",
                table: "exercises");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutID",
                table: "exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_workouts_WorkoutID",
                table: "exercises",
                column: "WorkoutID",
                principalTable: "workouts",
                principalColumn: "WorkoutID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
