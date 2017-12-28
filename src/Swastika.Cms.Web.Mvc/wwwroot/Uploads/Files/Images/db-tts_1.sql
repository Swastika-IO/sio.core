USE [tts]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Avatar] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[Culture] [nvarchar](max) NULL,
	[DOB] [datetime2](7) NULL,
	[Gender] [nvarchar](max) NULL,
	[IsActived] [bit] NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[LastModified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[NickName] [nvarchar](max) NULL,
	[RegisterType] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Article]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Article](
	[Id] [nvarchar](50) NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[Title] [nvarchar](4000) NULL,
	[Excerpt] [nvarchar](max) NULL,
	[FullContent] [nvarchar](max) NULL,
	[SeoTitle] [nvarchar](4000) NULL,
	[SeoDescription] [nvarchar](4000) NULL,
	[SeoKeywords] [nvarchar](4000) NULL,
	[Source] [nvarchar](250) NULL,
	[Views] [int] NULL,
	[Type] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_TTS_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Article_Module]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Article_Module](
	[ModuleId] [int] NOT NULL,
	[ArticleId] [nvarchar](50) NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Position] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_TTS_Article_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC,
	[ArticleId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Banner]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Banner](
	[Id] [nvarchar](128) NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Url] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](250) NULL,
	[Image] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[IsPublished] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_TTS_Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Category]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Category](
	[Id] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[Title] [nvarchar](4000) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NULL,
	[FullContent] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Views] [int] NULL,
	[SeoTitle] [nvarchar](4000) NULL,
	[SeoDescription] [nvarchar](4000) NULL,
	[SeoKeywords] [nvarchar](4000) NULL,
	[Level] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_TTS_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Category_Article]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Category_Article](
	[ArticleId] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TTS_Menu_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC,
	[CategoryId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Category_Category]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Category_Category](
	[Id] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TTS_Menu_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Category_Module]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Category_Module](
	[ModuleId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Position] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_TTS_Menu_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC,
	[CategoryId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Category_Position]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Category_Position](
	[Position] [int] NOT NULL,
	[CateId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_TTS_Category_Position] PRIMARY KEY CLUSTERED 
(
	[Position] ASC,
	[CateId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Comment]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Comment](
	[CommentId] [uniqueidentifier] NOT NULL,
	[ArticleId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[EditedBy] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[IsView] [bit] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Copy]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Copy](
	[Culture] [nvarchar](10) NOT NULL,
	[Keyword] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_TTX_Copy] PRIMARY KEY CLUSTERED 
(
	[Culture] ASC,
	[Keyword] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Culture]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Culture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[LCID] [nvarchar](50) NULL,
	[Alias] [nvarchar](150) NULL,
	[FullName] [nvarchar](150) NULL,
	[Description] [nvarchar](250) NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_TTS_Culture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Module]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Module](
	[Id] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Template] [nvarchar](50) NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Fields] [nvarchar](400) NULL,
 CONSTRAINT [PK_TTS_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Module_Article]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Module_Article](
	[ArticleId] [nvarchar](50) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TTS_Module_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC,
	[ModuleId] ASC,
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Module_Data]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Module_Data](
	[Id] [nvarchar](50) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Specificulture] [nvarchar](10) NOT NULL,
	[Fields] [nvarchar](400) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ArticleId] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TTS_Module_Data] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Parameter]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Parameter](
	[Name] [nvarchar](256) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTS_Position]    Script Date: 7/31/2017 9:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTS_Position](
	[Position] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TTS_Position] PRIMARY KEY CLUSTERED 
(
	[Position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20161206204752_Initial', N'1.1.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170626141230_aaa', N'1.1.2')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (1, N'Edit User', N'Edit User', N'e8a7c07c-23fe-4ace-a578-953ead1bacd4')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (2, N'Add User', N'Add User', N'5c1d3843-bd12-44d1-b006-11c4083c9fe5')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (3, N'Edit User', N'Edit User', N'5c1d3843-bd12-44d1-b006-11c4083c9fe5')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (4, N'Add User', N'Add User', N'44672eb8-e752-46ae-a7af-0b9ba2330ab8')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (5, N'Add User', N'Add User', N'd5b58124-e12f-40e5-a882-1e38aad48655')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (6, N'Edit User', N'Edit User', N'd5b58124-e12f-40e5-a882-1e38aad48655')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (7, N'Delete User', N'Delete User', N'd5b58124-e12f-40e5-a882-1e38aad48655')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Avatar], [CountryId], [Culture], [DOB], [Gender], [IsActived], [JoinDate], [LastModified], [ModifiedBy], [NickName], [RegisterType], [FirstName], [LastName]) VALUES (N'44672eb8-e752-46ae-a7af-0b9ba2330ab8', 0, N'847a5a47-10e8-4aa0-9bba-03a30b205186', N'abc@gmail.com', 0, 1, NULL, N'ABC@GMAIL.COM', N'ABC', N'AQAAAAEAACcQAAAAED4buPiuUdlMuaR0TcdpBez3F64RS193A86YQXkTzLo/3Lpbm2XhgTg8vN9BbZ5lEg==', NULL, 0, N'53910dd1-b92b-469e-81e2-7f8279437125', 0, N'abc', NULL, 0, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'abc', NULL, N'abc', N'abc')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Avatar], [CountryId], [Culture], [DOB], [Gender], [IsActived], [JoinDate], [LastModified], [ModifiedBy], [NickName], [RegisterType], [FirstName], [LastName]) VALUES (N'5c1d3843-bd12-44d1-b006-11c4083c9fe5', 0, N'2810e25c-bb1b-4d14-bcab-93f9ea2db5f7', N'nhathoang989@gmail.com', 0, 1, NULL, N'NHATHOANG989@GMAIL.COM', N'TINKU', N'AQAAAAEAACcQAAAAEOwBwaUuD/8eMIu5pTDzMTaVeapDqRiyoS8QwrEp1lAIf7WdRTO3r1mQvi01SLgvVA==', NULL, 0, N'a333b024-9835-4114-8d6e-1d9859bf9ca5', 0, N'tinku', NULL, 0, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'tinku89', NULL, N'Hoang', N'nguyen')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Avatar], [CountryId], [Culture], [DOB], [Gender], [IsActived], [JoinDate], [LastModified], [ModifiedBy], [NickName], [RegisterType], [FirstName], [LastName]) VALUES (N'd5b58124-e12f-40e5-a882-1e38aad48655', 0, N'df7bde6c-cadd-4f0a-b4a5-1531692da4dc', N'i.love.to.smile.around@gmail.com', 0, 1, NULL, N'I.LOVE.TO.SMILE.AROUND@GMAIL.COM', N'SMILEFOUNDER', N'AQAAAAEAACcQAAAAEKxvEEuSTqg78kVeSdMXTJD0IwlgfcedUG2T593Ix8uo05jkMot/FNAHBezKIUAXlg==', NULL, 0, N'44ffdf49-439b-4bc6-8610-06203b453a99', 0, N'smilefounder', NULL, 0, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'Huy', N'Nguyen')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Avatar], [CountryId], [Culture], [DOB], [Gender], [IsActived], [JoinDate], [LastModified], [ModifiedBy], [NickName], [RegisterType], [FirstName], [LastName]) VALUES (N'e8a7c07c-23fe-4ace-a578-953ead1bacd4', 0, N'16cf1272-5400-44e6-a7f0-5edca9189646', N'nhathoang989@gmail.com', 0, 1, NULL, N'NHATHOANG989@GMAIL.COM', N'NHATHOANG989@GMAIL.COM', N'AQAAAAEAACcQAAAAEL/HAgWtX60exWho4SHaUcAJmwIKGqrFfXh9KDgI1Nps9N4RCgj0MzJHdOeh0fqCQQ==', NULL, 0, N'a6ff1b7d-3ef6-4f4a-b148-f9cf2a236785', 0, N'nhathoang989@gmail.com', NULL, 0, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'tinku', NULL, N'Hoang', N'Nguyen')
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'0b997de3-3a80-4302-84be-c9f91958f79b', N'en-us', N'/Uploads/Modules/Banners\fffa67ae02ee4395b391c0cb07f46369.jpg', N'WELCOME TO TOTALTRAVELSOLUTIONS.ASIA', NULL, N'<p>

</p><p>Bạn đam mê khám phá những điều mới lạ, ước mơ được đặt chân đến những thành phố lãng mạn, lỗng lẫy và nguy nga? Thế nhưng, đôi lúc bạn vẫn chưa hài lòng về những chuyến du lịch đã qua. Tốn bao nhiêu thời gian và tiền điện thoại đây để kiếm một dịch vụ uy tín và chất lượng?</p><p>&nbsp;</p><p>Bạn đang lay hoay mất thời gian xin Visa, lo lắng khi người thân đi du lịch ở nơi xa, bạn phân vân nên không biết đặt niềm tin vào dịch vụ nào? Lại thêm đau đầu cho việc chọn khách sạn, đặt vé máy bay..v..v. Hãy tiết kiệm thời gian vàng bạc bằng cách quẳng gánh lo đó cho chúng tôi cùng những phiền muộn khác. Hãy để chúng tôi được chia sẻ và gánh vác giúp bạn.</p><p>&nbsp;</p><p>Chúng tôi - Total Travel Solutions Asia (TTS) – Giải Pháp Du Lịch Toàn Diện muốn cung cấp và đưa ra những giải pháp cho hành trình của bạn cùng gia đình diễn ra tốt đẹp nhất, an tâm nhất với chất lượng dịch vụ cùng cùng sự hỗ trợ xuyên suốt.</p>

<br><p></p>', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', NULL, NULL, 0, CAST(N'2017-07-22T09:29:26.167' AS DateTime), N'admin', 1, 1)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'0b997de3-3a80-4302-84be-c9f91958f79b', N'vi-vn', N'https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Stadtkirche_Wittenberg_Marktplatz_mit_Rathaus_11_C.jpg/290px-Stadtkirche_Wittenberg_Marktplatz_mit_Rathaus_11_C.jpg', N'CHÀO MỪNG ĐẾN VỚI TOTALTRAVELSOLUTIONS.ASIA', N'Bạn đam mê khám phá những điều mới lạ, ước mơ được đặt chân đến những thành phố lãng mạn, lỗng lẫy và nguy nga? Thế nhưng, đôi lúc bạn vẫn chưa hài lòng về những chuyến du lịch đã qua. Tốn bao nhiêu thời gian và tiền điện thoại đây để kiếm một dịch vụ uy tín và chất lượng?', N'<p>Bạn đam m&ecirc; kh&aacute;m ph&aacute; những điều mới lạ, ước mơ được đặt ch&acirc;n đến những th&agrave;nh phố l&atilde;ng mạn, lỗng lẫy v&agrave; nguy nga? Thế nhưng, đ&ocirc;i l&uacute;c bạn vẫn chưa h&agrave;i l&ograve;ng về những chuyến du lịch đ&atilde; qua. Tốn bao nhi&ecirc;u thời gian v&agrave; tiền điện thoại đ&acirc;y để kiếm một dịch vụ uy t&iacute;n v&agrave; chất lượng?</p>

<p>Bạn đang lay hoay mất thời gian xin Visa, lo lắng khi người th&acirc;n đi du lịch ở nơi xa, bạn ph&acirc;n v&acirc;n n&ecirc;n kh&ocirc;ng biết đặt niềm tin v&agrave;o dịch vụ n&agrave;o? Lại th&ecirc;m đau đầu cho việc chọn kh&aacute;ch sạn, đặt v&eacute; m&aacute;y bay..v..v. H&atilde;y tiết kiệm thời gian v&agrave;ng bạc bằng c&aacute;ch quẳng g&aacute;nh lo đ&oacute; cho ch&uacute;ng t&ocirc;i c&ugrave;ng những phiền muộn kh&aacute;c. H&atilde;y để ch&uacute;ng t&ocirc;i được chia sẻ v&agrave; g&aacute;nh v&aacute;c gi&uacute;p bạn.</p>

<p>Ch&uacute;ng t&ocirc;i - Total Travel Solutions Asia (TTS) &ndash; Giải Ph&aacute;p Du Lịch To&agrave;n Diện muốn cung cấp v&agrave; đưa ra những giải ph&aacute;p cho h&agrave;nh tr&igrave;nh của bạn c&ugrave;ng gia đ&igrave;nh diễn ra tốt đẹp nhất, an t&acirc;m nhất với chất lượng dịch vụ c&ugrave;ng c&ugrave;ng sự hỗ trợ xuy&ecirc;n suốt.</p>
', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', NULL, NULL, 0, CAST(N'2017-07-22T09:29:26.167' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', N'en-us', N'/Uploads/Modules/Banners/04ce0db3dd5b4c369754a5901a0701ae.jpg', N'YOUR ITINERARY', N'This is your truly classic 7 nights tour of Sri Lanka, covering all 6 UNESCO world heritage sites.
The tour takes you through a perfect balance of heritage, nature, & wildlife.', N'<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">This is your truly classic 7 nights tour of Sri Lanka, covering all 6 UNESCO world heritage sites.</p>

<p style="text-align:center">The tour takes you through a perfect balance of heritage, nature, &amp; wildlife.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<h2 style="text-align:center">YOUR ITINERARY</h2>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 1</h5>

<p style="text-align:center">AIRPORT / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Upon landing at BIA, you will be met by one of our representatives and garlanded with flowers.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/29.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then proceed to Habarana. Check-in at the hotel, and rest of the day free to relax.</p>

<p style="text-align:center">Over-night stay at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 2</h5>

<p style="text-align:center">SIGIRIYA / ANURADHAPURA / MIHINTALE / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">After breakfast, worship the sacred city of Anuradhapura.</p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/9.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Thereafter, visit Mihintale in the afternoon.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/10.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel. Over-night stay at at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 3</h5>

<p style="text-align:center">SIGIRIYA / POLONNARUWA / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, visit and climb the famous Sigiriya Rock Fortress.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/1.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Thereafter, visit the medieval capital of Polannaruwa.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/8.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel.</p>

<p style="text-align:center">Over-night stay at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 4</h5>

<p style="text-align:center">SIGIRIYA / DAMBULLA / KANDY</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, leave for Kandy. Visit Dambulla Rock Cave Temple on the way.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/7.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then it is time to explore the secrets of a Spice Garden and a Batik Factory.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/2.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Journey continues to Kandy. Check-in at the hotel.</p>

<p style="text-align:center">At 6:00pm witness the Kandyan Dance.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/6.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then, visit the Dalada Maligawa &nbsp;(Temple of the Tooth).</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/5.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel. Over-night stay at the hotel in Kandy.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 5</h5>

<p style="text-align:center">KANDY / PINNAWELA / NUWARA ELIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, visit Pinnawela Elephant Orphanage.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/4.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Baby elephants are bottle-fed around 9am and then the whole herd is taken for a bath in the river.</p>

<p style="text-align:center">Return to Kandy. Then, visit the Royal Botanical Garden.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/3.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Proceed to Nuwara Eliya.</p>

<p style="text-align:center">En-route, visit a Tea Factory.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/14.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Afterwards, visit the Golf course, Victoria Park, &amp; Gregory Lake.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/13.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Check-in at the hotel in Nuwara Eliya.</p>

<p style="text-align:center">Over-night stay at the hotel in Nuwara Eliya.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 6</h5>

<p style="text-align:center">NUWARA ELIYA / TISSAMAHARAMA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, depart to Kataragama. En-route visit Ravana water falls (8:00am).</p>

<p style="text-align:center">Check-in at the hotel.</p>

<p style="text-align:center">Around 3:00pm leave for a jeep safari of the Yala National Park.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/12.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel.</p>

<p style="text-align:center">Over-night stay at the hotel in Kataragama.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 7</h5>

<p style="text-align:center">TISSAMAHARAMA / GALLE / COLOMBO</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, transfer to Colombo. En-route visit Hambantota Salterns and the Stilt Fisherman at Weligama.</p>

<p style="text-align:center">Then arrive at the Galle Fort.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/11.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Continue journey to Colombo, and proceed on a Colombo City Tour.</p>

<p style="text-align:center">Over-night stay at the hotel in Mount Lavinia.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 8</h5>

<p style="text-align:center">COLOMBO / AIRPORT</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, depart to the airport in time for the departure flight.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">***PRICES ARE BASED ON ECONOMY HOTELS***</p>

<p style="text-align:center">For USD 795, you can upgrade to superior (4 star) hotels.</p>

<p style="text-align:center">For USD 1095, you can upgrade to deluxe (5 star) hotels.</p>

<p style="text-align:center">Continue to Maldives. <a href="http://totaltravelsolution.com/travel/maldives/" rel="nofollow" target="_blank">Click here</a></p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>
', N'YOUR-ITINERARY', N'YOUR-ITINERARY', N'YOUR-ITINERARY', NULL, NULL, 0, CAST(N'2017-07-17T10:14:09.497' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', N'vi-vn', N'http://www.ukkitesurfing.com/_images/beaches/beaches_pix_greatstone.jpg', N'YOUR ITINERARY', N'This is your truly classic 7 nights tour of Sri Lanka, covering all 6 UNESCO world heritage sites.
The tour takes you through a perfect balance of heritage, nature, & wildlife.', N'<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">This is your truly classic 7 nights tour of Sri Lanka, covering all 6 UNESCO world heritage sites.</p>

<p style="text-align:center">The tour takes you through a perfect balance of heritage, nature, &amp; wildlife.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<h2 style="text-align:center">YOUR ITINERARY</h2>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 1</h5>

<p style="text-align:center">AIRPORT / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Upon landing at BIA, you will be met by one of our representatives and garlanded with flowers.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/29.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then proceed to Habarana. Check-in at the hotel, and rest of the day free to relax.</p>

<p style="text-align:center">Over-night stay at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 2</h5>

<p style="text-align:center">SIGIRIYA / ANURADHAPURA / MIHINTALE / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">After breakfast, worship the sacred city of Anuradhapura.</p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/9.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Thereafter, visit Mihintale in the afternoon.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/10.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel. Over-night stay at at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 3</h5>

<p style="text-align:center">SIGIRIYA / POLONNARUWA / SIGIRIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, visit and climb the famous Sigiriya Rock Fortress.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/1.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Thereafter, visit the medieval capital of Polannaruwa.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/8.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel.</p>

<p style="text-align:center">Over-night stay at the hotel in Habarana.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 4</h5>

<p style="text-align:center">SIGIRIYA / DAMBULLA / KANDY</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, leave for Kandy. Visit Dambulla Rock Cave Temple on the way.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/7.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then it is time to explore the secrets of a Spice Garden and a Batik Factory.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/2.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Journey continues to Kandy. Check-in at the hotel.</p>

<p style="text-align:center">At 6:00pm witness the Kandyan Dance.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/6.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Then, visit the Dalada Maligawa &nbsp;(Temple of the Tooth).</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/5.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel. Over-night stay at the hotel in Kandy.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 5</h5>

<p style="text-align:center">KANDY / PINNAWELA / NUWARA ELIYA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, visit Pinnawela Elephant Orphanage.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/4.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Baby elephants are bottle-fed around 9am and then the whole herd is taken for a bath in the river.</p>

<p style="text-align:center">Return to Kandy. Then, visit the Royal Botanical Garden.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/3.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Proceed to Nuwara Eliya.</p>

<p style="text-align:center">En-route, visit a Tea Factory.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/14.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Afterwards, visit the Golf course, Victoria Park, &amp; Gregory Lake.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/13.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Check-in at the hotel in Nuwara Eliya.</p>

<p style="text-align:center">Over-night stay at the hotel in Nuwara Eliya.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 6</h5>

<p style="text-align:center">NUWARA ELIYA / TISSAMAHARAMA</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, depart to Kataragama. En-route visit Ravana water falls (8:00am).</p>

<p style="text-align:center">Check-in at the hotel.</p>

<p style="text-align:center">Around 3:00pm leave for a jeep safari of the Yala National Park.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/12.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Return to the hotel.</p>

<p style="text-align:center">Over-night stay at the hotel in Kataragama.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 7</h5>

<p style="text-align:center">TISSAMAHARAMA / GALLE / COLOMBO</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, transfer to Colombo. En-route visit Hambantota Salterns and the Stilt Fisherman at Weligama.</p>

<p style="text-align:center">Then arrive at the Galle Fort.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center"><img alt="" src="http://totaltravelsolution.com/wp-content/uploads/2015/04/11.jpg" /></p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">Continue journey to Colombo, and proceed on a Colombo City Tour.</p>

<p style="text-align:center">Over-night stay at the hotel in Mount Lavinia.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<h5 style="text-align:center">Day 8</h5>

<p style="text-align:center">COLOMBO / AIRPORT</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">After breakfast, depart to the airport in time for the departure flight.</p>

<p style="text-align:center">&nbsp;</p>

<div style="text-align:center">&nbsp;</div>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">***PRICES ARE BASED ON ECONOMY HOTELS***</p>

<p style="text-align:center">For USD 795, you can upgrade to superior (4 star) hotels.</p>

<p style="text-align:center">For USD 1095, you can upgrade to deluxe (5 star) hotels.</p>

<p style="text-align:center">Continue to Maldives. <a href="http://totaltravelsolution.com/travel/maldives/" rel="nofollow" target="_blank">Click here</a></p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>

<p style="text-align:center">&nbsp;</p>
', N'YOUR-ITINERARY', N'YOUR-ITINERARY', N'YOUR-ITINERARY', NULL, NULL, 0, CAST(N'2017-07-17T10:14:09.497' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'b4dd05a9-a425-4843-b43b-146fe78df009', N'vi-vn', N'/Uploads/undefined/307de25a708d4b4785b00ff2a590dacd.jpg', N'TOUR 2 (TUYẾN XANH LÁ):  PHÁP - THỤY SĨ – ITALIA - VATICAN  – MONACO', N'Chương trình 7 ngày / 6 đêm vui chơi thỏa thích 5 quốc gia và 11 thành phố Châu Âu, khởi hành từ PARIS, để đến với đất nước Thụy Sĩ thanh bình, đến với đất nước Ý với các thành phố mộng mơ và nghệ thuật Rome, Venice, Florence, thánh địa Vatican .. trở lại miền nam Pháp thăm quốc gia nhỏ bé nhưng giàu có bậc nhất thế giới Monaco, thành phố của các lễ hội và phim ảnh Nice, Cannes – trở lại Paris thơ mộng.', N'<p>Khởi h&agrave;nh THỨ 7 h&agrave;ng tuần từ Paris. Khung đường kh&eacute;p k&iacute;n 7 ng&agrave;y v&agrave; xoay v&ograve;ng, tour chạy suốt năm.<br />
THỤY SĨ&nbsp;: Lucerne<br />
ITALIA&nbsp;: Milan &ndash; Verona &ndash; Venice &ndash; Roma &ndash; Pisa &ndash; Florence<br />
VATICAN&nbsp;: Vatican<br />
MONACO&nbsp;: Monte-Carlo<br />
PH&Aacute;P&nbsp;: Nice - Cannes</p>

<p><img alt="" src="http://totaltravelsolutions.asia/image/data/demo/hinh8.jpg" /></p>

<p>&nbsp;</p>

<p><strong>Mi&ecirc;u Tả:</strong><br />
Tuyến Xanh đưa du kh&aacute;ch đến trung t&acirc;m những th&agrave;nh phố tuyệt đẹp bậc nhất Ch&acirc;u &Acirc;u của Ph&aacute;p, Thuỵ Sĩ v&agrave; &Yacute;. Từ Paris sẽ c&ugrave;ng du kh&aacute;ch qua v&ugrave;ng n&uacute;i An Pơ, Thuỵ Sĩ tuyệt đẹp, quanh năm phủ đầy tuyết trắng trước khi đi v&agrave;o v&ugrave;ng trung t&acirc;m nước &Yacute;, miền đất của kiến tr&uacute;c v&agrave; nghệ thuật.<br />
Kh&aacute;m ph&aacute; th&agrave;nh phố nổi độc đ&aacute;o nhất thế giới Venice, tản bộ qua khu th&agrave;nh cổ Verona v&agrave; ngắm nh&igrave;n c&aacute;i n&ocirc;i của nghệ thuật Phục Hưng Florence v&agrave; trải nghiệm 1 ng&agrave;y đ&aacute;ng nhớ tại Thủ đ&ocirc; Vĩnh Hằng &ndash; Rome với Đấu Trường Coliseum v&agrave; th&agrave;nh phố linh thi&ecirc;ng Vatican. V&agrave; sau c&ugrave;ng, qu&yacute; kh&aacute;ch sẽ được tận hưởng kh&ocirc;ng kh&iacute; m&aacute;t mẻ, nắng v&agrave;ng, trời gian xanh v&ugrave;ng Địa Trung Hải v&agrave; đồng qu&ecirc; miền Nam nước Ph&aacute;p trước khi trở về Paris để kết th&uacute;c chuyến đi. Một h&agrave;nh tr&igrave;nh tuyệt vời!</p>

<p><em>Ng&agrave;y 1: Thứ Bảy</em><br />
PARIS &ndash; LUCERNE(650km)<br />
H&agrave;nh tr&igrave;nh từ Paris đến th&agrave;nh phố Lucerne xinh đẹp của Thụy Sĩ. Tr&ecirc;n đường đi qu&yacute; kh&aacute;ch c&oacute; cơ hội ngắm nh&igrave;n phong cảnh miền qu&ecirc; thơ mộng của nước Ph&aacute;p v&agrave; d&atilde;y n&uacute;i Alps của Thụy Sĩ. Đo&agrave;n đi ngang Basel &ndash; nơi gặp nhau của bi&ecirc;n giới ba nước Ph&aacute;p, Đức, Thụy Sĩ. Đến Lucerne thanh b&igrave;nh, tham quan cầu gỗ cổ Chapel v&agrave; tự do mua sắm đồ lưu niệm hay đồng hồ Thụy Sĩ.<br />
<em>Kh&aacute;ch sạn 3*: Lucerne hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 2: Chủ Nhật</em><br />
LUCERNE&ndash; MILAN &ndash; VERONA &ndash; VENICE(480km)<br />
Đến kinh đ&ocirc; thời trang Milan, tham quan nh&agrave; thờ Duomo, khu trung t&acirc;m mua sắm Emmanuel II. Buổi chiều đến Verona, qu&ecirc; hương của Romeo v&agrave; Juliet. Đi bộ dọc theo khu th&agrave;nh cổ Verona đến thăm ng&ocirc;i nh&agrave; của n&agrave;ng Juliet.<br />
<em>Kh&aacute;ch sạn 3*: Venice hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 3: Thứ Hai</em><br />
VENICE &ndash; ROME(550km)<br />
Kh&aacute;m ph&aacute; th&agrave;nh phố tr&ecirc;n s&ocirc;ng Venice c&ugrave;ng với một hướng dẫn vi&ecirc;n địa phương: quảng trường San Marco, Cầu Than Thở, xem biểu diễn chế t&aacute;c thủy tinh Murano. Kh&aacute;ch c&oacute; thể lựa chọn đi thuyền Gondola dọc k&ecirc;nh Venice v&agrave; thưởng thức bữa trưa c&ugrave;ng đo&agrave;n với m&oacute;n m&igrave; Spaghetti đặc sản. Khởi h&agrave;nh xuống th&agrave;nh phố vĩnh hằng Rome.<br />
<em>Kh&aacute;ch sạn 3*: Rome hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 4: Thứ Ba</em><br />
ROME &ndash; VATICAN &ndash; FLORENCE (280km)<br />
Đến Vatican &ndash; quốc gia nhỏ nhất thế giới với Nh&agrave; thờ Th&aacute;nh Peter&rsquo;s Basilica tuyệt mỹ. Sau đ&oacute; tham quan Đ&agrave;i phun nước Trevi, tản bộ khu vực xung quanh Quảng trường T&acirc;y Ban Nha. Đến Đấu trường La M&atilde; Coliseum, du kh&aacute;ch c&oacute; thể v&agrave;o b&ecirc;n trong Đấu trường hoặc đi bộ đến Khải Ho&agrave;n M&ocirc;n Constantine gần đ&oacute; trước khi đi Florence.<br />
<em>Kh&aacute;ch sạn 3*: Florence hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 5: Thứ Tư</em><br />
FLORENCE &nbsp;&rarr; PISA &rarr; GENOA/SAN REMO (250km)<br />
Kh&aacute;m ph&aacute; Florence, th&agrave;nh phố được mệnh danh l&agrave; c&aacute;i n&ocirc;i văn h&oacute;a nghệ thuật Phục hưng, Quảng trường Michel-Angelo, cầu Vecchio, nh&agrave; thờ Đức Mẹ Duomo, th&aacute;p Campanile, bảo t&agrave;ng nghệ thuật Uffizi, mua sắm mặc h&agrave;ng da thuộc nổi tiếng của Florence. Tham quan Th&aacute;p nghi&ecirc;ng Pisa nổi tiếng thế giới.<br />
<em>Kh&aacute;ch sạn 3*: Genoa hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 6: Thứ Năm</em><br />
GENOA/SAN REMO &rarr; MONTE-CARLO &rarr; NICE &rarr; CANNES &rarr; AVIGNON (450km)<br />
Đến v&ugrave;ng Cote D&rsquo;Azur xinh đẹp b&ecirc;n bờ Địa Trung hải. Tham quan c&ocirc;ng quốc Monaco nhỏ b&eacute; nhưng gi&agrave;u đẹp v&agrave; thịnh vượng, l&acirc;u đ&agrave;i Grand Place, đi ngang qua s&ograve;ng bạc Monte-Carlo nổi tiếng tr&ecirc;n đường v&agrave;o th&agrave;nh phố. Gh&eacute; thăm thủ phủ Nice của V&ugrave;ng Cote D&rsquo;Azur, nh&agrave; m&aacute;y sản xuất nước hoa Fragonard. Th&agrave;nh phố điện ảnh Cannes &ndash; chụp ảnh tại nơi tổ chức li&ecirc;n hoan phim Cannes lừng danh. Tận hưởng cảm gi&aacute;c thư gi&atilde;n c&ugrave;ng cảnh biển tuyệt đẹp tại Cannes.<br />
<em>Kh&aacute;ch sạn 3*: Avignon hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 7: Thứ S&aacute;u</em><br />
AVIGNON &rarr; PARIS (700km)<br />
Bắt đầu h&agrave;nh tr&igrave;nh d&agrave;i trở lại Paris. Tr&ecirc;n đường đi Qu&yacute; kh&aacute;ch c&oacute; cơ hội ngắm nh&igrave;n khung cảnh thơ mộng của miền nam nước Ph&aacute;p. Đến Paris l&uacute;c ho&agrave;ng h&ocirc;n.<br />
<em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p><em>Kết th&uacute;c chương tr&igrave;nh tham quan</em></p>

<p><u><strong>Gi&aacute;:</strong></u><br />
- Người lớn: &euro;73/ người/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người : &euro;511<br />
- Trẻ em dưới 11 tuổi: &euro;63/trẻ/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người: &euro;441<br />
-&nbsp;<strong>(1) Kh&aacute;ch sạn</strong>: 3* theo ti&ecirc;u chuẩn Ch&acirc;u &Acirc;u. Ph&ograve;ng đ&ocirc;i d&agrave;nh cho 2 người.<br />
* Kh&aacute;ch lẻ sẽ ở gh&eacute;p với kh&aacute;ch lẻ kh&aacute;c. Y&ecirc;u cầu ph&ograve;ng đơn t&iacute;nh ph&iacute; 30 Euro/người/đ&ecirc;m.<br />
* Kh&aacute;ch lẻ đồng &yacute; ở gh&eacute;p sẽ t&iacute;nh phụ thu ph&ograve;ng đơn ngay khi đặt tour (30 Euro/người/đ&ecirc;m). Khi việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ ho&agrave;n lại tiền cho kh&aacute;ch lẻ sau khi kết th&uacute;c tour.<br />
* Trẻ em từ 2 đến 11 tuổi phải ngủ chung với 2 người lớn, giới hạn 1 ph&ograve;ng 1 trẻ. Nếu y&ecirc;u cầu ngủ giường ri&ecirc;ng cho trẻ th&igrave; t&iacute;nh theo ph&iacute; người lớn. Ng&agrave;y cuối h&agrave;nh tr&igrave;nh kh&ocirc;ng bao gồm kh&aacute;ch sạn.</p>

<p><strong>Thời gian:</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;07 ng&agrave;y (Tuỳ chọn số ng&agrave;y tham gia tour)<br />
<strong>Khởi h&agrave;nh:&nbsp;</strong>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Hằng tuần, xoanh v&ograve;ng, quanh năm. (Tuỳ chọn thời gian v&agrave; địa điểm bắt đầu)<br />
<strong>Điểm đ&oacute;n kh&aacute;ch:&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Paris (Thứ 7), Lucerne (Chủ Nhật), Milan (Chủ Nhật), Rome (Thứ 3).<em>&nbsp;Địa chỉ ch&iacute;nh x&aacute;c từng nơi sẽ cung cấp gần ng&agrave;y đi.</em></p>

<p><u><em><strong>BAO GỒM</strong></em></u></p>

<p>Xe đưa đ&oacute;n đo&agrave;n theo suốt chương tr&igrave;nh quy định.</p>

<p>06 đ&ecirc;m kh&aacute;ch sạn ti&ecirc;u chuẩn 3*** ph&ograve;ng đ&ocirc;i 2 người + 06 bữa ăn s&aacute;ng tại kh&aacute;ch sạn.<br />
Hướng dẫn vi&ecirc;n n&oacute;i tiếng việt theo chương tr&igrave;nh.<br />
&nbsp;<strong>(2) Ăn s&aacute;ng</strong>&nbsp;tại kh&aacute;ch sạn theo ti&ecirc;u chuẩn 3*. Ăn s&aacute;ng kiểu &Acirc;u: Cafe hoặc tr&agrave;, nước &eacute;p, b&aacute;nh m&igrave; v&agrave; mứt.<br />
<strong>(3) Xe tham quan:</strong>&nbsp;Sử dụng xe du lịch 46 chỗ hiện đại, sang trọng.<br />
<strong>(4) Hoạt động tham quan</strong>: Căn cứ theo h&agrave;nh tr&igrave;nh qu&yacute; kh&aacute;ch lựa chọn. Kh&ocirc;ng bao gồm v&eacute; v&agrave;o cổng của c&aacute;c điểm c&oacute; t&iacute;nh ph&iacute; v&agrave;o cổng v&agrave; c&aacute;c hoạt động tham quan ngo&agrave;i chương tr&igrave;nh. (Xem chi tiết Ph&iacute; Tham Quan.)<br />
<strong>(5) Hướng dẫn vi&ecirc;n:</strong>&nbsp;1 Hướng dẫn vi&ecirc;n người Việt/Hoa/Anh (tuỳ h&agrave;nh tr&igrave;nh, tuyến Đỏ v&agrave; tuyến Xanh L&aacute; c&oacute; hướng dẫn vi&ecirc;n người Việt) sẽ hướng dẫn du kh&aacute;ch trong suốt h&agrave;nh tr&igrave;nh. Tại một số điểm đặc biệt, sẽ c&oacute; th&ecirc;m hướng dẫn vi&ecirc;n địa phương theo quy định của ch&iacute;nh quyền sở tại.</p>

<p><em><u><strong>KH&Ocirc;NG BAO GỒM</strong></u></em><br />
V&eacute; m&aacute;y bay khứ hồi Việt Nam &ndash; Ph&aacute;p<br />
Thuế s&acirc;n bay c&aacute;c nước . Hộ chiếu &amp; Lệ ph&iacute; visa. Bảo hiểm y tế c&aacute; nh&acirc;n.<br />
Tiền bia, rượu, nước ngọt trong c&aacute;c bữa ăn ch&iacute;nh.<br />
Tiền điện thoại, giặt ủi, xem TV trả tiền hay sử dụng Mini bar tại kh&aacute;ch sạn.<br />
C&aacute;c chi ph&iacute; c&aacute; nh&acirc;n ph&aacute;t sinh kh&aacute;c ngo&agrave;i chương tr&igrave;nh qui định.<br />
H&agrave;nh l&yacute; qu&aacute; cước quy định.<br />
Tiền tip&rsquo;s 5 &euro;uros / ng&agrave;y/ kh&aacute;ch.<br />
C&aacute;c bữa ăn trưa/tối<br />
Ph&iacute; tham quan<br />
Thuế du lịch tại c&aacute;c th&agrave;nh phố</p>

<p><u><em><strong>LƯU &Yacute;</strong></em></u><br />
Để tr&aacute;nh tăng gi&aacute; tour, kh&aacute;ch sạn c&oacute; thể ở ngoại &ocirc;<br />
Qu&yacute; kh&aacute;ch được hướng dẫn bảng gi&aacute; taxes city v&agrave; ph&iacute; tham quan từng nơi, t&ugrave;y quyết định của qu&yacute; kh&aacute;ch&nbsp; để v&agrave;o thăm quan hay kh&ocirc;ng, cũng như được tư vấn c&aacute;c bữa ăn trưa v&agrave; tối, hoặc tự do.</p>

<p>Ch&uacute;ng t&ocirc;i cung cấp dịch vụ đưa đ&oacute;n tại s&acirc;n bay/ga v&agrave; đặt kh&aacute;ch sạn trước v&agrave; sau khi tham gia tour để chuyến đi của qu&yacute; kh&aacute;ch được thuận tiện v&agrave; thoải m&aacute;i hơn:</p>

<ul>
	<li><strong>Đặt Ph&ograve;ng Trước/ Sau Khi Tham Gia Tour:</strong>&nbsp;&nbsp;<strong>35Euro/người/ đ&ecirc;m/ph&ograve;ng gh&eacute;p</strong></li>
</ul>

<p>1. Ở c&ugrave;ng kh&aacute;ch sạn với đo&agrave;n, ng&agrave;y thứ 2 kh&aacute;ch h&agrave;ng c&oacute; thể l&ecirc;n xe tại kh&aacute;ch sạn, kh&ocirc;ng cần thiết đến điểm tập trung chỉ định.<br />
2. &Aacute;p dụng cho kh&aacute;ch trước v&agrave; sau 1 ng&agrave;y tham gia đo&agrave;n. Nếu kh&aacute;ch h&agrave;ng cần đặt ph&ograve;ng nhiều ng&agrave;y trước khi hoặc sau khi tham gia đo&agrave;n, vui l&ograve;ng li&ecirc;n hệ để được b&aacute;o gi&aacute;.<br />
3. Th&ocirc;ng tin kh&aacute;ch sạn sẽ b&aacute;o ch&iacute;nh x&aacute;c cho kh&aacute;ch h&agrave;ng trước 24 tiếng.</p>

<ul>
	<li><strong>Đưa Đ&oacute;n Tại S&acirc;n Bay:</strong>&nbsp;<strong>25 Euro/ mỗi người / mỗi chuyến</strong></li>
</ul>

<p>1. Tối thiểu 2 người trở l&ecirc;n, người lớn v&agrave; trẻ em c&ugrave;ng gi&aacute;, chỉ 1 kh&aacute;ch t&iacute;nh 50 Euro.<br />
2. Gi&aacute; tr&ecirc;n chỉ &aacute;p dụng cho c&aacute;c s&acirc;n bay v&agrave; kh&aacute;ch sạn trong th&agrave;nh phố, địa điểm tập trung, trạm xe&nbsp;lửa. Bao gồm th&agrave;nh phố như sau: Paris(CDG/ORY), Amsterdam(AMS), Frankfurt(FRA),&nbsp;Rome(FCO/CIA), Vienna(VIE) , Prague(PRG), London(LHR), Manchester(MAN), Madrid(MAD), Barcelona(BCN), Valencia(VLC), Seville(SVQ), Lisbon(LIS) (Ngo&agrave;i ra những th&agrave;nh phố kh&aacute;c sẽ b&aacute;o gi&aacute; sau.<br />
3. Thời gian đưa đ&oacute;n tại s&acirc;n bay từ 07 giờ đến 22 giờ, ngo&agrave;i ra sau giờ quy định v&agrave; phục vụ kh&aacute;c sẽ b&aacute;o gi&aacute; sau. Thời gian chờ tại s&acirc;n bay kh&ocirc;ng qu&aacute; 1 tiếng 30 ph&uacute;t, qu&aacute; thời gian quy định, t&agrave;i xế c&oacute; quyền đi về m&agrave; kh&ocirc;ng cần th&ocirc;ng b&aacute;o. Nếu y&ecirc;u cầu t&agrave;i xế quay lại đ&oacute;n th&igrave; t&iacute;nh ph&iacute; như ban đầu. Trường hợp h&atilde;ng h&agrave;ng kh&ocirc;ng trễ chuyến bay th&igrave; t&iacute;nh theo qu&aacute; giờ quy định, kh&aacute;ch h&agrave;ng c&oacute; thể y&ecirc;u cầu h&atilde;ng h&agrave;ng kh&ocirc;ng bồi thường.&nbsp;</p>

<p><strong>Thủ Tục Đăng K&yacute; V&agrave; Thanh To&aacute;n:</strong><br />
1. Khi đăng k&yacute; vui l&ograve;ng kiểm tra kỹ visa nhập cảnh, hộ chiếu v&agrave; những giấy tờ t&ugrave;y th&acirc;n kh&aacute;c cần phải c&ograve;n hạn &iacute;t nhất 6 th&aacute;ng.<br />
2. Khi đăng k&yacute;, đặt cọc 50%. Thanh to&aacute;n bằng VND (Tỷ gi&aacute; tại thời điểm đ&oacute;ng ph&iacute;) hoặc Euro. Thanh to&aacute;n phần c&ograve;n lại 30 ng&agrave;y hoặc chậm nhất 15 ng&agrave;y (trường hợp khẩn) trước ng&agrave;y xuất ph&aacute;t. Nếu trước 15 ng&agrave;y trước ng&agrave;y xuất ph&aacute;t kh&ocirc;ng thanh to&aacute;n, c&ocirc;ng ty ch&uacute;ng t&ocirc;i c&oacute; quyền hủy bỏ chỗ đ&atilde; đặt, &aacute;p dụng ch&iacute;nh s&aacute;ch Huỷ &amp; Ho&agrave;n Trả.<br />
3. Khi c&oacute; 1 kh&aacute;ch lẻ, ch&uacute;ng t&ocirc;i thu th&ecirc;m ph&iacute; 1 ph&ograve;ng ri&ecirc;ng. Ch&uacute;ng t&ocirc;i sẽ ho&agrave;n trả lại ph&iacute; kh&aacute;ch lẻ nếu qu&yacute; kh&aacute;ch đồng &yacute; gh&eacute;p ph&ograve;ng v&agrave; việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng khi du kh&aacute;ch ho&agrave;n th&agrave;nh tour (khi việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ c&oacute; giấy bi&ecirc;n nhận, qu&yacute; kh&aacute;ch giữ giấy bi&ecirc;n nhận n&agrave;y để c&ocirc;ng ty ch&uacute;ng t&ocirc;i ho&agrave;n trả tiền đặt cọc).<br />
4. Thanh to&aacute;n bằng tiền mặt tại văn ph&ograve;ng TTS hoặc chuyển khoản:<br />
Ng&acirc;n h&agrave;ng thương mại Cổ Phần Ngoại Thương Vi&ecirc;tn Nam - Vietcombank &ndash; Chi nh&aacute;nh TP.HCM.<br />
Chủ T&agrave;i khoản: Ch&acirc;u Kim Th&ugrave;y<br />
Số T&agrave;i khoản: 007 100 3383 412</p>

<p><strong>Ch&iacute;nh S&aacute;ch Hủy Chỗ V&agrave; Ho&agrave;n Trả:</strong><br />
Việc huỷ bỏ phải được thực hiện bằng Email v&agrave; văn bản, x&aacute;c nhận tại văn ph&ograve;ng GTS v&agrave;o ng&agrave;y l&agrave;m việc (Từ thứ 02 đến thứ 06). Mức ho&agrave;n trả căn cứ theo điều khoản như sau:<br />
1.&nbsp; 15 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu huỷ bỏ được ho&agrave;n 100% ph&iacute; đ&atilde; đ&oacute;ng. Được chuyển nhượng,&nbsp;&nbsp;thay đổi lịch tr&igrave;nh.<br />
2. Trong v&ograve;ng 14-8 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 50% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.<br />
3. Trong v&ograve;ng 0-7 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 100% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.</p>

<p><br />
<strong>Ph&iacute; Tham Quan</strong></p>

<p><br />
<strong>Lưu &yacute;:</strong><br />
- Bảng gi&aacute; chỉ mang t&iacute;nh chất tham khảo.&nbsp; Khi c&oacute; sự thay đổi, hướng dẫn vi&ecirc;n sẽ th&ocirc;ng b&aacute;o cho qu&yacute; kh&aacute;ch.<br />
- C&aacute;c hoạt động tham quan, show, v&eacute; v&agrave;o cửa, c&aacute;c bữa ăn đặc biệt&hellip; l&agrave; tuỳ chọn của du kh&aacute;ch, kh&ocirc;ng bao gồm trong gi&aacute; tour. Hướng dẫn vi&ecirc;n sẽ hỗ trợ đăng k&yacute; v&agrave; mua v&eacute; cho qu&yacute; kh&aacute;ch. Việc mua v&eacute; được tiến h&agrave;nh rất nhanh ch&oacute;ng v&agrave; chuy&ecirc;n nghiệp.<br />
- Thuế v&agrave; Lệ Ph&iacute; v&agrave;o th&agrave;nh phố l&agrave; bắt buộc, theo quy định của ch&iacute;nh quyền địa phương. Hướng dẫn vi&ecirc;n sẽ hỗ trợ qu&yacute; kh&aacute;ch thực hiện việc đ&oacute;ng thuế v&agrave; lệ ph&iacute; n&agrave;y.</p>

<p><strong>Tour 2 Green Line &ndash; Optional Activities Price List</strong></p>

<table border="1" cellpadding="1" cellspacing="1">
	<tbody>
		<tr>
			<td>Đấu trường La M&atilde; (Coliseum &ndash; Rome)</td>
			<td>12 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Du thuyền Gondola (1 thuyền &iacute;t nhất 6 người)</td>
			<td>30 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>M&oacute;n mỳ &Yacute; truyền thống của &Yacute;</td>
			<td>20 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Pisa Tower</td>
			<td>20 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Italian Home Made Spaghetti Lunch (Venice)</td>
			<td>20 Eur / kh&aacute;ch</td>
		</tr>
	</tbody>
</table>

<p>Thuế th&agrave;nh phố của &Yacute; v&agrave; Monaco (tổng 45 Eur / kh&aacute;ch) (City tax)</p>

<p>Phải được thanh to&aacute;n trước khi v&agrave;o th&agrave;nh phố (bắt buộc)</p>

<table border="1" cellpadding="1" cellspacing="1">
	<tbody>
		<tr>
			<td>Thuế v&agrave;o Venice + thuế ngồi thuyền + thuế qua đ&ecirc;m<br />
			&nbsp;</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Thuế v&agrave;o Florence + thuế qua đ&ecirc;m</td>
			<td>10 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Thuế v&agrave;o Rome + thuế qua đ&ecirc;m</td>
			<td>10 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Thuế v&agrave;o Pisa</td>
			<td>5 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Thuế v&agrave;o Monaco</td>
			<td>5 Eur / kh&aacute;ch<br />
			<br />
			&nbsp;</td>
		</tr>
	</tbody>
</table>

<p><a href="http://totaltravelsolutions.asia/#tab-related">Tour Li&ecirc;n Quan (6)</a></p>

<ul>
	<li><a href="http://totaltravelsolutions.asia/tour-4-(tuyen-vang):-tay-ban-nha-%E2%80%93-bo-dao-nha">Tour 4 (TUYẾN V&Agrave;NG): T&acirc;y Ban Nha &ndash; Bồ Đ&agrave;o Nha (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-5-(tuyen-tim)-anh-quoc-%E2%80%93-scotland">Tour 5 (TUYẾN T&Iacute;M) ANH QUỐC &ndash; SCOTLAND (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-(tuyen-xanh-duong):-duc-%E2%80%93-cong-hoa-sec-%E2%80%93-slovakia-%E2%80%93-hungary-%E2%80%93-ao-%E2%80%93-thuy-si">Tour 3 (TUYẾN XANH DƯƠNG): ĐỨC &ndash; CỘNG HO&Agrave; S&Eacute;C &ndash; SLOVAKIA &ndash; HUNGARY &ndash; &Aacute;O &ndash; THUỴ SĨ (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-vg">Tour 3 vg (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-6-(tuyen-cam):-phap-andorra-%E2%80%93-tay-nha">Tour 6 (TUYẾN CAM): PH&Aacute;P - ANDORRA &ndash; T&Acirc;Y BAN NHA (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-1-(tuyen-do)-:-phap-%E2%80%93-luxemboug-%E2%80%93-duc-%E2%80%93-ha-lan-%E2%80%93-bi">Tour 1 (TUYẾN ĐỎ) : PH&Aacute;P &ndash; LUXEMBOUG &ndash; ĐỨC &ndash; H&Agrave; LAN &ndash; BỈ (03/03/16)</a></li>
</ul>
', N'business-theme', N'business-theme', N'business-theme', NULL, NULL, 0, CAST(N'2017-07-30T10:49:35.483' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'cf1b2454-dc57-40db-8f95-891ad0cef974', N'en-us', NULL, N'WELCOME TO TOTALTRAVELSOLUTIONS.ASIA', NULL, N'<p>

</p><p>Bạn đam mê khám phá những điều mới lạ, ước mơ được đặt chân đến những thành phố lãng mạn, lỗng lẫy và nguy nga? Thế nhưng, đôi lúc bạn vẫn chưa hài lòng về những chuyến du lịch đã qua. Tốn bao nhiêu thời gian và tiền điện thoại đây để kiếm một dịch vụ uy tín và chất lượng?</p><p>&nbsp;</p><p>Bạn đang lay hoay mất thời gian xin Visa, lo lắng khi người thân đi du lịch ở nơi xa, bạn phân vân nên không biết đặt niềm tin vào dịch vụ nào? Lại thêm đau đầu cho việc chọn khách sạn, đặt vé máy bay..v..v. Hãy tiết kiệm thời gian vàng bạc bằng cách quẳng gánh lo đó cho chúng tôi cùng những phiền muộn khác. Hãy để chúng tôi được chia sẻ và gánh vác giúp bạn.</p><p>&nbsp;</p><p>Chúng tôi - Total Travel Solutions Asia (TTS) – Giải Pháp Du Lịch Toàn Diện muốn cung cấp và đưa ra những giải pháp cho hành trình của bạn cùng gia đình diễn ra tốt đẹp nhất, an tâm nhất với chất lượng dịch vụ cùng cùng sự hỗ trợ xuyên suốt.</p><p>&nbsp;</p><p>Vì chúng tôi muốn bạn dành tâm sức để:</p><p>&nbsp;</p><p>- Hòa mình vào làn sóng biển cùng với cát trắng và nắng vàng dưới ánh hoàng hôn Châu Á;</p><p>- Tận hưởng không khí trong lành căng tràn lá phổi, tham quan vùng đất lâu đời lịch sử, nơi địa đàng thanh bình, cảnh vật đẹp như chuyện cổ tích mọi miền Châu Âu;</p><p>- Khám phá miền hoang dã, tự do và phiêu lưu mạo hiểm ở Châu Phi;</p><p>- Hòa nhập vào lễ hội tưng bừng, rộn rã điệu samba, màu sắc rực rỡ tại vùng Nam Mỹ;</p><p>- Thực hiện giấc mơ đặt chân đến vùng đất hứa hẹn, một thế giới như được thu nhỏ xứ cờ hoa Bắc Mỹ</p><p>- Hay băng qua đại dương mênh mông đến quốc đảo lớn nhất thế giới – Australia xứ sở của những chú chuột túi.</p><p>&nbsp;</p><p>Và còn nhiều những trải nghiệm thú vị, cung bậc cảm xúc cứ đi từ ngạc nhiên này đến ngạc nhiên khác.  Xuân – Hạ - Thu – Đông,  bốn mùa đa sắc, đất trời rộng mở dưới đôi chân bạn.</p><p>&nbsp;</p><p>Hiểu được điều đó, Total Travel Solutions Asia cung cấp những dịch vụ:</p><ul><li>Tư vấn và xin visa trên toàn thế giới</li><li>Đầu tư định cư tại Hòa Kỳ</li><li>Land tour Châu Âu</li><li>Tổ chức tour du lịch trong nước và quốc tế</li><li>Thiết kế tour riêng</li><li>Đại lý vé máy bay trong nước và quốc tế</li><li>Dịch vụ xe đưa đón từ Sân bay, nhà gare</li><li>Đặt khách sạn với giá tốt nhất</li><li>Dịch thuật – Phiên dịch</li></ul><p><strong>Total Travel Solutions Asia – Giải Pháp Du Lịch Toàn Diện Team.</strong></p>

<br><p></p>', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', N'chao-mung-den-voi-totaltravelsolutionsasia', NULL, NULL, 0, CAST(N'2017-07-16T15:57:23.503' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'd4c825f3-0647-479d-9714-7f4df2838dc5', N'en-UK', N'https://s-media-cache-ak0.pinimg.com/736x/97/06/32/970632f6c84be9672b9e68b12d2d6da6.jpg', N'Business theme', N'There are many variations of passages of Lorem Ipsum available, but the majority', NULL, N'business-theme', N'business-theme', N'business-theme', NULL, NULL, 0, CAST(N'2017-07-30T10:52:17.327' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'd4c825f3-0647-479d-9714-7f4df2838dc5', N'en-us', N'https://s-media-cache-ak0.pinimg.com/736x/97/06/32/970632f6c84be9672b9e68b12d2d6da6.jpg', N'TOUR 1 (TUYẾN ĐỎ) : PHÁP – LUXEMBOUG – ĐỨC – HÀ LAN – BỈ', N'Khởi hành THỨ NĂM hàng tuần – vui chơi thỏa thích 5 quốc gia và 10 thành phố
HÀ LAN  - AMSTERDAM
BỈ - BRUXELLES
PHÁP – PARIS REIMS
Luxembourg – TP Luxembourg
ĐỨC – TRIER / KOBLENZ / FRANKFURT / BONN / COLOGNE', N'<p><img alt="" src="http://totaltravelsolutions.asia/image/data/demo/hinh4.jpg" /></p>

<p><strong>Giới Thiệu:</strong><br />
Tham qia v&agrave;o Tuyến Đỏ để tham quan những th&agrave;nh phố nổi tiếng v&agrave; quan trọng nhất v&ugrave;ng Bắc &Acirc;u. Tour sẽ đi qua quốc gia nhỏ bẻ nhưng rất phồn thịnh Luxembourg, c&aacute;c th&agrave;nh phố lịch sử l&acirc;u đời của nước Đức như Cologne, Frankfurt v&agrave; Bonn, Amsterdam y&ecirc;n b&igrave;nh với hệ thống k&ecirc;nh rạch hiền ho&agrave; uốn quanh th&agrave;nh phố hay trung t&acirc;m ch&iacute;nh trị của nước Bỉ.<br />
Với khung cảnh tuyệt đẹp v&agrave; nhiều trải nghiệm th&uacute; vị, Tuyến Đỏ ho&agrave;n to&agrave;n xứng đ&aacute;ng để bạn d&agrave;nh một tuần tham quan.</p>

<p><br />
<em>Ng&agrave;y 1: Thứ Năm</em><br />
PARIS &rarr; VERSAILLES &rarr; PARIS (50km)<br />
Kh&aacute;m ph&aacute; kinh đ&ocirc; &aacute;nh s&aacute;ng Paris: Đại lộ thi&ecirc;n đ&agrave;ng Champs Elysees, Quảng trường Concorde, Khải Ho&agrave;n M&ocirc;n (Arc de Triomph), ng&ocirc;i mộ của Napoleon, th&aacute;p Eiffel, du thuyền tr&ecirc;n s&ocirc;ng Seine v&agrave; ngắm nh&igrave;n những thắng cảnh nằm dọc hai b&ecirc;n bờ s&ocirc;ng như: Nh&agrave; thờ Đức b&agrave;, Cầu Alexander III. Sau đ&oacute; đi tham quan l&acirc;u đ&agrave;i Versailles trước khi quay trở lại Paris.</p>

<p><em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 2: Thứ s&aacute;u:</em><br />
PARIS<br />
Kh&aacute;m ph&aacute; Bảo t&agrave;ng Le Louvre, nơi chứa h&agrave;ng trăm ng&agrave;n t&aacute;c phẩm nghệ thuật c&oacute; gi&aacute; trị của nh&acirc;n loại, trong đ&oacute; đ&aacute;ng ch&uacute; &yacute; nhất l&agrave;: bức tranh nổi tiếng vẽ n&agrave;ng Mona Lisa với nụ cười b&iacute; ẩn của Leonardo da Vinci, Tượng nữ thần sắc đẹp Venus, hay Nữ thần săn bắn&hellip;Tự do tham quan, đến cửa h&agrave;ng miễn thuế hoặc mua sắm tại c&aacute;c trung t&acirc;m thương mại nổi tiếng như: Galeries Lafayette v&agrave; Printemps.<br />
<em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p>Ng&agrave;y 3: Thứ Bảy<br />
PARIS &rarr; REIMS &rarr; LUXEMBOURG (420km)<br />
Đến Reims &ndash; Thủ phủ rượu Champagne nổi tiếng thế giới của nước Ph&aacute;p. Đ&acirc;y cũng l&agrave; nơi c&aacute;c vị Vua của Ph&aacute;p đăng quang v&agrave;o thế kỷ 11. Tham quan Nh&agrave; thờ Đức mẹ Reims &ndash; biểu tượng quan trọng của di sản văn h&oacute;a Ph&aacute;p. Đến Luxembourg, đất nước nhỏ b&eacute; nhưng rất thịnh vượng của ch&acirc;u &Acirc;u. Gh&eacute; thăm Cầu Adolphe v&agrave; Viện lập ph&aacute;p.<br />
<em>Kh&aacute;ch sạn 3*: Luxembourg hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 4: Chủ nhật</em><br />
LUXEMBOURG &rarr; TRIER &rarr; KOBLENZ &rarr; FRANKFURT (400km)<br />
Đến Trier, thị trấn l&acirc;u đời nhất của Đức, gh&eacute; Porta Nigra, th&agrave;nh phố với kiến tr&uacute;c La M&atilde; được bảo tồn h&agrave;ng ng&agrave;n năm qua. Tham quan nh&agrave; v&agrave; l&agrave; bảo t&agrave;ng Karl Marx. Du ngoạn bằng thuyền tr&ecirc;n d&ograve;ng s&ocirc;ng Rhine. Đến Frankfurt, tham quan thị trấn nhỏ Rudesheim nổi tiếng với đặc sản rượu vang v&agrave; Romer platz &ndash; c&ocirc;ng tr&igrave;nh kiến tr&uacute;c v&ocirc; c&ugrave;ng đặc biệt.<br />
<em>Kh&aacute;ch sạn 3*: Frankfurt hay khu vực l&acirc;n cận</em><br />
<em>Ng&agrave;y 5: Thứ Hai</em><br />
FRANKFURT &nbsp;&rarr; BONN &rarr; COLOGNE &rarr; AMSTERDAM (350km)<br />
Đến Bonn, cố đ&ocirc; của T&acirc;y Đức sau chiến tranh thế giới lần 2, tham quan T&ograve;a nh&agrave; Town Hall v&agrave; nh&agrave; của cố nhạc sĩ thi&ecirc;n t&agrave;i Beethoven, nh&agrave; thờ lớn Cologne &ndash; di sản UNESCO, tự do tham quan mua sắm. Buổi chiều đo&agrave;n rời Cologne thẳng tiến đến H&agrave; Lan.<br />
<em>Kh&aacute;ch sạn 3*: Amsterdam hay khu vực l&acirc;n cận</em></p>

<p><br />
<em>Ng&agrave;y 6: Thứ Ba</em><br />
AMSTERDAM &rarr; ZAANSE SCHANS &rarr; AMSTERDAM (50km)<br />
Thăm l&agrave;ng Zannse Schans xinh đẹp, hiền ho&agrave; với những chiếc cối xay gi&oacute;, biểu tưởng của đất nước H&agrave; Lan, thăm xưởng guốc gỗ, xưởng sản xuất ph&ocirc; mai nổi tiếng,&nbsp;l&agrave;ng Vonlendam (Từ giữa th&aacute;ng 3 đến giữa th&aacute;ng 5, đo&agrave;n sẽ đi vườn Keukenhof). Sau đ&oacute;, v&agrave;o trung t&acirc;m Amsterdam, thăm xưởng chế t&aacute;c kim cương. Du kh&aacute;ch tuỳ chọn du ngoạn bằng thuyền tr&ecirc;n c&aacute;c con k&ecirc;nh dọc Amsterdam. Buổi chiều, &nbsp;gh&eacute; thăm khu đ&egrave;n đỏ n&aacute;o nhiệt của Amsterdam.<br />
<em>Kh&aacute;ch sạn 3*: Amsterdam hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 7: Thứ Tư</em><br />
AMSTERDAM &rarr; BRUSSELS &rarr; PARIS (500km)<br />
Đến Thủ đ&ocirc; Brussels của Bỉ, nơi đặt trụ sở của Li&ecirc;n Minh Ch&acirc;u &Acirc;u. Tham quan M&ocirc; h&igrave;nh ph&acirc;n tử học Atomium. V&agrave;o trung t&acirc;m thủ đ&ocirc;, tham quan Quảng trường lớn, Bức tượng đồng ch&uacute; b&eacute; đứng t&egrave; nổi tiếng Manneken Pis, tự do mua sắm chocolate v&agrave; b&aacute;nh waffles nổi tiếng của Bỉ. Sau đ&oacute; chia tay Brussels để di chuyển xuống Paris, Ph&aacute;p.<br />
<em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p>Kết th&uacute;c chương tr&igrave;nh tham quan</p>

<p><strong><u>Gi&aacute;:</u></strong><br />
- Người lớn: &euro;73/ người/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người : &euro;511<br />
- Trẻ em dưới 11 tuổi: &euro;63/trẻ/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người: &euro;441<br />
-&nbsp;<strong>(1) Kh&aacute;ch sạn:</strong>&nbsp;3* theo ti&ecirc;u chuẩn Ch&acirc;u &Acirc;u. Ph&ograve;ng đ&ocirc;i d&agrave;nh cho 2 người.<br />
* Kh&aacute;ch lẻ sẽ ở gh&eacute;p với kh&aacute;ch lẻ kh&aacute;c. Y&ecirc;u cầu ph&ograve;ng đơn t&iacute;nh ph&iacute; 30 Euro/người/đ&ecirc;m.<br />
* Kh&aacute;ch lẻ đồng &yacute; ở gh&eacute;p sẽ t&iacute;nh phụ thu ph&ograve;ng đơn ngay khi đặt tour (30 Euro/người/đ&ecirc;m). Khi việc việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ ho&agrave;n lại tiền cho kh&aacute;ch lẻ sau khi kết th&uacute;c tour.<br />
* Trẻ em từ 2 đến 11 tuổi phải ngủ chung với 2 người lớn, giới hạn 1 ph&ograve;ng 1 trẻ. Nếu y&ecirc;u cầu ngủ giường ri&ecirc;ng cho trẻ th&igrave; t&iacute;nh theo ph&iacute; người lớn. Ng&agrave;y cuối h&agrave;nh tr&igrave;nh kh&ocirc;ng bao gồm kh&aacute;ch sạn.</p>

<p><strong>Thời gian:&nbsp;&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;07 ng&agrave;y (Tuỳ chọn số ng&agrave;y tham gia tour)<br />
<strong>Khởi h&agrave;nh:</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Hằng tuần, xoanh v&ograve;ng, quanh năm. (Tuỳ chọn thời gian v&agrave; địa điểm bắt đầu)<br />
<strong>Điểm đ&oacute;n kh&aacute;ch:&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Paris (Thứ 5, Thứ 6, Thứ 7), Luxembourg (Chủ Nhật), Frankfurt (Thứ 2), Cologne (Thứ 2), Amsterdam (Thứ 4),&nbsp;Brussels (Thứ 4). Địa chỉ ch&iacute;nh x&aacute;c từng nơi sẽ cung cấp gần ng&agrave;y đi.</p>

<p><em><strong>BAO GỒM</strong></em><br />
Xe đưa đ&oacute;n đo&agrave;n theo suốt chương tr&igrave;nh quy định.<br />
06 đ&ecirc;m kh&aacute;ch sạn ti&ecirc;u chuẩn 3*** ph&ograve;ng đ&ocirc;i 2 người + 06 bữa ăn s&aacute;ng tại kh&aacute;ch sạn.<br />
Hướng dẫn vi&ecirc;n n&oacute;i tiếng việt theo chương tr&igrave;nh.<br />
&nbsp;<strong>(2) Ăn s&aacute;ng</strong>&nbsp;tại kh&aacute;ch sạn theo ti&ecirc;u chuẩn 3*. Ăn s&aacute;ng kiểu &Acirc;u: Cafe hoặc tr&agrave;, nước &eacute;p, b&aacute;nh m&igrave; v&agrave; mứt.<br />
<strong>(3) Xe tham quan</strong>: Sử dụng xe du lịch 46 chỗ hiện đại, sang trọng.<br />
<strong>(4) Hoạt động tham quan:</strong>&nbsp;Căn cứ theo h&agrave;nh tr&igrave;nh qu&yacute; kh&aacute;ch lựa chọn. Kh&ocirc;ng bao gồm v&eacute; v&agrave;o cổng của c&aacute;c điểm c&oacute; t&iacute;nh ph&iacute; v&agrave;o cổng v&agrave; c&aacute;c hoạt động tham quan ngo&agrave;i chương tr&igrave;nh. (Xem chi tiết Ph&iacute; Tham Quan.)<br />
<strong>(5) Hướng dẫn vi&ecirc;n:</strong>&nbsp;1 Hướng dẫn vi&ecirc;n người Việt/Hoa/Anh (tuỳ h&agrave;nh tr&igrave;nh, tuyến Đỏ v&agrave; tuyến Xanh L&aacute; c&oacute; hướng dẫn vi&ecirc;n người Việt) sẽ hướng dẫn du kh&aacute;ch trong suốt h&agrave;nh tr&igrave;nh. Tại một số điểm đặc biệt, sẽ c&oacute; th&ecirc;m hướng dẫn vi&ecirc;n địa phương theo quy định của ch&iacute;nh quyền sở tại.</p>

<p><br />
<em><strong>KH&Ocirc;NG BAO GỒM</strong></em><br />
V&eacute; m&aacute;y bay khứ hồi Việt Nam &ndash; Ph&aacute;p<br />
Thuế s&acirc;n bay c&aacute;c nước . Hộ chiếu &amp; Lệ ph&iacute; visa. Bảo hiểm y tế c&aacute; nh&acirc;n.<br />
Tiền bia, rượu, nước ngọt trong c&aacute;c bữa ăn ch&iacute;nh.<br />
Tiền điện thoại, giặt ủi, xem TV trả tiền hay sử dụng Mini bar tại kh&aacute;ch sạn.<br />
C&aacute;c chi ph&iacute; c&aacute; nh&acirc;n ph&aacute;t sinh kh&aacute;c ngo&agrave;i chương tr&igrave;nh qui định.<br />
H&agrave;nh l&yacute; qu&aacute; cước quy định.<br />
Tiền tip&rsquo;s 5 &euro;uros / ng&agrave;y/ kh&aacute;ch.<br />
C&aacute;c bữa ăn trưa/tối<br />
Ph&iacute; tham quan<br />
Thuế du lịch tại c&aacute;c th&agrave;nh phố</p>

<p><strong>LƯU &Yacute;</strong><br />
Để tr&aacute;nh tăng gi&aacute; tour, kh&aacute;ch sạn c&oacute; thể ở ngoại &ocirc;<br />
Qu&yacute; kh&aacute;ch được hướng dẫn bảng gi&aacute; taxes city v&agrave; ph&iacute; tham quan từng nơi, t&ugrave;y quyết định của qu&yacute; kh&aacute;ch&nbsp; để v&agrave;o thăm quan hay kh&ocirc;ng, cũng như được tư vấn c&aacute;c bữa ăn trưa v&agrave; tối, hoặc tự do.</p>

<p>Ch&uacute;ng t&ocirc;i cung cấp dịch vụ đưa đ&oacute;n tại s&acirc;n bay/ga v&agrave; đặt kh&aacute;ch sạn trước v&agrave; sau khi tham gia tour để chuyến đi của qu&yacute; kh&aacute;ch được thuận tiện v&agrave; thoải m&aacute;i hơn:<br />
<strong>Đặt Ph&ograve;ng Trước/ Sau Khi Tham Gia Tour</strong>:&nbsp;&nbsp;<strong>35Euro/người/ đ&ecirc;m/ph&ograve;ng gh&eacute;p</strong><br />
1. Ở c&ugrave;ng kh&aacute;ch sạn với đo&agrave;n, ng&agrave;y thứ 2 kh&aacute;ch h&agrave;ng c&oacute; thể l&ecirc;n xe tại kh&aacute;ch sạn, kh&ocirc;ng cần thiết đến điểm tập trung chỉ định.<br />
2. &Aacute;p dụng cho kh&aacute;ch trước v&agrave; sau 1 ng&agrave;y tham gia đo&agrave;n. Nếu kh&aacute;ch h&agrave;ng cần đặt ph&ograve;ng nhiều ng&agrave;y trước khi hoặc sau khi tham gia đo&agrave;n, vui l&ograve;ng li&ecirc;n hệ để được b&aacute;o gi&aacute;.<br />
3. Th&ocirc;ng tin kh&aacute;ch sạn sẽ b&aacute;o ch&iacute;nh x&aacute;c cho kh&aacute;ch h&agrave;ng trước 24 tiếng.</p>

<ul>
	<li><strong>Đưa Đ&oacute;n Tại S&acirc;n Bay</strong>:&nbsp;<strong>25 Euro/ mỗi người / mỗi chuyến</strong></li>
</ul>

<p>1. Tối thiểu 2 người trở l&ecirc;n, người lớn v&agrave; trẻ em c&ugrave;ng gi&aacute;, chỉ 1 kh&aacute;ch t&iacute;nh 50 Euro.<br />
2. Gi&aacute; tr&ecirc;n chỉ &aacute;p dụng cho c&aacute;c s&acirc;n bay v&agrave; kh&aacute;ch sạn trong th&agrave;nh phố, địa điểm tập trung, trạm xe&nbsp;lửa. Bao gồm th&agrave;nh phố như sau: Paris(CDG/ORY), Amsterdam(AMS), Frankfurt(FRA),&nbsp;Rome(FCO/CIA), Vienna(VIE) , Prague(PRG), London(LHR), Manchester(MAN), Madrid(MAD), Barcelona(BCN), Valencia(VLC), Seville(SVQ), Lisbon(LIS) (Ngo&agrave;i ra những th&agrave;nh phố kh&aacute;c sẽ b&aacute;o gi&aacute; sau.<br />
3. Thời gian đưa đ&oacute;n tại s&acirc;n bay từ 07 giờ đến 22 giờ, ngo&agrave;i ra sau giờ quy định v&agrave; phục vụ kh&aacute;c sẽ b&aacute;o gi&aacute; sau. Thời gian chờ tại s&acirc;n bay kh&ocirc;ng qu&aacute; 1 tiếng 30 ph&uacute;t, qu&aacute; thời gian quy định, t&agrave;i xế c&oacute; quyền đi về m&agrave; kh&ocirc;ng cần th&ocirc;ng b&aacute;o. Nếu y&ecirc;u cầu t&agrave;i xế quay lại đ&oacute;n th&igrave; t&iacute;nh ph&iacute; như ban đầu. Trường hợp h&atilde;ng h&agrave;ng kh&ocirc;ng trễ chuyến bay th&igrave; t&iacute;nh theo qu&aacute; giờ quy định, kh&aacute;ch h&agrave;ng c&oacute; thể y&ecirc;u cầu h&atilde;ng h&agrave;ng kh&ocirc;ng bồi thường.&nbsp;</p>

<ul>
	<li><strong>Thủ Tục Đăng K&yacute; V&agrave; Thanh To&aacute;n:</strong></li>
</ul>

<p>1. Khi đăng k&yacute; vui l&ograve;ng kiểm tra kỹ visa nhập cảnh, hộ chiếu v&agrave; những giấy tờ t&ugrave;y th&acirc;n kh&aacute;c cần phải c&ograve;n hạn &iacute;t nhất 6 th&aacute;ng.<br />
2. Khi đăng k&yacute;, đặt cọc 50%. Thanh to&aacute;n bằng VND (Tỷ gi&aacute; tại thời điểm đ&oacute;ng ph&iacute;) hoặc Euro. Thanh to&aacute;n phần c&ograve;n lại 30 ng&agrave;y hoặc chậm nhất 15 ng&agrave;y (trường hợp khẩn) trước ng&agrave;y xuất ph&aacute;t. Nếu trước 15 ng&agrave;y trước ng&agrave;y xuất ph&aacute;t kh&ocirc;ng thanh to&aacute;n, c&ocirc;ng ty ch&uacute;ng t&ocirc;i c&oacute; quyền hủy bỏ chỗ đ&atilde; đặt, &aacute;p dụng ch&iacute;nh s&aacute;ch Huỷ &amp; Ho&agrave;n Trả.<br />
3. Khi c&oacute; 1 kh&aacute;ch lẻ, ch&uacute;ng t&ocirc;i thu th&ecirc;m ph&iacute; 1 ph&ograve;ng ri&ecirc;ng. Ch&uacute;ng t&ocirc;i sẽ ho&agrave;n trả lại ph&iacute; kh&aacute;ch lẻ nếu qu&yacute; kh&aacute;ch đồng &yacute; gh&eacute;p ph&ograve;ng v&agrave; việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng khi du kh&aacute;ch ho&agrave;n th&agrave;nh tour (khi việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ c&oacute; giấy bi&ecirc;n nhận, qu&yacute; kh&aacute;ch giữ giấy bi&ecirc;n nhận n&agrave;y để c&ocirc;ng ty ch&uacute;ng t&ocirc;i ho&agrave;n trả tiền đặt cọc).<br />
4. Thanh to&aacute;n bằng tiền mặt tại văn ph&ograve;ng TTS hoặc chuyển khoản:<br />
Ng&acirc;n h&agrave;ng thương mại Cổ Phần Ngoại Thương Vi&ecirc;tn Nam - Vietcombank &ndash; Chi nh&aacute;nh TP.HCM.<br />
Chủ T&agrave;i khoản: Ch&acirc;u Kim Th&ugrave;y<br />
Số T&agrave;i khoản: 007 100 3383 412</p>

<ul>
	<li><strong>Ch&iacute;nh S&aacute;ch Hủy Chỗ V&agrave; Ho&agrave;n Trả:</strong></li>
</ul>

<p>Việc huỷ bỏ phải được thực hiện bằng Email v&agrave; văn bản, x&aacute;c nhận tại văn ph&ograve;ng GTS v&agrave;o ng&agrave;y l&agrave;m việc (Từ thứ 02 đến thứ 06). Mức ho&agrave;n trả căn cứ theo điều khoản như sau:<br />
1.&nbsp; 15 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu huỷ bỏ được ho&agrave;n 100% ph&iacute; đ&atilde; đ&oacute;ng. Được chuyển nhượng,&nbsp;&nbsp;thay đổi lịch tr&igrave;nh.<br />
2. Trong v&ograve;ng 14-8 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 50% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.<br />
3. Trong v&ograve;ng 0-7 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 100% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.</p>

<p><strong>Ph&iacute; Tham Quan</strong></p>

<p><strong>Lưu &yacute;:</strong><br />
- Bảng gi&aacute; chỉ mang t&iacute;nh chất tham khảo.&nbsp; Khi c&oacute; sự thay đổi, hướng dẫn vi&ecirc;n sẽ th&ocirc;ng b&aacute;o cho qu&yacute; kh&aacute;ch.<br />
- C&aacute;c hoạt động tham quan, show, v&eacute; v&agrave;o cửa, c&aacute;c bữa ăn đặc biệt&hellip; l&agrave; tuỳ chọn của du kh&aacute;ch, kh&ocirc;ng bao gồm trong gi&aacute; tour. Hướng dẫn vi&ecirc;n sẽ hỗ trợ đăng k&yacute; v&agrave; mua v&eacute; cho qu&yacute; kh&aacute;ch. Việc mua v&eacute; được tiến h&agrave;nh rất nhanh ch&oacute;ng v&agrave; chuy&ecirc;n nghiệp.<br />
- Thuế v&agrave; Lệ Ph&iacute; v&agrave;o th&agrave;nh phố l&agrave; bắt buộc, theo quy định của ch&iacute;nh quyền địa phương. Hướng dẫn vi&ecirc;n sẽ hỗ trợ qu&yacute; kh&aacute;ch thực hiện việc đ&oacute;ng thuế v&agrave; lệ ph&iacute; n&agrave;y.</p>

<p><strong>Tour 1 Red Line &ndash; Optional Activities Price List</strong></p>

<table border="1" cellpadding="1" cellspacing="1" style="height:416px; width:100%">
	<tbody>
		<tr>
			<td>
			<p>Vườn Keukenhof (th&aacute;ng 3 &ndash; th&aacute;ng 5)</p>
			</td>
			<td>
			<p>15 Eur / kh&aacute;ch</p>
			</td>
		</tr>
		<tr>
			<td>Bảo t&agrave;ng Louvre (Thứ 3 đ&oacute;ng cửa)</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Th&aacute;p Eiffel (tầng 2)</td>
			<td>11 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Th&aacute;p Eiffel (tầng thượng)</td>
			<td>15.5 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Du thuyền dọc c&aacute;c con k&ecirc;nh Amsterdam</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Tour Montparnasse</td>
			<td>14.5 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Du thuyền s&ocirc;ng Rhine</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris Lido Show</td>
			<td>140 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris Moulin Rouge Show</td>
			<td>140 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Khu Đ&egrave;n Đỏ Amsterdam &amp; Live show</td>
			<td>50 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris by Night</td>
			<td>35 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>L&agrave;ng truyền thống Volendam H&agrave; Lan</td>
			<td>10 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>French multi-course dinner (bữa ăn nhiều m&oacute;n truyền thống Ph&aacute;p)</td>
			<td>65 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Bữa ăn truyền thống Đức với beer (Koblenz)</td>
			<td>20 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Vườn Keukenhof (th&aacute;ng 3 &ndash; th&aacute;ng 5)</td>
			<td>16 Eur / kh&aacute;ch</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p><a href="http://totaltravelsolutions.asia/#tab-related">Tour Li&ecirc;n Quan (6)</a></p>

<ul>
	<li><a href="http://totaltravelsolutions.asia/tour-4-(tuyen-vang):-tay-ban-nha-%E2%80%93-bo-dao-nha">Tour 4 (TUYẾN V&Agrave;NG): T&acirc;y Ban Nha &ndash; Bồ Đ&agrave;o Nha (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-5-(tuyen-tim)-anh-quoc-%E2%80%93-scotland">Tour 5 (TUYẾN T&Iacute;M) ANH QUỐC &ndash; SCOTLAND (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-2-(tuyen-xanh-la):-phap-thuy-si-%E2%80%93-italia-vatican-%E2%80%93-monaco">Tour 2 (TUYẾN XANH L&Aacute;): PH&Aacute;P - THỤY SĨ &ndash; ITALIA - VATICAN &ndash; MONACO (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-(tuyen-xanh-duong):-duc-%E2%80%93-cong-hoa-sec-%E2%80%93-slovakia-%E2%80%93-hungary-%E2%80%93-ao-%E2%80%93-thuy-si">Tour 3 (TUYẾN XANH DƯƠNG): ĐỨC &ndash; CỘNG HO&Agrave; S&Eacute;C &ndash; SLOVAKIA &ndash; HUNGARY &ndash; &Aacute;O &ndash; THUỴ SĨ (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-vg">Tour 3 vg (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-6-(tuyen-cam):-phap-andorra-%E2%80%93-tay-nha">Tour 6 (TUYẾN CAM): PH&Aacute;P - ANDORRA &ndash; T&Acirc;Y BAN NHA (25/02/16)</a></li>
</ul>
', N'business-theme', N'business-theme', N'business-theme', NULL, NULL, 0, CAST(N'2017-07-30T10:52:17.327' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Article] ([Id], [Specificulture], [Image], [Title], [Excerpt], [FullContent], [SeoTitle], [SeoDescription], [SeoKeywords], [Source], [Views], [Type], [CreatedDate], [CreatedBy], [IsVisible], [IsDeleted]) VALUES (N'd4c825f3-0647-479d-9714-7f4df2838dc5', N'vi-vn', N'/Uploads/undefined/9d5fa71c5447456dbd37f658957ffdfb.jpg', N'TOUR 1 (TUYẾN ĐỎ) : PHÁP – LUXEMBOUG – ĐỨC – HÀ LAN – BỈ', N'Khởi hành THỨ NĂM hàng tuần – vui chơi thỏa thích 5 quốc gia và 10 thành phố
HÀ LAN  - AMSTERDAM
BỈ - BRUXELLES
PHÁP – PARIS REIMS
Luxembourg – TP Luxembourg
ĐỨC – TRIER / KOBLENZ / FRANKFURT / BONN / COLOGNE', N'<p><img alt="" src="http://totaltravelsolutions.asia/image/data/demo/hinh4.jpg" /></p>

<p><strong>Giới Thiệu:</strong><br />
Tham qia v&agrave;o Tuyến Đỏ để tham quan những th&agrave;nh phố nổi tiếng v&agrave; quan trọng nhất v&ugrave;ng Bắc &Acirc;u. Tour sẽ đi qua quốc gia nhỏ bẻ nhưng rất phồn thịnh Luxembourg, c&aacute;c th&agrave;nh phố lịch sử l&acirc;u đời của nước Đức như Cologne, Frankfurt v&agrave; Bonn, Amsterdam y&ecirc;n b&igrave;nh với hệ thống k&ecirc;nh rạch hiền ho&agrave; uốn quanh th&agrave;nh phố hay trung t&acirc;m ch&iacute;nh trị của nước Bỉ.<br />
Với khung cảnh tuyệt đẹp v&agrave; nhiều trải nghiệm th&uacute; vị, Tuyến Đỏ ho&agrave;n to&agrave;n xứng đ&aacute;ng để bạn d&agrave;nh một tuần tham quan.</p>

<p><br />
<em>Ng&agrave;y 1: Thứ Năm</em><br />
PARIS &rarr; VERSAILLES &rarr; PARIS (50km)<br />
Kh&aacute;m ph&aacute; kinh đ&ocirc; &aacute;nh s&aacute;ng Paris: Đại lộ thi&ecirc;n đ&agrave;ng Champs Elysees, Quảng trường Concorde, Khải Ho&agrave;n M&ocirc;n (Arc de Triomph), ng&ocirc;i mộ của Napoleon, th&aacute;p Eiffel, du thuyền tr&ecirc;n s&ocirc;ng Seine v&agrave; ngắm nh&igrave;n những thắng cảnh nằm dọc hai b&ecirc;n bờ s&ocirc;ng như: Nh&agrave; thờ Đức b&agrave;, Cầu Alexander III. Sau đ&oacute; đi tham quan l&acirc;u đ&agrave;i Versailles trước khi quay trở lại Paris.</p>

<p><em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 2: Thứ s&aacute;u:</em><br />
PARIS<br />
Kh&aacute;m ph&aacute; Bảo t&agrave;ng Le Louvre, nơi chứa h&agrave;ng trăm ng&agrave;n t&aacute;c phẩm nghệ thuật c&oacute; gi&aacute; trị của nh&acirc;n loại, trong đ&oacute; đ&aacute;ng ch&uacute; &yacute; nhất l&agrave;: bức tranh nổi tiếng vẽ n&agrave;ng Mona Lisa với nụ cười b&iacute; ẩn của Leonardo da Vinci, Tượng nữ thần sắc đẹp Venus, hay Nữ thần săn bắn&hellip;Tự do tham quan, đến cửa h&agrave;ng miễn thuế hoặc mua sắm tại c&aacute;c trung t&acirc;m thương mại nổi tiếng như: Galeries Lafayette v&agrave; Printemps.<br />
<em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p>Ng&agrave;y 3: Thứ Bảy<br />
PARIS &rarr; REIMS &rarr; LUXEMBOURG (420km)<br />
Đến Reims &ndash; Thủ phủ rượu Champagne nổi tiếng thế giới của nước Ph&aacute;p. Đ&acirc;y cũng l&agrave; nơi c&aacute;c vị Vua của Ph&aacute;p đăng quang v&agrave;o thế kỷ 11. Tham quan Nh&agrave; thờ Đức mẹ Reims &ndash; biểu tượng quan trọng của di sản văn h&oacute;a Ph&aacute;p. Đến Luxembourg, đất nước nhỏ b&eacute; nhưng rất thịnh vượng của ch&acirc;u &Acirc;u. Gh&eacute; thăm Cầu Adolphe v&agrave; Viện lập ph&aacute;p.<br />
<em>Kh&aacute;ch sạn 3*: Luxembourg hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 4: Chủ nhật</em><br />
LUXEMBOURG &rarr; TRIER &rarr; KOBLENZ &rarr; FRANKFURT (400km)<br />
Đến Trier, thị trấn l&acirc;u đời nhất của Đức, gh&eacute; Porta Nigra, th&agrave;nh phố với kiến tr&uacute;c La M&atilde; được bảo tồn h&agrave;ng ng&agrave;n năm qua. Tham quan nh&agrave; v&agrave; l&agrave; bảo t&agrave;ng Karl Marx. Du ngoạn bằng thuyền tr&ecirc;n d&ograve;ng s&ocirc;ng Rhine. Đến Frankfurt, tham quan thị trấn nhỏ Rudesheim nổi tiếng với đặc sản rượu vang v&agrave; Romer platz &ndash; c&ocirc;ng tr&igrave;nh kiến tr&uacute;c v&ocirc; c&ugrave;ng đặc biệt.<br />
<em>Kh&aacute;ch sạn 3*: Frankfurt hay khu vực l&acirc;n cận</em><br />
<em>Ng&agrave;y 5: Thứ Hai</em><br />
FRANKFURT &nbsp;&rarr; BONN &rarr; COLOGNE &rarr; AMSTERDAM (350km)<br />
Đến Bonn, cố đ&ocirc; của T&acirc;y Đức sau chiến tranh thế giới lần 2, tham quan T&ograve;a nh&agrave; Town Hall v&agrave; nh&agrave; của cố nhạc sĩ thi&ecirc;n t&agrave;i Beethoven, nh&agrave; thờ lớn Cologne &ndash; di sản UNESCO, tự do tham quan mua sắm. Buổi chiều đo&agrave;n rời Cologne thẳng tiến đến H&agrave; Lan.<br />
<em>Kh&aacute;ch sạn 3*: Amsterdam hay khu vực l&acirc;n cận</em></p>

<p><br />
<em>Ng&agrave;y 6: Thứ Ba</em><br />
AMSTERDAM &rarr; ZAANSE SCHANS &rarr; AMSTERDAM (50km)<br />
Thăm l&agrave;ng Zannse Schans xinh đẹp, hiền ho&agrave; với những chiếc cối xay gi&oacute;, biểu tưởng của đất nước H&agrave; Lan, thăm xưởng guốc gỗ, xưởng sản xuất ph&ocirc; mai nổi tiếng,&nbsp;l&agrave;ng Vonlendam (Từ giữa th&aacute;ng 3 đến giữa th&aacute;ng 5, đo&agrave;n sẽ đi vườn Keukenhof). Sau đ&oacute;, v&agrave;o trung t&acirc;m Amsterdam, thăm xưởng chế t&aacute;c kim cương. Du kh&aacute;ch tuỳ chọn du ngoạn bằng thuyền tr&ecirc;n c&aacute;c con k&ecirc;nh dọc Amsterdam. Buổi chiều, &nbsp;gh&eacute; thăm khu đ&egrave;n đỏ n&aacute;o nhiệt của Amsterdam.<br />
<em>Kh&aacute;ch sạn 3*: Amsterdam hay khu vực l&acirc;n cận</em></p>

<p><em>Ng&agrave;y 7: Thứ Tư</em><br />
AMSTERDAM &rarr; BRUSSELS &rarr; PARIS (500km)<br />
Đến Thủ đ&ocirc; Brussels của Bỉ, nơi đặt trụ sở của Li&ecirc;n Minh Ch&acirc;u &Acirc;u. Tham quan M&ocirc; h&igrave;nh ph&acirc;n tử học Atomium. V&agrave;o trung t&acirc;m thủ đ&ocirc;, tham quan Quảng trường lớn, Bức tượng đồng ch&uacute; b&eacute; đứng t&egrave; nổi tiếng Manneken Pis, tự do mua sắm chocolate v&agrave; b&aacute;nh waffles nổi tiếng của Bỉ. Sau đ&oacute; chia tay Brussels để di chuyển xuống Paris, Ph&aacute;p.<br />
<em>Kh&aacute;ch sạn 3*: Paris hay khu vực l&acirc;n cận</em></p>

<p>Kết th&uacute;c chương tr&igrave;nh tham quan</p>

<p><strong><u>Gi&aacute;:</u></strong><br />
- Người lớn: &euro;73/ người/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người : &euro;511<br />
- Trẻ em dưới 11 tuổi: &euro;63/trẻ/ng&agrave;y =&gt; Tour 7 ng&agrave;y/người: &euro;441<br />
-&nbsp;<strong>(1) Kh&aacute;ch sạn:</strong>&nbsp;3* theo ti&ecirc;u chuẩn Ch&acirc;u &Acirc;u. Ph&ograve;ng đ&ocirc;i d&agrave;nh cho 2 người.<br />
* Kh&aacute;ch lẻ sẽ ở gh&eacute;p với kh&aacute;ch lẻ kh&aacute;c. Y&ecirc;u cầu ph&ograve;ng đơn t&iacute;nh ph&iacute; 30 Euro/người/đ&ecirc;m.<br />
* Kh&aacute;ch lẻ đồng &yacute; ở gh&eacute;p sẽ t&iacute;nh phụ thu ph&ograve;ng đơn ngay khi đặt tour (30 Euro/người/đ&ecirc;m). Khi việc việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ ho&agrave;n lại tiền cho kh&aacute;ch lẻ sau khi kết th&uacute;c tour.<br />
* Trẻ em từ 2 đến 11 tuổi phải ngủ chung với 2 người lớn, giới hạn 1 ph&ograve;ng 1 trẻ. Nếu y&ecirc;u cầu ngủ giường ri&ecirc;ng cho trẻ th&igrave; t&iacute;nh theo ph&iacute; người lớn. Ng&agrave;y cuối h&agrave;nh tr&igrave;nh kh&ocirc;ng bao gồm kh&aacute;ch sạn.</p>

<p><strong>Thời gian:&nbsp;&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;07 ng&agrave;y (Tuỳ chọn số ng&agrave;y tham gia tour)<br />
<strong>Khởi h&agrave;nh:</strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Hằng tuần, xoanh v&ograve;ng, quanh năm. (Tuỳ chọn thời gian v&agrave; địa điểm bắt đầu)<br />
<strong>Điểm đ&oacute;n kh&aacute;ch:&nbsp;</strong>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Paris (Thứ 5, Thứ 6, Thứ 7), Luxembourg (Chủ Nhật), Frankfurt (Thứ 2), Cologne (Thứ 2), Amsterdam (Thứ 4),&nbsp;Brussels (Thứ 4). Địa chỉ ch&iacute;nh x&aacute;c từng nơi sẽ cung cấp gần ng&agrave;y đi.</p>

<p><em><strong>BAO GỒM</strong></em><br />
Xe đưa đ&oacute;n đo&agrave;n theo suốt chương tr&igrave;nh quy định.<br />
06 đ&ecirc;m kh&aacute;ch sạn ti&ecirc;u chuẩn 3*** ph&ograve;ng đ&ocirc;i 2 người + 06 bữa ăn s&aacute;ng tại kh&aacute;ch sạn.<br />
Hướng dẫn vi&ecirc;n n&oacute;i tiếng việt theo chương tr&igrave;nh.<br />
&nbsp;<strong>(2) Ăn s&aacute;ng</strong>&nbsp;tại kh&aacute;ch sạn theo ti&ecirc;u chuẩn 3*. Ăn s&aacute;ng kiểu &Acirc;u: Cafe hoặc tr&agrave;, nước &eacute;p, b&aacute;nh m&igrave; v&agrave; mứt.<br />
<strong>(3) Xe tham quan</strong>: Sử dụng xe du lịch 46 chỗ hiện đại, sang trọng.<br />
<strong>(4) Hoạt động tham quan:</strong>&nbsp;Căn cứ theo h&agrave;nh tr&igrave;nh qu&yacute; kh&aacute;ch lựa chọn. Kh&ocirc;ng bao gồm v&eacute; v&agrave;o cổng của c&aacute;c điểm c&oacute; t&iacute;nh ph&iacute; v&agrave;o cổng v&agrave; c&aacute;c hoạt động tham quan ngo&agrave;i chương tr&igrave;nh. (Xem chi tiết Ph&iacute; Tham Quan.)<br />
<strong>(5) Hướng dẫn vi&ecirc;n:</strong>&nbsp;1 Hướng dẫn vi&ecirc;n người Việt/Hoa/Anh (tuỳ h&agrave;nh tr&igrave;nh, tuyến Đỏ v&agrave; tuyến Xanh L&aacute; c&oacute; hướng dẫn vi&ecirc;n người Việt) sẽ hướng dẫn du kh&aacute;ch trong suốt h&agrave;nh tr&igrave;nh. Tại một số điểm đặc biệt, sẽ c&oacute; th&ecirc;m hướng dẫn vi&ecirc;n địa phương theo quy định của ch&iacute;nh quyền sở tại.</p>

<p><br />
<em><strong>KH&Ocirc;NG BAO GỒM</strong></em><br />
V&eacute; m&aacute;y bay khứ hồi Việt Nam &ndash; Ph&aacute;p<br />
Thuế s&acirc;n bay c&aacute;c nước . Hộ chiếu &amp; Lệ ph&iacute; visa. Bảo hiểm y tế c&aacute; nh&acirc;n.<br />
Tiền bia, rượu, nước ngọt trong c&aacute;c bữa ăn ch&iacute;nh.<br />
Tiền điện thoại, giặt ủi, xem TV trả tiền hay sử dụng Mini bar tại kh&aacute;ch sạn.<br />
C&aacute;c chi ph&iacute; c&aacute; nh&acirc;n ph&aacute;t sinh kh&aacute;c ngo&agrave;i chương tr&igrave;nh qui định.<br />
H&agrave;nh l&yacute; qu&aacute; cước quy định.<br />
Tiền tip&rsquo;s 5 &euro;uros / ng&agrave;y/ kh&aacute;ch.<br />
C&aacute;c bữa ăn trưa/tối<br />
Ph&iacute; tham quan<br />
Thuế du lịch tại c&aacute;c th&agrave;nh phố</p>

<p><strong>LƯU &Yacute;</strong><br />
Để tr&aacute;nh tăng gi&aacute; tour, kh&aacute;ch sạn c&oacute; thể ở ngoại &ocirc;<br />
Qu&yacute; kh&aacute;ch được hướng dẫn bảng gi&aacute; taxes city v&agrave; ph&iacute; tham quan từng nơi, t&ugrave;y quyết định của qu&yacute; kh&aacute;ch&nbsp; để v&agrave;o thăm quan hay kh&ocirc;ng, cũng như được tư vấn c&aacute;c bữa ăn trưa v&agrave; tối, hoặc tự do.</p>

<p>Ch&uacute;ng t&ocirc;i cung cấp dịch vụ đưa đ&oacute;n tại s&acirc;n bay/ga v&agrave; đặt kh&aacute;ch sạn trước v&agrave; sau khi tham gia tour để chuyến đi của qu&yacute; kh&aacute;ch được thuận tiện v&agrave; thoải m&aacute;i hơn:<br />
<strong>Đặt Ph&ograve;ng Trước/ Sau Khi Tham Gia Tour</strong>:&nbsp;&nbsp;<strong>35Euro/người/ đ&ecirc;m/ph&ograve;ng gh&eacute;p</strong><br />
1. Ở c&ugrave;ng kh&aacute;ch sạn với đo&agrave;n, ng&agrave;y thứ 2 kh&aacute;ch h&agrave;ng c&oacute; thể l&ecirc;n xe tại kh&aacute;ch sạn, kh&ocirc;ng cần thiết đến điểm tập trung chỉ định.<br />
2. &Aacute;p dụng cho kh&aacute;ch trước v&agrave; sau 1 ng&agrave;y tham gia đo&agrave;n. Nếu kh&aacute;ch h&agrave;ng cần đặt ph&ograve;ng nhiều ng&agrave;y trước khi hoặc sau khi tham gia đo&agrave;n, vui l&ograve;ng li&ecirc;n hệ để được b&aacute;o gi&aacute;.<br />
3. Th&ocirc;ng tin kh&aacute;ch sạn sẽ b&aacute;o ch&iacute;nh x&aacute;c cho kh&aacute;ch h&agrave;ng trước 24 tiếng.</p>

<ul>
	<li><strong>Đưa Đ&oacute;n Tại S&acirc;n Bay</strong>:&nbsp;<strong>25 Euro/ mỗi người / mỗi chuyến</strong></li>
</ul>

<p>1. Tối thiểu 2 người trở l&ecirc;n, người lớn v&agrave; trẻ em c&ugrave;ng gi&aacute;, chỉ 1 kh&aacute;ch t&iacute;nh 50 Euro.<br />
2. Gi&aacute; tr&ecirc;n chỉ &aacute;p dụng cho c&aacute;c s&acirc;n bay v&agrave; kh&aacute;ch sạn trong th&agrave;nh phố, địa điểm tập trung, trạm xe&nbsp;lửa. Bao gồm th&agrave;nh phố như sau: Paris(CDG/ORY), Amsterdam(AMS), Frankfurt(FRA),&nbsp;Rome(FCO/CIA), Vienna(VIE) , Prague(PRG), London(LHR), Manchester(MAN), Madrid(MAD), Barcelona(BCN), Valencia(VLC), Seville(SVQ), Lisbon(LIS) (Ngo&agrave;i ra những th&agrave;nh phố kh&aacute;c sẽ b&aacute;o gi&aacute; sau.<br />
3. Thời gian đưa đ&oacute;n tại s&acirc;n bay từ 07 giờ đến 22 giờ, ngo&agrave;i ra sau giờ quy định v&agrave; phục vụ kh&aacute;c sẽ b&aacute;o gi&aacute; sau. Thời gian chờ tại s&acirc;n bay kh&ocirc;ng qu&aacute; 1 tiếng 30 ph&uacute;t, qu&aacute; thời gian quy định, t&agrave;i xế c&oacute; quyền đi về m&agrave; kh&ocirc;ng cần th&ocirc;ng b&aacute;o. Nếu y&ecirc;u cầu t&agrave;i xế quay lại đ&oacute;n th&igrave; t&iacute;nh ph&iacute; như ban đầu. Trường hợp h&atilde;ng h&agrave;ng kh&ocirc;ng trễ chuyến bay th&igrave; t&iacute;nh theo qu&aacute; giờ quy định, kh&aacute;ch h&agrave;ng c&oacute; thể y&ecirc;u cầu h&atilde;ng h&agrave;ng kh&ocirc;ng bồi thường.&nbsp;</p>

<ul>
	<li><strong>Thủ Tục Đăng K&yacute; V&agrave; Thanh To&aacute;n:</strong></li>
</ul>

<p>1. Khi đăng k&yacute; vui l&ograve;ng kiểm tra kỹ visa nhập cảnh, hộ chiếu v&agrave; những giấy tờ t&ugrave;y th&acirc;n kh&aacute;c cần phải c&ograve;n hạn &iacute;t nhất 6 th&aacute;ng.<br />
2. Khi đăng k&yacute;, đặt cọc 50%. Thanh to&aacute;n bằng VND (Tỷ gi&aacute; tại thời điểm đ&oacute;ng ph&iacute;) hoặc Euro. Thanh to&aacute;n phần c&ograve;n lại 30 ng&agrave;y hoặc chậm nhất 15 ng&agrave;y (trường hợp khẩn) trước ng&agrave;y xuất ph&aacute;t. Nếu trước 15 ng&agrave;y trước ng&agrave;y xuất ph&aacute;t kh&ocirc;ng thanh to&aacute;n, c&ocirc;ng ty ch&uacute;ng t&ocirc;i c&oacute; quyền hủy bỏ chỗ đ&atilde; đặt, &aacute;p dụng ch&iacute;nh s&aacute;ch Huỷ &amp; Ho&agrave;n Trả.<br />
3. Khi c&oacute; 1 kh&aacute;ch lẻ, ch&uacute;ng t&ocirc;i thu th&ecirc;m ph&iacute; 1 ph&ograve;ng ri&ecirc;ng. Ch&uacute;ng t&ocirc;i sẽ ho&agrave;n trả lại ph&iacute; kh&aacute;ch lẻ nếu qu&yacute; kh&aacute;ch đồng &yacute; gh&eacute;p ph&ograve;ng v&agrave; việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng khi du kh&aacute;ch ho&agrave;n th&agrave;nh tour (khi việc gh&eacute;p ph&ograve;ng th&agrave;nh c&ocirc;ng sẽ c&oacute; giấy bi&ecirc;n nhận, qu&yacute; kh&aacute;ch giữ giấy bi&ecirc;n nhận n&agrave;y để c&ocirc;ng ty ch&uacute;ng t&ocirc;i ho&agrave;n trả tiền đặt cọc).<br />
4. Thanh to&aacute;n bằng tiền mặt tại văn ph&ograve;ng TTS hoặc chuyển khoản:<br />
Ng&acirc;n h&agrave;ng thương mại Cổ Phần Ngoại Thương Vi&ecirc;tn Nam - Vietcombank &ndash; Chi nh&aacute;nh TP.HCM.<br />
Chủ T&agrave;i khoản: Ch&acirc;u Kim Th&ugrave;y<br />
Số T&agrave;i khoản: 007 100 3383 412</p>

<ul>
	<li><strong>Ch&iacute;nh S&aacute;ch Hủy Chỗ V&agrave; Ho&agrave;n Trả:</strong></li>
</ul>

<p>Việc huỷ bỏ phải được thực hiện bằng Email v&agrave; văn bản, x&aacute;c nhận tại văn ph&ograve;ng GTS v&agrave;o ng&agrave;y l&agrave;m việc (Từ thứ 02 đến thứ 06). Mức ho&agrave;n trả căn cứ theo điều khoản như sau:<br />
1.&nbsp; 15 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu huỷ bỏ được ho&agrave;n 100% ph&iacute; đ&atilde; đ&oacute;ng. Được chuyển nhượng,&nbsp;&nbsp;thay đổi lịch tr&igrave;nh.<br />
2. Trong v&ograve;ng 14-8 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 50% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.<br />
3. Trong v&ograve;ng 0-7 ng&agrave;y trước ng&agrave;y khởi h&agrave;nh: nếu hủy bỏ, khấu trừ 100% trong tổng số tiền đ&atilde; thanh to&aacute;n. Kh&ocirc;ng được chuyển nhượng, thay đổi lịch tr&igrave;nh.</p>

<p><strong>Ph&iacute; Tham Quan</strong></p>

<p><strong>Lưu &yacute;:</strong><br />
- Bảng gi&aacute; chỉ mang t&iacute;nh chất tham khảo.&nbsp; Khi c&oacute; sự thay đổi, hướng dẫn vi&ecirc;n sẽ th&ocirc;ng b&aacute;o cho qu&yacute; kh&aacute;ch.<br />
- C&aacute;c hoạt động tham quan, show, v&eacute; v&agrave;o cửa, c&aacute;c bữa ăn đặc biệt&hellip; l&agrave; tuỳ chọn của du kh&aacute;ch, kh&ocirc;ng bao gồm trong gi&aacute; tour. Hướng dẫn vi&ecirc;n sẽ hỗ trợ đăng k&yacute; v&agrave; mua v&eacute; cho qu&yacute; kh&aacute;ch. Việc mua v&eacute; được tiến h&agrave;nh rất nhanh ch&oacute;ng v&agrave; chuy&ecirc;n nghiệp.<br />
- Thuế v&agrave; Lệ Ph&iacute; v&agrave;o th&agrave;nh phố l&agrave; bắt buộc, theo quy định của ch&iacute;nh quyền địa phương. Hướng dẫn vi&ecirc;n sẽ hỗ trợ qu&yacute; kh&aacute;ch thực hiện việc đ&oacute;ng thuế v&agrave; lệ ph&iacute; n&agrave;y.</p>

<p><strong>Tour 1 Red Line &ndash; Optional Activities Price List</strong></p>

<table border="1" cellpadding="1" cellspacing="1" style="height:416px; width:100%">
	<tbody>
		<tr>
			<td>
			<p>Vườn Keukenhof (th&aacute;ng 3 &ndash; th&aacute;ng 5)</p>
			</td>
			<td>
			<p>15 Eur / kh&aacute;ch</p>
			</td>
		</tr>
		<tr>
			<td>Bảo t&agrave;ng Louvre (Thứ 3 đ&oacute;ng cửa)</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Th&aacute;p Eiffel (tầng 2)</td>
			<td>11 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Th&aacute;p Eiffel (tầng thượng)</td>
			<td>15.5 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Du thuyền dọc c&aacute;c con k&ecirc;nh Amsterdam</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Tour Montparnasse</td>
			<td>14.5 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Du thuyền s&ocirc;ng Rhine</td>
			<td>15 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris Lido Show</td>
			<td>140 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris Moulin Rouge Show</td>
			<td>140 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Khu Đ&egrave;n Đỏ Amsterdam &amp; Live show</td>
			<td>50 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Paris by Night</td>
			<td>35 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>L&agrave;ng truyền thống Volendam H&agrave; Lan</td>
			<td>10 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>French multi-course dinner (bữa ăn nhiều m&oacute;n truyền thống Ph&aacute;p)</td>
			<td>65 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Bữa ăn truyền thống Đức với beer (Koblenz)</td>
			<td>20 Eur / kh&aacute;ch</td>
		</tr>
		<tr>
			<td>Vườn Keukenhof (th&aacute;ng 3 &ndash; th&aacute;ng 5)</td>
			<td>16 Eur / kh&aacute;ch</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p><a href="http://totaltravelsolutions.asia/#tab-related">Tour Li&ecirc;n Quan (6)</a></p>

<ul>
	<li><a href="http://totaltravelsolutions.asia/tour-4-(tuyen-vang):-tay-ban-nha-%E2%80%93-bo-dao-nha">Tour 4 (TUYẾN V&Agrave;NG): T&acirc;y Ban Nha &ndash; Bồ Đ&agrave;o Nha (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-5-(tuyen-tim)-anh-quoc-%E2%80%93-scotland">Tour 5 (TUYẾN T&Iacute;M) ANH QUỐC &ndash; SCOTLAND (17/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-2-(tuyen-xanh-la):-phap-thuy-si-%E2%80%93-italia-vatican-%E2%80%93-monaco">Tour 2 (TUYẾN XANH L&Aacute;): PH&Aacute;P - THỤY SĨ &ndash; ITALIA - VATICAN &ndash; MONACO (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-(tuyen-xanh-duong):-duc-%E2%80%93-cong-hoa-sec-%E2%80%93-slovakia-%E2%80%93-hungary-%E2%80%93-ao-%E2%80%93-thuy-si">Tour 3 (TUYẾN XANH DƯƠNG): ĐỨC &ndash; CỘNG HO&Agrave; S&Eacute;C &ndash; SLOVAKIA &ndash; HUNGARY &ndash; &Aacute;O &ndash; THUỴ SĨ (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-3-vg">Tour 3 vg (25/02/16)</a></li>
	<li><a href="http://totaltravelsolutions.asia/tour-6-(tuyen-cam):-phap-andorra-%E2%80%93-tay-nha">Tour 6 (TUYẾN CAM): PH&Aacute;P - ANDORRA &ndash; T&Acirc;Y BAN NHA (25/02/16)</a></li>
</ul>
', N'business-theme', N'business-theme', N'business-theme', NULL, NULL, 0, CAST(N'2017-07-30T10:52:17.327' AS DateTime), N'admin', 1, 0)
GO
INSERT [dbo].[TTS_Banner] ([Id], [Specificulture], [Url], [Alias], [Image], [CreatedDate], [IsPublished], [IsDeleted], [ModifiedBy]) VALUES (N'8bb6e420-457d-4b8b-82d9-28f2ff5c1e7d', N'vi-vn', N'#', N'asdfadsf', N'Banners\Ping-Pong-Paddle-4255.jpg', NULL, 1, 0, NULL)
GO
INSERT [dbo].[TTS_Banner] ([Id], [Specificulture], [Url], [Alias], [Image], [CreatedDate], [IsPublished], [IsDeleted], [ModifiedBy]) VALUES (N'aa6bdc9d-9798-4374-9662-37865820c3c3', N'en-UK', N'#', N'asdasdsa', N'Banners\4ad7b034-40ae-4108-89e2-8355a52928b9.jpg', NULL, 0, 0, NULL)
GO
INSERT [dbo].[TTS_Banner] ([Id], [Specificulture], [Url], [Alias], [Image], [CreatedDate], [IsPublished], [IsDeleted], [ModifiedBy]) VALUES (N'aa6bdc9d-9798-4374-9662-37865820c3c3', N'en-us', N'#', N'asdasdsa', N'Banners\4ad7b034-40ae-4108-89e2-8355a52928b9.jpg', NULL, 0, 0, NULL)
GO
INSERT [dbo].[TTS_Banner] ([Id], [Specificulture], [Url], [Alias], [Image], [CreatedDate], [IsPublished], [IsDeleted], [ModifiedBy]) VALUES (N'b6d5a0ee-e2b1-4826-958d-337902e88429', N'vi-vn', N'#', N'Vietnam Banner', N'Banners\tts-logo.png', NULL, 1, 0, NULL)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (1, N'en-UK', NULL, N'Home', N'Home Page', NULL, NULL, 3, NULL, N'Home', N'Home', N'Home', 0, CAST(N'2017-07-16T10:56:05.643' AS DateTime), N'admin', 0, 0)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (1, N'en-us', NULL, N'Total travel solution', N'Home Page', NULL, NULL, 3, NULL, N'total-travel-solution', N'total-travel-solution', N'total-travel-solution', 0, CAST(N'2017-07-16T10:56:05.643' AS DateTime), N'admin', 0, 0)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (1, N'vi-vn', NULL, N'Trang chủ', N'CHÀO MỪNG ĐẾN VỚI TOTALTRAVELSOLUTIONS.ASIA', NULL, N'<p>&nbsp;</p>

<p>Bạn đam m&ecirc; kh&aacute;m ph&aacute; những điều mới lạ, ước mơ được đặt ch&acirc;n đến những th&agrave;nh phố l&atilde;ng mạn, lỗng lẫy v&agrave; nguy nga? Thế nhưng, đ&ocirc;i l&uacute;c bạn vẫn chưa h&agrave;i l&ograve;ng về những chuyến du lịch đ&atilde; qua. Tốn bao nhi&ecirc;u thời gian v&agrave; tiền điện thoại đ&acirc;y để kiếm một dịch vụ uy t&iacute;n v&agrave; chất lượng?</p>

<p>&nbsp;</p>

<p>Bạn đang lay hoay mất thời gian xin Visa, lo lắng khi người th&acirc;n đi du lịch ở nơi xa, bạn ph&acirc;n v&acirc;n n&ecirc;n kh&ocirc;ng biết đặt niềm tin v&agrave;o dịch vụ n&agrave;o? Lại th&ecirc;m đau đầu cho việc chọn kh&aacute;ch sạn, đặt v&eacute; m&aacute;y bay..v..v. H&atilde;y tiết kiệm thời gian v&agrave;ng bạc bằng c&aacute;ch quẳng g&aacute;nh lo đ&oacute; cho ch&uacute;ng t&ocirc;i c&ugrave;ng những phiền muộn kh&aacute;c. H&atilde;y để ch&uacute;ng t&ocirc;i được chia sẻ v&agrave; g&aacute;nh v&aacute;c gi&uacute;p bạn.</p>

<p>&nbsp;</p>

<p>Ch&uacute;ng t&ocirc;i - Total Travel Solutions Asia (TTS) &ndash; Giải Ph&aacute;p Du Lịch To&agrave;n Diện muốn cung cấp v&agrave; đưa ra những giải ph&aacute;p cho h&agrave;nh tr&igrave;nh của bạn c&ugrave;ng gia đ&igrave;nh diễn ra tốt đẹp nhất, an t&acirc;m nhất với chất lượng dịch vụ c&ugrave;ng c&ugrave;ng sự hỗ trợ xuy&ecirc;n suốt.</p>

<p>&nbsp;</p>

<p>V&igrave; ch&uacute;ng t&ocirc;i muốn bạn d&agrave;nh t&acirc;m sức để:</p>

<p>&nbsp;</p>

<p>- H&ograve;a m&igrave;nh v&agrave;o l&agrave;n s&oacute;ng biển c&ugrave;ng với c&aacute;t trắng v&agrave; nắng v&agrave;ng dưới &aacute;nh ho&agrave;ng h&ocirc;n Ch&acirc;u &Aacute;;</p>

<p>- Tận hưởng kh&ocirc;ng kh&iacute; trong l&agrave;nh căng tr&agrave;n l&aacute; phổi, tham quan v&ugrave;ng đất l&acirc;u đời lịch sử, nơi địa đ&agrave;ng thanh b&igrave;nh, cảnh vật đẹp như chuyện cổ t&iacute;ch mọi miền Ch&acirc;u &Acirc;u;</p>

<p>- Kh&aacute;m ph&aacute; miền hoang d&atilde;, tự do v&agrave; phi&ecirc;u lưu mạo hiểm ở Ch&acirc;u Phi;</p>

<p>- H&ograve;a nhập v&agrave;o lễ hội tưng bừng, rộn r&atilde; điệu samba, m&agrave;u sắc rực rỡ tại v&ugrave;ng Nam Mỹ;</p>

<p>- Thực hiện giấc mơ đặt ch&acirc;n đến v&ugrave;ng đất hứa hẹn, một thế giới như được thu nhỏ xứ cờ hoa Bắc Mỹ</p>

<p>- Hay băng qua đại dương m&ecirc;nh m&ocirc;ng đến quốc đảo lớn nhất thế giới &ndash; Australia xứ sở của những ch&uacute; chuột t&uacute;i.</p>

<p>&nbsp;</p>

<p>V&agrave; c&ograve;n nhiều những trải nghiệm th&uacute; vị, cung bậc cảm x&uacute;c cứ đi từ ngạc nhi&ecirc;n n&agrave;y đến ngạc nhi&ecirc;n kh&aacute;c. Xu&acirc;n &ndash; Hạ - Thu &ndash; Đ&ocirc;ng, bốn m&ugrave;a đa sắc, đất trời rộng mở dưới đ&ocirc;i ch&acirc;n bạn.</p>

<p>&nbsp;</p>

<p>Hiểu được điều đ&oacute;, Total Travel Solutions Asia cung cấp những dịch vụ:</p>

<ul>
	<li>Tư vấn v&agrave; xin visa tr&ecirc;n to&agrave;n thế giới</li>
	<li>Đầu tư định cư tại H&ograve;a Kỳ</li>
	<li>Land tour Ch&acirc;u &Acirc;u</li>
	<li>Tổ chức tour du lịch trong nước v&agrave; quốc tế</li>
	<li>Thiết kế tour ri&ecirc;ng</li>
	<li>Đại l&yacute; v&eacute; m&aacute;y bay trong nước v&agrave; quốc tế</li>
	<li>Dịch vụ xe đưa đ&oacute;n từ S&acirc;n bay, nh&agrave; gare</li>
	<li>Đặt kh&aacute;ch sạn với gi&aacute; tốt nhất</li>
	<li>Dịch thuật &ndash; Phi&ecirc;n dịch</li>
</ul>

<p><strong>Total Travel Solutions Asia &ndash; Giải Ph&aacute;p Du Lịch To&agrave;n Diện Team.</strong></p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>
', 3, NULL, N'Trang-chu', N'Trang-chu', N'Trang-chu', 0, CAST(N'2017-07-16T10:56:05.643' AS DateTime), N'admin', 0, 0)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (2, N'en-UK', NULL, N'Visa', N'Visa', NULL, N'<p>

</p><p>Bạn cần lấy visa đi nước nào?</p><p>Bạn cần lấy visa theo diện nào?</p><p>Hãy chọn nơi đến và Total Travel Solutions Asia (TTS Asia) – Giải Pháp Du Lịch Toàn Diện sẽ &nbsp;giúp bạn đạt được Visa hiệu quả nhất.</p><p><b>&nbsp;</b></p><p><b>Chuyên Visa Du Lịch</b></p><p>&nbsp;</p><p>Là loại visa phổ biến nhất, thủ tục đơn giản nhất, thời gian làm nhanh nhất và tỉ lệ đậu visa cũng cao nhất.<br>TTS Asia sẽ tư vấn cho bạn một cách hiệu quả nhất, tùy vào từng hồ sơ xin visa mà TTS Asia sẽ đưa ra hướng giải quyết khác nhau sao cho có lợi nhất, nhìn chung visa đi các nước đều có một số điểm cơ bản như sau:</p><p>- Khả năng tài chính</p><p>- Công việc ổn định, thu nhập tương đối</p><p>- Lịch sử đi du lịch nước ngoài</p><p>- Thư mời (nếu có)</p><p>- Khả năng phỏng vấn</p><p>- Nghệ thuật sắp xếp hồ sơ</p><p><b><i>&nbsp;</i></b></p><p><b><i><u>Visa xuất cảnh du lich các nước:</u></i></b></p><p>- Visa Mỹ</p><p>- Visa Canada</p><p>- Visa New Zealand</p><p>- Visa Úc</p><p>- Visa Anh Quốc</p><p>- Visa các nước Châu Âu (Pháp, Đức, Bỉ, Hà Lan, Tây Ban Nha, Italy, Thuỵ Sĩ, …)</p><p>- Visa Dubai</p><p>- Visa Nhật Bản</p><p>- Visa Hàn Quốc</p><p>- Visa Đài Loan</p><p>- Visa Hồng Kông, Ma Cao</p><p>- Visa Trung Quốc</p><p>- Visa Ai Cập</p><p>&nbsp;</p><p>Ngoài ra, TTS Asia hỗ trợ thêm những loại Visa như sau:</p><p>&nbsp;</p><ol><li>Visa lao động</li><li>Visa hôn thê</li><li>Visa vợ chồng</li><li>Visa du hoc</li><li>Bảo lãnh gia đình</li><li>Bảo lãnh đồng tính.</li></ol><p>&nbsp;</p><p><b><i><u>Visa nhập cảnh cho người nước ngoài du lịch tại Viet Nam (Visa on arrival):</u></i></b></p><p>&nbsp;</p><p>Thư mời bảo lãnh xin visa nhập cảnh vào Việt Nam cho người nước ngoài:</p><p>- &nbsp; Thư mời du lịch</p><p>- &nbsp; Thư mời business</p><p>&nbsp;</p><p><strong>Gia hạn visa: </strong>khi hết hạn visa thị thực du lịch người nước ngoài, xin vui lòng liên hệ với chúng tôi để được tư vấn chi tiết cho từng trường hợp cụ thể tại địa chỉ email: <u><a target="_blank" rel="nofollow">info.totaltravelsolutions@gmail.com</a></u></p><p>&nbsp;</p><p>Hoặc gọi số: [+84] 93909 8087  - [+84] 903709561 (viber, whatsapp, zalo)</p><p>&nbsp;</p><p>&nbsp;</p><p>Chi tiết vui lòng liên hệ TTS Asia Team.</p>

<br><p></p>', 1, NULL, N'Visa', N'Visa', N'Visa', 0, CAST(N'2017-07-16T11:26:35.140' AS DateTime), N'admin', 0, 0)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (2, N'en-us', NULL, N'Visa Du Lịch', NULL, NULL, N'<p>&nbsp;</p>

<p>Bạn cần lấy visa đi nước n&agrave;o?</p>

<p>Bạn cần lấy visa theo diện n&agrave;o?</p>

<p>H&atilde;y chọn nơi đến v&agrave; Total Travel Solutions Asia (TTS Asia) &ndash; Giải Ph&aacute;p Du Lịch To&agrave;n Diện sẽ &nbsp;gi&uacute;p bạn đạt được Visa hiệu quả nhất.</p>

<p><strong>&nbsp;</strong></p>

<p><strong>Chuy&ecirc;n Visa Du Lịch</strong></p>

<p>&nbsp;</p>

<p>L&agrave; loại visa phổ biến nhất, thủ tục đơn giản nhất, thời gian l&agrave;m nhanh nhất v&agrave; tỉ lệ đậu visa cũng cao nhất.<br />
TTS Asia sẽ tư vấn cho bạn một c&aacute;ch hiệu quả nhất, t&ugrave;y v&agrave;o từng hồ sơ xin visa m&agrave; TTS Asia sẽ đưa ra hướng giải quyết kh&aacute;c nhau sao cho c&oacute; lợi nhất, nh&igrave;n chung visa đi c&aacute;c nước đều c&oacute; một số điểm cơ bản như sau:</p>

<p>- Khả năng t&agrave;i ch&iacute;nh</p>

<p>- C&ocirc;ng việc ổn định, thu nhập tương đối</p>

<p>- Lịch sử đi du lịch nước ngo&agrave;i</p>

<p>- Thư mời (nếu c&oacute;)</p>

<p>- Khả năng phỏng vấn</p>

<p>- Nghệ thuật sắp xếp hồ sơ</p>

<p><strong><em>&nbsp;</em></strong></p>

<p><strong><em><u>Visa xuất cảnh du lich c&aacute;c nước:</u></em></strong></p>

<p>- Visa Mỹ</p>

<p>- Visa Canada</p>

<p>- Visa New Zealand</p>

<p>- Visa &Uacute;c</p>

<p>- Visa Anh Quốc</p>

<p>- Visa c&aacute;c nước Ch&acirc;u &Acirc;u (Ph&aacute;p, Đức, Bỉ, H&agrave; Lan, T&acirc;y Ban Nha, Italy, Thuỵ Sĩ, &hellip;)</p>

<p>- Visa Dubai</p>

<p>- Visa Nhật Bản</p>

<p>- Visa H&agrave;n Quốc</p>

<p>- Visa Đ&agrave;i Loan</p>

<p>- Visa Hồng K&ocirc;ng, Ma Cao</p>

<p>- Visa Trung Quốc</p>

<p>- Visa Ai Cập</p>

<p>&nbsp;</p>

<p>Ngo&agrave;i ra, TTS Asia hỗ trợ th&ecirc;m những loại Visa như sau:</p>

<p>&nbsp;</p>

<ol>
	<li>Visa lao động</li>
	<li>Visa h&ocirc;n th&ecirc;</li>
	<li>Visa vợ chồng</li>
	<li>Visa du hoc</li>
	<li>Bảo l&atilde;nh gia đ&igrave;nh</li>
	<li>Bảo l&atilde;nh đồng t&iacute;nh.</li>
</ol>

<p>&nbsp;</p>

<p><strong><em><u>Visa nhập cảnh cho người nước ngo&agrave;i du lịch tại Viet Nam (Visa on arrival):</u></em></strong></p>

<p>&nbsp;</p>

<p>Thư mời bảo l&atilde;nh xin visa nhập cảnh v&agrave;o Việt Nam cho người nước ngo&agrave;i:</p>

<p>- &nbsp; Thư mời du lịch</p>

<p>- &nbsp; Thư mời business</p>

<p>&nbsp;</p>

<p><strong>Gia hạn visa: </strong>khi hết hạn visa thị thực du lịch người nước ngo&agrave;i, xin vui l&ograve;ng li&ecirc;n hệ với ch&uacute;ng t&ocirc;i để được tư vấn chi tiết cho từng trường hợp cụ thể tại địa chỉ email: <u>info.totaltravelsolutions@gmail.com</u></p>

<p>&nbsp;</p>

<p>Hoặc gọi số: [+84] 93909 8087 - [+84] 903709561 (viber, whatsapp, zalo)</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>Chi tiết vui l&ograve;ng li&ecirc;n hệ TTS Asia Team.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>
', 2, NULL, N'visa-du-lich', N'visa-du-lich', N'visa-du-lich', 0, CAST(N'2017-07-16T11:26:35.140' AS DateTime), N'admin', 0, 0)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (2, N'vi-vn', NULL, N'Visa', NULL, N'/Uploads/Modules/Banners/1f88de9245cc4843b7f9260755196697.jpg', N'<p>

</p><p>Bạn cần lấy visa đi nước nào?</p><p>Bạn cần lấy visa theo diện nào?</p><p>Hãy chọn nơi đến và Total Travel Solutions Asia (TTS Asia) – Giải Pháp Du Lịch Toàn Diện sẽ &nbsp;giúp bạn đạt được Visa hiệu quả nhất.</p><p><b>&nbsp;</b></p><p><b>Chuyên Visa Du Lịch</b></p><p>&nbsp;</p><p>Là loại visa phổ biến nhất, thủ tục đơn giản nhất, thời gian làm nhanh nhất và tỉ lệ đậu visa cũng cao nhất.<br>TTS Asia sẽ tư vấn cho bạn một cách hiệu quả nhất, tùy vào từng hồ sơ xin visa mà TTS Asia sẽ đưa ra hướng giải quyết khác nhau sao cho có lợi nhất, nhìn chung visa đi các nước đều có một số điểm cơ bản như sau:</p><p>- Khả năng tài chính</p><p>- Công việc ổn định, thu nhập tương đối</p><p>- Lịch sử đi du lịch nước ngoài</p><p>- Thư mời (nếu có)</p><p>- Khả năng phỏng vấn</p><p>- Nghệ thuật sắp xếp hồ sơ</p><p><b><i>&nbsp;</i></b></p><p><b><i><u>Visa xuất cảnh du lich các nước:</u></i></b></p><p>- Visa Mỹ</p><p>- Visa Canada</p><p>- Visa New Zealand</p><p>- Visa Úc</p><p>- Visa Anh Quốc</p><p>- Visa các nước Châu Âu (Pháp, Đức, Bỉ, Hà Lan, Tây Ban Nha, Italy, Thuỵ Sĩ, …)</p><p>- Visa Dubai</p><p>- Visa Nhật Bản</p><p>- Visa Hàn Quốc</p><p>- Visa Đài Loan</p><p>- Visa Hồng Kông, Ma Cao</p><p>- Visa Trung Quốc</p><p>- Visa Ai Cập</p><p>&nbsp;</p><p>Ngoài ra, TTS Asia hỗ trợ thêm những loại Visa như sau:</p><p>&nbsp;</p><ol><li>Visa lao động</li><li>Visa hôn thê</li><li>Visa vợ chồng</li><li>Visa du hoc</li><li>Bảo lãnh gia đình</li><li>Bảo lãnh đồng tính.</li></ol><p>&nbsp;</p><p><b><i><u>Visa nhập cảnh cho người nước ngoài du lịch tại Viet Nam (Visa on arrival):</u></i></b></p><p>&nbsp;</p><p>Thư mời bảo lãnh xin visa nhập cảnh vào Việt Nam cho người nước ngoài:</p><p>- &nbsp; Thư mời du lịch</p><p>- &nbsp; Thư mời business</p><p>&nbsp;</p><p><strong>Gia hạn visa: </strong>khi hết hạn visa thị thực du lịch người nước ngoài, xin vui lòng liên hệ với chúng tôi để được tư vấn chi tiết cho từng trường hợp cụ thể tại địa chỉ email: <u><a target="_blank" rel="nofollow">info.totaltravelsolutions@gmail.com</a></u></p><p>&nbsp;</p><p>Hoặc gọi số: [+84] 93909 8087  - [+84] 903709561 (viber, whatsapp, zalo)</p><p>&nbsp;</p><p>&nbsp;</p><p>Chi tiết vui lòng liên hệ TTS Asia Team.</p>

<br><p></p>', 1, NULL, N'Visa', N'Visa', N'Visa', 0, CAST(N'2017-07-16T11:26:35.140' AS DateTime), N'admin', 0, 1)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (3, N'vi-vn', NULL, N'Tin du lịch', NULL, NULL, NULL, 2, NULL, N'Tin-du-lich', N'Tin-du-lich', N'Tin-du-lich', 1, CAST(N'2017-07-24T16:53:38.857' AS DateTime), N'admin', 0, 10)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (4, N'vi-vn', NULL, N'Tin tức visa', NULL, NULL, NULL, 2, NULL, N'Tin-tuc-visa', N'Tin-tuc-visa', N'Tin-tuc-visa', 0, CAST(N'2017-07-24T17:55:03.107' AS DateTime), N'admin', 0, 10)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (5, N'vi-vn', NULL, N'Định cư USA', N'Định cư USA', NULL, NULL, 0, NULL, N'Dinh-cu-USA', N'Dinh-cu-USA', N'Dinh-cu-USA', 0, CAST(N'2017-07-25T14:28:04.490' AS DateTime), N'admin', 0, 4)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (6, N'vi-vn', NULL, N'EB1C', NULL, N'/Uploads/Modules/Banners/543ae648418743438ead772c60ae767b.jpg', N'<p>

</p><p><em><strong>USA chào đón người thành đạt như bạn !</strong></em></p><p><strong>Total Travel Solutions Asia giới thiệu chương trình Định cư đầu tư dưới hình thức Doanh nghiệp EB1C</strong></p><p>Trước khi bắt đầu quá trình này, Anh/chị phải có một công ty đủ điều kiện tại quốc gia mà anh chị đang sinh sống. Đây là một vài tiêu chí để đánh giá một doanh nghiệp đủ điều kiện:</p><ul><li>Doanh thu hàng năm ít nhất tương đương 300.000 Đô la Mỹ.</li><li>Có sử dụng ít nhất 5-7 lao động.</li><li>Đã hoạt động ít nhất 02 năm.</li><li>Vốn đầu tư 300.000 Đô la Mỹ</li></ul><p>Nếu Anh/chị có một doanh nghiệp đủ điều kiện và đã/đang từng là người sở hữu, giám đốc hoặc quản lý cấp cao ít nhất 01 năm trong vòng 03 năm gần đây, chúng tôi sẵn sàng hợp tác cùng Anh/chị. Chúng tôi hợp tác với các công dân nước ngoài, những người muốn trở thành thường trú nhân/công dân hợp pháp tại Hoa Kỳ. Thông qua sự tham gia của chúng tôi với chương trình VISA dành cho cấp điều hành, chúng tôi giúp đối tác của mình đầu tư vào các dự án đã được chính phủ phê duyệt và các doanh nghiệp tư nhân. Bằng cách này, nhà đàu tư và gia đình họ có đủ điều kiện được cấp thẻ xanh Hoa Kỳ và trở thành thường trú nhân/ công dân Hoa Kỳ hợp pháp.</p><p>Cam kết hoàn lại cho nhà đầu tư $300,000 Đô la Mỹ tiền đầu tư bằng:</p><ul><li>Cam kết mức lương $72,000 Đô la Mỹ/ năm trong vòng 4 năm, thanh toán hàng tuần cho nhà đầu tư.</li><li>Năm thứ 5, nhà đầu tư sẽ nhận nốt $72,000 Đô la Mỹ, được thanh toán theo tuần như là khoản bán lại cổ phần trong liên doanh</li></ul><p>Visa xét duyệt nhanh chóng và trong vòng 90 ngày có visa theo dạng làm việc 1 năm L1, gia đình theo dạng L2 và có thể đi qua Mỹ trước, sau khi hết hạn visa 1 năm thì có thẻ xanh 7 năm, sau 7 năm xin gia hạn tiếp.</p><p>Để biết thêm thông tin chi tiết vui lòng liên hệ Total Travel Solutions Asia - Giải Pháp Du Lịch Toàn Diện team.</p>

<br><p></p>', 1, NULL, N'EB1C', N'EB1C', N'EB1C', 0, CAST(N'2017-07-25T14:29:36.207' AS DateTime), N'admin', 0, 10)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (7, N'en-UK', NULL, N'Tour Châu Âu', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut 
et dolore magna aliqua. Ut enim ad minim veniam', NULL, NULL, 2, NULL, N'Tour-Chau-Au', N'Tour-Chau-Au', N'Tour-Chau-Au', 0, CAST(N'2017-07-25T16:50:47.083' AS DateTime), N'admin', 0, 2)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (7, N'en-us', NULL, N'Tour Châu Âu', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut 
et dolore magna aliqua. Ut enim ad minim veniam', NULL, NULL, 2, NULL, N'Tour-Chau-Au', N'Tour-Chau-Au', N'Tour-Chau-Au', 0, CAST(N'2017-07-25T16:50:47.083' AS DateTime), N'admin', 0, 2)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (7, N'vi-vn', NULL, N'Tour Châu Âu', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut 
et dolore magna aliqua. Ut enim ad minim veniam', NULL, NULL, 2, NULL, N'Tour-Chau-Au', N'Tour-Chau-Au', N'Tour-Chau-Au', 0, CAST(N'2017-07-25T16:50:47.083' AS DateTime), N'admin', 0, 2)
GO
INSERT [dbo].[TTS_Category] ([Id], [Specificulture], [Icon], [Title], [Description], [Image], [FullContent], [Type], [Views], [SeoTitle], [SeoDescription], [SeoKeywords], [Level], [CreatedDate], [CreatedBy], [IsDeleted], [Priority]) VALUES (8, N'vi-vn', NULL, N'Tin tức', NULL, NULL, NULL, 0, NULL, N'Tin-tuc', N'Tin-tuc', N'Tin-tuc', 0, CAST(N'2017-07-25T16:53:23.457' AS DateTime), N'admin', 0, 6)
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'0b997de3-3a80-4302-84be-c9f91958f79b', 3, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'0b997de3-3a80-4302-84be-c9f91958f79b', 4, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', 2, N'en-us')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', 2, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', 3, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', 4, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'b4dd05a9-a425-4843-b43b-146fe78df009', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'cf1b2454-dc57-40db-8f95-891ad0cef974', 2, N'en-us')
GO
INSERT [dbo].[TTS_Category_Article] ([ArticleId], [CategoryId], [Specificulture]) VALUES (N'd4c825f3-0647-479d-9714-7f4df2838dc5', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Category] ([Id], [ParentId], [Specificulture]) VALUES (3, 8, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Category] ([Id], [ParentId], [Specificulture]) VALUES (4, 8, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Category] ([Id], [ParentId], [Specificulture]) VALUES (6, 5, N'vi-vn')
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (1, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (1, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (1, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (4, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (4, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (4, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (5, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (5, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (6, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (6, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (6, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (7, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (7, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (7, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (8, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (8, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (8, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (9, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (9, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (9, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (10, 1, N'en-UK', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (10, 1, N'en-us', 0, 0)
GO
INSERT [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture], [Position], [Priority]) VALUES (10, 1, N'vi-vn', 0, 0)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 1, N'en-UK', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 1, N'en-us', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 1, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 2, N'en-UK', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 2, N'en-us', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 2, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 5, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 7, N'en-us', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 7, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (1, 8, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 1, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 2, N'en-UK', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 2, N'en-us', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 2, N'vi-vn', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 7, N'en-us', NULL)
GO
INSERT [dbo].[TTS_Category_Position] ([Position], [CateId], [Specificulture], [Description]) VALUES (3, 7, N'vi-vn', NULL)
GO
SET IDENTITY_INSERT [dbo].[TTS_Culture] ON 

GO
INSERT [dbo].[TTS_Culture] ([Id], [Specificulture], [LCID], [Alias], [FullName], [Description], [Icon]) VALUES (2, N'en-us', N'1033      ', N'English   ', N'English US', N'English (US)', N'flag-icon-us')
GO
INSERT [dbo].[TTS_Culture] ([Id], [Specificulture], [LCID], [Alias], [FullName], [Description], [Icon]) VALUES (3, N'vi-vn', N'1066', N'Vietnamese', N'Vietnamese', N'Tiếng Việt', N'flag-icon-vn')
GO
INSERT [dbo].[TTS_Culture] ([Id], [Specificulture], [LCID], [Alias], [FullName], [Description], [Icon]) VALUES (4, N'en-UK', N'2057', N'UK', N'United Kingdom', N'English (UK)', N'flag-icon-gb')
GO
SET IDENTITY_INSERT [dbo].[TTS_Culture] OFF
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (1, N'en-UK', N'Home_Banners', N'Modules\_Banners', N'Home Banners', N'Home Banners', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (1, N'en-us', N'Home_Banners', N'Modules\_Banners', N'Home Banners', N'Home Banners', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (1, N'vi-vn', N'Home_Banners', N'Modules\_Banners', N'Home Banners', N'Home Banners', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"BrieftContent","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (4, N'en-UK', N'Partners', N'Modules\_Partners', N'Đối tác', N'Chúng tôi - Total Travel Solutions Asia (TTS) – Giải Pháp Du Lịch Toàn Diện muốn cung cấp và đưa ra những giải pháp cho hành trình của bạn cùng gia đình diễn ra tốt đẹp nhất, an tâm nhất với chất lượng dịch vụ cùng cùng sự hỗ trợ xuyên suốt.', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (4, N'en-us', N'Partners', N'Modules\_Partners', N'Partners', N'Chúng tôi - Total Travel Solutions Asia (TTS) – Giải Pháp Du Lịch Toàn Diện muốn cung cấp và đưa ra những giải pháp cho hành trình của bạn cùng gia đình diễn ra tốt đẹp nhất, an tâm nhất với chất lượng dịch vụ cùng cùng sự hỗ trợ xuyên suốt.', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (4, N'vi-vn', N'Partners', N'Modules\_Partners', N'Đối tác', N'Chúng tôi - Total Travel Solutions Asia (TTS) – Giải Pháp Du Lịch Toàn Diện muốn cung cấp và đưa ra những giải pháp cho hành trình của bạn cùng gia đình diễn ra tốt đẹp nhất, an tâm nhất với chất lượng dịch vụ cùng cùng sự hỗ trợ xuyên suốt.', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (5, N'en-UK', N'Socials', N'Modules\_TopSocials', N'Socials Networks', N'Socials Networks', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (5, N'en-us', N'Socials', N'Modules\_TopSocials', N'Socials Networks', N'Socials Networks', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (5, N'vi-vn', N'Socials', N'Modules\_TopSocials', N'Socials Networks', N'Socials Networks', N'[{"Name":"Icon","DataType":3},{"Name":"Url","DataType":3},{"Name":"Alias","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (6, N'en-UK', N'Services', N'Modules\_Services', N'Dịch vụ nổi bật của TTS', N'Total Travel Solutions Asia cung cấp những dịch vụ chuyên nghiệp như sau', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (6, N'en-us', N'Services', N'Modules\_Services', N'Special Services', N'Total Travel Solutions Asia cung cấp những dịch vụ chuyên nghiệp như sau', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (6, N'vi-vn', N'Services', N'Modules\_Services', N'Dịch vụ nổi bật của TTS', N'Total Travel Solutions Asia cung cấp những dịch vụ chuyên nghiệp như sau', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (7, N'en-UK', N'HotTours', N'Modules\_HotTours', N'Tour nổi bật', N'Các tour trong chương trình được mọi người lựa chọn  nhiều nhất', N'[]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (7, N'en-us', N'HotTours', N'Modules\_HotTours', N'Tour nổi bật', N'Các tour trong chương trình được mọi người lựa chọn  nhiều nhất', N'[]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (7, N'vi-vn', N'HotTours', N'Modules\_HotTours', N'Tour nổi bật', N'Các tour trong chương trình được mọi người lựa chọn  nhiều nhất', N'[]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (8, N'en-UK', N'OtherServices', N'Modules\_OtherServices', N'Dịch vụ khác', N'Ngoài những dịch vụ nổi bật bên trên chúng tôi còn có  những dịch vụ hỗ trợ khác', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (8, N'en-us', N'OtherServices', N'Modules\_OtherServices', N'Other Services', N'Ngoài những dịch vụ nổi bật bên trên chúng tôi còn có  những dịch vụ hỗ trợ khác', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (8, N'vi-vn', N'OtherServices', N'Modules\_OtherServices', N'Dịch vụ khác', N'Ngoài những dịch vụ nổi bật bên trên chúng tôi còn có  những dịch vụ hỗ trợ khác', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (9, N'en-UK', N'Clients', N'Modules\_Clients', N'What our client says', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut  et dolore magna aliqua. Ut enim ad minim veniam', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (9, N'en-us', N'Clients', N'Modules\_Clients', N'What our client says', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut  et dolore magna aliqua. Ut enim ad minim veniam', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (9, N'vi-vn', N'Clients', N'Modules\_Clients', N'What our client says', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut  et dolore magna aliqua. Ut enim ad minim veniam', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (10, N'en-UK', N'Contacts', N'Modules\_Contacts', N'How to Reach Us?', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (10, N'en-us', N'Contacts', N'Modules\_Contacts', N'How to Reach Us?', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]')
GO
INSERT [dbo].[TTS_Module] ([Id], [Specificulture], [Name], [Template], [Title], [Description], [Fields]) VALUES (10, N'vi-vn', N'Contacts', N'Modules\_Contacts', N'How to Reach Us?', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]')
GO
INSERT [dbo].[TTS_Module_Article] ([ArticleId], [ModuleId], [Specificulture]) VALUES (N'0b997de3-3a80-4302-84be-c9f91958f79b', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Module_Article] ([ArticleId], [ModuleId], [Specificulture]) VALUES (N'aa8a1616-4949-41b0-959b-77e563c2929a', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Module_Article] ([ArticleId], [ModuleId], [Specificulture]) VALUES (N'b4dd05a9-a425-4843-b43b-146fe78df009', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Module_Article] ([ArticleId], [ModuleId], [Specificulture]) VALUES (N'd4c825f3-0647-479d-9714-7f4df2838dc5', 7, N'vi-vn')
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'01218fef38e141ae9a96037252f53396', 5, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Url","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-linkedin"},"Alias":{"DataType":0,"Value":"LinkedIn"}}', NULL, NULL, CAST(N'2017-07-25T09:21:16.257' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'0f03774b-597b-42eb-9cff-3c598d6870ca', 4, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/5740bd0be2494a30b06c591f1c8ca28a.png"},"Alias":{"DataType":0,"Value":"Partner 4"}}', NULL, NULL, CAST(N'2017-07-26T07:07:30.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'126b0188-2d48-4f80-bf6d-b03b5373a666', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-paper-plane-o"},"Title":{"DataType":0,"Value":"Thiết Kế"},"Description":{"DataType":0,"Value":"Thiết kế tour riêng cho gia đình và nhóm bạn bè"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:35.127' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'1a623bef-9ff4-4c9b-aa48-b5634f7a54b8', 4, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc73e86532914ede8f3bd04f8a114236.png"},"Alias":{"DataType":0,"Value":"Partner 3"}}', NULL, NULL, CAST(N'2017-07-26T07:05:06.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'1a908c11bcc8497994aff1aa308860be', 4, N'vi-vn', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc73e86532914ede8f3bd04f8a114236.png"},"Alias":{"DataType":0,"Value":"Partner 3"}}', NULL, NULL, CAST(N'2017-07-26T07:05:06.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'1ab1a3fd68de4a2590923a55fc4cd366', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-ticket"},"Title":{"DataType":0,"Value":"Đại Lý"},"Description":{"DataType":0,"Value":"Đại lý vé máy bay trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:47.443' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'2167d9638b3d48ab8d24445dc57c3f8d', 9, N'vi-vn', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/07d475e9dc774864a47b56a082f3b7cd.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:23.220' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'228390c8b2144c258d5fb93c9fa6a6b4', 6, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"ĐẦU TƯ"},"Description":{"DataType":0,"Value":"Đầu tư định cư tại Hòa Kỳ và các nước Châu Âu"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/cdc12facad0046eabcd351f1dab71f8b.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:49:39.210' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'2c199b87-31cf-4ef4-a840-f3eb587ef698', 9, N'en-us', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/07d475e9dc774864a47b56a082f3b7cd.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:23.220' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'2f2824c4-1c63-4609-800b-4dbe29fb0249', 6, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Visa"},"Description":{"DataType":0,"Value":"Tư vấn và xin visa trên toàn thế giới"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/b7ed540fb69140e2bfb48c32aa93daab.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:48:01.020' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'32a8da3a-1669-4fdd-805a-8d39a1139565', 4, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/23130a6ad2aa45308b804a15383458c2.png"},"Alias":{"DataType":0,"Value":"Partner 2"}}', NULL, NULL, CAST(N'2017-07-25T07:15:28.193' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'32c4125c031c49909270d6046a8221e6', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-users"},"Title":{"DataType":0,"Value":"Tổ Chức"},"Description":{"DataType":0,"Value":"Tổ chức tour du lịch trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:03.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'3a154aeb-037f-412a-984a-be7008d0e169', 5, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":null},"Icon":{"DataType":3,"Value":"fa fa-skype"},"Alias":{"DataType":0,"Value":"Skype"}}', NULL, NULL, CAST(N'2017-07-29T11:56:08.480' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'3dfd1d23-11ed-4ea0-9179-7a109fafa55c', 5, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"https://www.facebook.com"},"Icon":{"DataType":3,"Value":"fa fa-facebook"},"Alias":{"DataType":0,"Value":"Facebook"}}', NULL, NULL, CAST(N'2017-07-25T09:10:50.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'41b4e89a-62b3-417c-bccb-38d1023578be', 6, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Visa"},"Description":{"DataType":0,"Value":"Tư vấn và xin visa trên toàn thế giới"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/b7ed540fb69140e2bfb48c32aa93daab.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:48:01.020' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'449deb1acd054a5196c336660f552f72', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-car"},"Title":{"DataType":0,"Value":"Đưa đón"},"Description":{"DataType":0,"Value":"Dịch vụ xe đưa đón từ Sân bay, nhà gare"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:23.937' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'45fc85c2-0088-427e-a349-1b0007198e37', 9, N'en-us', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/7591aa478dd64b2d970fc6076cc10c33.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:04:10.930' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'47f50448-e2be-4204-8904-d5bf965e6f39', 9, N'en-UK', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/7591aa478dd64b2d970fc6076cc10c33.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:04:10.930' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'51e2d6f3-1348-4066-b11f-5f9636690bbe', 6, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"TOUR"},"Description":{"DataType":0,"Value":"Land tour Châu Âu và các nước khác"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/f48a40db89b04765ae5754d84089f2d3.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:50:28.770' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'53b565d7-452d-4f6c-b20d-337c01da04fe', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-building"},"Title":{"DataType":0,"Value":"Khách sạn"},"Description":{"DataType":0,"Value":"Đặt khách sạn với giá tốt nhất"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:38.007' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'59c7a3c3-e795-44b1-bf8b-840d01cf3c3b', 5, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-linkedin"},"Alias":{"DataType":0,"Value":"LinkedIn"}}', NULL, NULL, CAST(N'2017-07-25T09:21:16.257' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'5a227c47-246b-484a-a5fe-ef541db834a6', 6, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"ĐẦU TƯ"},"Description":{"DataType":0,"Value":"Đầu tư định cư tại Hòa Kỳ và các nước Châu Âu"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/cdc12facad0046eabcd351f1dab71f8b.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:49:39.210' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'5a5fb741-55e5-4297-9303-d139a044c69e', 9, N'en-us', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/c26515b8520543fb925f0342fd67da89.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:47.930' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'5b49ce8d-b819-4969-b0da-6389770eda00', 1, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Paris"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/0d04a650d0fa4e39bdfb4fdafa2f4ae0.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-22T02:47:56.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'5c56cf4c-03e2-4b9f-a180-03bf80240dad', 5, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"https://www.facebook.com"},"Icon":{"DataType":3,"Value":"fa fa-facebook"},"Alias":{"DataType":0,"Value":"Facebook"}}', NULL, NULL, CAST(N'2017-07-25T09:10:50.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'6', 6, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Visa"},"Description":{"DataType":0,"Value":"Tư vấn và xin visa trên toàn thế giới"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/b7ed540fb69140e2bfb48c32aa93daab.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:48:01.020' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'633348c4-3147-4f99-84f7-e0311625bd17', 9, N'en-UK', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/07d475e9dc774864a47b56a082f3b7cd.png"},"Name":{"DataType":0,"Value":"tinku"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:23.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'6e57968a5399477db6460db1f099eba8', 5, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Url","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-twitter"},"Alias":{"DataType":0,"Value":"Twister"}}', NULL, NULL, CAST(N'2017-07-25T09:20:39.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'6ec52fbb-39b3-4de2-81bf-3ca1f129c5e0', 10, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]', N'{"Title":{"DataType":0,"Value":"Head Office"},"Address":{"DataType":0,"Value":"34 Đường 43, Phường 4, Quận 4 Hồ Chí Minh, Việt Nam"},"Phone":{"DataType":0,"Value":"+84 903709561"},"Email":{"DataType":0,"Value":"info.tts@gmail.com"},"Gmap":{"DataType":5,"Value":"<p><iframe frameborder=\"0\" height=\"450\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.704062370992!2d106.70153671519046!3d10.75727569233453!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f6d90ee467d%3A0x5c6536ace44b7f5c!2zMzQgU-G7kSA0MywgcGjGsOG7nW5nIDQsIFF14bqtbiA0LCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1501388931918\" style=\"border:0\" width=\"600\"></iframe></p>\r\n"}}', NULL, NULL, CAST(N'2017-07-30T04:18:24.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'706a0136-c7c8-496e-953b-ef8fd88182a9', 5, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-linkedin"},"Alias":{"DataType":0,"Value":"LinkedIn"}}', NULL, NULL, CAST(N'2017-07-25T09:21:16.257' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'74a27335-64f9-4b57-afee-c71c115f7705', 4, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/23130a6ad2aa45308b804a15383458c2.png"},"Alias":{"DataType":0,"Value":"Partner 2"}}', NULL, NULL, CAST(N'2017-07-25T07:15:28.193' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'77bf8a1e02db4754a9c0506b222c1a99', 4, N'vi-vn', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/23130a6ad2aa45308b804a15383458c2.png"},"Alias":{"DataType":0,"Value":"Partner 2"}}', NULL, NULL, CAST(N'2017-07-25T07:15:28.193' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'795c045f-a9c6-4c14-a758-8544b1377c89', 6, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"TOUR"},"Description":{"DataType":0,"Value":"Land tour Châu Âu và các nước khác"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/f48a40db89b04765ae5754d84089f2d3.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:50:28.770' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'7aef46b1f26e4696b7f70ac66389f01b', 6, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"TOUR"},"Description":{"DataType":0,"Value":"Land tour Châu Âu và các nước khác"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/f48a40db89b04765ae5754d84089f2d3.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:50:28.770' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'81972af0fb0b4ccda613236f476fd40b', 9, N'vi-vn', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/beb2718de540451a94c85561b2a982aa.jpg"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:47.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'8740b89b-0886-406b-9a47-4908081fc846', 4, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc9e1dd5209041c189076d7fe7100c85.png"},"Alias":{"DataType":0,"Value":"Partner 1"}}', NULL, NULL, CAST(N'2017-07-25T07:05:33.590' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'897529d7-79a7-4fc4-ad95-e7125cbf958a', 6, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0},{"Name":"Url","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Investigate"},"Description":{"DataType":0,"Value":"Đầu tư định cư tại Hòa Kỳ và các nước Châu Âu"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/cdc12facad0046eabcd351f1dab71f8b.png"},"Alias":{"DataType":0,"Value":null},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-26T04:49:39.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'8a148ebe-30dd-4684-9735-59c65e0a5b0d', 4, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/5740bd0be2494a30b06c591f1c8ca28a.png"},"Alias":{"DataType":0,"Value":"Partner 4"}}', NULL, NULL, CAST(N'2017-07-26T07:07:30.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'8a60aa83-f18c-4e07-b74b-3517c9c5f59a', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-users"},"Title":{"DataType":0,"Value":"Tổ Chức"},"Description":{"DataType":0,"Value":"Tổ chức tour du lịch trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:03.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'8ab47a32acff4648a91995fb069234a8', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-building"},"Title":{"DataType":0,"Value":"Khách sạn"},"Description":{"DataType":0,"Value":"Đặt khách sạn với giá tốt nhất"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:38.007' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'8bc5c8932b124c2899d2f05a76299f22', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-language"},"Title":{"DataType":0,"Value":"Ngôn ngữ"},"Description":{"DataType":0,"Value":"Dịch thuật – Phiên dịch"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:51.337' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'9305e205f4254ae79444d16dd9fd61c3', 1, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Paris"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/0d04a650d0fa4e39bdfb4fdafa2f4ae0.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit"}}', NULL, NULL, CAST(N'2017-07-22T02:47:56.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'9ac3b451-884e-47a3-9a65-1f767e96c7ad', 4, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/45eccadfbfe744f092c95a35b7c7ac74.png"},"Alias":{"DataType":0,"Value":"Partner 5"}}', NULL, NULL, CAST(N'2017-07-26T07:09:34.467' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'9cfdd59e-1878-498a-a010-b145024becdc', 1, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":null},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/bd4c37aad8844e07b431970322485fde.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-25T03:38:29.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'9dbcbd51-bc84-473b-8cd9-306ab43aee55', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-car"},"Title":{"DataType":0,"Value":"Đưa đón"},"Description":{"DataType":0,"Value":"Dịch vụ xe đưa đón từ Sân bay, nhà gare"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:23.937' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'a22e33c5-f4a1-4b6a-b41d-749cb0dc5159', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-ticket"},"Title":{"DataType":0,"Value":"Đại Lý"},"Description":{"DataType":0,"Value":"Đại lý vé máy bay trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:47.443' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'a52194fd-c97e-4250-962c-2143a937dcdd', 4, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc73e86532914ede8f3bd04f8a114236.png"},"Alias":{"DataType":0,"Value":"Partner 3"}}', NULL, NULL, CAST(N'2017-07-26T07:05:06.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'ae953021-0f85-4329-801a-832d1c4c6d92', 1, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":null},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/bd4c37aad8844e07b431970322485fde.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-25T03:38:29.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'b569c765-5356-40a5-a8e4-4652528d76f9', 5, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-twitter"},"Alias":{"DataType":0,"Value":"Twister"}}', NULL, NULL, CAST(N'2017-07-25T09:20:39.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'b57c1864-118c-4d7e-b940-3f8e7f19216d', 4, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc9e1dd5209041c189076d7fe7100c85.png"},"Alias":{"DataType":0,"Value":"Partner 1"}}', NULL, NULL, CAST(N'2017-07-25T07:05:33.590' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'ba58d2055c9e426ba1966d9d18e4bc4e', 4, N'vi-vn', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/5740bd0be2494a30b06c591f1c8ca28a.png"},"Alias":{"DataType":0,"Value":"Partner 4"}}', NULL, NULL, CAST(N'2017-07-26T07:07:30.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'bab40bb6-93a6-4ec0-849b-304236fbe730', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-language"},"Title":{"DataType":0,"Value":"Ngôn ngữ"},"Description":{"DataType":0,"Value":"Dịch thuật – Phiên dịch"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:51.337' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'bca98a18-bb5b-4974-8229-51c1210b748c', 5, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":null},"Icon":{"DataType":3,"Value":"fa fa-skype"},"Alias":{"DataType":0,"Value":"Skype"}}', NULL, NULL, CAST(N'2017-07-29T11:56:08.480' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'c3a2c70d-3f16-42f8-b71d-5f5685d2e465', 9, N'en-UK', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/c26515b8520543fb925f0342fd67da89.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:03:47.930' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'cb578f2548504479a4d3ffe4e04d419d', 10, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]', N'{"Title":{"DataType":0,"Value":"Head Office"},"Address":{"DataType":0,"Value":"34 Đường 43, Phường 4, Quận 4 Hồ Chí Minh, Việt Nam"},"Phone":{"DataType":0,"Value":"+84 903709561"},"Email":{"DataType":0,"Value":"info.tts@gmail.com"},"Gmap":{"DataType":5,"Value":"<p><iframe frameborder=\"0\" height=\"450\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.704062370992!2d106.70153671519046!3d10.75727569233453!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f6d90ee467d%3A0x5c6536ace44b7f5c!2zMzQgU-G7kSA0MywgcGjGsOG7nW5nIDQsIFF14bqtbiA0LCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1501388931918\" style=\"border:0\" width=\"600\"></iframe></p>\r\n"}}', NULL, NULL, CAST(N'2017-07-30T04:18:24.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'cec79fed-7f8a-4f3c-b02f-75f1efeb9ab4', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-paper-plane-o"},"Title":{"DataType":0,"Value":"Thiết Kế"},"Description":{"DataType":0,"Value":"Thiết kế tour riêng cho gia đình và nhóm bạn bè"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:35.127' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'd2d35b1f-8be4-4f85-b6fc-f16e19f97dbc', 8, N'en-UK', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-users"},"Title":{"DataType":0,"Value":"Tổ Chức"},"Description":{"DataType":0,"Value":"Tổ chức tour du lịch trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:03.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'd5c7694f-deb7-4ef6-9770-4964bb2b03b3', 1, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":null},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/803b38ee2fdc4ed98ead2d85752f5b91.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-24T08:07:31.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'd6578d10117942afb0f382abe85f7f29', 4, N'vi-vn', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/dc9e1dd5209041c189076d7fe7100c85.png"},"Alias":{"DataType":0,"Value":"Partner 1"}}', NULL, NULL, CAST(N'2017-07-25T07:05:33.590' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'dff4f70c-6685-4d69-ab68-787f31226aed', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-building"},"Title":{"DataType":0,"Value":"Khách sạn"},"Description":{"DataType":0,"Value":"Đặt khách sạn với giá tốt nhất"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:38.007' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'e11d25e0-852e-4b92-9b1d-ab3a4b5b0cb9', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-language"},"Title":{"DataType":0,"Value":"Ngôn ngữ"},"Description":{"DataType":0,"Value":"Dịch thuật – Phiên dịch"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:51.337' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'e68e63ea-963e-4a04-b132-a5cfce4a135a', 1, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":null},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/803b38ee2fdc4ed98ead2d85752f5b91.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-24T08:07:31.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'e7cd90f3-8d6e-4541-a698-9d5a32886118', 4, N'en-us', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/45eccadfbfe744f092c95a35b7c7ac74.png"},"Alias":{"DataType":0,"Value":"Partner 5"}}', NULL, NULL, CAST(N'2017-07-26T07:09:34.467' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'e9a404fdb0084351a34468585330ccd9', 1, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Head Office"},"Image":{"DataType":2,"Value":"/Uploads/Modules/1/3f114d90473f4319afdffebda1d5dc6f.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit"}}', NULL, NULL, CAST(N'2017-07-24T08:07:31.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'e9c05e4fc98149ca96a156bded55f972', 1, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Ha Long Bay"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/67e6be4588994be3b011020a68d09699.jpg"},"Url":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit Lorem ipsum dolor sit amet, consectetur adipisicing elit"}}', NULL, NULL, CAST(N'2017-07-30T07:39:08.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'ebc2b24aba6e4bb6b48281e8409f8a59', 5, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Url","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"https://www.facebook.com"},"Icon":{"DataType":3,"Value":"fa fa-facebook"},"Alias":{"DataType":0,"Value":"Facebook"}}', NULL, NULL, CAST(N'2017-07-25T09:10:50.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'ec626457-9a52-4b8d-bd15-c8323c5e0bbc', 10, N'en-us', N'[{"Name":"Title","DataType":0},{"Name":"Address","DataType":0},{"Name":"Phone","DataType":0},{"Name":"Email","DataType":0},{"Name":"Gmap","DataType":5}]', N'{"Title":{"DataType":0,"Value":"Head Office"},"Address":{"DataType":0,"Value":"34 Đường 43, Phường 4, Quận 4 Hồ Chí Minh, Việt Nam"},"Phone":{"DataType":0,"Value":"+84 903709561"},"Email":{"DataType":0,"Value":"info.tts@gmail.com"},"Gmap":{"DataType":5,"Value":"<p><iframe frameborder=\"0\" height=\"450\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.704062370992!2d106.70153671519046!3d10.75727569233453!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f6d90ee467d%3A0x5c6536ace44b7f5c!2zMzQgU-G7kSA0MywgcGjGsOG7nW5nIDQsIFF14bqtbiA0LCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1501388931918\" style=\"border:0\" width=\"600\"></iframe></p>\r\n"}}', NULL, NULL, CAST(N'2017-07-30T04:18:24.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'ee609613db94424397411b60ce6e98a1', 8, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-paper-plane-o"},"Title":{"DataType":0,"Value":"Thiết Kế"},"Description":{"DataType":0,"Value":"Thiết kế tour riêng cho gia đình và nhóm bạn bè"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:35.127' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f088aa3f-52d8-44a0-842d-fa678b1af724', 1, N'en-UK', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"Alias","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Paris"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/0d04a650d0fa4e39bdfb4fdafa2f4ae0.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-22T02:47:56.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f126be6dcbd64c54bb5b5c1557fa0514', 9, N'vi-vn', N'[{"Name":"Image","DataType":2},{"Name":"Name","DataType":0},{"Name":"Job Title","DataType":0},{"Name":"Quote","DataType":0}]', N'{"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/7591aa478dd64b2d970fc6076cc10c33.png"},"Name":{"DataType":0,"Value":"John Doe"},"Job Title":{"DataType":0,"Value":"Director of corlate.com"},"Quote":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt"}}', NULL, NULL, CAST(N'2017-07-30T04:04:10.930' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f4cffdc6-caed-464b-b983-9e221a439a7d', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-ticket"},"Title":{"DataType":0,"Value":"Đại Lý"},"Description":{"DataType":0,"Value":"Đại lý vé máy bay trong nước và quốc tế"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:35:47.443' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f6bf82b0-66c9-427c-8d89-6a9172c50d4b', 5, N'en-UK', N'[{"Name":"Url","DataType":0},{"Name":"Icon","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Icon":{"DataType":3,"Value":"fa fa-twitter"},"Alias":{"DataType":0,"Value":"Twister"}}', NULL, NULL, CAST(N'2017-07-25T09:20:39.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f8f8e706-4250-4a23-919d-e2ac21224d32', 8, N'en-us', N'[{"Name":"Icon","DataType":3},{"Name":"Title","DataType":0},{"Name":"Description","DataType":0},{"Name":"Url","DataType":0}]', N'{"Icon":{"DataType":3,"Value":"fa fa fa-car"},"Title":{"DataType":0,"Value":"Đưa đón"},"Description":{"DataType":0,"Value":"Dịch vụ xe đưa đón từ Sân bay, nhà gare"},"Url":{"DataType":0,"Value":null}}', NULL, NULL, CAST(N'2017-07-29T05:34:23.937' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'f97a3e6eef2b4264853acf4829d8aee3', 4, N'vi-vn', N'[{"Name":"Url","DataType":0},{"Name":"Image","DataType":2},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":"#"},"Image":{"DataType":2,"Value":"/Uploads/Modules/Banners/45eccadfbfe744f092c95a35b7c7ac74.png"},"Alias":{"DataType":0,"Value":"Partner 5"}}', NULL, NULL, CAST(N'2017-07-26T07:09:34.467' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'fa94cbbe07474e5881e98ab4a6327301', 1, N'vi-vn', N'[{"Name":"Title","DataType":0},{"Name":"Image","DataType":2},{"Name":"Url","DataType":0},{"Name":"BrieftContent","DataType":0}]', N'{"Title":{"DataType":0,"Value":"Sysney"},"Image":{"DataType":2,"Value":"/Uploads/Modules/1/28f92cdac36240f796c982a1cd69bf4c.jpg"},"Url":{"DataType":0,"Value":null},"Alias":{"DataType":0,"Value":null},"BrieftContent":{"DataType":0,"Value":"Lorem ipsum dolor sit amet, consectetur adipisicing elit"}}', NULL, NULL, CAST(N'2017-07-25T03:38:29.000' AS DateTime))
GO
INSERT [dbo].[TTS_Module_Data] ([Id], [ModuleId], [Specificulture], [Fields], [Value], [ArticleId], [CategoryId], [CreatedDate]) VALUES (N'faf086a82d06436caed5528106893080', 5, N'vi-vn', N'[{"Name":"Icon","DataType":3},{"Name":"Url","DataType":3},{"Name":"Alias","DataType":0}]', N'{"Url":{"DataType":0,"Value":null},"Icon":{"DataType":3,"Value":"fa fa-skype"},"Alias":{"DataType":0,"Value":"Skype"}}', NULL, NULL, CAST(N'2017-07-29T11:56:08.480' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TTS_Position] ON 

GO
INSERT [dbo].[TTS_Position] ([Position], [Description]) VALUES (1, N'Top')
GO
INSERT [dbo].[TTS_Position] ([Position], [Description]) VALUES (2, N'Left')
GO
INSERT [dbo].[TTS_Position] ([Position], [Description]) VALUES (3, N'Footer')
GO
SET IDENTITY_INSERT [dbo].[TTS_Position] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TTS_Culture]    Script Date: 7/31/2017 9:26:49 AM ******/
ALTER TABLE [dbo].[TTS_Culture] ADD  CONSTRAINT [IX_TTS_Culture] UNIQUE NONCLUSTERED 
(
	[Specificulture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [CountryId]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [IsActived]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('0001-01-01T00:00:00.000') FOR [JoinDate]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('0001-01-01T00:00:00.000') FOR [LastModified]
GO
ALTER TABLE [dbo].[TTS_Article] ADD  CONSTRAINT [DF_Articles_loai]  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[TTS_Article] ADD  CONSTRAINT [DF_Articles_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
ALTER TABLE [dbo].[TTS_Article] ADD  CONSTRAINT [DF_Articles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TTS_Banner] ADD  CONSTRAINT [DF_TTS_Banner_CultureCode]  DEFAULT (N'en') FOR [Specificulture]
GO
ALTER TABLE [dbo].[TTS_Banner] ADD  CONSTRAINT [DF_TTS_Banner_Url]  DEFAULT (N'#') FOR [Url]
GO
ALTER TABLE [dbo].[TTS_Banner] ADD  CONSTRAINT [DF_TTS_Banner_IsPublished]  DEFAULT ((0)) FOR [IsPublished]
GO
ALTER TABLE [dbo].[TTS_Banner] ADD  CONSTRAINT [DF_TTS_Banner_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TTS_Category] ADD  CONSTRAINT [DF_TTS_Category_Type]  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[TTS_Category] ADD  CONSTRAINT [DF_Menus_Level]  DEFAULT ((0)) FOR [Level]
GO
ALTER TABLE [dbo].[TTS_Category] ADD  CONSTRAINT [DF_TTS_Category_Priority]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[TTS_Article]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Article_TTS_Culture] FOREIGN KEY([Specificulture])
REFERENCES [dbo].[TTS_Culture] ([Specificulture])
GO
ALTER TABLE [dbo].[TTS_Article] CHECK CONSTRAINT [FK_TTS_Article_TTS_Culture]
GO
ALTER TABLE [dbo].[TTS_Article_Module]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Article_Module_TTS_Article] FOREIGN KEY([ArticleId], [Specificulture])
REFERENCES [dbo].[TTS_Article] ([Id], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Article_Module] CHECK CONSTRAINT [FK_TTS_Article_Module_TTS_Article]
GO
ALTER TABLE [dbo].[TTS_Article_Module]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Article_Module_TTS_Module1] FOREIGN KEY([ModuleId], [Specificulture])
REFERENCES [dbo].[TTS_Module] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Article_Module] CHECK CONSTRAINT [FK_TTS_Article_Module_TTS_Module1]
GO
ALTER TABLE [dbo].[TTS_Banner]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Banner_TTS_Culture] FOREIGN KEY([Specificulture])
REFERENCES [dbo].[TTS_Culture] ([Specificulture])
GO
ALTER TABLE [dbo].[TTS_Banner] CHECK CONSTRAINT [FK_TTS_Banner_TTS_Culture]
GO
ALTER TABLE [dbo].[TTS_Category]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_TTS_Culture] FOREIGN KEY([Specificulture])
REFERENCES [dbo].[TTS_Culture] ([Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category] CHECK CONSTRAINT [FK_TTS_Menu_TTS_Culture]
GO
ALTER TABLE [dbo].[TTS_Category_Article]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Article_TTS_Article1] FOREIGN KEY([ArticleId], [Specificulture])
REFERENCES [dbo].[TTS_Article] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category_Article] CHECK CONSTRAINT [FK_TTS_Menu_Article_TTS_Article1]
GO
ALTER TABLE [dbo].[TTS_Category_Article]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Article_TTS_Menu] FOREIGN KEY([CategoryId], [Specificulture])
REFERENCES [dbo].[TTS_Category] ([Id], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Category_Article] CHECK CONSTRAINT [FK_TTS_Menu_Article_TTS_Menu]
GO
ALTER TABLE [dbo].[TTS_Category_Category]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Menu_TTS_Menu] FOREIGN KEY([Id], [Specificulture])
REFERENCES [dbo].[TTS_Category] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category_Category] CHECK CONSTRAINT [FK_TTS_Menu_Menu_TTS_Menu]
GO
ALTER TABLE [dbo].[TTS_Category_Category]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Menu_TTS_Menu1] FOREIGN KEY([ParentId], [Specificulture])
REFERENCES [dbo].[TTS_Category] ([Id], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Category_Category] CHECK CONSTRAINT [FK_TTS_Menu_Menu_TTS_Menu1]
GO
ALTER TABLE [dbo].[TTS_Category_Module]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Module_TTS_Menu] FOREIGN KEY([CategoryId], [Specificulture])
REFERENCES [dbo].[TTS_Category] ([Id], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Category_Module] CHECK CONSTRAINT [FK_TTS_Menu_Module_TTS_Menu]
GO
ALTER TABLE [dbo].[TTS_Category_Module]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Menu_Module_TTS_Module1] FOREIGN KEY([ModuleId], [Specificulture])
REFERENCES [dbo].[TTS_Module] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category_Module] CHECK CONSTRAINT [FK_TTS_Menu_Module_TTS_Module1]
GO
ALTER TABLE [dbo].[TTS_Category_Position]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Category_Position_TTS_Category] FOREIGN KEY([CateId], [Specificulture])
REFERENCES [dbo].[TTS_Category] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category_Position] CHECK CONSTRAINT [FK_TTS_Category_Position_TTS_Category]
GO
ALTER TABLE [dbo].[TTS_Category_Position]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Category_Position_TTS_Position] FOREIGN KEY([Position])
REFERENCES [dbo].[TTS_Position] ([Position])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Category_Position] CHECK CONSTRAINT [FK_TTS_Category_Position_TTS_Position]
GO
ALTER TABLE [dbo].[TTS_Module]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_TTS_Culture] FOREIGN KEY([Specificulture])
REFERENCES [dbo].[TTS_Culture] ([Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Module] CHECK CONSTRAINT [FK_TTS_Module_TTS_Culture]
GO
ALTER TABLE [dbo].[TTS_Module_Article]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_Article_TTS_Article1] FOREIGN KEY([ArticleId], [Specificulture])
REFERENCES [dbo].[TTS_Article] ([Id], [Specificulture])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Module_Article] CHECK CONSTRAINT [FK_TTS_Module_Article_TTS_Article1]
GO
ALTER TABLE [dbo].[TTS_Module_Article]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_Article_TTS_Module] FOREIGN KEY([ModuleId], [Specificulture])
REFERENCES [dbo].[TTS_Module] ([Id], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Module_Article] CHECK CONSTRAINT [FK_TTS_Module_Article_TTS_Module]
GO
ALTER TABLE [dbo].[TTS_Module_Data]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_Data_TTS_Article_Module] FOREIGN KEY([ModuleId], [ArticleId], [Specificulture])
REFERENCES [dbo].[TTS_Article_Module] ([ModuleId], [ArticleId], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Module_Data] CHECK CONSTRAINT [FK_TTS_Module_Data_TTS_Article_Module]
GO
ALTER TABLE [dbo].[TTS_Module_Data]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_Data_TTS_Category_Module] FOREIGN KEY([ModuleId], [CategoryId], [Specificulture])
REFERENCES [dbo].[TTS_Category_Module] ([ModuleId], [CategoryId], [Specificulture])
GO
ALTER TABLE [dbo].[TTS_Module_Data] CHECK CONSTRAINT [FK_TTS_Module_Data_TTS_Category_Module]
GO
ALTER TABLE [dbo].[TTS_Module_Data]  WITH CHECK ADD  CONSTRAINT [FK_TTS_Module_Data_TTS_Module] FOREIGN KEY([ModuleId], [Specificulture])
REFERENCES [dbo].[TTS_Module] ([Id], [Specificulture])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTS_Module_Data] CHECK CONSTRAINT [FK_TTS_Module_Data_TTS_Module]
GO
