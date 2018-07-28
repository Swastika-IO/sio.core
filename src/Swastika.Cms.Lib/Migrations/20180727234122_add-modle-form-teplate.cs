using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class addmodleformteplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormTemplate",
                table: "sioc_module",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormTemplate",
                table: "sioc_module");
        }
    }
}
