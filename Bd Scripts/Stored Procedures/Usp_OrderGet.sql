USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_OrderGet]
AS

BEGIN
	SELECT
		IdOrder,
		OrderNumber,
		CustomerName,
		[Date]
	FROM
		[dbo].[vw_GetOrder]
END