using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Idea2Tasks.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "SubTasks",
                newName: "DurationInHrs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationInHrs",
                table: "SubTasks",
                newName: "Duration");
        }
    }
}
