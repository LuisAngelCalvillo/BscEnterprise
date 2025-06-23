ALTER VIEW vw_GetPermission
AS	

SELECT
	p.IdPermission,
	p.[Name] AS PermissionName,
	r.IdRole,
	r.[Name] AS RoleName,
	u.IdUser
FROM
	[dbo].[Tb_Permission] p
INNER JOIN
	[dbo].[Tb_RolePermission] rp
ON 
	rp.PermissionId = p.IdPermission
INNER JOIN
	[dbo].[Tb_Role] r
ON
	r.IdRole = rp.RoleId
INNER JOIN
	[dbo].[Tb_User] u
ON
	u.RoleId = r.IdRole
WHERE
	p.IsActive = 1