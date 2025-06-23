ALTER VIEW vw_GetDetailOrder
AS
SELECT 
	oi.IdDetailOrder,
	oi.Quantity,
	oi.ProductId,
	o.IdOrder,
	p.ProductKey,
	p.[Name]
FROM     
	[dbo].[Tb_DetailOrder] AS oi
INNER JOIN
	[dbo].[Tb_Order] AS o
ON	
	o.IdOrder = oi.OrderId
INNER JOIN 
	[dbo].[Tb_Product] p
ON
	p.IdProduct = oi.ProductId