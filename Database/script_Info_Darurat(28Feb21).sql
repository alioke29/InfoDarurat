USE [Info_Darurat]
GO
/****** Object:  Table [dbo].[Aktivitas]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aktivitas](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[IDKartu] [bigint] NULL,
	[JamMasuk] [nvarchar](10) NULL,
	[JamKeluar] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DaftarAlat]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaftarAlat](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[NamaAlat] [nvarchar](100) NULL,
	[Desc] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kartu]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kartu](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[NoKartu] [nvarchar](10) NULL,
	[Desc] [nvarchar](100) NULL,
	[NamaPetugas] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Level]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[LevelName] [nvarchar](100) NULL,
	[Desc] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[DisplayName] [nvarchar](100) NULL,
	[UrlNav] [nvarchar](200) NULL,
	[ParentMenuId] [bigint] NULL,
	[SortNumber] [nvarchar](2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Panggilan]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Panggilan](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[IDLevel] [bigint] NULL,
	[Nama] [nvarchar](100) NULL,
	[Spec] [nvarchar](100) NULL,
	[NoPanggilan] [nvarchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersiapanAlat]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersiapanAlat](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[IDPanggilan] [bigint] NULL,
	[NamaPeralatan] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Desc] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[IDRole] [bigint] NULL,
	[IDMenu] [bigint] NULL,
	[IsActiveMenu] [bit] NULL,
	[IsAdd] [bit] NULL,
	[IsEdit] [bit] NULL,
	[IsDelete] [bit] NULL,
	[IsExport] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/28/2021 1:30:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(4,1) NOT NULL,
	[IDRole] [bigint] NULL,
	[IDKartu] [bigint] NULL,
	[Code] [nvarchar](50) NULL,
	[UserName] [nvarchar](20) NULL,
	[Fullname] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[IsLogin] [bit] NULL,
	[IsActive] [bit] NULL,
	[LastLoginDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Aktivitas] ON 

INSERT [dbo].[Aktivitas] ([ID], [IDKartu], [JamMasuk], [JamKeluar], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, 4, N'08.00', N'17.00', NULL, NULL, NULL, NULL)
INSERT [dbo].[Aktivitas] ([ID], [IDKartu], [JamMasuk], [JamKeluar], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, 5, N'09.00', N'12.00', NULL, NULL, NULL, NULL)
INSERT [dbo].[Aktivitas] ([ID], [IDKartu], [JamMasuk], [JamKeluar], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, 4, N'09:00', N'24:00', CAST(0x0000ACC300A5BAFA AS DateTime), N'System', CAST(0x0000ACD200AAD137 AS DateTime), N'System')
SET IDENTITY_INSERT [dbo].[Aktivitas] OFF
SET IDENTITY_INSERT [dbo].[DaftarAlat] ON 

INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Help', NULL, CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Kampak', NULL, CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Vitamin', NULL, CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Perban', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (8, N'Antiseptik', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (9, N'Racun Api', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10007, N'test123', N'', CAST(0x0000ACC70161EF88 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10011, N'test1234', N'', CAST(0x0000ACC701642E45 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10012, N'test12345', N'', CAST(0x0000ACC7016443D1 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10014, N'dfg', N'', CAST(0x0000ACC701745C3F AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[DaftarAlat] ([ID], [NamaAlat], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10013, N'fgf', N'', CAST(0x0000ACC70171B894 AS DateTime), N'System', NULL, NULL)
SET IDENTITY_INSERT [dbo].[DaftarAlat] OFF
SET IDENTITY_INSERT [dbo].[Kartu] ON 

INSERT [dbo].[Kartu] ([ID], [NoKartu], [Desc], [NamaPetugas], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'123ABC ', N'Tamu', N'Budi Santoso', 1, CAST(0x0000ACA300000000 AS DateTime), N'System', CAST(0x0000ACD200A899A9 AS DateTime), N'System')
INSERT [dbo].[Kartu] ([ID], [NoKartu], [Desc], [NamaPetugas], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'129PKQ', N'Petugas', N'Rina Mariana', 0, CAST(0x0000ACA300000000 AS DateTime), N'System', CAST(0x0000ACC30089AD27 AS DateTime), N'System')
SET IDENTITY_INSERT [dbo].[Kartu] OFF
SET IDENTITY_INSERT [dbo].[Level] ON 

INSERT [dbo].[Level] ([ID], [LevelName], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Level 1', N'-', CAST(0x0000ACB301061F51 AS DateTime), N'System', CAST(0x0000ACD200AEF084 AS DateTime), N'System')
INSERT [dbo].[Level] ([ID], [LevelName], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Level 2', N'-', CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Level] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (4, N'Setting Security', N'-', 0, N'0', NULL, NULL, CAST(0x0000ACB301061F51 AS DateTime), N'System')
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (5, N'Master User', N'UserList', 4, N'', CAST(0x0000A8AE00000000 AS DateTime), N'system', NULL, NULL)
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (6, N'Master Role', N'RoleList', 4, N'1', CAST(0x0000ACAE00F09ED3 AS DateTime), N'System', CAST(0x0000ACAE00F09ED3 AS DateTime), N'System')
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (10, N'Kartu', N'KartuList', 9, N'1', NULL, NULL, CAST(0x0000ACB600D7C83A AS DateTime), N'System')
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (9, N'Area Terlarang', N'-', 0, N'0', NULL, NULL, CAST(0x0000ACB301062A37 AS DateTime), N'System')
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (11, N'Aktifitas', N'AktivitasList', 9, N'2', CAST(0x0000ACB30107AC35 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (14, N'Sistem Darurat', N'-', 0, N'0', CAST(0x0000ACB801101064 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (15, N'Level', N'LevelList', 14, N'1', NULL, NULL, CAST(0x0000ACB9008CACAA AS DateTime), N'System')
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (16, N'No Panggilan', N'PanggilanList', 14, N'2', CAST(0x0000ACB80110F74B AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[Menu] ([ID], [DisplayName], [UrlNav], [ParentMenuId], [SortNumber], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (17, N'Persiapan Alat', N'PersiapanAlatList', 14, N'3', CAST(0x0000ACB8011109FD AS DateTime), N'System', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Panggilan] ON 

INSERT [dbo].[Panggilan] ([ID], [IDLevel], [Nama], [Spec], [NoPanggilan], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, 4, N'Bimo Jaya', N'Medis', N'08184534534', CAST(0x0000ACB301061F51 AS DateTime), N'System', CAST(0x0000ACD200AEFC2C AS DateTime), N'System')
INSERT [dbo].[Panggilan] ([ID], [IDLevel], [Nama], [Spec], [NoPanggilan], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, 5, N'Aryo Wiguna', N'Petugas', N'08125654656', CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Panggilan] OFF
SET IDENTITY_INSERT [dbo].[PersiapanAlat] ON 

INSERT [dbo].[PersiapanAlat] ([ID], [IDPanggilan], [NamaPeralatan], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, 5, N'Help, Vitamin', CAST(0x0000ACB301061F51 AS DateTime), N'System', CAST(0x0000ACC70138B7D1 AS DateTime), N'System')
INSERT [dbo].[PersiapanAlat] ([ID], [IDPanggilan], [NamaPeralatan], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, 4, N'Kampak, Racun Api', CAST(0x0000ACB301061F51 AS DateTime), N'System', NULL, NULL)
INSERT [dbo].[PersiapanAlat] ([ID], [IDPanggilan], [NamaPeralatan], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (8, 4, N'Perban, Antiseptik, Racun Api', CAST(0x0000ACDB00A2B32B AS DateTime), N'System', NULL, NULL)
SET IDENTITY_INSERT [dbo].[PersiapanAlat] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [Desc], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Administrator', N'User Super Admistrator', NULL, NULL, CAST(0x0000ACD100B95B14 AS DateTime), N'System')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (4, 4, 4, 1, 1, 1, 1, 1, CAST(0x0000A61300000000 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (5, 4, 5, 1, 1, 1, 1, 1, CAST(0x0000A61300000000 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (6, 4, 6, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F1384D AS DateTime), N'System', CAST(0x0000ACAE00F1384D AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (7, 4, 7, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F13F0B AS DateTime), N'System', CAST(0x0000ACAE00F13F0B AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (8, 4, 9, 1, 1, 1, 1, 1, CAST(0x0000A61300000000 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (9, 4, 10, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F1384D AS DateTime), N'System', CAST(0x0000ACAE00F1384D AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (10, 4, 11, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F13F0B AS DateTime), N'System', CAST(0x0000ACAE00F13F0B AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (11, 4, 14, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F13F0B AS DateTime), N'System', CAST(0x0000ACAE00F13F0B AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (12, 4, 15, 1, 1, 1, 1, 1, CAST(0x0000A61300000000 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (13, 4, 16, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F1384D AS DateTime), N'System', CAST(0x0000ACAE00F1384D AS DateTime), N'System')
INSERT [dbo].[UserRoles] ([ID], [IDRole], [IDMenu], [IsActiveMenu], [IsAdd], [IsEdit], [IsDelete], [IsExport], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdateBy]) VALUES (14, 4, 17, 1, 1, 1, 1, 1, CAST(0x0000ACAE00F13F0B AS DateTime), N'System', CAST(0x0000ACAE00F13F0B AS DateTime), N'System')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [IDRole], [IDKartu], [Code], [UserName], [Fullname], [Email], [Password], [IsLogin], [IsActive], [LastLoginDate], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, 4, 4, N'4', N'admin', N'Administrator', N'admin_darurat@gmail.com', N'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', 0, 1, CAST(0x0000ACAE0114F398 AS DateTime), CAST(0x0000ACAE0114F398 AS DateTime), N'System', CAST(0x0000ACD200A5A37F AS DateTime), N'System')
INSERT [dbo].[Users] ([ID], [IDRole], [IDKartu], [Code], [UserName], [Fullname], [Email], [Password], [IsLogin], [IsActive], [LastLoginDate], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, 4, 5, N'4', N'sofyan', N'Sofyan Ali', N'Sofyan.Ali@gmail.com', N'1ad41c30da700d6e0a9b4009e61150240a948c16834934651cf972af659fbd26', 0, 1, CAST(0x0000ACAE01168C8C AS DateTime), CAST(0x0000ACAE01168C8C AS DateTime), N'System', CAST(0x0000ACDB00B1EBCD AS DateTime), N'System')
INSERT [dbo].[Users] ([ID], [IDRole], [IDKartu], [Code], [UserName], [Fullname], [Email], [Password], [IsLogin], [IsActive], [LastLoginDate], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (17, 4, 0, N'4', N'zhar', N'Azhar Usni', N'zhar@gmail.com', N'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', 0, 1, NULL, NULL, NULL, CAST(0x0000ACC8011DA65B AS DateTime), N'System')
INSERT [dbo].[Users] ([ID], [IDRole], [IDKartu], [Code], [UserName], [Fullname], [Email], [Password], [IsLogin], [IsActive], [LastLoginDate], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (19, 4, 0, N'4', N'teguh', N'Teguh Panjaitan', N'teguh@gmail.com', N'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', 0, 1, NULL, CAST(0x0000ACC2015192A0 AS DateTime), N'System', CAST(0x0000ACC8011DAF58 AS DateTime), N'System')
SET IDENTITY_INSERT [dbo].[Users] OFF
