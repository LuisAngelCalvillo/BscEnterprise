USE [bsc-enterprise-dev]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tr_Product_UpdateStock]
ON [dbo].[Tb_CartItem]

AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE 
		p
	SET 
		Stock = (Stock - inserted.Quantity)
	FROM 
		Tb_Product p
	INNER JOIN 
		inserted 
	ON 
		p.IdProduct = inserted.ProductId
END;