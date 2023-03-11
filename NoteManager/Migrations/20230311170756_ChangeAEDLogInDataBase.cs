using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteManager.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAEDLogInDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "AddEditDeleteLogs",
                newName: "NoteText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteText",
                table: "AddEditDeleteLogs",
                newName: "NoteID");
        }
    }
}
