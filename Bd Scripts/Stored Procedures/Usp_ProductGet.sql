USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_ProductGet]
AS

BEGIN
	SELECT
		IdProduct,
		ProductKey,
		[Name],
		Stock
	FROM
		vw_GetProduct
END