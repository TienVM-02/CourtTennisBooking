USE [master]
GO
/****** Object:  Database [TennisBooking_v1]    Script Date: 6/14/2022 10:11:32 PM ******/
CREATE DATABASE [TennisBooking_v1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TennisBooking_v2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\TennisBooking_v2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TennisBooking_v2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\TennisBooking_v2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [TennisBooking_v1] SET RECOVERY FULL 
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
/****** Object:  Table [dbo].[Account]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Email] [varchar](200) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[RoleId] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [varchar](10) NOT NULL,
	[CusId] [varchar](200) NULL,
	[CreateDate] [datetime] NULL,
	[TimeStart] [varchar](6) NULL,
	[TimeEnd] [varchar](6) NULL,
	[Price] [float] NULL,
	[CourtId] [varchar](20) NULL,
	[BookingDate] [date] NULL,
	[Status] [bit] NULL,
	[CusName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourtOwner]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtOwner](
	[Email] [varchar](200) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Phone] [varchar](11) NULL,
	[Dob] [date] NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](300) NULL,
 CONSTRAINT [PK_CourtOwners] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Email] [varchar](200) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Phone] [varchar](11) NOT NULL,
	[Dob] [date] NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](300) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [varchar](5) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TennisCourt]    Script Date: 6/14/2022 10:11:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TennisCourt](
	[Id] [varchar](20) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Price] [float] NULL,
	[OwnerId] [varchar](200) NULL,
	[Group] [varchar](50) NULL,
	[Rating] [float] NULL,
	[Image] [varchar](300) NULL,
 CONSTRAINT [PK_TennisCourt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Email], [Password], [RoleId]) VALUES (N'luanhm@gmail.com', N'123', N'OC')
INSERT [dbo].[Account] ([Email], [Password], [RoleId]) VALUES (N'tienvm@gmail.com', N'123', N'CU')
INSERT [dbo].[Account] ([Email], [Password], [RoleId]) VALUES (N'tuanhh@gmail.com', N'123', N'OC')
GO
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [BookingDate], [Status], [CusName]) VALUES (N'1 ', N'tienvm@gmail.com', CAST(N'2022-06-14T00:00:00.000' AS DateTime), N'08:00', N'10:00', 250000, N'FU2', CAST(N'2022-06-15' AS Date), 1, N'Vo Minh Tien')
INSERT [dbo].[Booking] ([Id], [CusId], [CreateDate], [TimeStart], [TimeEnd], [Price], [CourtId], [BookingDate], [Status], [CusName]) VALUES (N'2', N'doanh@gmail.com', CAST(N'2022-06-14T00:00:00.000' AS DateTime), N'14:00', N'15:000', 250000, N'GG2', CAST(N'2022-06-15' AS Date), 1, N'Trieu Quoc Doanh')
GO
INSERT [dbo].[CourtOwner] ([Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (N'luanhm@gmail.com', N'Hua Minh Luan', N'0346963147', CAST(N'2000-01-01' AS Date), 1, N'SG Gateway')
INSERT [dbo].[CourtOwner] ([Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (N'tuanhh@gmail.com', N'Vu Anh Tuan', N'0346852963', CAST(N'2000-01-01' AS Date), 1, N'SG Gateway')
GO
INSERT [dbo].[Customer] ([Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (N'doanh@gmail.com', N'Trieu Quoc Doanh', N'0346957989', CAST(N'2000-01-01' AS Date), 1, N'Quan 9')
INSERT [dbo].[Customer] ([Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (N'thuong@gmail.com', N'Pham Thi Thuong', N'0364959656', CAST(N'2000-01-01' AS Date), 0, N'Quan 9')
INSERT [dbo].[Customer] ([Email], [FullName], [Phone], [Dob], [Gender], [Address]) VALUES (N'tienvm@gmail.com', N'Vo Minh Tien ', N'0346754955', CAST(N'2000-02-01' AS Date), 1, N'Le Van Viet')
GO
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (N'AD', N'Admin')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (N'CU', N'Customer')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (N'OC', N'Owner court')
GO
INSERT [dbo].[TennisCourt] ([Id], [Address], [Name], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (N'FU', N'DH FPT', N'San 1', 250000, N'luanhm@gmail.com', N'1', 4.9, N'image')
INSERT [dbo].[TennisCourt] ([Id], [Address], [Name], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (N'FU2', N'DH FPT', N'San 2 ', 250000, N'luanhm@gmail.com', N'1', 4.5, N'image')
INSERT [dbo].[TennisCourt] ([Id], [Address], [Name], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (N'GG', N'Xa lo Ha Noi', N'Gateway 1', 300000, N'tuanhh@gmail.com', N'1', 4.9, N'image')
INSERT [dbo].[TennisCourt] ([Id], [Address], [Name], [Price], [OwnerId], [Group], [Rating], [Image]) VALUES (N'GG2', N'Xa lo Ha Noi', N'Gateway 2', 250000, N'tuanhh@gmail.com', N'2', 4.5, N'image')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Booking]    Script Date: 6/14/2022 10:11:33 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Booking] ON [dbo].[Booking]
(
	[CourtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customers] FOREIGN KEY([CusId])
REFERENCES [dbo].[Customer] ([Email])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customers]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_TennisCourt] FOREIGN KEY([CourtId])
REFERENCES [dbo].[TennisCourt] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_TennisCourt]
GO
ALTER TABLE [dbo].[TennisCourt]  WITH CHECK ADD  CONSTRAINT [FK_TennisCourt_CourtOwners] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[CourtOwner] ([Email])
GO
ALTER TABLE [dbo].[TennisCourt] CHECK CONSTRAINT [FK_TennisCourt_CourtOwners]
GO
USE [master]
GO
ALTER DATABASE [TennisBooking_v1] SET  READ_WRITE 
GO
