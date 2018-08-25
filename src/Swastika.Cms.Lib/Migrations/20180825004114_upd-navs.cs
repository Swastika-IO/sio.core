using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class updnavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sioc_related_product_sioc_product1",
                table: "sioc_related_product");

            migrationBuilder.DropForeignKey(
                name: "FK_sioc_related_product_sioc_product",
                table: "sioc_related_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sioc_related_product",
                table: "sioc_related_product");

            migrationBuilder.DropIndex(
                name: "IX_sioc_related_product_SourceProductId_Specificulture",
                table: "sioc_related_product");

            migrationBuilder.DropColumn(
                name: "SourceProductId",
                table: "sioc_related_product");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "sioc_related_product",
                newName: "DestinationId");

            migrationBuilder.RenameColumn(
                name: "RelatedProductId",
                table: "sioc_related_product",
                newName: "SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_sioc_related_product_RelatedProductId_Specificulture",
                table: "sioc_related_product",
                newName: "IX_sioc_related_product_SourceId_Specificulture");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_related_product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_related_product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "sioc_product",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sioc_related_product",
                table: "sioc_related_product",
                columns: new[] { "SourceId", "DestinationId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_DestinationId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "DestinationId", "Specificulture" });

            migrationBuilder.AddForeignKey(
                name: "FK_sioc_related_product_sioc_product1",
                table: "sioc_related_product",
                columns: new[] { "DestinationId", "Specificulture" },
                principalTable: "sioc_product",
                principalColumns: new[] { "Id", "Specificulture" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sioc_related_product_sioc_product",
                table: "sioc_related_product",
                columns: new[] { "SourceId", "Specificulture" },
                principalTable: "sioc_product",
                principalColumns: new[] { "Id", "Specificulture" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sioc_related_product_sioc_product1",
                table: "sioc_related_product");

            migrationBuilder.DropForeignKey(
                name: "FK_sioc_related_product_sioc_product",
                table: "sioc_related_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sioc_related_product",
                table: "sioc_related_product");

            migrationBuilder.DropIndex(
                name: "IX_sioc_related_product_DestinationId_Specificulture",
                table: "sioc_related_product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_related_product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_related_product");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "sioc_related_product",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "sioc_related_product",
                newName: "RelatedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_sioc_related_product_SourceId_Specificulture",
                table: "sioc_related_product",
                newName: "IX_sioc_related_product_RelatedProductId_Specificulture");

            migrationBuilder.AddColumn<string>(
                name: "SourceProductId",
                table: "sioc_related_product",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "sioc_product",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sioc_related_product",
                table: "sioc_related_product",
                columns: new[] { "SourceProductId", "RelatedProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_SourceProductId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "SourceProductId", "Specificulture" });

            migrationBuilder.AddForeignKey(
                name: "FK_sioc_related_product_sioc_product1",
                table: "sioc_related_product",
                columns: new[] { "RelatedProductId", "Specificulture" },
                principalTable: "sioc_product",
                principalColumns: new[] { "Id", "Specificulture" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sioc_related_product_sioc_product",
                table: "sioc_related_product",
                columns: new[] { "SourceProductId", "Specificulture" },
                principalTable: "sioc_product",
                principalColumns: new[] { "Id", "Specificulture" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
