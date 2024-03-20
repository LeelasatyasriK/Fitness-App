using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercises_goals_GoalID",
                table: "exercises");

            migrationBuilder.DropIndex(
                name: "IX_exercises_GoalID",
                table: "exercises");

            migrationBuilder.DropColumn(
                name: "GoalID",
                table: "exercises");

            migrationBuilder.CreateTable(
                name: "ExercisesGoals",
                columns: table => new
                {
                    exercisesExerciseID = table.Column<int>(type: "int", nullable: false),
                    goalsGoalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesGoals", x => new { x.exercisesExerciseID, x.goalsGoalID });
                    table.ForeignKey(
                        name: "FK_ExercisesGoals_exercises_exercisesExerciseID",
                        column: x => x.exercisesExerciseID,
                        principalTable: "exercises",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesGoals_goals_goalsGoalID",
                        column: x => x.goalsGoalID,
                        principalTable: "goals",
                        principalColumn: "GoalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesGoals_goalsGoalID",
                table: "ExercisesGoals",
                column: "goalsGoalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisesGoals");

            migrationBuilder.AddColumn<int>(
                name: "GoalID",
                table: "exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_exercises_GoalID",
                table: "exercises",
                column: "GoalID");

            migrationBuilder.AddForeignKey(
                name: "FK_exercises_goals_GoalID",
                table: "exercises",
                column: "GoalID",
                principalTable: "goals",
                principalColumn: "GoalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
