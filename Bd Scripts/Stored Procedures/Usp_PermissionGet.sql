USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_PermissionGet]

@UserId INT

AS

BEGIN
	SELECT
		PermissionName
	FROM
		vw_GetPermission
	WHERE
		IdUser = @UserId
END