using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sioc_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    FullName = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    UpdatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sioc_copy",
                columns: table => new
                {
                    Culture = table.Column<string>(maxLength: 10, nullable: false),
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Note = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_copy", x => new { x.Culture, x.Keyword });
                });

            migrationBuilder.CreateTable(
                name: "sioc_culture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    FullName = table.Column<string>(maxLength: 150, nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    LCID = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_culture", x => x.Id);
                    table.UniqueConstraint("AK_sioc_culture_Specificulture", x => x.Specificulture);
                });

            migrationBuilder.CreateTable(
                name: "sioc_media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "('en-us')"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FileProperties = table.Column<string>(maxLength: 4000, nullable: true),
                    FileSize = table.Column<long>(nullable: false, defaultValueSql: "((0))"),
                    FileType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Title = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_media", x => new { x.Id, x.Specificulture });
                });

            migrationBuilder.CreateTable(
                name: "sioc_parameter",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_parameter", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "sioc_position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sioc_theme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sioc_article",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(type: "ntext", nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    Source = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_article", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Article_TTS_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CssClass = table.Column<string>(maxLength: 50, nullable: true),
                    Excerpt = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Layout = table.Column<string>(maxLength: 50, nullable: true),
                    Level = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    StaticUrl = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_TTS_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_configuration",
                columns: table => new
                {
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Category = table.Column<string>(maxLength: 250, nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_configuration", x => new { x.Keyword, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sioc_Configuration_Sioc_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sioc_language",
                columns: table => new
                {
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Category = table.Column<string>(maxLength: 250, nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_language", x => new { x.Keyword, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sioc_Language_Sioc_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Fields = table.Column<string>(maxLength: 4000, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Type = table.Column<int>(nullable: false, defaultValueSql: "('0')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_TTS_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sioc_product",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(type: "ntext", nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: false, defaultValueSql: "((0))"),
                    PriceUnit = table.Column<string>(maxLength: 10, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    Source = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Product_TTS_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_file",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FolderType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    ThemeId = table.Column<int>(nullable: true),
                    ThemeName = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_file", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sioc_file_sioc_template",
                        column: x => x.ThemeId,
                        principalTable: "sioc_theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_template",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FolderType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    MobileContent = table.Column<string>(type: "ntext", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Scripts = table.Column<string>(type: "ntext", nullable: true),
                    SpaContent = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Styles = table.Column<string>(type: "ntext", nullable: true),
                    TemplateId = table.Column<int>(nullable: false),
                    TemplateName = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sioc_template_file_sioc_template",
                        column: x => x.TemplateId,
                        principalTable: "sioc_theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_article_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_article_media", x => new { x.MediaId, x.ArticleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_article_media_sioc_article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_article_media_sioc_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sioc_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_article",
                columns: table => new
                {
                    ArticleId = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_article", x => new { x.ArticleId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Article_TTS_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Category_Article_TTS_Category",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_category", x => new { x.Id, x.ParentId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Category_TTS_Category",
                        columns: x => new { x.Id, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Category_Category_TTS_Category1",
                        columns: x => new { x.ParentId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_position",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_position", x => new { x.PositionId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Position_TTS_Position",
                        column: x => x.PositionId,
                        principalTable: "sioc_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_Category_Position_TTS_Category",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_article_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_article_module", x => new { x.ModuleId, x.ArticleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Article_Module_TTS_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Article_Module_TTS_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_module", x => new { x.ModuleId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Module_TTS_Category",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Menu_Module_TTS_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module_article",
                columns: table => new
                {
                    ArticleId = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_article", x => new { x.ArticleId, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_Article_TTS_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Article_TTS_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_product",
                columns: table => new
                {
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_product", x => new { x.ProductId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Product_TTS_Category",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Category_Product_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module_product",
                columns: table => new
                {
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_product", x => new { x.ProductId, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_Product_TTS_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Product_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_product_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product_media", x => new { x.MediaId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_product_media_sioc_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sioc_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_product_media_sioc_product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_product_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product_module", x => new { x.ModuleId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Product_Module_TTS_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_Product_Module_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_related_product",
                columns: table => new
                {
                    SourceProductId = table.Column<string>(maxLength: 50, nullable: false),
                    RelatedProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_related_product", x => new { x.SourceProductId, x.RelatedProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_related_product_sioc_product1",
                        columns: x => new { x.RelatedProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_related_product_sioc_product",
                        columns: x => new { x.SourceProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module_attribute_set",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    ArticleId = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fields = table.Column<string>(maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_attribute_set", x => new { x.Id, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_Attribute_set_TTS_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Attribute_set_TTS_Article_Module",
                        columns: x => new { x.ModuleId, x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article_module",
                        principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Attribute_set_TTS_Category_Module",
                        columns: x => new { x.ModuleId, x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category_module",
                        principalColumns: new[] { "ModuleId", "CategoryId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module_data",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    ArticleId = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fields = table.Column<string>(maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    ProductId = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_data", x => new { x.Id, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_Data_TTS_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Data_TTS_Category_Module",
                        columns: x => new { x.ModuleId, x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category_module",
                        principalColumns: new[] { "ModuleId", "CategoryId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Data_TTS_Product_Module",
                        columns: x => new { x.ModuleId, x.ProductId, x.Specificulture },
                        principalTable: "sioc_article_module",
                        principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_module_attribute_value",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttributeSetId = table.Column<Guid>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(type: "ntext", nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Width = table.Column<int>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_attribute_value", x => new { x.Id, x.AttributeSetId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_module_attribute_value_sioc_module_attribute_set",
                        columns: x => new { x.AttributeSetId, x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module_attribute_set",
                        principalColumns: new[] { "Id", "ModuleId", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_Specificulture",
                table: "sioc_article",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_media_ArticleId_Specificulture",
                table: "sioc_article_media",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_media_MediaId_Specificulture",
                table: "sioc_article_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_module_ArticleId_Specificulture",
                table: "sioc_article_module",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_module_ModuleId_Specificulture",
                table: "sioc_article_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_Specificulture",
                table: "sioc_category",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_article_ArticleId_Specificulture",
                table: "sioc_category_article",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_article_CategoryId_Specificulture",
                table: "sioc_category_article",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_category_Id_Specificulture",
                table: "sioc_category_category",
                columns: new[] { "Id", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_category_ParentId_Specificulture",
                table: "sioc_category_category",
                columns: new[] { "ParentId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_module_CategoryId_Specificulture",
                table: "sioc_category_module",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_module_ModuleId_Specificulture",
                table: "sioc_category_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_position_CategoryId_Specificulture",
                table: "sioc_category_position",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_product_CategoryId_Specificulture",
                table: "sioc_category_product",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_product_ProductId_Specificulture",
                table: "sioc_category_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_configuration_Specificulture",
                table: "sioc_configuration",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_Culture",
                table: "sioc_culture",
                column: "Specificulture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sioc_file_ThemeId",
                table: "sioc_file",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_language_Specificulture",
                table: "sioc_language",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_Specificulture",
                table: "sioc_module",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_article_ArticleId_Specificulture",
                table: "sioc_module_article",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_article_ModuleId_Specificulture",
                table: "sioc_module_article",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_attribute_set_ModuleId_Specificulture",
                table: "sioc_module_attribute_set",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_attribute_set_ModuleId_ArticleId_Specificulture",
                table: "sioc_module_attribute_set",
                columns: new[] { "ModuleId", "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_attribute_set_ModuleId_CategoryId_Specificulture",
                table: "sioc_module_attribute_set",
                columns: new[] { "ModuleId", "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_attribute_value_AttributeSetId_ModuleId_Specificulture",
                table: "sioc_module_attribute_value",
                columns: new[] { "AttributeSetId", "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_data_ModuleId_Specificulture",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_data_ModuleId_ArticleId_Specificulture",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_data_ModuleId_CategoryId_Specificulture",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_data_ModuleId_ProductId_Specificulture",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_product_ModuleId_Specificulture",
                table: "sioc_module_product",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_product_ProductId_Specificulture",
                table: "sioc_module_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_Specificulture",
                table: "sioc_product",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_media_MediaId_Specificulture",
                table: "sioc_product_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_media_ProductId_Specificulture",
                table: "sioc_product_media",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_module_ModuleId_Specificulture",
                table: "sioc_product_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_module_ProductId_Specificulture",
                table: "sioc_product_module",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_RelatedProductId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "RelatedProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_SourceProductId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "SourceProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_template_file_TemplateId",
                table: "sioc_template",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_article_media");

            migrationBuilder.DropTable(
                name: "sioc_category_article");

            migrationBuilder.DropTable(
                name: "sioc_category_category");

            migrationBuilder.DropTable(
                name: "sioc_category_position");

            migrationBuilder.DropTable(
                name: "sioc_category_product");

            migrationBuilder.DropTable(
                name: "sioc_comment");

            migrationBuilder.DropTable(
                name: "sioc_configuration");

            migrationBuilder.DropTable(
                name: "sioc_copy");

            migrationBuilder.DropTable(
                name: "sioc_file");

            migrationBuilder.DropTable(
                name: "sioc_language");

            migrationBuilder.DropTable(
                name: "sioc_module_article");

            migrationBuilder.DropTable(
                name: "sioc_module_attribute_value");

            migrationBuilder.DropTable(
                name: "sioc_module_data");

            migrationBuilder.DropTable(
                name: "sioc_module_product");

            migrationBuilder.DropTable(
                name: "sioc_parameter");

            migrationBuilder.DropTable(
                name: "sioc_product_media");

            migrationBuilder.DropTable(
                name: "sioc_product_module");

            migrationBuilder.DropTable(
                name: "sioc_related_product");

            migrationBuilder.DropTable(
                name: "sioc_template");

            migrationBuilder.DropTable(
                name: "sioc_position");

            migrationBuilder.DropTable(
                name: "sioc_module_attribute_set");

            migrationBuilder.DropTable(
                name: "sioc_media");

            migrationBuilder.DropTable(
                name: "sioc_product");

            migrationBuilder.DropTable(
                name: "sioc_theme");

            migrationBuilder.DropTable(
                name: "sioc_article_module");

            migrationBuilder.DropTable(
                name: "sioc_category_module");

            migrationBuilder.DropTable(
                name: "sioc_article");

            migrationBuilder.DropTable(
                name: "sioc_category");

            migrationBuilder.DropTable(
                name: "sioc_module");

            migrationBuilder.DropTable(
                name: "sioc_culture");
        }
    }
}