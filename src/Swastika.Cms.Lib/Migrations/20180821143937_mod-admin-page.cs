using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class modadminpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "sioc_portal_page");

            migrationBuilder.RenameColumn(
                name: "Descriotion",
                table: "sioc_portal_page",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "sioc_portal_page",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "sioc_portal_page",
                newName: "Descriotion");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "sioc_portal_page",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "sioc_portal_page",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
