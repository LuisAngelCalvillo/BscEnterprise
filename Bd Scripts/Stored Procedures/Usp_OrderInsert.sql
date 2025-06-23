USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE dbo.[Usp_OrderInsert]
	@OrderNumber VARCHAR(100),
    @CustomerName VARCHAR(100),
	@Date DATETIME,
    @Items dbo.OrderItemType READONLY
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @Result INT = -1;
    DECLARE @NewOrderId INT;

	IF NOT EXISTS (
        SELECT 
			1
        FROM 
			@Items oi
        INNER JOIN 
			[Tb_Product] p 
		ON 
			p.IdProduct = oi.ProductId
        WHERE 
			p.Stock < oi.Quantity
    )
	BEGIN
		INSERT INTO Tb_Order 
		(
			OrderNumber, 
			CustomerName, 
			[Date]
		)
		VALUES 
		(
			@OrderNumber, 
			@CustomerName, 
			@Date
		);

		SET @NewOrderId = SCOPE_IDENTITY();

		INSERT INTO Tb_DetailOrder 
		(
			Quantity, 
			ProductId, 
			OrderId
		)
		SELECT 
			Quantity, 
			ProductId, 
			@NewOrderId
		FROM @Items;
	END

    SET @Result = @NewOrderId;
	SELECT @Result;
END