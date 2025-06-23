ALTER VIEW vw_GetProduct
AS
SELECT 
	p.IdProduct,
	p.ProductKey, 
	p.[Name], 
	p.Stock
FROM     
	[dbo].[Tb_Product] p
WHERE
	p.IsActive = 1