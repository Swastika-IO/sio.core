using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class adddefaultlanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "sioc_language",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "sioc_language");
        }
    }
}
