USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_UserInsert]

@Email VARCHAR (320),
@Name VARCHAR(MAX),
@LastName VARCHAR(MAX),
@Password VARCHAR(100),
@IsActive BIT,
@RoleId INT

AS

BEGIN
	SET NOCOUNT ON;
	DECLARE @Result INT = -1;

	INSERT INTO [dbo].[Tb_User]
	(
		[Email],
		[Name],
		[LastName],
		[Password],
		[IsActive],
		[RoleId]
	)
	VALUES
	(
		@Email,
		@Name,
		@LastName,
		@Password,
		@IsActive,
		@RoleId
	)

	SET @Result = SCOPE_IDENTITY();
	SELECT @Result;
END