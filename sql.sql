USE [master]
GO
/****** Object:  Database [Travel_Booker]    Script Date: 5/4/2022 6:01:23 AM ******/
CREATE DATABASE [Travel_Booker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Travel_Booker', FILENAME = N'D:\SQL SEVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Travel_Booker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Travel_Booker_log', FILENAME = N'D:\SQL SEVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Travel_Booker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Travel_Booker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Travel_Booker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Travel_Booker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Travel_Booker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Travel_Booker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Travel_Booker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Travel_Booker] SET ARITHABORT OFF 
GO
ALTER DATABASE [Travel_Booker] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Travel_Booker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Travel_Booker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Travel_Booker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Travel_Booker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Travel_Booker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Travel_Booker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Travel_Booker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Travel_Booker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Travel_Booker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Travel_Booker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Travel_Booker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Travel_Booker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Travel_Booker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Travel_Booker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Travel_Booker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Travel_Booker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Travel_Booker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Travel_Booker] SET  MULTI_USER 
GO
ALTER DATABASE [Travel_Booker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Travel_Booker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Travel_Booker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Travel_Booker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Travel_Booker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Travel_Booker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Travel_Booker] SET QUERY_STORE = OFF
GO
USE [Travel_Booker]
GO
/****** Object:  Table [dbo].[Accomodation]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accomodation](
	[accomodationID] [int] IDENTITY(1,1) NOT NULL,
	[accomodationName] [nchar](50) NOT NULL,
	[categoryID] [int] NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[phoneNumber] [char](50) NOT NULL,
	[city] [nchar](50) NULL,
	[country] [nchar](20) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[image] [nvarchar](200) NULL,
	[rate] [int] NULL,
	[utilities] [int] NULL,
 CONSTRAINT [PK_Accomodation_1] PRIMARY KEY CLUSTERED 
(
	[accomodationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccomodationDetails]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccomodationDetails](
	[detailID] [int] NOT NULL,
	[roomName] [nchar](200) NOT NULL,
	[roomNumber] [nchar](10) NULL,
	[roomPrice] [decimal](18, 2) NOT NULL,
	[roomCapacity] [int] NULL,
	[roomStatus] [nchar](20) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Accomodation_Details] PRIMARY KEY CLUSTERED 
(
	[detailID] ASC,
	[roomName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [varchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Salt] [nchar](10) NULL,
	[Active] [bit] NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[RoleID] [int] NULL,
	[LastLogin] [datetime] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookingID] [char](10) NOT NULL,
	[customerID] [int] NOT NULL,
	[categoryID] [int] NOT NULL,
	[bookingStatusID] [char](10) NOT NULL,
	[bookingDetailID] [char](10) NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[bookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[bookingDetailID] [char](10) NOT NULL,
	[bookingDate] [date] NULL,
	[arrivalDate] [date] NULL,
	[departureDate] [date] NULL,
	[numberPeople] [int] NULL,
	[assignRoomID] [nchar](50) NULL,
	[totalAmount] [decimal](18, 2) NULL,
	[paymentID] [nchar](10) NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[bookingDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingStatus]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingStatus](
	[statusID] [char](10) NOT NULL,
	[status] [nchar](50) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Booking Status] PRIMARY KEY CLUSTERED 
(
	[statusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryID] [int] NOT NULL,
	[categoryName] [nchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerID] [char](10) NOT NULL,
	[surname] [nchar](20) NOT NULL,
	[lastname] [nchar](20) NOT NULL,
	[gender] [nchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[phoneNumber] [char](50) NULL,
	[dateofbirth] [date] NULL,
	[nationality] [nchar](50) NULL,
	[idNumber] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[paymentID] [nchar](10) NOT NULL,
	[bookingID] [char](10) NOT NULL,
	[date] [date] NULL,
	[paymentTypeID] [nchar](10) NOT NULL,
	[paymentStatusID] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[paymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentStatus]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStatus](
	[paymentStatusID] [nchar](10) NOT NULL,
	[status] [nchar](20) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_PaymentStatus] PRIMARY KEY CLUSTERED 
(
	[paymentStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[paymentTypeID] [nchar](10) NOT NULL,
	[paymentType] [nchar](10) NULL,
	[status] [nchar](20) NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[paymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [char](10) NOT NULL,
	[userName] [char](50) NULL,
	[password] [char](100) NULL,
	[loginDate] [date] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilities]    Script Date: 5/4/2022 6:01:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilities](
	[utilityID] [int] IDENTITY(1,1) NOT NULL,
	[utilityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Utilities] PRIMARY KEY CLUSTERED 
(
	[utilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accomodation]  WITH CHECK ADD  CONSTRAINT [FK_Accomodation_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Accomodation] CHECK CONSTRAINT [FK_Accomodation_Category]
GO
ALTER TABLE [dbo].[AccomodationDetails]  WITH CHECK ADD  CONSTRAINT [FK_AccomodationDetails_Accomodation] FOREIGN KEY([detailID])
REFERENCES [dbo].[Accomodation] ([accomodationID])
GO
ALTER TABLE [dbo].[AccomodationDetails] CHECK CONSTRAINT [FK_AccomodationDetails_Accomodation]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Accounts] FOREIGN KEY([customerID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Accounts]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_BookingDetails] FOREIGN KEY([bookingDetailID])
REFERENCES [dbo].[BookingDetails] ([bookingDetailID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_BookingDetails]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_BookingStatus] FOREIGN KEY([bookingStatusID])
REFERENCES [dbo].[BookingStatus] ([statusID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_BookingStatus]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Category]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_BookingDetails] FOREIGN KEY([paymentID])
REFERENCES [dbo].[Payment] ([paymentID])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_BookingDetails]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Booking] FOREIGN KEY([bookingID])
REFERENCES [dbo].[Booking] ([bookingID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Booking]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentStatus] FOREIGN KEY([paymentStatusID])
REFERENCES [dbo].[PaymentStatus] ([paymentStatusID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentStatus]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([paymentTypeID])
REFERENCES [dbo].[PaymentType] ([paymentTypeID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Customer] FOREIGN KEY([userID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Customer]
GO
USE [master]
GO
ALTER DATABASE [Travel_Booker] SET  READ_WRITE 
GO
