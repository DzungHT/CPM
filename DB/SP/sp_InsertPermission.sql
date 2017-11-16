SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DzungHT
-- Create date: 17th Nov, 2017
-- Description:	Thủ tục thêm mới Permission
-- =============================================
IF EXISTS (SELECT p.name FROM sys.procedures p WHERE p.name = 'sp_InsertPermission')
	DROP PROC sp_InsertPermission

GO

CREATE PROCEDURE sp_InsertPermission 
	@resourceID int, 
	@operationID int,
	@name nvarchar(500)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Permission
			SELECT 
				@resourceID as ResourceID,
				@operationID as OperationID,
				CONCAT( (SELECT o.Code FROM Operation o WHERE o.OperationID = @operationID) , '_', (SELECT r.Code FROM Resource r WHERE r.ResourceID = @resourceID) ) as CODE,
				@name

			INSERT INTO RolePermission
			SELECT
				0 as RoleID,
				p.PermissionID
			FROM Permission p
			WHERE
				NOT EXISTS (SELECT * FROM RolePermission rp WHERE rp.PermissionID = p.PermissionID)
				
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH	

END
GO
