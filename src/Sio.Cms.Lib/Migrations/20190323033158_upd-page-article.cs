using Microsoft.EntityFrameworkCore.Migrations;

namespace Sio.Cms.Lib.Migrations
{
    public partial class updpagearticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraFields",
                table: "sio_page",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraFields",
                table: "sio_article",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraFields",
                table: "sio_page");

            migrationBuilder.DropColumn(
                name: "ExtraFields",
                table: "sio_article");
        }
    }
}
