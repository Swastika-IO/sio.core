using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sio.Cms.Lib.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sio_cms_user",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 450, nullable: true),
                    Avatar = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_cms_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_copy",
                columns: table => new
                {
                    Culture = table.Column<string>(maxLength: 10, nullable: false),
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Note = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_copy", x => new { x.Culture, x.Keyword });
                });

            migrationBuilder.CreateTable(
                name: "sio_culture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    FullName = table.Column<string>(maxLength: 150, nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    LCID = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_culture", x => x.Id);
                    table.UniqueConstraint("AK_sio_culture_Specificulture", x => x.Specificulture);
                });

            migrationBuilder.CreateTable(
                name: "sio_customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 256, nullable: true),
                    Username = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(maxLength: 250, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    Avatar = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 450, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    IsAgreeNotified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FileProperties = table.Column<string>(maxLength: 4000, nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    FileType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Tags = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_media", x => new { x.Id, x.Specificulture });
                });

            migrationBuilder.CreateTable(
                name: "sio_parameter",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_parameter", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "sio_portal_page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    TextKeyword = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    TextDefault = table.Column<string>(maxLength: 250, nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_portal_page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_set_attribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 350, nullable: true),
                    Fields = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_set_attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_theme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PreviewUrl = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sio_configuration",
                columns: table => new
                {
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Category = table.Column<string>(maxLength: 250, nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_configuration", x => new { x.Keyword, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Configuration_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_language",
                columns: table => new
                {
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Category = table.Column<string>(maxLength: 250, nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_language", x => new { x.Keyword, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Language_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Fields = table.Column<string>(maxLength: 4000, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    FormTemplate = table.Column<string>(maxLength: 250, nullable: true),
                    EdmTemplate = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PageSize = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Module_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_url_alias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    SourceId = table.Column<string>(maxLength: 250, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_url_alias", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Url_Alias_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    StoreId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_order", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_order_sio_cms_customer",
                        column: x => x.CustomerId,
                        principalTable: "sio_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_portal_page_navigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_portal_page_navigation", x => new { x.Id, x.ParentId });
                    table.ForeignKey(
                        name: "FK_sio_portal_page_navigation_sio_portal_page",
                        column: x => x.Id,
                        principalTable: "sio_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_portal_page_navigation_sio_portal_page1",
                        column: x => x.ParentId,
                        principalTable: "sio_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_portal_page_role",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PageId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_portal_page_role", x => new { x.RoleId, x.PageId });
                    table.ForeignKey(
                        name: "FK_sio_portal_page_role_sio_portal_page",
                        column: x => x.PageId,
                        principalTable: "sio_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_portal_page_position",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false),
                    PortalPageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_portal_page_position", x => new { x.PositionId, x.PortalPageId });
                    table.ForeignKey(
                        name: "FK_Sio_PortalPage_Position_Sio_PortalPage",
                        column: x => x.PortalPageId,
                        principalTable: "sio_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_PortalPage_Position_Sio_Position",
                        column: x => x.PositionId,
                        principalTable: "sio_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    SetAttributeId = table.Column<int>(nullable: true),
                    SetAttributeData = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    PublishedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    Source = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_article", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_article_sio_set_attribute",
                        column: x => x.SetAttributeId,
                        principalTable: "sio_set_attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Article_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    SetAttributeId = table.Column<int>(nullable: true),
                    SetAttributeData = table.Column<string>(nullable: true),
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
                    Priority = table.Column<int>(nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    StaticUrl = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true),
                    PageSize = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_page_sio_set_attribute",
                        column: x => x.SetAttributeId,
                        principalTable: "sio_set_attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Page_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    SetAttributeId = table.Column<int>(nullable: true),
                    SetAttributeData = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    PrivacyId = table.Column<string>(maxLength: 10, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    Source = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    DealPrice = table.Column<double>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    ImportPrice = table.Column<double>(nullable: false),
                    Material = table.Column<string>(maxLength: 250, nullable: true),
                    NormalPrice = table.Column<double>(nullable: false),
                    PackageCount = table.Column<int>(nullable: false),
                    TotalSaled = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_product", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_product_sio_set_attribute",
                        column: x => x.SetAttributeId,
                        principalTable: "sio_set_attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Product_Sio_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sio_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_file",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FolderType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: true),
                    ThemeName = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_file", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sio_file_sio_template",
                        column: x => x.ThemeId,
                        principalTable: "sio_theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_template",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FolderType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    MobileContent = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Scripts = table.Column<string>(nullable: true),
                    SpaContent = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Styles = table.Column<string>(nullable: true),
                    ThemeId = table.Column<int>(nullable: false),
                    ThemeName = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sio_template_sio_theme",
                        column: x => x.ThemeId,
                        principalTable: "sio_theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_article_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_article_media", x => new { x.MediaId, x.ArticleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_article_media_sio_article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_article_media_sio_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sio_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_article_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_article_module", x => new { x.ModuleId, x.ArticleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Article_Module_Sio_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Article_Module_Sio_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_module_article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module_article", x => new { x.ArticleId, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Module_Article_Sio_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Article_Sio_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_related_article",
                columns: table => new
                {
                    SourceId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    Image = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_related_article", x => new { x.SourceId, x.DestinationId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_related_article_sio_article1",
                        columns: x => new { x.DestinationId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_related_article_sio_article",
                        columns: x => new { x.SourceId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_page_article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page_article", x => new { x.ArticleId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Page_Article_Sio_Article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Page_Article_Sio_Page",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_page_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page_module", x => new { x.ModuleId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Page_Module_Sio_Page",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Menu_Module_Sio_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sio_page_page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page_page", x => new { x.Id, x.ParentId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Page_Page_Sio_Page",
                        columns: x => new { x.Id, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Page_Page_Sio_Page1",
                        columns: x => new { x.ParentId, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_page_position",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page_position", x => new { x.PositionId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Page_Position_Sio_Position",
                        column: x => x.PositionId,
                        principalTable: "sio_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sio_Page_Position_Sio_Page",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: true),
                    ArticleId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    FullName = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sio_comment_sio_article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sio_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_comment_sio_order",
                        columns: x => new { x.OrderId, x.Specificulture },
                        principalTable: "sio_order",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_comment_sio_product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_module_product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module_product", x => new { x.ProductId, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Module_Product_Sio_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Product_Sio_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_order_item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PriceUnit = table.Column<string>(maxLength: 50, nullable: true),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_order_item", x => new { x.ProductId, x.OrderId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Order_Item_Order",
                        columns: x => new { x.OrderId, x.Specificulture },
                        principalTable: "sio_order",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Item_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_page_product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_page_product", x => new { x.ProductId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Page_Product_Sio_Page",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sio_page",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Page_Product_Sio_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_product_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_product_media", x => new { x.MediaId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_product_media_sio_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sio_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_product_media_sio_product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_product_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_product_module", x => new { x.ModuleId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Product_Module_Sio_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sio_Product_Module_Sio_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_related_product",
                columns: table => new
                {
                    SourceId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    Image = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_related_product", x => new { x.SourceId, x.DestinationId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_related_product_sio_product1",
                        columns: x => new { x.DestinationId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sio_related_product_sio_product",
                        columns: x => new { x.SourceId, x.Specificulture },
                        principalTable: "sio_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_module_attribute_set",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    ArticleId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fields = table.Column<string>(maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module_attribute_set", x => new { x.Id, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Module_Attribute_set_Sio_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Attribute_set_Sio_Article_Module",
                        columns: x => new { x.ModuleId, x.ArticleId, x.Specificulture },
                        principalTable: "sio_article_module",
                        principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Attribute_set_Sio_Page_Module",
                        columns: x => new { x.ModuleId, x.CategoryId, x.Specificulture },
                        principalTable: "sio_page_module",
                        principalColumns: new[] { "ModuleId", "CategoryId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_module_data",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    ArticleId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fields = table.Column<string>(maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module_data", x => new { x.Id, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sio_Module_Data_Sio_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sio_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Data_Sio_Page_Module",
                        columns: x => new { x.ModuleId, x.CategoryId, x.Specificulture },
                        principalTable: "sio_page_module",
                        principalColumns: new[] { "ModuleId", "CategoryId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sio_Module_Data_Sio_Product_Module",
                        columns: x => new { x.ModuleId, x.ProductId, x.Specificulture },
                        principalTable: "sio_article_module",
                        principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sio_module_attribute_value",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttributeSetId = table.Column<Guid>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sio_module_attribute_value", x => new { x.Id, x.AttributeSetId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sio_module_attribute_value_sio_module_attribute_set",
                        columns: x => new { x.AttributeSetId, x.ModuleId, x.Specificulture },
                        principalTable: "sio_module_attribute_set",
                        principalColumns: new[] { "Id", "ModuleId", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_SetAttributeId",
                table: "sio_article",
                column: "SetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_Specificulture",
                table: "sio_article",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_media_ArticleId_Specificulture",
                table: "sio_article_media",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_media_MediaId_Specificulture",
                table: "sio_article_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_module_ArticleId_Specificulture",
                table: "sio_article_module",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_article_module_ModuleId_Specificulture",
                table: "sio_article_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_comment_ArticleId_Specificulture",
                table: "sio_comment",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_comment_OrderId_Specificulture",
                table: "sio_comment",
                columns: new[] { "OrderId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_comment_ProductId_Specificulture",
                table: "sio_comment",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_configuration_Specificulture",
                table: "sio_configuration",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_Sio_Culture",
                table: "sio_culture",
                column: "Specificulture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sio_file_ThemeId",
                table: "sio_file",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_language_Specificulture",
                table: "sio_language",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_Specificulture",
                table: "sio_module",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_article_ArticleId_Specificulture",
                table: "sio_module_article",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_article_ModuleId_Specificulture",
                table: "sio_module_article",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_attribute_set_ModuleId_Specificulture",
                table: "sio_module_attribute_set",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_attribute_set_ModuleId_ArticleId_Specificulture",
                table: "sio_module_attribute_set",
                columns: new[] { "ModuleId", "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_attribute_set_ModuleId_PageId_Specificulture",
                table: "sio_module_attribute_set",
                columns: new[] { "ModuleId", "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_attribute_value_AttributeSetId_ModuleId_Specificulture",
                table: "sio_module_attribute_value",
                columns: new[] { "AttributeSetId", "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_data_ModuleId_Specificulture",
                table: "sio_module_data",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_data_ModuleId_ArticleId_Specificulture",
                table: "sio_module_data",
                columns: new[] { "ModuleId", "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_data_ModuleId_PageId_Specificulture",
                table: "sio_module_data",
                columns: new[] { "ModuleId", "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_data_ModuleId_ProductId_Specificulture",
                table: "sio_module_data",
                columns: new[] { "ModuleId", "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_product_ModuleId_Specificulture",
                table: "sio_module_product",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_module_product_ProductId_Specificulture",
                table: "sio_module_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_order_CustomerId",
                table: "sio_order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_order_Specificulture",
                table: "sio_order",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_order_item_Specificulture",
                table: "sio_order_item",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "AK_sio_order_item_Id_Specificulture",
                table: "sio_order_item",
                columns: new[] { "Id", "Specificulture" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sio_order_item_OrderId_Specificulture",
                table: "sio_order_item",
                columns: new[] { "OrderId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_order_item_ProductId_Specificulture",
                table: "sio_order_item",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_SetAttributeId",
                table: "sio_page",
                column: "SetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_Specificulture",
                table: "sio_page",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_article_ArticleId_Specificulture",
                table: "sio_page_article",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_article_PageId_Specificulture",
                table: "sio_page_article",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_module_PageId_Specificulture",
                table: "sio_page_module",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_module_ModuleId_Specificulture",
                table: "sio_page_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_page_Id_Specificulture",
                table: "sio_page_page",
                columns: new[] { "Id", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_page_ParentId_Specificulture",
                table: "sio_page_page",
                columns: new[] { "ParentId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_position_PageId_Specificulture",
                table: "sio_page_position",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_product_PageId_Specificulture",
                table: "sio_page_product",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_page_product_ProductId_Specificulture",
                table: "sio_page_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_portal_page_navigation_ParentId",
                table: "sio_portal_page_navigation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_portal_page_position_PortalPageId",
                table: "sio_portal_page_position",
                column: "PortalPageId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_portal_page_role_PageId",
                table: "sio_portal_page_role",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_SetAttributeId",
                table: "sio_product",
                column: "SetAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_Specificulture",
                table: "sio_product",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_media_MediaId_Specificulture",
                table: "sio_product_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_media_ProductId_Specificulture",
                table: "sio_product_media",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_module_ModuleId_Specificulture",
                table: "sio_product_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_product_module_ProductId_Specificulture",
                table: "sio_product_module",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_related_article_DestinationId_Specificulture",
                table: "sio_related_article",
                columns: new[] { "DestinationId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_related_article_SourceId_Specificulture",
                table: "sio_related_article",
                columns: new[] { "SourceId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_related_product_DestinationId_Specificulture",
                table: "sio_related_product",
                columns: new[] { "DestinationId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_related_product_SourceId_Specificulture",
                table: "sio_related_product",
                columns: new[] { "SourceId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sio_template_file_TemplateId",
                table: "sio_template",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_sio_url_alias_Specificulture",
                table: "sio_url_alias",
                column: "Specificulture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sio_article_media");

            migrationBuilder.DropTable(
                name: "sio_cms_user");

            migrationBuilder.DropTable(
                name: "sio_comment");

            migrationBuilder.DropTable(
                name: "sio_configuration");

            migrationBuilder.DropTable(
                name: "sio_copy");

            migrationBuilder.DropTable(
                name: "sio_file");

            migrationBuilder.DropTable(
                name: "sio_language");

            migrationBuilder.DropTable(
                name: "sio_module_article");

            migrationBuilder.DropTable(
                name: "sio_module_attribute_value");

            migrationBuilder.DropTable(
                name: "sio_module_data");

            migrationBuilder.DropTable(
                name: "sio_module_product");

            migrationBuilder.DropTable(
                name: "sio_order_item");

            migrationBuilder.DropTable(
                name: "sio_page_article");

            migrationBuilder.DropTable(
                name: "sio_page_page");

            migrationBuilder.DropTable(
                name: "sio_page_position");

            migrationBuilder.DropTable(
                name: "sio_page_product");

            migrationBuilder.DropTable(
                name: "sio_parameter");

            migrationBuilder.DropTable(
                name: "sio_portal_page_navigation");

            migrationBuilder.DropTable(
                name: "sio_portal_page_position");

            migrationBuilder.DropTable(
                name: "sio_portal_page_role");

            migrationBuilder.DropTable(
                name: "sio_product_media");

            migrationBuilder.DropTable(
                name: "sio_product_module");

            migrationBuilder.DropTable(
                name: "sio_related_article");

            migrationBuilder.DropTable(
                name: "sio_related_product");

            migrationBuilder.DropTable(
                name: "sio_template");

            migrationBuilder.DropTable(
                name: "sio_url_alias");

            migrationBuilder.DropTable(
                name: "sio_module_attribute_set");

            migrationBuilder.DropTable(
                name: "sio_order");

            migrationBuilder.DropTable(
                name: "sio_position");

            migrationBuilder.DropTable(
                name: "sio_portal_page");

            migrationBuilder.DropTable(
                name: "sio_media");

            migrationBuilder.DropTable(
                name: "sio_product");

            migrationBuilder.DropTable(
                name: "sio_theme");

            migrationBuilder.DropTable(
                name: "sio_article_module");

            migrationBuilder.DropTable(
                name: "sio_page_module");

            migrationBuilder.DropTable(
                name: "sio_customer");

            migrationBuilder.DropTable(
                name: "sio_article");

            migrationBuilder.DropTable(
                name: "sio_page");

            migrationBuilder.DropTable(
                name: "sio_module");

            migrationBuilder.DropTable(
                name: "sio_set_attribute");

            migrationBuilder.DropTable(
                name: "sio_culture");
        }
    }
}
