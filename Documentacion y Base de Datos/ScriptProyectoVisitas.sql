USE [master]
GO
/****** Object:  Database [RegistroVisitantes]    Script Date: 5/19/2022 7:40:53 AM ******/
CREATE DATABASE [RegistroVisitantes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegistroVisitantes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RegistroVisitantes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegistroVisitantes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RegistroVisitantes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RegistroVisitantes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegistroVisitantes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegistroVisitantes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegistroVisitantes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegistroVisitantes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RegistroVisitantes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegistroVisitantes] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RegistroVisitantes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET RECOVERY FULL 
GO
ALTER DATABASE [RegistroVisitantes] SET  MULTI_USER 
GO
ALTER DATABASE [RegistroVisitantes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegistroVisitantes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegistroVisitantes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegistroVisitantes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegistroVisitantes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RegistroVisitantes', N'ON'
GO
ALTER DATABASE [RegistroVisitantes] SET QUERY_STORE = OFF
GO
USE [RegistroVisitantes]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/19/2022 7:40:53 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Changes]    Script Date: 5/19/2022 7:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Changes](
	[IdChanges] [int] IDENTITY(1,1) NOT NULL,
	[ChangesNames] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Changes] PRIMARY KEY CLUSTERED 
(
	[IdChanges] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 5/19/2022 7:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventsAssignations]    Script Date: 5/19/2022 7:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsAssignations](
	[IdEventsAssignation] [int] IDENTITY(1,1) NOT NULL,
	[VisitorId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EventsAssignations] PRIMARY KEY CLUSTERED 
(
	[IdEventsAssignation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 5/19/2022 7:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitors](
	[VisitorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Last_Date_Register] [datetime] NOT NULL,
 CONSTRAINT [PK_Visitors] PRIMARY KEY CLUSTERED 
(
	[VisitorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitsHistories]    Script Date: 5/19/2022 7:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitsHistories](
	[VisitsId] [int] IDENTITY(1,1) NOT NULL,
	[VisitorId] [int] NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[DateIncome] [datetime] NOT NULL,
	[DateDeparture] [datetime] NOT NULL,
 CONSTRAINT [PK_VisitsHistories] PRIMARY KEY CLUSTERED 
(
	[VisitsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_EventsAssignations_EventId]    Script Date: 5/19/2022 7:40:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_EventsAssignations_EventId] ON [dbo].[EventsAssignations]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventsAssignations_VisitorId]    Script Date: 5/19/2022 7:40:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_EventsAssignations_VisitorId] ON [dbo].[EventsAssignations]
(
	[VisitorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VisitsHistories_VisitorId]    Script Date: 5/19/2022 7:40:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_VisitsHistories_VisitorId] ON [dbo].[VisitsHistories]
(
	[VisitorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventsAssignations]  WITH CHECK ADD  CONSTRAINT [FK_EventsAssignations_Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventsAssignations] CHECK CONSTRAINT [FK_EventsAssignations_Events_EventId]
GO
ALTER TABLE [dbo].[EventsAssignations]  WITH CHECK ADD  CONSTRAINT [FK_EventsAssignations_Visitors_VisitorId] FOREIGN KEY([VisitorId])
REFERENCES [dbo].[Visitors] ([VisitorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventsAssignations] CHECK CONSTRAINT [FK_EventsAssignations_Visitors_VisitorId]
GO
ALTER TABLE [dbo].[VisitsHistories]  WITH CHECK ADD  CONSTRAINT [FK_VisitsHistories_Visitors_VisitorId] FOREIGN KEY([VisitorId])
REFERENCES [dbo].[Visitors] ([VisitorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VisitsHistories] CHECK CONSTRAINT [FK_VisitsHistories_Visitors_VisitorId]
GO
USE [master]
GO
ALTER DATABASE [RegistroVisitantes] SET  READ_WRITE 
GO
