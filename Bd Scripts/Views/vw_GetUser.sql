ALTER VIEW vw_GetUser
AS
SELECT 
	u.IdUser,
	u.Email, 
	u.[Name], 
	u.LastName, 
	u.[Password],
	r.[Name] AS RoleName, 
	u.RoleId
FROM     
	[dbo].[Tb_User] AS u
INNER JOIN
    dbo.Tb_Role AS r
ON 
	r.IdRole = u.RoleId
WHERE
	u.IsActive = 1