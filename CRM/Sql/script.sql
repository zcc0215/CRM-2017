USE [master]
GO
/****** Object:  Database [test]    Script Date: 2017/10/27 13:56:42 ******/
CREATE DATABASE [test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\test_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test] SET ARITHABORT OFF 
GO
ALTER DATABASE [test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test] SET RECOVERY FULL 
GO
ALTER DATABASE [test] SET  MULTI_USER 
GO
ALTER DATABASE [test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [test] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'test', N'ON'
GO
USE [test]
GO
/****** Object:  Schema [HangFire]    Script Date: 2017/10/27 13:56:42 ******/
CREATE SCHEMA [HangFire]
GO
/****** Object:  Table [dbo].[ActivityAssignManage]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityAssignManage](
	[aaId] [int] IDENTITY(1,1) NOT NULL,
	[aafkamId] [int] NULL,
	[aaName] [nvarchar](50) NULL,
	[aaBudget] [numeric](18, 2) NULL,
	[aafkRole] [int] NULL,
	[aaResult] [int] NULL,
	[aaRemark] [nvarchar](50) NULL,
	[aaBeginTime] [datetime] NULL,
	[aaEndTime] [datetime] NULL,
 CONSTRAINT [PK_ActivityAssignManage] PRIMARY KEY CLUSTERED 
(
	[aaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityManage]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityManage](
	[amId] [int] IDENTITY(1,1) NOT NULL,
	[amName] [nvarchar](50) NULL,
	[amfkRole] [int] NULL,
	[amBudget] [numeric](18, 2) NULL,
	[amResult] [int] NULL,
	[amBeginTime] [datetime] NULL,
	[amEndTime] [datetime] NULL,
 CONSTRAINT [PK_ActivityManage] PRIMARY KEY CLUSTERED 
(
	[amId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusiChance]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusiChance](
	[bcId] [int] IDENTITY(1,1) NOT NULL,
	[bcfkspId] [int] NULL,
	[bcName] [nvarchar](50) NULL,
 CONSTRAINT [PK_BusiChance] PRIMARY KEY CLUSTERED 
(
	[bcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClueManage]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClueManage](
	[cmId] [int] IDENTITY(1,1) NOT NULL,
	[cmCustomerName] [nvarchar](50) NULL,
	[cmPhone] [nvarchar](50) NULL,
	[cmEmail] [nvarchar](50) NULL,
	[cmBeginTime] [nvarchar](50) NULL,
	[cmEndTime] [nvarchar](50) NULL,
	[cmfkRole] [int] NULL,
 CONSTRAINT [PK_ClueManage] PRIMARY KEY CLUSTERED 
(
	[cmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContractManage]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractManage](
	[cmId] [int] IDENTITY(1,1) NOT NULL,
	[cmfkomId] [int] NULL,
	[cmName] [nchar](10) NULL,
 CONSTRAINT [PK_ContractManage] PRIMARY KEY CLUSTERED 
(
	[cmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMUser]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMUser](
	[uId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ufkDepart] [int] NULL,
	[ufkRole] [int] NULL,
 CONSTRAINT [PK_CRMUser] PRIMARY KEY CLUSTERED 
(
	[uId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Depart]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depart](
	[hrdId] [int] IDENTITY(1,1) NOT NULL,
	[hrdDepartName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Depart] PRIMARY KEY CLUSTERED 
(
	[hrdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderManage]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderManage](
	[omId] [int] IDENTITY(1,1) NOT NULL,
	[omfkbcId] [int] NULL,
	[omName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderManage] PRIMARY KEY CLUSTERED 
(
	[omId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[rId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[RoleButtons] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[rId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleButton]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleButton](
	[rbId] [int] IDENTITY(1,1) NOT NULL,
	[rbName] [nvarchar](50) NULL,
	[rbHref] [nvarchar](50) NULL,
	[rbHrefName] [nvarchar](50) NULL,
	[rbCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_RoleButton] PRIMARY KEY CLUSTERED 
(
	[rbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleProject]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleProject](
	[spId] [int] IDENTITY(1,1) NOT NULL,
	[spfkRole] [int] NULL,
	[spfkamId] [int] NULL,
	[spfktcId] [int] NULL,
	[spName] [nvarchar](50) NULL,
	[spBeginTime] [datetime] NULL,
	[spEndTime] [datetime] NULL,
 CONSTRAINT [PK_SaleProject] PRIMARY KEY CLUSTERED 
(
	[spId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[sId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[sId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TargetCustomers]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetCustomers](
	[tcId] [int] IDENTITY(1,1) NOT NULL,
	[tcfkamId] [int] NULL,
	[tcName] [nvarchar](50) NULL,
	[tcSex] [nvarchar](50) NULL,
	[tcPhone] [nvarchar](50) NULL,
	[tcEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_TargetCustomers] PRIMARY KEY CLUSTERED 
(
	[tcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[AggregatedCounter]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[AggregatedCounter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [bigint] NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_CounterAggregated] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Counter]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Counter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [smallint] NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_Counter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Hash]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Hash](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Field] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ExpireAt] [datetime2](7) NULL,
 CONSTRAINT [PK_HangFire_Hash] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Job]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Job](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NULL,
	[StateName] [nvarchar](20) NULL,
	[InvocationData] [nvarchar](max) NOT NULL,
	[Arguments] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_Job] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[JobParameter]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[JobParameter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangFire_JobParameter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[JobQueue]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[JobQueue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[Queue] [nvarchar](50) NOT NULL,
	[FetchedAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_JobQueue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[List]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[List](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_List] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Schema]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Schema](
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_HangFire_Schema] PRIMARY KEY CLUSTERED 
(
	[Version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Server]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Server](
	[Id] [nvarchar](100) NOT NULL,
	[Data] [nvarchar](max) NULL,
	[LastHeartbeat] [datetime] NOT NULL,
 CONSTRAINT [PK_HangFire_Server] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[Set]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Set](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Score] [float] NOT NULL,
	[Value] [nvarchar](256) NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_Set] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HangFire].[State]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Reason] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Data] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangFire_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ActivityAssignManage] ON 

INSERT [dbo].[ActivityAssignManage] ([aaId], [aafkamId], [aaName], [aaBudget], [aafkRole], [aaResult], [aaRemark], [aaBeginTime], [aaEndTime]) VALUES (1, 1, N'租用场地', CAST(100.00 AS Numeric(18, 2)), 2, 0, N'联系校办', CAST(N'2017-08-30 00:00:00.000' AS DateTime), CAST(N'2017-08-31 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ActivityAssignManage] OFF
SET IDENTITY_INSERT [dbo].[ActivityManage] ON 

INSERT [dbo].[ActivityManage] ([amId], [amName], [amfkRole], [amBudget], [amResult], [amBeginTime], [amEndTime]) VALUES (1, N'校园活动', 2, CAST(2000.00 AS Numeric(18, 2)), 2, CAST(N'2017-08-28 04:20:00.000' AS DateTime), CAST(N'2017-08-31 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ActivityManage] OFF
SET IDENTITY_INSERT [dbo].[BusiChance] ON 

INSERT [dbo].[BusiChance] ([bcId], [bcfkspId], [bcName]) VALUES (1, 1, N'苏宁展台促销')
SET IDENTITY_INSERT [dbo].[BusiChance] OFF
SET IDENTITY_INSERT [dbo].[ClueManage] ON 

INSERT [dbo].[ClueManage] ([cmId], [cmCustomerName], [cmPhone], [cmEmail], [cmBeginTime], [cmEndTime], [cmfkRole]) VALUES (4, N'微软', N'110', N'1@qq.com', N'2017/1/1 0:00:00', N'2017/1/2 0:00:00', 2)
SET IDENTITY_INSERT [dbo].[ClueManage] OFF
SET IDENTITY_INSERT [dbo].[ContractManage] ON 

INSERT [dbo].[ContractManage] ([cmId], [cmfkomId], [cmName]) VALUES (1, 1, N' 苏宁销售     ')
SET IDENTITY_INSERT [dbo].[ContractManage] OFF
SET IDENTITY_INSERT [dbo].[CRMUser] ON 

INSERT [dbo].[CRMUser] ([uId], [Username], [Password], [ufkDepart], [ufkRole]) VALUES (1, N'admin', N'e10adc3949ba59abbe56e057f20f883e', 1, 2)
INSERT [dbo].[CRMUser] ([uId], [Username], [Password], [ufkDepart], [ufkRole]) VALUES (4, N'张三', N'e10adc3949ba59abbe56e057f20f883e', 2, 2)
SET IDENTITY_INSERT [dbo].[CRMUser] OFF
SET IDENTITY_INSERT [dbo].[Depart] ON 

INSERT [dbo].[Depart] ([hrdId], [hrdDepartName]) VALUES (1, N'市场部')
INSERT [dbo].[Depart] ([hrdId], [hrdDepartName]) VALUES (2, N'销售部')
SET IDENTITY_INSERT [dbo].[Depart] OFF
SET IDENTITY_INSERT [dbo].[OrderManage] ON 

INSERT [dbo].[OrderManage] ([omId], [omfkbcId], [omName]) VALUES (1, 1, N'苏宁促销商品')
SET IDENTITY_INSERT [dbo].[OrderManage] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([rId], [RoleName], [RoleButtons]) VALUES (2, N'总经理', N'1')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleButton] ON 

INSERT [dbo].[RoleButton] ([rbId], [rbName], [rbHref], [rbHrefName], [rbCode]) VALUES (1, N'导出', N'/Export/BusiAnalysis', N'业务分析', N'Export')
INSERT [dbo].[RoleButton] ([rbId], [rbName], [rbHref], [rbHrefName], [rbCode]) VALUES (4, N'导入', N'/Import/BusiAnalysis', N'导入', N'Import')
SET IDENTITY_INSERT [dbo].[RoleButton] OFF
SET IDENTITY_INSERT [dbo].[SaleProject] ON 

INSERT [dbo].[SaleProject] ([spId], [spfkRole], [spfkamId], [spfktcId], [spName], [spBeginTime], [spEndTime]) VALUES (1, 2, 1, 41, N'苏宁展台', CAST(N'2017-09-21 00:00:00.000' AS DateTime), CAST(N'2017-09-22 00:00:00.000' AS DateTime))
INSERT [dbo].[SaleProject] ([spId], [spfkRole], [spfkamId], [spfktcId], [spName], [spBeginTime], [spEndTime]) VALUES (6, 2, 1, 41, N'百脑汇展台', CAST(N'2017-09-21 00:00:00.000' AS DateTime), CAST(N'2017-09-23 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[SaleProject] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([sId], [Name], [Age]) VALUES (1, N'张三', N'22')
INSERT [dbo].[Student] ([sId], [Name], [Age]) VALUES (6, N'李四', N'21')
INSERT [dbo].[Student] ([sId], [Name], [Age]) VALUES (44, N'王五', N'23')
INSERT [dbo].[Student] ([sId], [Name], [Age]) VALUES (49, N'赵六', N'24')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[TargetCustomers] ON 

INSERT [dbo].[TargetCustomers] ([tcId], [tcfkamId], [tcName], [tcSex], [tcPhone], [tcEmail]) VALUES (41, 1, N'张三', N'男', N'15822530215', N'zcc0215@gmail.com')
INSERT [dbo].[TargetCustomers] ([tcId], [tcfkamId], [tcName], [tcSex], [tcPhone], [tcEmail]) VALUES (42, 1, N'王五', N'男', N'123', N'zcc0215@hotmail.com')
SET IDENTITY_INSERT [dbo].[TargetCustomers] OFF
SET IDENTITY_INSERT [HangFire].[AggregatedCounter] ON 

INSERT [HangFire].[AggregatedCounter] ([Id], [Key], [Value], [ExpireAt]) VALUES (1, N'stats:succeeded', 2, NULL)
INSERT [HangFire].[AggregatedCounter] ([Id], [Key], [Value], [ExpireAt]) VALUES (2, N'stats:succeeded:2017-09-06', 4, CAST(N'2017-10-06 08:09:25.470' AS DateTime))
INSERT [HangFire].[AggregatedCounter] ([Id], [Key], [Value], [ExpireAt]) VALUES (3, N'stats:succeeded:2017-09-06-07', 1, CAST(N'2017-09-07 07:59:44.283' AS DateTime))
INSERT [HangFire].[AggregatedCounter] ([Id], [Key], [Value], [ExpireAt]) VALUES (4, N'stats:succeeded:2017-09-06-08', 3, CAST(N'2017-09-07 08:09:25.493' AS DateTime))
SET IDENTITY_INSERT [HangFire].[AggregatedCounter] OFF
SET IDENTITY_INSERT [HangFire].[Job] ON 

INSERT [HangFire].[Job] ([Id], [StateId], [StateName], [InvocationData], [Arguments], [CreatedAt], [ExpireAt]) VALUES (1, 9, N'Succeeded', N'{"Type":"BLL.CommonBLL, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null","Method":"BulkAdd","ParameterTypes":"[\"System.Data.DataTable, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"]","Arguments":"[\"[{\\\"cmCustomerName\\\":\\\"微软\\\",\\\"cmPhone\\\":\\\"110\\\",\\\"cmEmail\\\":\\\"1@qq.com\\\",\\\"cmBeginTime\\\":\\\"2017/1/1 0:00:00\\\",\\\"cmEndTime\\\":\\\"2017/1/2 0:00:00\\\"}]\"]"}', N'["[{\"cmCustomerName\":\"微软\",\"cmPhone\":\"110\",\"cmEmail\":\"1@qq.com\",\"cmBeginTime\":\"2017/1/1 0:00:00\",\"cmEndTime\":\"2017/1/2 0:00:00\"}]"]', CAST(N'2017-09-06 07:59:43.860' AS DateTime), CAST(N'2017-09-07 08:02:44.790' AS DateTime))
INSERT [HangFire].[Job] ([Id], [StateId], [StateName], [InvocationData], [Arguments], [CreatedAt], [ExpireAt]) VALUES (2, 12, N'Succeeded', N'{"Type":"BLL.testBLL, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null","Method":"addStudent","ParameterTypes":"[\"Model.Student, Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\"]","Arguments":"[\"{\\\"sId\\\":null,\\\"Name\\\":\\\"张三1\\\",\\\"Age\\\":\\\"22\\\"}\"]"}', N'["{\"sId\":null,\"Name\":\"张三1\",\"Age\":\"22\"}"]', CAST(N'2017-09-06 08:09:25.007' AS DateTime), CAST(N'2017-09-07 08:09:25.587' AS DateTime))
SET IDENTITY_INSERT [HangFire].[Job] OFF
SET IDENTITY_INSERT [HangFire].[JobParameter] ON 

INSERT [HangFire].[JobParameter] ([Id], [JobId], [Name], [Value]) VALUES (1, 1, N'CurrentCulture', N'"zh-CN"')
INSERT [HangFire].[JobParameter] ([Id], [JobId], [Name], [Value]) VALUES (2, 1, N'CurrentUICulture', N'"zh-CN"')
INSERT [HangFire].[JobParameter] ([Id], [JobId], [Name], [Value]) VALUES (3, 2, N'CurrentCulture', N'"zh-CN"')
INSERT [HangFire].[JobParameter] ([Id], [JobId], [Name], [Value]) VALUES (4, 2, N'CurrentUICulture', N'"zh-CN"')
SET IDENTITY_INSERT [HangFire].[JobParameter] OFF
INSERT [HangFire].[Schema] ([Version]) VALUES (5)
INSERT [HangFire].[Server] ([Id], [Data], [LastHeartbeat]) VALUES (N'zcc-pc:7012:c67579b3-ed72-46b9-8560-ed74dec59a87', N'{"WorkerCount":20,"Queues":["default"],"StartedAt":"2017-09-07T00:15:33.0012471Z"}', CAST(N'2017-09-07 00:15:33.207' AS DateTime))
SET IDENTITY_INSERT [HangFire].[State] ON 

INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (1, 1, N'Enqueued', NULL, CAST(N'2017-09-06 07:59:43.950' AS DateTime), N'{"EnqueuedAt":"2017-09-06T07:59:43.8276881Z","Queue":"default"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (2, 1, N'Processing', NULL, CAST(N'2017-09-06 07:59:44.147' AS DateTime), N'{"StartedAt":"2017-09-06T07:59:44.0597014Z","ServerId":"zcc-pc:8540:7601f8f6-f0cf-4a10-b091-17add8fe7a8f","WorkerId":"8cb817d4-616c-48d8-bacb-8ca7bd3280dc"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (3, 1, N'Succeeded', NULL, CAST(N'2017-09-06 07:59:44.293' AS DateTime), N'{"SucceededAt":"2017-09-06T07:59:44.2387117Z","PerformanceDuration":"62","Latency":"316","Result":"false"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (4, 1, N'Enqueued', N'Triggered via Dashboard UI', CAST(N'2017-09-06 08:02:04.450' AS DateTime), N'{"EnqueuedAt":"2017-09-06T08:02:04.4097290Z","Queue":"default"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (5, 1, N'Processing', NULL, CAST(N'2017-09-06 08:02:04.530' AS DateTime), N'{"StartedAt":"2017-09-06T08:02:04.4897336Z","ServerId":"zcc-pc:8540:7601f8f6-f0cf-4a10-b091-17add8fe7a8f","WorkerId":"5b9c640a-c5e7-473a-abd0-c448d6588f4f"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (6, 1, N'Succeeded', NULL, CAST(N'2017-09-06 08:02:04.673' AS DateTime), N'{"SucceededAt":"2017-09-06T08:02:04.6327417Z","PerformanceDuration":"39","Latency":"140732","Result":"false"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (7, 1, N'Enqueued', N'Triggered via Dashboard UI', CAST(N'2017-09-06 08:02:44.527' AS DateTime), N'{"EnqueuedAt":"2017-09-06T08:02:44.4930216Z","Queue":"default"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (8, 1, N'Processing', NULL, CAST(N'2017-09-06 08:02:44.607' AS DateTime), N'{"StartedAt":"2017-09-06T08:02:44.5630256Z","ServerId":"zcc-pc:8540:7601f8f6-f0cf-4a10-b091-17add8fe7a8f","WorkerId":"c2fcf2e7-050c-4a05-85e5-7bb7e6510889"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (9, 1, N'Succeeded', NULL, CAST(N'2017-09-06 08:02:44.773' AS DateTime), N'{"SucceededAt":"2017-09-06T08:02:44.7040337Z","PerformanceDuration":"37","Latency":"180807","Result":"false"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (10, 2, N'Enqueued', NULL, CAST(N'2017-09-06 08:09:25.070' AS DateTime), N'{"EnqueuedAt":"2017-09-06T08:09:24.9829283Z","Queue":"default"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (11, 2, N'Processing', NULL, CAST(N'2017-09-06 08:09:25.260' AS DateTime), N'{"StartedAt":"2017-09-06T08:09:25.1519380Z","ServerId":"zcc-pc:6116:23465e74-e671-467c-bcfd-06a46530601e","WorkerId":"771f4a77-257a-4df9-bce2-9d95a8ae5d02"}')
INSERT [HangFire].[State] ([Id], [JobId], [Name], [Reason], [CreatedAt], [Data]) VALUES (12, 2, N'Succeeded', NULL, CAST(N'2017-09-06 08:09:25.520' AS DateTime), N'{"SucceededAt":"2017-09-06T08:09:25.4199533Z","PerformanceDuration":"88","Latency":"324","Result":"true"}')
SET IDENTITY_INSERT [HangFire].[State] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_HangFire_CounterAggregated_Key]    Script Date: 2017/10/27 13:56:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_HangFire_CounterAggregated_Key] ON [HangFire].[AggregatedCounter]
(
	[Key] ASC
)
INCLUDE ( 	[Value]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_Counter_Key]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Counter_Key] ON [HangFire].[Counter]
(
	[Key] ASC
)
INCLUDE ( 	[Value]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HangFire_Hash_ExpireAt]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Hash_ExpireAt] ON [HangFire].[Hash]
(
	[ExpireAt] ASC
)
INCLUDE ( 	[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_Hash_Key]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Hash_Key] ON [HangFire].[Hash]
(
	[Key] ASC
)
INCLUDE ( 	[ExpireAt]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_HangFire_Hash_Key_Field]    Script Date: 2017/10/27 13:56:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_HangFire_Hash_Key_Field] ON [HangFire].[Hash]
(
	[Key] ASC,
	[Field] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HangFire_Job_ExpireAt]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Job_ExpireAt] ON [HangFire].[Job]
(
	[ExpireAt] ASC
)
INCLUDE ( 	[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_Job_StateName]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Job_StateName] ON [HangFire].[Job]
(
	[StateName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_JobParameter_JobIdAndName]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_JobParameter_JobIdAndName] ON [HangFire].[JobParameter]
(
	[JobId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_JobQueue_QueueAndFetchedAt]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_JobQueue_QueueAndFetchedAt] ON [HangFire].[JobQueue]
(
	[Queue] ASC,
	[FetchedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HangFire_List_ExpireAt]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_List_ExpireAt] ON [HangFire].[List]
(
	[ExpireAt] ASC
)
INCLUDE ( 	[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_List_Key]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_List_Key] ON [HangFire].[List]
(
	[Key] ASC
)
INCLUDE ( 	[ExpireAt],
	[Value]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HangFire_Set_ExpireAt]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Set_ExpireAt] ON [HangFire].[Set]
(
	[ExpireAt] ASC
)
INCLUDE ( 	[Id]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_HangFire_Set_Key]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_Set_Key] ON [HangFire].[Set]
(
	[Key] ASC
)
INCLUDE ( 	[ExpireAt],
	[Value]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_HangFire_Set_KeyAndValue]    Script Date: 2017/10/27 13:56:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_HangFire_Set_KeyAndValue] ON [HangFire].[Set]
(
	[Key] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HangFire_State_JobId]    Script Date: 2017/10/27 13:56:42 ******/
CREATE NONCLUSTERED INDEX [IX_HangFire_State_JobId] ON [HangFire].[State]
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [HangFire].[JobParameter]  WITH CHECK ADD  CONSTRAINT [FK_HangFire_JobParameter_Job] FOREIGN KEY([JobId])
REFERENCES [HangFire].[Job] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [HangFire].[JobParameter] CHECK CONSTRAINT [FK_HangFire_JobParameter_Job]
GO
ALTER TABLE [HangFire].[State]  WITH CHECK ADD  CONSTRAINT [FK_HangFire_State_Job] FOREIGN KEY([JobId])
REFERENCES [HangFire].[Job] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [HangFire].[State] CHECK CONSTRAINT [FK_HangFire_State_Job]
GO
/****** Object:  StoredProcedure [dbo].[P_BusiChance]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_BusiChance] 
    @bcType nvarchar(50)='insert',
	@bcId int =null,
	@bcfkspId int =null,
	@bcName nvarchar(50)=null
    
AS
BEGIN
     if @bcType='insert'
	 begin
     insert into BusiChance values(@bcfkspId,null)
	 end
	 else if @bcType='update'
	 begin
	 update BusiChance set bcName=@bcName where bcId = @bcId
	 end
END


GO
/****** Object:  StoredProcedure [dbo].[p_db_wsp]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
CREATE PROC [dbo].[p_db_wsp]
    @dbname VARCHAR(50) ,   --数据库名  
    @path VARCHAR(100) ,    --实体类所在目录名，如D:/My/Models  
    @namespace VARCHAR(50) --实体类命名空间,默认值为Models  
AS --判断数据库是否存在  
    IF ( DB_ID(@dbname) IS NOT NULL )
        BEGIN  
            IF ( ISNULL(@namespace, '') = '' )
                SET @namespace = 'Models';  
-- 允许配置高级选项  
            EXEC sp_configure 'show advanced options', 1;  
-- 重新配置  
            RECONFIGURE;  
-- 启用Ole Automation Procedures   
            EXEC sp_configure 'Ole Automation Procedures', 1;  
-- 启用xp_cmdshell,可以向磁盘中写入文件  
            EXEC sp_configure 'xp_cmdshell', 1;  
-- 重新配置  
            RECONFIGURE;  
            DECLARE @dbsql VARCHAR(1000) ,
                @tablename VARCHAR(100);  
            SET @dbsql = 'declare wsp cursor for select name from ' + @dbname
                + '..sysobjects where xtype=''u''  and name <>''sysdiagrams''';  
            EXEC(@dbsql);  
            OPEN wsp;  
            FETCH wsp INTO @tablename;--使用游标循环遍历数据库中每个表  
            WHILE ( @@fetch_status = 0 )
                BEGIN  
--根据表中字段组合实体类中的字段和属性  
                    DECLARE @nsql NVARCHAR(4000) ,
                        @sql VARCHAR(8000);  
                    SET @nsql = 'select @s=isnull(@s+char(9),''using System;'
                        + CHAR(13) + 'using System.Collections.Generic;'
                        + CHAR(13) + 'using System.Text;' + CHAR(13)
                        + 'namespace ' + @namespace + CHAR(13) + '{' + CHAR(13)
                        + CHAR(9) + 'public class ' + @tablename + CHAR(13)
                        + '{''+char(13)+char(9))+  char(13)+char(9)+''public ''+  
case when a.name in(''image'',''uniqueidentifier'',''ntext'',''varchar'',''ntext'',''nchar'',''nvarchar'',''text'',''char'') then ''string''  
when a.name in(''tinyint'',''smallint'',''int'') then ''int?''  
when a.name=''bigint'' then ''long''  
when a.name in(''datetime'',''smalldatetime'') then ''DateTime?''  
when a.name in(''float'',''decimal'',''numeric'',''money'',''real'',''smallmoney'') then ''decimal''  
when a.name =''bit'' then ''bool''  
else a.name end  
+'' ''+b.name+'' ''+''{get;set;}''+char(13)  
from ' + @dbname + '..syscolumns b,  
(select distinct name,xtype from ' + @dbname + '..systypes where status=0) a  
where a.xtype=b.xtype and b.id=object_id(''' + @dbname + '..' + @tablename
                        + ''')';  
                    EXEC sp_executesql @nsql, N'@s varchar(8000) output',
                        @sql OUTPUT;  
                    SET @sql = @sql + CHAR(9) + '}' + CHAR(13) + '}';  
--print @sql  
                    DECLARE @err INT ,
                        @fso INT ,
                        @fleExists BIT ,
                        @file VARCHAR(100);  
                    SET @file = @path + '/' + @tablename + '.cs';  
                    EXEC @err= sp_OACreate 'Scripting.FileSystemObject',
                        @fso OUTPUT;  
                    EXEC @err= sp_OAMethod @fso, 'FileExists',
                        @fleExists OUTPUT, @file;  
                    EXEC @err = sp_OADestroy @fso;  
   
                    IF @fleExists != 0
                        EXEC('exec xp_cmdshell ''del '+@file+''''); --存在则删除  
                    EXEC('exec xp_cmdshell ''echo '+@sql+' > '+@file+''''); --将文本写进文件中  
                    SET @sql = NULL;  
                    FETCH wsp INTO @tablename;  
                END;  
            CLOSE wsp;  
            DEALLOCATE wsp;  
            PRINT '生成成功！';  
        END;  
    ELSE
        PRINT '数据库不存在！';
GO
/****** Object:  StoredProcedure [dbo].[P_Student]    Script Date: 2017/10/27 13:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_Student] 
　　@Name nvarchar(50) ='张三',
　　@Age int = 22
    --@return int out
AS
BEGIN
	--SELECT * from Student where Name=@Name and Age=@Age
	insert into Student values('赵六','24')
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aafkamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务责任人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aafkRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaBeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAssignManage', @level2type=N'COLUMN',@level2name=N'aaEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动管理主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指派角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amfkRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amBeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityManage', @level2type=N'COLUMN',@level2name=N'amEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务机会主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BusiChance', @level2type=N'COLUMN',@level2name=N'bcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联销售计划' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BusiChance', @level2type=N'COLUMN',@level2name=N'bcfkspId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务机会名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BusiChance', @level2type=N'COLUMN',@level2name=N'bcName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmCustomerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'意向开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmBeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'意向结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分配角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClueManage', @level2type=N'COLUMN',@level2name=N'cmfkRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同管理主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContractManage', @level2type=N'COLUMN',@level2name=N'cmId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContractManage', @level2type=N'COLUMN',@level2name=N'cmfkomId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContractManage', @level2type=N'COLUMN',@level2name=N'cmName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CRMUser', @level2type=N'COLUMN',@level2name=N'uId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CRMUser', @level2type=N'COLUMN',@level2name=N'Username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CRMUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CRMUser', @level2type=N'COLUMN',@level2name=N'ufkDepart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CRMUser', @level2type=N'COLUMN',@level2name=N'ufkRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Depart', @level2type=N'COLUMN',@level2name=N'hrdId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Depart', @level2type=N'COLUMN',@level2name=N'hrdDepartName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单管理主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderManage', @level2type=N'COLUMN',@level2name=N'omId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联业务机会' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderManage', @level2type=N'COLUMN',@level2name=N'omfkbcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderManage', @level2type=N'COLUMN',@level2name=N'omName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'rId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'责任人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'具有权限的按钮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleButtons'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleButton', @level2type=N'COLUMN',@level2name=N'rbId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleButton', @level2type=N'COLUMN',@level2name=N'rbName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮方法地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleButton', @level2type=N'COLUMN',@level2name=N'rbHref'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮显示名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleButton', @level2type=N'COLUMN',@level2name=N'rbHrefName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleButton', @level2type=N'COLUMN',@level2name=N'rbCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售计划主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'责任人角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spfkRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联市场活动' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spfkamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spfktcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售计划名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售计划起始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spBeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售计划结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SaleProject', @level2type=N'COLUMN',@level2name=N'spEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'sId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student', @level2type=N'COLUMN',@level2name=N'Age'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标客户主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联活动' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcfkamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcSex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TargetCustomers', @level2type=N'COLUMN',@level2name=N'tcEmail'
GO
USE [master]
GO
ALTER DATABASE [test] SET  READ_WRITE 
GO
