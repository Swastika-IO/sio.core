using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class update_identity_role_portal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "sioc_product",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "sioc_cms_user",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Username = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_cms_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sioc_portal_page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    RouteAction = table.Column<string>(maxLength: 50, nullable: true),
                    RouteName = table.Column<string>(maxLength: 50, nullable: true),
                    RouteValue = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_portal_page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sioc_portal_page_navigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_portal_page_navigation", x => new { x.Id, x.ParentId });
                    table.ForeignKey(
                        name: "FK_sioc_portal_page_navigation_sioc_portal_page",
                        column: x => x.Id,
                        principalTable: "sioc_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_portal_page_navigation_sioc_portal_page1",
                        column: x => x.ParentId,
                        principalTable: "sioc_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_portal_page_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PageId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    RoleId = table.Column<string>(maxLength: 450, nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_portal_page_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sioc_portal_page_role_sioc_portal_page",
                        column: x => x.PageId,
                        principalTable: "sioc_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_portal_page_navigation_ParentId",
                table: "sioc_portal_page_navigation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_portal_page_role_PageId",
                table: "sioc_portal_page_role",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_cms_user");

            migrationBuilder.DropTable(
                name: "sioc_portal_page_navigation");

            migrationBuilder.DropTable(
                name: "sioc_portal_page_role");

            migrationBuilder.DropTable(
                name: "sioc_portal_page");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "sioc_product",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValueSql: "(N'')");
        }
    }
}
