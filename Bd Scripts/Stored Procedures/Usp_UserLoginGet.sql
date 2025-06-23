USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_UserLoginGet]

@Email VARCHAR (320)

AS

BEGIN
	SELECT
		IdUser,
		Email,
		[Name],
		LastName,
		[Password],
		RoleName
	FROM
		[dbo].[vw_GetUser]
	WHERE
		Email = @Email
END