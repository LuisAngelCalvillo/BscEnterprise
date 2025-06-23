ALTER VIEW vw_GetOrder
AS
SELECT 
	o.IdOrder,
	o.OrderNumber,
	o.CustomerName,
	o.[Date]
FROM     
	[dbo].[Tb_Order] AS o