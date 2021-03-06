USE [master]
GO
/****** Object:  Database [TennisBooking_v1]    Script Date: 6/7/2022 3:23:47 PM ******/
CREATE DATABASE [TennisBooking_v1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TennisBooking_v1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TIENK14\MSSQL\DATA\TennisBooking_v1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TennisBooking_v1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TIENK14\MSSQL\DATA\TennisBooking_v1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TennisBooking_v1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TennisBooking_v1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TennisBooking_v1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET ARITHABORT OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TennisBooking_v1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TennisBooking_v1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TennisBooking_v1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TennisBooking_v1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TennisBooking_v1] SET  MULTI_USER 
GO
ALTER DATABASE [TennisBooking_v1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TennisBooking_v1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TennisBooking_v1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TennisBooking_v1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TennisBooking_v1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TennisBooking_v1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TennisBooking_v1', N'ON'
GO
ALTER DATABASE [TennisBooking_v1] SET QUERY_STORE = OFF
GO
USE [TennisBooking_v1]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Email] [varchar](200) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[RoleId] [varchar](5) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[TimeStart] [time](7) NULL,
	[TimeEnd] [time](7) NULL,
	[Price] [float] NULL,
	[CourtId] [int] NULL,
	[Slot] [int] NULL,
	[BookingDate] [date] NULL,
	[Status] [bit] NULL,
	[CusName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourtOwner]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](200) NULL,
	[FullName] [nvarchar](100) NULL,
	[Phone] [varchar](11) NULL,
	[Dob] [date] NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](300) NULL,
 CONSTRAINT [PK_CourtOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Phone] [varchar](11) NOT NULL,
	[Dob] [date] NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [varchar](5) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TennisCourt]    Script Date: 6/7/2022 3:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TennisCourt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](300) NULL,
	[Price] [float] NULL,
	[OwnerId] [int] NULL,
	[Group] [nchar](10) NULL,
	[Rating] [float] NULL,
	[Image] [varchar](500) NULL,
 CONSTRAINT [PK_TennisCourt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Email], [Password], [RoleId]) VALUES (N'tienvmt02@gmail.com', N'123', N'CU')
INSERT [dbo].[Account] ([Email], [Password], [RoleId]) VALUES (N'tuanva@gmail.com', N'123', N'OW')
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (1, 1, CAST(N'2022-06-02T00:00:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), 250000, 1, 1, CAST(N'2022-06-02' AS Date), 1, N'Minh Tiến')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (4, 1, CAST(N'2022-06-02T00:00:00.000' AS DateTime), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), 250000, 1, 2, CAST(N'2022-06-02' AS Date), 1, N'Minh Tiến')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (5, 2, CAST(N'2022-06-02T00:00:00.000' AS DateTime), CAST(N'14:00:00' AS Time), CAST(N'16:00:00' AS Time), 300000, 2, 5, CAST(N'2022-06-02' AS Date), 1, N'Quốc Doanh')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (6, 2, CAST(N'2022-06-02T00:00:00.000' AS DateTime), CAST(N'18:00:00' AS Time), CAST(N'20:00:00' AS Time), 310000, 2, 7, CAST(N'2022-06-02' AS Date), 1, N'Quốc Doanh')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (7, 2, CAST(N'2022-06-03T00:00:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), 300000, 2, 2, CAST(N'2022-06-04' AS Date), 1, N'Quốc Doanh')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (8, 2, CAST(N'2022-06-03T00:00:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), 300000, 2, 2, CAST(N'2022-06-03' AS Date), 1, N'Quốc Doanh')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [Slot], [BookingDate], [Status], [CusName]) VALUES (9, 2, CAST(N'2022-06-03T00:00:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), 300000, 2, 2, CAST(N'2022-06-05' AS Date), 0, N'Quốc Doanh')
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[CourtOwner] ON 

INSERT [dbo].[CourtOwner] ([Id], [Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (1, N'tuanva@gmail.com', N'Anh Tuấn', N'0346754922', CAST(N'2000-01-01' AS Date), 1, N'Gateway')
INSERT [dbo].[CourtOwner] ([Id], [Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (2, N'thuongPT@gmail.com', N'Phạm Thương ', N'0345256354', CAST(N'2000-01-01' AS Date), 0, N'Võ Văn Ngân')
SET IDENTITY_INSERT [dbo].[CourtOwner] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (1, N'tien@gmail.com', N'Minh Tiến', N'0346754958', CAST(N'2000-02-01' AS Date), 1, N'Võ Văn Hát')
INSERT [dbo].[Customer] ([Id], [Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (2, N'bodoanh@gmail.com', N'Quốc Doanh', N'0345963658', CAST(N'2000-01-01' AS Date), 1, N'Suối Tiên')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'AD', N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'CU', N'Customer')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (N'OW', N'Owner')
GO
SET IDENTITY_INSERT [dbo].[TennisCourt] ON 

INSERT [dbo].[TennisCourt] ([Id], [Name], [Address], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (1, N'FPTU ', N'Khu CNC', 250000, 1, N'1         ', 4.5, N'https://thegioithethao.vn/thiet-ke-thi-cong/kich-thuoc-san-tennis-tieu-chuan-thi-dau-n63.html')
INSERT [dbo].[TennisCourt] ([Id], [Name], [Address], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (2, N'FPTU 2', N'Khu CNC', 300000, 1, N'1         ', 4, N'https://thegioithethao.vn/thiet-ke-thi-cong/kich-thuoc-san-tennis-tieu-chuan-thi-dau-n63.html')
INSERT [dbo].[TennisCourt] ([Id], [Name], [Address], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (4, N'Phù Đổng ', N'Võ  Văn Ngân', 310000, 2, N'1         ', 4.5, N'https://thegioithethao.vn/thiet-ke-thi-cong/kich-thuoc-san-tennis-tieu-chuan-thi-dau-n63.html')
INSERT [dbo].[TennisCourt] ([Id], [Name], [Address], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (5, N'Phù Đổng 2', N'Võ  Văn Ngân', 310000, 2, N'1         ', 4.3, N'https://thegioithethao.vn/thiet-ke-thi-cong/kich-thuoc-san-tennis-tieu-chuan-thi-dau-n63.html')
SET IDENTITY_INSERT [dbo].[TennisCourt] OFF
GO
/****** Object:  Index [uq_Booking]    Script Date: 6/7/2022 3:23:47 PM ******/
ALTER TABLE [dbo].[Booking] ADD  CONSTRAINT [uq_Booking] UNIQUE NONCLUSTERED 
(
	[BookingDate] ASC,
	[Slot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__A9D10534C6E89C76]    Script Date: 6/7/2022 3:23:47 PM ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [UQ__Customer__A9D10534C6E89C76] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uq_TennisCourt]    Script Date: 6/7/2022 3:23:47 PM ******/
ALTER TABLE [dbo].[TennisCourt] ADD  CONSTRAINT [uq_TennisCourt] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Unique_key]    Script Date: 6/7/2022 3:23:47 PM ******/
CREATE NONCLUSTERED COLUMNSTORE INDEX [Unique_key] ON [dbo].[Booking]
(
	[CourtId]
)WITH (DROP_EXISTING = OFF, COMPRESSION_DELAY = 0) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([CusId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_TennisCourt] FOREIGN KEY([CourtId])
REFERENCES [dbo].[TennisCourt] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_TennisCourt]
GO
ALTER TABLE [dbo].[TennisCourt]  WITH CHECK ADD  CONSTRAINT [FK_TennisCourt_CourtOwner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[CourtOwner] ([Id])
GO
ALTER TABLE [dbo].[TennisCourt] CHECK CONSTRAINT [FK_TennisCourt_CourtOwner]
GO
USE [master]
GO
ALTER DATABASE [TennisBooking_v1] SET  READ_WRITE 
GO
