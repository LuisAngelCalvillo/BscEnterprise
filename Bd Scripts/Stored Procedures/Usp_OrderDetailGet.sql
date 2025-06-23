USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_OrderDetailGet]

@OrderId INT

AS

BEGIN
	SELECT
		IdDetailOrder,
		Quantity,
		ProductId,
		IdOrder,
		ProductKey,
		[Name]
	FROM
		[dbo].[vw_GetDetailOrder]
	WHERE
		IdOrder = @OrderId
END