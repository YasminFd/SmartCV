using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedIn_URL",
                table: "resumes");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "resumes",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "resumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicUrl",
                table: "resumes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "grade",
                table: "resumes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicUrl",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "resumes");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "resumes",
                newName: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn_URL",
                table: "resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
