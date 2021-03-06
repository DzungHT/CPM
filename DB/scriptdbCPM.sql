USE [CPM]
GO
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [FK_USER_ROLE_DATA_USER_ROLE]
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
ALTER TABLE [dbo].[UserRoleData] DROP CONSTRAINT [DF__USER_ROLE__IS_DE__2B3F6F97]
GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [DF__USER_ROLE__IS_AC__29572725]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [DF__ROLE_MENU__IS_AC__21B6055D]
GO
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [DF__MENU__STATUS__1BFD2C07]
GO
ALTER TABLE [dbo].[DomainData] DROP CONSTRAINT [DF__DOMAIN_DA__IS_AC__173876EA]
GO
/****** Object:  Table [dbo].[UserRoleData]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[UserRoleData]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[UserRole]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[RolePermission]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[RoleMenu]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Resource]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Permission]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Operation]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Menu]
GO
/****** Object:  Table [dbo].[DomainType]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[DomainType]
GO
/****** Object:  Table [dbo].[DomainData]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[DomainData]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[Application]
GO
/****** Object:  Table [dbo].[AppDomainType]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[AppDomainType]
GO
/****** Object:  Table [dbo].[ActionLog]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP TABLE [dbo].[ActionLog]
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuByAccount]    Script Date: 9/22/2017 9:23:23 AM ******/
DROP PROCEDURE [dbo].[spGetMenuByAccount]
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuByAccount]    Script Date: 9/22/2017 9:23:23 AM ******/
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
/****** Object:  Table [dbo].[ActionLog]    Script Date: 9/22/2017 9:23:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionLog](
	[ActionLogID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[ActionTime] [date] NULL,
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
PRIMARY KEY CLUSTERED 
(
	[ActionLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppDomainType]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppDomainType](
	[DomainTypeID] [int] NOT NULL,
	[ApplicationID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Application]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Password] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DomainData]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[DomainType]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NULL,
	[Sort_Order] [int] NULL,
	[Path] [nvarchar](100) NULL,
	[FullPart] [nvarchar](1000) NULL,
	[ApplicationID] [int] NULL,
	[NewID] [int] NULL,
	[Status] [int] NULL,
	[Key] [int] NULL,
	[MenuCss] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operation]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[Resource]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[NewID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 9/22/2017 9:23:24 AM ******/
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
/****** Object:  Table [dbo].[RolePermission]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[PermissionID] [int] NOT NULL,
	[RoleID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NULL,
	[FullName] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
	[EmployeeCode] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[NewID] [int] NULL,
	[ChangePasswordDate] [date] NULL,
	[NeedChangePassword] [int] NULL,
	[EncryptedPassword] [nvarchar](200) NULL,
	[ActiveCode] [nvarchar](100) NULL,
	[RequestDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NULL,
	[RoleID] [int] NULL,
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoleData]    Script Date: 9/22/2017 9:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleData](
	[UserRoleID] [int] NOT NULL,
	[DomainDataID] [int] NOT NULL,
	[IsDefault] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (1, N'admin', N'DoanVuongDang', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, N'doanvd@gmail.com', N'0961793995', 1, NULL, NULL, NULL, NULL, N'1', NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (2, N'test', N'DoanVuongDang', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (3, N'doantest', N'sssss', N'zgv9FQWbaNZ2iIhNej0+jA==', N'avc', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[DomainData] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[RoleMenu] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRole] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoleData] ADD  DEFAULT ((0)) FOR [IsDefault]
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
ALTER TABLE [dbo].[UserRoleData]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLE_DATA_USER_ROLE] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[UserRole] ([UserRoleID])
GO
ALTER TABLE [dbo].[UserRoleData] CHECK CONSTRAINT [FK_USER_ROLE_DATA_USER_ROLE]
GO
