USE [CPM]
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuByAccount]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[ActionLog]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[AppDomainType]    Script Date: 10/12/2017 10:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppDomainType](
	[DomainTypeID] [int] NOT NULL,
	[ApplicationID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Application]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[DomainData]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[DomainType]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[OAuthAccessToken]    Script Date: 10/12/2017 10:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthAccessToken](
	[TokenId] [nvarchar](50) NULL,
	[Token] [nvarchar](100) NULL,
	[AuthenticationId] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[ClientId] [nvarchar](50) NULL,
	[Authentication] [nvarchar](50) NULL,
	[RefreshToken] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OAuthClientDetails]    Script Date: 10/12/2017 10:22:32 PM ******/
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
	[RefreshTokenValidity] [int] NULL,
 CONSTRAINT [PK_AuthClientDetails] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OAuthDetails]    Script Date: 10/12/2017 10:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthDetails](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ClientId] [nvarchar](50) NOT NULL,
	[IpAccess] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OAuthRefreshToken]    Script Date: 10/12/2017 10:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAuthRefreshToken](
	[TokenId] [nvarchar](50) NULL,
	[Token] [nvarchar](50) NULL,
	[Authentication] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operation]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[Resource]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[RolePermission]    Script Date: 10/12/2017 10:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[PermissionID] [int] NOT NULL,
	[RoleID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/12/2017 10:22:32 PM ******/
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
/****** Object:  Table [dbo].[UserRoleData]    Script Date: 10/12/2017 10:22:32 PM ******/
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
INSERT [dbo].[OAuthAccessToken] ([TokenId], [Token], [AuthenticationId], [UserName], [ClientId], [Authentication], [RefreshToken]) VALUES (NULL, N'(BLOB)', NULL, N'cpm', N'cpm-client-id', NULL, NULL)
INSERT [dbo].[OAuthClientDetails] ([ClientId], [ResourceIds], [ClientSecret], [Scope], [GrantTypes], [WebServerRedirectUri], [Authorities], [AccessTokenValidity], [RefreshTokenValidity]) VALUES (N'cpm-client-id', N'rest_api', N'123456', N'trust,read,write', N'password,authorization_code,refresh_token,implicit', NULL, N'ROLE_ADMINISTRATOR', 100000, 100000)
INSERT [dbo].[OAuthDetails] ([UserName], [Password], [ClientId], [IpAccess]) VALUES (N'cpm', N'123456', N'cpm-client-id', N'192.*')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (1, N'admin', N'DoanVuongDang', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, N'doanvd@gmail.com', N'0961793995', 1, NULL, NULL, NULL, NULL, N'1', NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (2, N'test', N'DoanVuongDang', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (3, N'doantest', N'sssss', N'zgv9FQWbaNZ2iIhNej0+jA==', N'avc', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (1002, N'doanvd', NULL, N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserID], [LoginName], [FullName], [Password], [EmployeeCode], [Email], [PhoneNumber], [Status], [NewID], [ChangePasswordDate], [NeedChangePassword], [EncryptedPassword], [ActiveCode], [RequestDate]) VALUES (1003, N'admin', N'doanvd test update', N'zgv9FQWbaNZ2iIhNej0+jA==', NULL, N'doanvd@gmail.com', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[DomainData] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  DEFAULT (NULL) FOR [TokenId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  DEFAULT (NULL) FOR [AuthenticationId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  DEFAULT (NULL) FOR [UserName]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  DEFAULT (NULL) FOR [ClientId]
GO
ALTER TABLE [dbo].[OAuthAccessToken] ADD  DEFAULT (NULL) FOR [RefreshToken]
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
ALTER TABLE [dbo].[OAuthRefreshToken] ADD  DEFAULT (NULL) FOR [TokenId]
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
ALTER TABLE [dbo].[OAuthDetails]  WITH CHECK ADD  CONSTRAINT [FK_OAuthDetails_OAuthClientDetails] FOREIGN KEY([ClientId])
REFERENCES [dbo].[OAuthClientDetails] ([ClientId])
GO
ALTER TABLE [dbo].[OAuthDetails] CHECK CONSTRAINT [FK_OAuthDetails_OAuthClientDetails]
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
