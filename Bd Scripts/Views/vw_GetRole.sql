CREATE VIEW vw_GetRole
AS
SELECT 
	r.IdRole,
	r.[Name]
FROM     
	[dbo].[Tb_Role] r