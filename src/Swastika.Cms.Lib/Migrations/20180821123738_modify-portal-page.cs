using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class modifyportalpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "sioc_portal_page");

            migrationBuilder.DropColumn(
                name: "RouteAction",
                table: "sioc_portal_page");

            migrationBuilder.RenameColumn(
                name: "RouteValue",
                table: "sioc_portal_page",
                newName: "TextKeyword");

            migrationBuilder.RenameColumn(
                name: "RouteName",
                table: "sioc_portal_page",
                newName: "Icon");

            migrationBuilder.AddColumn<string>(
                name: "Descriotion",
                table: "sioc_portal_page",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextDefault",
                table: "sioc_portal_page",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriotion",
                table: "sioc_portal_page");

            migrationBuilder.DropColumn(
                name: "TextDefault",
                table: "sioc_portal_page");

            migrationBuilder.RenameColumn(
                name: "TextKeyword",
                table: "sioc_portal_page",
                newName: "RouteValue");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "sioc_portal_page",
                newName: "RouteName");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "sioc_portal_page",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteAction",
                table: "sioc_portal_page",
                maxLength: 50,
                nullable: true);
        }
    }
}
