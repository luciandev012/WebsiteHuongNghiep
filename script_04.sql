USE [VocationalGuidance]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/4/2021 9:53:15 PM ******/
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
/****** Object:  Table [dbo].[HollandMultipleChoices]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HollandMultipleChoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](250) NULL,
	[HLTableId] [int] NOT NULL,
 CONSTRAINT [PK_HollandMultipleChoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HollandResult]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HollandResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Table] [int] NOT NULL,
	[Result] [ntext] NULL,
 CONSTRAINT [PK_HollandResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HollandScore]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HollandScore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Table] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[TimeStamp] [varchar](50) NULL,
 CONSTRAINT [PK_HollandScore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HollandTables]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HollandTables](
	[HLTableId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_HollandTables] PRIMARY KEY CLUSTERED 
(
	[HLTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HollandTrackers]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HollandTrackers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Step] [int] NOT NULL,
	[Times] [int] NOT NULL,
	[TimeStamp] [varchar](50) NULL,
	[UserId] [uniqueidentifier] NOT NULL DEFAULT ('00000000-0000-0000-0000-000000000000'),
 CONSTRAINT [PK_HollandTrackers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[DoB] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 11/4/2021 9:53:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211005103620_Initial', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211005160620_AddIdentity', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211005165327_SeedingDataIdentity', N'5.0.10')
SET IDENTITY_INSERT [dbo].[HollandMultipleChoices] ON 

INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1, N'Tôi có tính tự lập', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (2, N'Tôi suy nghĩ thực tế', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (3, N'Tôi là người thích nghi với môi trường mới', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (4, N'Tôi có thể vận hành, điều khiển các máy móc thiết bị', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (5, N'Tôi làm các công việc thủ công như gấp giấy, đan, móc', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (6, N'Tôi thích tiếp xúc với thiên nhiên, động vật, cây cỏ', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (7, N'Tôi thích những công việc sử dụng tay chân hơn là trí óc', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (8, N'Tôi thích những công việc thấy ngay kết quả', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (9, N'Tôi thích làmviệc ngoài trời hơn là trong phòng học, văn phòng', 1)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (10, N'Tôi có tìm hiểu khám phá nhiều vấn đề mới', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (11, N'Tôi có khả năng phân tích vấn đề', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (12, N'Tôi biết suy nghĩ một cách mạch lạc, chặt chẽ', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (13, N'Tôi thích thực hiện các thí nghiệm hay nghiên cứu', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (14, N'Tôi có khả năng tổng hợp, khái quát, suy đoán những vấn đề', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (15, N'Tôi thích những hoạt động điều tra, phân loại, kiểm tra, đánh giá', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (16, N'Tôi tự tổ chức công việc mình phái làm', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (17, N'Tôi thích suy nghĩ về những vấn đề phức tạp, làm những công việc phức tạp', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (18, N'Tôi có khả năng giải quyết các vấn đề', 2)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1005, N'Tôi là người dễ xúc động', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1006, N'Tôi có óc tưởng tượng phong phú', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1007, N'Tôi thích sự tự do, không theo những quy định , quy tắc', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1008, N'Tôi có khả năng thuyết trình, diễn xuất', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1009, N'Tôi có thể chụp hình hoặc vẽ tranh, trang trí, điêu khắc', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1010, N'Tôi có năng khiếu âm nhạc', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1011, N'Tôi có khả năng viết, trình bày những ý tưởng của mình', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1012, N'Tôi thích làm những công việc mới, những công việc đòi hỏi sự sáng tạo', 3)
INSERT [dbo].[HollandMultipleChoices] ([Id], [Question], [HLTableId]) VALUES (1013, N'Tôi thoải mái bộc lộ những ý thích', 3)
SET IDENTITY_INSERT [dbo].[HollandMultipleChoices] OFF
SET IDENTITY_INSERT [dbo].[HollandResult] ON 

INSERT [dbo].[HollandResult] ([Id], [Table], [Result]) VALUES (1, 1, N'Kiểu người R (Realistic - Người thực tế): (tổng điểm số của bảng A là cao nhất so với các bảng khác)
Người thuộc nhóm sở thích nghề nghiệp này thường có khả năng về kỹ thuật, công nghệ, hệ thống; ưa thích làm việc với đồ vật, máy móc, động thực vật; thích làm các công việc ngoài trời.
Ngành nghề phù hợp với nhóm này bao gồm những nghề về kiến trúc, an toàn lao động, nghề mộc, xây dựng, thủy sản, kỹ thuật, máy tàu thủy, lái xe, huấn luyện viên, nông - lâm nghiệp (quản lý trang trại, nhân giống cá, lâm nghiệp...), cơ khí (chế tạo máy, bảo trì và sửa chữa thiết bị, luyện kim, cơ khí ứng dụng, tự động...), điện - điện tử, địa lý - địa chất (đo đạc, vẽ bản đồ địa chính), dầu khí, hải dương học, quản lý công nghiệp...
')
INSERT [dbo].[HollandResult] ([Id], [Table], [Result]) VALUES (2, 2, N'Kiểu người I (Investigative - Người nghiên cứu): (tổng điểm số của bảng B là cao nhất so với các bảng khác)
Có khả năng về quan sát, khám phá, phân tích đánh giá và giải quyết các vấn đề.
Ngành nghề phù hợp với nhóm này bao gồm: Các ngành thuộc lĩnh vực khoa học tự nhiên (toán, lý, hóa, sinh, địa lý, địa chất, thống kê...); khoa học xã hội (nhân học, tâm lý, địa lý...); y - dược (bác sĩ gây mê, hồi sức, bác sĩ phẫu thuật, nha sĩ...); khoa học công nghệ (công nghệ thông tin, môi trường, điện, vật lý kỹ thuật, xây dựng...); nông lâm (nông học, thú y...).
')
INSERT [dbo].[HollandResult] ([Id], [Table], [Result]) VALUES (3, 3, N'Kiểu người I (Investigative - Người nghiên cứu): (tổng điểm số của bảng B là cao nhất so với các bảng khác)
Có khả năng về quan sát, khám phá, phân tích đánh giá và giải quyết các vấn đề.
Ngành nghề phù hợp với nhóm này bao gồm: Các ngành thuộc lĩnh vực khoa học tự nhiên (toán, lý, hóa, sinh, địa lý, địa chất, thống kê...); khoa học xã hội (nhân học, tâm lý, địa lý...); y - dược (bác sĩ gây mê, hồi sức, bác sĩ phẫu thuật, nha sĩ...); khoa học công nghệ (công nghệ thông tin, môi trường, điện, vật lý kỹ thuật, xây dựng...); nông lâm (nông học, thú y...).
')
SET IDENTITY_INSERT [dbo].[HollandResult] OFF
SET IDENTITY_INSERT [dbo].[HollandScore] ON 

INSERT [dbo].[HollandScore] ([Id], [Table], [Score], [TimeStamp]) VALUES (2, 1, 16, N'11/2/2021 4:14:39 PM')
INSERT [dbo].[HollandScore] ([Id], [Table], [Score], [TimeStamp]) VALUES (3, 2, 21, N'11/2/2021 4:14:39 PM')
INSERT [dbo].[HollandScore] ([Id], [Table], [Score], [TimeStamp]) VALUES (4, 3, 18, N'11/2/2021 4:14:39 PM')
INSERT [dbo].[HollandScore] ([Id], [Table], [Score], [TimeStamp]) VALUES (5, 1, 18, N'11/3/2021 2:36:47 PM')
INSERT [dbo].[HollandScore] ([Id], [Table], [Score], [TimeStamp]) VALUES (6, 2, 20, N'11/3/2021 2:36:47 PM')
SET IDENTITY_INSERT [dbo].[HollandScore] OFF
SET IDENTITY_INSERT [dbo].[HollandTables] ON 

INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (1, N'Bảng A (R: Realistic - Người thực tế)')
INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (2, N'Bảng B (I: Investigative - Người thích nghiên cứu)')
INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (3, N'Bảng C (A : Artistic - Người có tính nghệ sĩ )')
INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (4, N'Bảng D ( S: Social - Người có Tính xã hội )')
INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (5, N'Bảng E ( E: Enterprising - Người dám nghĩ dám làm)')
INSERT [dbo].[HollandTables] ([HLTableId], [Name]) VALUES (6, N'Bảng F ( C : Conventional - Người công chức )')
SET IDENTITY_INSERT [dbo].[HollandTables] OFF
SET IDENTITY_INSERT [dbo].[HollandTrackers] ON 

INSERT [dbo].[HollandTrackers] ([Id], [Step], [Times], [TimeStamp], [UserId]) VALUES (4, 3, 1, N'11/2/2021 4:14:39 PM', N'4790b67c-8dd9-45c0-8457-0eaa334382ed')
INSERT [dbo].[HollandTrackers] ([Id], [Step], [Times], [TimeStamp], [UserId]) VALUES (5, 3, 0, N'11/3/2021 2:36:47 PM', N'4790b67c-8dd9-45c0-8457-0eaa334382ed')
SET IDENTITY_INSERT [dbo].[HollandTrackers] OFF
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f39a6ba2-d19f-49ba-b75e-2f5c4f1aaaf2', N'Role pupil for person study in school (under 18)', N'pupil', N'pupil', N'3fd0a5b6-a552-4fac-bd25-e0d86954f970')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a01ab883-d923-4c7d-bf6f-42d1592f2280', N'Administrator role', N'admin', N'admin', N'f5c9156f-fb11-44b7-9aff-8f1a9affd137')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ef936e2f-d09a-4fdf-8842-459ed6350702', N'Role student for person study in university', N'student', N'student', N'395131ec-9ada-4b26-9e6f-50f55f3c9321')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4790b67c-8dd9-45c0-8457-0eaa334382ed', N'ef936e2f-d09a-4fdf-8842-459ed6350702')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'1c2e9655-416b-4ff8-9413-1e1d13e0f403', N'a01ab883-d923-4c7d-bf6f-42d1592f2280')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [DoB], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4790b67c-8dd9-45c0-8457-0eaa334382ed', N'Minh', N'Van', CAST(N'1999-01-10 00:00:00.0000000' AS DateTime2), N'0234565578', N'0234565578', N'abcd@gmail.com', N'ABCD@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMbfa45KYONEIBK6E4R1k+I5ODTvIgvGKjQG/ebWt9CLCHuHbnFHqdWehecicvUjHQ==', N'', N'ee1e4d4c-5370-4478-9355-596ae293f97f', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [DoB], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1c2e9655-416b-4ff8-9413-1e1d13e0f403', N'Anh', N'Quang', CAST(N'1998-02-23 00:00:00.0000000' AS DateTime2), N'0123456789', N'0123456789', N'abcxyz@gmail.com', N'abcxyz@gmail.com', 1, N'AQAAAAEAACcQAAAAEMbfa45KYONEIBK6E4R1k+I5ODTvIgvGKjQG/ebWt9CLCHuHbnFHqdWehecicvUjHQ==', N'', N'31125af5-109d-4bf8-9efc-0d7b8439f113', NULL, 0, 0, NULL, 0, 0)
ALTER TABLE [dbo].[HollandMultipleChoices]  WITH CHECK ADD  CONSTRAINT [FK_HollandMultipleChoices_HollandTables_HLTableId] FOREIGN KEY([HLTableId])
REFERENCES [dbo].[HollandTables] ([HLTableId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HollandMultipleChoices] CHECK CONSTRAINT [FK_HollandMultipleChoices_HollandTables_HLTableId]
GO
ALTER TABLE [dbo].[HollandTrackers]  WITH CHECK ADD  CONSTRAINT [FK_HollandTrackers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HollandTrackers] CHECK CONSTRAINT [FK_HollandTrackers_Users_UserId]
GO
