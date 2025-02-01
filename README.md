# Script for the database :
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE [master]
GO
/****** Object:  Database [GymManagementDB]    Script Date: 01-02-2025 03:05:45 AM ******/
CREATE DATABASE [GymManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GymManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GymManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GymManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GymManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GymManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GymManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GymManagementDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GymManagementDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GymManagementDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GymManagementDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [GymManagementDB] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [GymManagementDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GymManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GymManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GymManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GymManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GymManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GymManagementDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GymManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GymManagementDB] SET  ENABLE_BROKER 
GO

ALTER DATABASE [GymManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GymManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GymManagementDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GymManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GymManagementDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GymManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GymManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GymManagementDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [GymManagementDB] SET  MULTI_USER 
GO

ALTER DATABASE [GymManagementDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GymManagementDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GymManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GymManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GymManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GymManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [GymManagementDB] SET QUERY_STORE = ON
GO

ALTER DATABASE [GymManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [GymManagementDB] SET  READ_WRITE 
GO
-------------------------------------------------------------------------------------------------------------------------------------
# GymClasses Table Script :
USE [GymManagementDB]
GO

/****** Object:  Table [dbo].[GymClasses]    Script Date: 01-02-2025 03:07:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GymClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[Duration] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_ClassDate] UNIQUE NONCLUSTERED 
(
	[StartDate] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GymClasses]  WITH CHECK ADD CHECK  (([Capacity]>=(1)))
GO

ALTER TABLE [dbo].[GymClasses]  WITH CHECK ADD CHECK  (([Duration]>(0)))
GO

ALTER TABLE [dbo].[GymClasses]  WITH CHECK ADD CHECK  (([EndDate]>getdate()))
GO
Booking Table scripts :

USE [GymManagementDB]
GO

/****** Object:  Table [dbo].[Bookings]    Script Date: 01-02-2025 03:12:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GymClassId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[ParticipationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Booking] UNIQUE NONCLUSTERED 
(
	[GymClassId] ASC,
	[MemberId] ASC,
	[ParticipationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([GymClassId])
REFERENCES [dbo].[GymClasses] ([Id])
GO

ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO

ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD CHECK  (([ParticipationDate]>getdate()))
GO
Members Table Script:
USE [GymManagementDB]
GO

/****** Object:  Table [dbo].[Members]    Script Date: 01-02-2025 03:13:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
Schema for the database 
CREATE DATABASE GymManagementDB;
GO
---------------------------------------------------------------------------------------------------------
# GymClasses Table :
USE GymManagementDB;
GO

CREATE TABLE GymClasses (
    Id INT IDENTITY(1,1) PRIMARY KE Y,
    Name NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL CHECK (EndDate > GETDATE()),  
    StartTime TIME NOT NULL,
    Duration INT NOT NULL CHECK (Duration > 0),  
    Capacity INT NOT NULL CHECK (Capacity >= 1),  1
    CONSTRAINT UQ_ClassDate UNIQUE (StartDate, StartTime)  
);
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
# Members Table:
CREATE TABLE Members (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
# Bookings Table :
CREATE TABLE Bookings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GymClassId INT NOT NULL,
    MemberId INT NOT NULL,
    ParticipationDate DATETIME NOT NULL CHECK (ParticipationDate > GETDATE()),  -
    FOREIGN KEY (GymClassId) REFERENCES GymClasses(Id),
    FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT UQ_Booking UNIQUE (GymClassId, MemberId, ParticipationDate)  
);
GO
