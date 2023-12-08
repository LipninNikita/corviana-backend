using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quest.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TimesToFinish = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false),
                    QuestLifeTime = table.Column<byte>(type: "smallint", nullable: false),
                    QuestType = table.Column<byte>(type: "smallint", nullable: false),
                    DtCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quests");
        }
    }
}
