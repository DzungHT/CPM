SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DzungHT
-- Create date: 17th Nov 2017
-- Description:	Thủ tục lấy quyền của user
-- =============================================
IF EXISTS (SELECT p.name FROM sys.procedures p WHERE p.name = 'sp_GetUserPermission')
	DROP PROC sp_GetUserPermission

GO
CREATE PROCEDURE sp_GetUserPermission 
	@userID int,
	@applicationCode nvarchar(50)
AS
BEGIN
	SELECT DISTINCT p.Code FROM UserRole ur
	INNER JOIN RolePermission rp ON ur.RoleID = rp.RoleID
	INNER JOIN Permission p ON p.PermissionID = rp.PermissionID
	INNER JOIN Resource r ON r.ResourceID = p.ResourceID
	INNER JOIN Application app ON r.ApplicationID = app.ApplicationID
	WHERE 
		ur.UserID = @userID
		AND app.Code = @applicationCode
END
GO
