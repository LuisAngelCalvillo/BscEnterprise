USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_RoleGet]
AS

BEGIN
	SELECT
		IdRole,
		[Name]
	FROM
		vw_GetRole
END