/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2012 (11.0.2100)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [CPM]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RequestDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ActiveCode'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'FullName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ChangePasswordTime'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'NeedChangePassword'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Sort_Order'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'MenuPID'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'HostClientAdress'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'IPClientAdress'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'ActionType'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'ActionTime'
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuByAccount]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP PROCEDURE [dbo].[spGetMenuByAccount]
GO
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [FK_UserRoleData_User]
GO
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [FK_UserRoleData_Role]
GO
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [FK_USER_ROLE_DATA_DOMAIN_DATA]
GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_USER_ROLE_USER]
GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_USER_ROLE_ROLE]
GO
ALTER TABLE [dbo].[RolePermission] DROP CONSTRAINT [FK_ROLE_PERMISSION_ROLE]
GO
ALTER TABLE [dbo].[RolePermission] DROP CONSTRAINT [FK_ROLE_PERMISSION_PERMISSION]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_ROLE_MENU_ROLE]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_ROLE_MENU_MENU]
GO
ALTER TABLE [dbo].[Resource] DROP CONSTRAINT [FK_RESOURCE_APPLICATION]
GO
ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_PERMISSION_RESOURCE]
GO
ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_PERMISSION_OPERATION]
GO
ALTER TABLE [dbo].[OAuthRefreshToken] DROP CONSTRAINT [FK_OAuthRefreshToken_OAuthAccessToken]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [FK_OAuthClientDetails_OAuthDetails]
GO
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [FK_MENU_APPLICATION]
GO
ALTER TABLE [dbo].[DomainData] DROP CONSTRAINT [FK_DOMAIN_DATA_DOMAIN_TYPE]
GO
ALTER TABLE [dbo].[AppDomainType] DROP CONSTRAINT [FK_APP_DOMAIN_TYPE_DOMAIN_TYPE]
GO
ALTER TABLE [dbo].[AppDomainType] DROP CONSTRAINT [FK_APP_DOMAIN_TYPE_APPLICATION]
GO
ALTER TABLE [dbo].[ActionLog] DROP CONSTRAINT [FK_ACTION_LOG_USER]
GO
ALTER TABLE [dbo].[ActionLog] DROP CONSTRAINT [FK_ACTION_LOG_ROLE]
GO
ALTER TABLE [dbo].[ActionLog] DROP CONSTRAINT [FK_ACTION_LOG_PERMISSION]
GO
ALTER TABLE [dbo].[ActionLog] DROP CONSTRAINT [FK_ACTION_LOG_DOMAIN_DATA]
GO
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [DF__UserRoleD__IsDef__412EB0B6]
GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [DF__UserRole__IsActi__403A8C7D]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [DF__RoleMenu__IsActi__3F466844]
GO
ALTER TABLE [dbo].[OAuthRefreshToken] DROP CONSTRAINT [DF__OauthRefr__Token__6C190EBB]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Refre__3D5E1FD2]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Acces__3C69FB99]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Autho__3B75D760]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__WebSe__3A81B327]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Grant__398D8EEE]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Scope__38996AB5]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Clien__37A5467C]
GO
ALTER TABLE [dbo].[OAuthClientDetails] DROP CONSTRAINT [DF__OAuthClie__Resou__36B12243]
GO
ALTER TABLE [dbo].[OAuthAccessToken] DROP CONSTRAINT [DF__OauthAcce__Refre__6A30C649]
GO
ALTER TABLE [dbo].[OAuthAccessToken] DROP CONSTRAINT [DF__OauthAcce__Clien__693CA210]
GO
ALTER TABLE [dbo].[OAuthAccessToken] DROP CONSTRAINT [DF__OauthAcce__UserN__68487DD7]
GO
ALTER TABLE [dbo].[OAuthAccessToken] DROP CONSTRAINT [DF__OauthAcce__Authe__6754599E]
GO
ALTER TABLE [dbo].[OAuthAccessToken] DROP CONSTRAINT [DF__OauthAcce__Token__66603565]
GO
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [DF__Menu__Status__30F848ED]
GO
ALTER TABLE [dbo].[DomainData] DROP CONSTRAINT [DF__DomainDat__IsAct__300424B4]
GO
/****** Object:  Table [dbo].[UserRoleData]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[UserRoleData]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[UserRole]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Tokens]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[RolePermission]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[RoleMenu]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Resource]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Permission]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Operation]
GO
/****** Object:  Table [dbo].[OAuthRefreshToken]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[OAuthRefreshToken]
GO
/****** Object:  Table [dbo].[OAuthDetails]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[OAuthDetails]
GO
/****** Object:  Table [dbo].[OAuthClientDetails]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[OAuthClientDetails]
GO
/****** Object:  Table [dbo].[OAuthAccessToken]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[OAuthAccessToken]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Menu]
GO
/****** Object:  Table [dbo].[DomainType]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[DomainType]
GO
/****** Object:  Table [dbo].[DomainData]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[DomainData]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[Application]
GO
/****** Object:  Table [dbo].[AppDomainType]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[AppDomainType]
GO
/****** Object:  Table [dbo].[ActionLog]    Script Date: 11/14/2017 1:59:13 AM ******/
DROP TABLE [dbo].[ActionLog]
GO
/****** Object:  Table [dbo].[ActionLog]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionLog](
	[ActionLogID] [int] IDENTITY(1,1) NOT NULL,
	[ActionTime] [datetime] NULL,
	[ActionType] [nvarchar](250) NULL,
	[IPClientAdress] [nvarchar](50) NULL,
	[HostClientAdress] [nvarchar](50) NULL,
	[ServerUrl] [nvarchar](250) NULL,
	[Status] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[UserID] [int] NULL,
	[RoleID] [int] NULL,
	[PermissionID] [int] NULL,
	[DomainDataID] [int] NULL,
 CONSTRAINT [PK__ActionLo__428D61A2344651E2] PRIMARY KEY CLUSTERED 
(
	[ActionLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppDomainType]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppDomainType](
	[DomainTypeID] [int] NOT NULL,
	[ApplicationID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomainData]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainData](
	[DomainDataID] [int] IDENTITY(1,1) NOT NULL,
	[DataID] [int] NULL,
	[DataCode] [nvarchar](50) NULL,
	[DataName] [nvarchar](200) NULL,
	[ParentID] [int] NULL,
	[Path] [nvarchar](100) NULL,
	[FullPath] [nvarchar](1000) NULL,
	[Status] [int] NULL,
	[DomainTypeID] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[PathLevel] [int] NULL,
	[IsActive] [int] NULL,
	[MarketCompanyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DomainDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomainType]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainType](
	[DomainTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DomainTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuPID] [int] NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [varchar](500) NULL,
	[Sort_Order] [int] NULL,
	[Path] [varchar](100) NULL,
	[ApplicationID] [int] NULL,
	[Status] [int] NULL,
	[FontIcon] [varchar](50) NULL,
 CONSTRAINT [PK__Menu__C99ED25094B132D1] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAuthAccessToken]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthAccessToken](
	[TokenId] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](50) NULL,
	[AuthenticationId] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[ClientId] [nvarchar](50) NOT NULL,
	[Authentication] [nvarchar](50) NULL,
	[RefreshToken] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OAuthAccessToken] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAuthClientDetails]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthClientDetails](
	[ClientId] [nvarchar](50) NOT NULL,
	[ResourceIds] [nvarchar](50) NULL,
	[ClientSecret] [nvarchar](50) NULL,
	[Scope] [nvarchar](50) NULL,
	[GrantTypes] [nvarchar](50) NULL,
	[WebServerRedirectUri] [nvarchar](50) NULL,
	[Authorities] [nvarchar](50) NULL,
	[AccessTokenValidity] [int] NULL,
	[RefreshTokenValidity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAuthDetails]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthDetails](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ClientId] [nvarchar](50) NOT NULL,
	[IpAccess] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OAuthDetails] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAuthRefreshToken]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthRefreshToken](
	[TokenId] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](50) NULL,
	[Authentication] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[OperationID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[OperationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceID] [int] NULL,
	[OperationID] [int] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[ResourceID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[ApplicationID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenu](
	[MenuID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[IsActive] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[PermissionID] [int] NOT NULL,
	[RoleID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AuthToken] [nvarchar](250) NOT NULL,
	[IssuesOn] [datetime] NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
	[NeedChangePassword] [bit] NULL,
	[ChangePasswordTime] [datetime] NULL,
	[FullName] [nvarchar](200) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](100) NULL,
	[Status] [int] NULL,
	[ActiveCode] [nvarchar](100) NULL,
	[RequestDate] [datetime] NULL,
 CONSTRAINT [PK__User__1788CCAC6551A650] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleData]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleData](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[DomainDataID] [int] NOT NULL,
	[IsDefault] [int] NULL,
 CONSTRAINT [PK_UserRoleData] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC,
	[DomainDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OAuthClientDetails] ([ClientId], [ResourceIds], [ClientSecret], [Scope], [GrantTypes], [WebServerRedirectUri], [Authorities], [AccessTokenValidity], [RefreshTokenValidity]) VALUES (N'cpm-client-id', N'rest_api', N'123456', N'trust,read,write', N'password,authorization_code,refresh_token,implicit', NULL, N'ROLE_ADMINISTRATOR', 100000, 100000)
INSERT [dbo].[OAuthDetails] ([UserName], [Password], [ClientId], [IpAccess]) VALUES (N'cpm', N'123456', N'cpm-client-id', N'192.*')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (1, N'admin', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, N'DoanVuongDang', N'doanvd@gmail.com', N'0961793995', 1, N'1', NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (2, N'test', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, N'DoanVuongDang', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (3, N'doantest', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, N'sssss', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (1002, N'doanvd', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (1003, N'admin', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, N'doanvd test update', N'doanvd@gmail.com', NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (1004, N'admin123', N'admin123', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [Password], [NeedChangePassword], [ChangePasswordTime], [FullName], [Email], [PhoneNumber], [Status], [ActiveCode], [RequestDate]) VALUES (1005, N'admin321', N'admin123', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[DomainData] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF__Menu__Status__30F848ED]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  CONSTRAINT [DF__OauthAcce__Token__66603565]  DEFAULT (NULL) FOR [TokenId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  CONSTRAINT [DF__OauthAcce__Authe__6754599E]  DEFAULT (NULL) FOR [AuthenticationId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  CONSTRAINT [DF__OauthAcce__UserN__68487DD7]  DEFAULT (NULL) FOR [UserName]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  CONSTRAINT [DF__OauthAcce__Clien__693CA210]  DEFAULT (NULL) FOR [ClientId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  CONSTRAINT [DF__OauthAcce__Refre__6A30C649]  DEFAULT (NULL) FOR [RefreshToken]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [ResourceIds]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [ClientSecret]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [Scope]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [GrantTypes]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [WebServerRedirectUri]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [Authorities]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [AccessTokenValidity]
GO
ALTER TABLE [dbo].[OAuthClientDetails] ADD  DEFAULT (NULL) FOR [RefreshTokenValidity]
GO
ALTER TABLE [dbo].[OAuthRefreshToken] ADD  CONSTRAINT [DF__OauthRefr__Token__6C190EBB]  DEFAULT (NULL) FOR [TokenId]
GO
ALTER TABLE [dbo].[RoleMenu] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF__UserRole__IsActi__403A8C7D]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoleData] ADD  CONSTRAINT [DF__UserRoleD__IsDef__412EB0B6]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[ActionLog]  WITH CHECK ADD  CONSTRAINT [FK_ACTION_LOG_DOMAIN_DATA] FOREIGN KEY([DomainDataID])
REFERENCES [dbo].[DomainData] ([DomainDataID])
GO
ALTER TABLE [dbo].[ActionLog] CHECK CONSTRAINT [FK_ACTION_LOG_DOMAIN_DATA]
GO
ALTER TABLE [dbo].[ActionLog]  WITH CHECK ADD  CONSTRAINT [FK_ACTION_LOG_PERMISSION] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[ActionLog] CHECK CONSTRAINT [FK_ACTION_LOG_PERMISSION]
GO
ALTER TABLE [dbo].[ActionLog]  WITH CHECK ADD  CONSTRAINT [FK_ACTION_LOG_ROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[ActionLog] CHECK CONSTRAINT [FK_ACTION_LOG_ROLE]
GO
ALTER TABLE [dbo].[ActionLog]  WITH CHECK ADD  CONSTRAINT [FK_ACTION_LOG_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ActionLog] CHECK CONSTRAINT [FK_ACTION_LOG_USER]
GO
ALTER TABLE [dbo].[AppDomainType]  WITH CHECK ADD  CONSTRAINT [FK_APP_DOMAIN_TYPE_APPLICATION] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Application] ([ApplicationID])
GO
ALTER TABLE [dbo].[AppDomainType] CHECK CONSTRAINT [FK_APP_DOMAIN_TYPE_APPLICATION]
GO
ALTER TABLE [dbo].[AppDomainType]  WITH CHECK ADD  CONSTRAINT [FK_APP_DOMAIN_TYPE_DOMAIN_TYPE] FOREIGN KEY([DomainTypeID])
REFERENCES [dbo].[DomainType] ([DomainTypeID])
GO
ALTER TABLE [dbo].[AppDomainType] CHECK CONSTRAINT [FK_APP_DOMAIN_TYPE_DOMAIN_TYPE]
GO
ALTER TABLE [dbo].[DomainData]  WITH CHECK ADD  CONSTRAINT [FK_DOMAIN_DATA_DOMAIN_TYPE] FOREIGN KEY([DomainTypeID])
REFERENCES [dbo].[DomainType] ([DomainTypeID])
GO
ALTER TABLE [dbo].[DomainData] CHECK CONSTRAINT [FK_DOMAIN_DATA_DOMAIN_TYPE]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_MENU_APPLICATION] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Application] ([ApplicationID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_MENU_APPLICATION]
GO
ALTER TABLE [dbo].[OAuthClientDetails]  WITH CHECK ADD  CONSTRAINT [FK_OAuthClientDetails_OAuthDetails] FOREIGN KEY([ClientId])
REFERENCES [dbo].[OAuthDetails] ([ClientId])
GO
ALTER TABLE [dbo].[OAuthClientDetails] CHECK CONSTRAINT [FK_OAuthClientDetails_OAuthDetails]
GO
ALTER TABLE [dbo].[OAuthRefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_OAuthRefreshToken_OAuthAccessToken] FOREIGN KEY([TokenId])
REFERENCES [dbo].[OAuthAccessToken] ([TokenId])
GO
ALTER TABLE [dbo].[OAuthRefreshToken] CHECK CONSTRAINT [FK_OAuthRefreshToken_OAuthAccessToken]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_PERMISSION_OPERATION] FOREIGN KEY([OperationID])
REFERENCES [dbo].[Operation] ([OperationID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_PERMISSION_OPERATION]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_PERMISSION_RESOURCE] FOREIGN KEY([ResourceID])
REFERENCES [dbo].[Resource] ([ResourceID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_PERMISSION_RESOURCE]
GO
ALTER TABLE [dbo].[Resource]  WITH CHECK ADD  CONSTRAINT [FK_RESOURCE_APPLICATION] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Application] ([ApplicationID])
GO
ALTER TABLE [dbo].[Resource] CHECK CONSTRAINT [FK_RESOURCE_APPLICATION]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_ROLE_MENU_MENU] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_ROLE_MENU_MENU]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_ROLE_MENU_ROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_ROLE_MENU_ROLE]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_ROLE_PERMISSION_PERMISSION] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_ROLE_PERMISSION_PERMISSION]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_ROLE_PERMISSION_ROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_ROLE_PERMISSION_ROLE]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLE_ROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_USER_ROLE_ROLE]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLE_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_USER_ROLE_USER]
GO
ALTER TABLE [dbo].[UserRoleData]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLE_DATA_DOMAIN_DATA] FOREIGN KEY([DomainDataID])
REFERENCES [dbo].[DomainData] ([DomainDataID])
GO
ALTER TABLE [dbo].[UserRoleData] CHECK CONSTRAINT [FK_USER_ROLE_DATA_DOMAIN_DATA]
GO
ALTER TABLE [dbo].[UserRoleData]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleData_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoleData] CHECK CONSTRAINT [FK_UserRoleData_Role]
GO
ALTER TABLE [dbo].[UserRoleData]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleData_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserRoleData] CHECK CONSTRAINT [FK_UserRoleData_User]
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuByAccount]    Script Date: 11/14/2017 1:59:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetMenuByAccount]
	@AccountID int
AS
BEGIN
SELECT m.* 
FROM Menu m
WHERE m.MenuID in (
	SELECT rl.MenuID FROM RoleMenu rl
	INNER JOIN UserRole ur on ur.RoleID = rl.RoleID and ur.UserID = @AccountID
	WHERE (rl.IsActive is null or rl.IsActive = 1) AND (ur.IsActive is null or ur.IsActive = 1)
)
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Thời gian tác động' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'ActionTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại tác động' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'ActionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP của Client' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'IPClientAdress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP Host' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'HostClientAdress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng thái' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mô tả' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActionLog', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID menu cha' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'MenuPID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mã menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mô tả' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ĐƯờng dẫn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vị trí sắp xếp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Sort_Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Đường dẫn menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng thái của menu: 0: inactive, 1: active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mã tác động' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mô tả' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bảng tác động' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên đăng nhập' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mật khẩu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cần đổi mật khẩu?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'NeedChangePassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày, giờ đổi mật khẩu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ChangePasswordTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên đầy đủ của user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'FullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Địa chỉ email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số điện thoại' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng thái: 0 = inactive; 1 = active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mã active user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ActiveCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ngày request' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RequestDate'
GO
