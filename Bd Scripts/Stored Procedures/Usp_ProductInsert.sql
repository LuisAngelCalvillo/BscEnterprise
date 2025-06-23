USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_ProductInsert]

@ProductKey VARCHAR(MAX),
@Name VARCHAR(MAX),
@Stock INT,
@IsActive BIT
AS

BEGIN
	SET NOCOUNT ON;

	DECLARE @Result INT = -1;

	INSERT INTO [dbo].[Tb_Product]
	(
		ProductKey,
		[Name],
		Stock,
		[IsActive]
	)
	VALUES
	(
		@ProductKey,
		@Name,
		@Stock,
		@IsActive
	)

	SET @Result = SCOPE_IDENTITY()
	SELECT @Result;
END