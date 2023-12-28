using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Answer.API.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annotation",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "IdQuestion",
                table: "Answers",
                newName: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "IdQuestion");

            migrationBuilder.AddColumn<string>(
                name: "Annotation",
                table: "Answers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
