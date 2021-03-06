USE [master]
GO
/****** Object:  Database [Team-1]    Script Date: 13-04-2020 17:52:54 ******/
CREATE DATABASE [Team-1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Team-1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.REVANTHSQL\MSSQL\DATA\Team-1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Team-1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.REVANTHSQL\MSSQL\DATA\Team-1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Team-1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Team-1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Team-1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Team-1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Team-1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Team-1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Team-1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Team-1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Team-1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Team-1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Team-1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Team-1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Team-1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Team-1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Team-1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Team-1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Team-1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Team-1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Team-1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Team-1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Team-1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Team-1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Team-1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Team-1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Team-1] SET RECOVERY FULL 
GO
ALTER DATABASE [Team-1] SET  MULTI_USER 
GO
ALTER DATABASE [Team-1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Team-1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Team-1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Team-1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Team-1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Team-1', N'ON'
GO
ALTER DATABASE [Team-1] SET QUERY_STORE = OFF
GO
USE [Team-1]
GO
/****** Object:  Table [dbo].[tblBankDetails]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBankDetails](
	[Bank_ID] [char](10) NOT NULL,
	[Bank_Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblBankDetails] PRIMARY KEY CLUSTERED 
(
	[Bank_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBooking]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBooking](
	[Booking_ID] [int] IDENTITY(20,1) NOT NULL,
	[Customer_ID] [nvarchar](10) NOT NULL,
	[HotelID] [nvarchar](15) NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[Number_of_Adults] [int] NOT NULL,
	[Number_of_Children] [int] NOT NULL,
	[Number_of_Nights] [int] NOT NULL,
	[Room_Type] [nvarchar](10) NOT NULL,
	[Number_of_Rooms] [int] NOT NULL,
 CONSTRAINT [PK_tblBooking] PRIMARY KEY CLUSTERED 
(
	[Booking_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[COUNTRY_ID] [nvarchar](20) NOT NULL,
	[CITY_NAME] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblCity] PRIMARY KEY CLUSTERED 
(
	[CITY_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountry](
	[COUNTRY_ID] [nvarchar](20) NOT NULL,
	[COUNTRY_NAME] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED 
(
	[COUNTRY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[Customer_ID] [nvarchar](10) NOT NULL,
	[CustomerName] [nvarchar](20) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[ContactNumber] [bigint] NOT NULL,
	[EmailAddress] [nvarchar](30) NOT NULL,
	[Country] [nvarchar](20) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[PinCode] [int] NOT NULL,
	[State] [nvarchar](10) NOT NULL,
	[CustomerType] [nvarchar](20) NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHotelDetails]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHotelDetails](
	[HotelID] [nvarchar](15) NOT NULL,
	[Hotel_Name] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](20) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[Hotel_Description] [nvarchar](150) NOT NULL,
	[Number_of_AC_Rooms] [int] NOT NULL,
	[Number_of_Non_AC_Rooms] [int] NOT NULL,
	[Rate_for_one_night_for_one_children_AC] [int] NOT NULL,
	[Rate_for_one_night_for_one_adult_AC] [int] NOT NULL,
	[Rate_for_one_night_for_one_children_NONAC] [int] NOT NULL,
	[Rate_for_one_night_for_one_adult_NONAC] [int] NOT NULL,
 CONSTRAINT [PK_tblHotelDetails] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogin](
	[UserId] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[UserType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_tblLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 13-04-2020 17:52:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[TransactionID] [int] IDENTITY(20,1) NOT NULL,
	[Customer_ID] [nvarchar](10) NOT NULL,
	[Bank_ID] [char](10) NOT NULL,
	[Credit_card_Number] [bigint] NOT NULL,
	[Card_Type] [nvarchar](20) NOT NULL,
	[Name_on_Card] [nvarchar](20) NOT NULL,
	[Date_of_Transaction] [datetime] NOT NULL,
	[Expiry_Date] [nvarchar](10) NOT NULL,
	[CVV_Number] [int] NOT NULL,
	[Account_Number] [nvarchar](15) NOT NULL,
	[Pin_Number] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblBankDetails] ([Bank_ID], [Bank_Name]) VALUES (N'HDFC      ', N'HDFC Bank')
INSERT [dbo].[tblBankDetails] ([Bank_ID], [Bank_Name]) VALUES (N'ICICI     ', N'ICICI Bank')
INSERT [dbo].[tblBankDetails] ([Bank_ID], [Bank_Name]) VALUES (N'SBI       ', N'State Bank Of India')
SET IDENTITY_INSERT [dbo].[tblBooking] ON 

INSERT [dbo].[tblBooking] ([Booking_ID], [Customer_ID], [HotelID], [BookingDate], [ArrivalDate], [DepartureDate], [Number_of_Adults], [Number_of_Children], [Number_of_Nights], [Room_Type], [Number_of_Rooms]) VALUES (20, N'B1000', N'WOW1111', CAST(N'2020-04-02T21:15:26.127' AS DateTime), CAST(N'2020-04-04T00:00:00.000' AS DateTime), CAST(N'2020-04-08T00:00:00.000' AS DateTime), 3, 1, 4, N'AC', 3)
INSERT [dbo].[tblBooking] ([Booking_ID], [Customer_ID], [HotelID], [BookingDate], [ArrivalDate], [DepartureDate], [Number_of_Adults], [Number_of_Children], [Number_of_Nights], [Room_Type], [Number_of_Rooms]) VALUES (23, N'B1000', N'WOW1111', CAST(N'2020-04-03T12:52:11.357' AS DateTime), CAST(N'2020-04-04T00:00:00.000' AS DateTime), CAST(N'2020-04-10T00:00:00.000' AS DateTime), 2, 5, 4, N'AC', 4)
INSERT [dbo].[tblBooking] ([Booking_ID], [Customer_ID], [HotelID], [BookingDate], [ArrivalDate], [DepartureDate], [Number_of_Adults], [Number_of_Children], [Number_of_Nights], [Room_Type], [Number_of_Rooms]) VALUES (27, N'H1000', N'WOW1111', CAST(N'2020-04-04T00:00:00.000' AS DateTime), CAST(N'2020-04-05T00:00:00.000' AS DateTime), CAST(N'2020-08-04T00:00:00.000' AS DateTime), 2, 4, 2, N'AC', 4)
INSERT [dbo].[tblBooking] ([Booking_ID], [Customer_ID], [HotelID], [BookingDate], [ArrivalDate], [DepartureDate], [Number_of_Adults], [Number_of_Children], [Number_of_Nights], [Room_Type], [Number_of_Rooms]) VALUES (30, N'B1000', N'WOW5555', CAST(N'2020-04-06T00:41:14.043' AS DateTime), CAST(N'2020-04-07T00:00:00.000' AS DateTime), CAST(N'2020-04-10T00:00:00.000' AS DateTime), 2, 1, 3, N'AC', 2)
SET IDENTITY_INSERT [dbo].[tblBooking] OFF
INSERT [dbo].[tblCity] ([COUNTRY_ID], [CITY_NAME]) VALUES (N'001', N'Chennai')
INSERT [dbo].[tblCity] ([COUNTRY_ID], [CITY_NAME]) VALUES (N'002', N'Chicago')
INSERT [dbo].[tblCity] ([COUNTRY_ID], [CITY_NAME]) VALUES (N'001', N'Hyderabad')
INSERT [dbo].[tblCity] ([COUNTRY_ID], [CITY_NAME]) VALUES (N'001', N'Kolkata')
INSERT [dbo].[tblCity] ([COUNTRY_ID], [CITY_NAME]) VALUES (N'002', N'NewYork')
INSERT [dbo].[tblCountry] ([COUNTRY_ID], [COUNTRY_NAME]) VALUES (N'001', N'India')
INSERT [dbo].[tblCountry] ([COUNTRY_ID], [COUNTRY_NAME]) VALUES (N'002', N'USA')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'A1000', N'Avinash', CAST(N'2000-04-16T00:00:00.000' AS DateTime), 9440927055, N'devan355a@gmail.com', N'india', N'hyd', 895212, N'telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'B1000', N'Bhavin', CAST(N'1989-11-09T00:00:00.000' AS DateTime), 917494445445, N'bhavin20@gmail.com', N'India', N'Hyderabad', 926371, N'Telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'E1000', N'Eshwari', CAST(N'1993-12-01T00:00:00.000' AS DateTime), 919440927011, N'devana45@gmail.com', N'india', N'hyd', 895215, N'telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'G1000', N'Gayathri', CAST(N'1992-05-27T00:00:00.000' AS DateTime), 919494445445, N'gayathri12@gmail.com', N'india', N'kurnool', 515002, N'telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'H1000', N'Harishma', CAST(N'1994-09-01T00:00:00.000' AS DateTime), 919440927011, N'harishma45@gmail.com', N'India', N'Ananthapur', 515001, N'ap', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'H1001', N'Hari', CAST(N'1943-04-23T00:00:00.000' AS DateTime), 917440927011, N'hari45@gmail.com', N'India', N'Ananthapur', 515001, N'ap', N'senior citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'K1000', N'Kethan', CAST(N'1995-01-03T00:00:00.000' AS DateTime), 917494445449, N'kethu95@gmail.com', N'Australia', N'Bendigo', 999999, N'Victoria', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'P1000', N'Pratheek', CAST(N'1974-09-29T00:00:00.000' AS DateTime), 917678787878, N'pmallik74@gmail.com', N'Canada', N'Subcity', 734353, N'Waterloo', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'P1001', N'Priyanka', CAST(N'1997-04-16T00:00:00.000' AS DateTime), 919440927022, N'Priya@gmail.com', N'India', N'hyd', 500072, N'telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'R1002', N'Revaa', CAST(N'1960-04-24T00:00:00.000' AS DateTime), 9875632142, N'devan35a@gmail.com', N'india', N'atp', 456789, N'ap', N'senior citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'R1003', N'Revanth', CAST(N'1998-07-24T00:00:00.000' AS DateTime), 919440927011, N'devanaRev@gmail.com', N'India', N'Ananthapur', 515001, N'ap', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'S1000', N'Sakshi', CAST(N'1983-03-15T00:00:00.000' AS DateTime), 917676767622, N'sakku83@gmail.com', N'America', N'SanJose', 123125, N'California', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'S1001', N'Shourya', CAST(N'1997-06-30T00:00:00.000' AS DateTime), 917656565653, N'sgoenka97@gmail.com', N'India', N'Warangal', 999888, N'Telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'S1002', N'Santosh', CAST(N'1998-04-16T00:00:00.000' AS DateTime), 919440927011, N'santosh@gmail.com', N'India', N'Hyd', 515001, N'Telangana', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'T1000', N'Tapasya', CAST(N'1980-11-11T00:00:00.000' AS DateTime), 919292456789, N'tappu80@gmail.com', N'India', N'Vijayawada', 434343, N'Andhra', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'U1000', N'Uttej', CAST(N'1959-06-04T00:00:00.000' AS DateTime), 918499994456, N'uttej59@gmail.com', N'America', N'LosAngeles', 123123, N'California', N'senior citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'U1001', N'Urvasi', CAST(N'1978-12-18T00:00:00.000' AS DateTime), 918765432112, N'urvasi78@gmail.com', N'America', N'Sanfrancisco', 123124, N'California', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'Y1000', N'Yamini', CAST(N'1996-09-04T00:00:00.000' AS DateTime), 919494335335, N'yamini45@gmail.com', N'America', N'Dallas', 516471, N'Texas', N'normal citizen')
INSERT [dbo].[tblCustomer] ([Customer_ID], [CustomerName], [DateOfBirth], [ContactNumber], [EmailAddress], [Country], [City], [PinCode], [State], [CustomerType]) VALUES (N'Z1000', N'Zakir', CAST(N'1993-02-02T00:00:00.000' AS DateTime), 919848232819, N'khanzak93@gmail.com', N'India', N'Kurnool', 444444, N'Telangana', N'normal citizen')
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW1111', N'wowhotelus', N'America', N'New York', N'food at its best and great hospitality', 233, 190, 2200, 3200, 1957, 2100)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW1112', N'wowhotelatp', N'India', N'Hyderabad', N'famous for spicy food', 220, 210, 2500, 3000, 1500, 2200)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW1234', N'wowhotelhyd', N'India', N'Hyderabad', N'great view and hospitality', 200, 149, 2500, 3200, 1500, 2150)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW1236', N'wowhotelker', N'India', N'Allepey', N'Good for its sea food', 201, 150, 2500, 3800, 1650, 2350)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW1447', N'wowhotelbris', N'UK', N'Bristol', N'Great FOOD', 150, 100, 2500, 2700, 1000, 2500)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW3333', N'wowhotelcan', N'Canada', N'Ontario', N'Luxurious Rooms and
famous for its chinese food', 260, 175, 2140, 3950, 1450, 2340)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW5555', N'wowhotelukman', N'UK', N'Manchester', N'Luxurious Rooms,Great Hospitality and free Wi-fi with free breakfast for 5 days.', 285, 196, 2435, 3400, 1885, 2400)
INSERT [dbo].[tblHotelDetails] ([HotelID], [Hotel_Name], [Country], [City], [Hotel_Description], [Number_of_AC_Rooms], [Number_of_Non_AC_Rooms], [Rate_for_one_night_for_one_children_AC], [Rate_for_one_night_for_one_adult_AC], [Rate_for_one_night_for_one_children_NONAC], [Rate_for_one_night_for_one_adult_NONAC]) VALUES (N'WOW9444', N'wowhotelkol', N'India', N'Chennai', N'best sea food', 150, 148, 2200, 2504, 1200, 2000)
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'A0001', N'xyz', N'Admin')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'A1000', N'Pizza@1234', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'B1000', N'Pizza@456', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'E1000', N'Qwerty@45', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'G1000', N'Qscqaz@678', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'H1000', N'Qscqaz@123', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'H1001', N'Qscqaz@456', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'K1000', N'Burger@123', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'P1000', N'Paneer@#*4', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'P1001', N'Pizza@456', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'R1002', N'Gobi@123', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'R1003', N'Pizza@456', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'S1000', N'Roadie*765', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'S1001', N'Momos@#12', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'S1002', N'Pizza@456', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'T1000', N'Rummy#675', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'U1000', N'Gulab#590', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'U1001', N'Sandman@56', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'Y1000', N'Region@123', N'Customer')
INSERT [dbo].[tblLogin] ([UserId], [Password], [UserType]) VALUES (N'Z1000', N'Anuasd*123', N'Customer')
SET IDENTITY_INSERT [dbo].[tblPayment] ON 

INSERT [dbo].[tblPayment] ([TransactionID], [Customer_ID], [Bank_ID], [Credit_card_Number], [Card_Type], [Name_on_Card], [Date_of_Transaction], [Expiry_Date], [CVV_Number], [Account_Number], [Pin_Number], [Amount]) VALUES (23, N'B1000', N'SBI       ', 9874563217894561, N'Visa', N'Revanth', CAST(N'2020-04-03T12:50:47.827' AS DateTime), N'02/22', 489, N'0087451277', 456398, 17400)
INSERT [dbo].[tblPayment] ([TransactionID], [Customer_ID], [Bank_ID], [Credit_card_Number], [Card_Type], [Name_on_Card], [Date_of_Transaction], [Expiry_Date], [CVV_Number], [Account_Number], [Pin_Number], [Amount]) VALUES (27, N'H1000', N'ICICI     ', 8965478965478569, N'Master', N'Harsihma', CAST(N'2020-04-04T00:00:00.000' AS DateTime), N'07/23', 654, N'0012345678', 987987, 10000)
INSERT [dbo].[tblPayment] ([TransactionID], [Customer_ID], [Bank_ID], [Credit_card_Number], [Card_Type], [Name_on_Card], [Date_of_Transaction], [Expiry_Date], [CVV_Number], [Account_Number], [Pin_Number], [Amount]) VALUES (30, N'B1000', N'ICICI     ', 1234567890123456, N'master', N'reddy', CAST(N'2020-04-06T00:40:21.940' AS DateTime), N'08/24', 765, N'0012345678', 765432, 9235)
SET IDENTITY_INSERT [dbo].[tblPayment] OFF
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblCustomer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[tblCustomer] ([Customer_ID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblCustomer]
GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblHotelDetails] FOREIGN KEY([HotelID])
REFERENCES [dbo].[tblHotelDetails] ([HotelID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblHotelDetails]
GO
ALTER TABLE [dbo].[tblCity]  WITH CHECK ADD  CONSTRAINT [FK_tblCity_tblCountry] FOREIGN KEY([COUNTRY_ID])
REFERENCES [dbo].[tblCountry] ([COUNTRY_ID])
GO
ALTER TABLE [dbo].[tblCity] CHECK CONSTRAINT [FK_tblCity_tblCountry]
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblPayment_tblBankDetails] FOREIGN KEY([Bank_ID])
REFERENCES [dbo].[tblBankDetails] ([Bank_ID])
GO
ALTER TABLE [dbo].[tblPayment] CHECK CONSTRAINT [FK_tblPayment_tblBankDetails]
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblPayment_tblCustomer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[tblCustomer] ([Customer_ID])
GO
ALTER TABLE [dbo].[tblPayment] CHECK CONSTRAINT [FK_tblPayment_tblCustomer]
GO
/****** Object:  StoredProcedure [dbo].[Proc1]    Script Date: 13-04-2020 17:52:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Proc1]
@CustomerName nvarchar(15)
 as 
 begin
select top 1 Customer_ID from tblCustomer where substring( Customer_ID,0,2)=substring(@CustomerName,0,2) 
order by Customer_ID desc

 

end
GO
USE [master]
GO
ALTER DATABASE [Team-1] SET  READ_WRITE 
GO
