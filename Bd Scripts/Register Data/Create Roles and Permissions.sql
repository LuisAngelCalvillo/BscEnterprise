INSERT INTO [dbo].[Tb_Role] ([Name],[IsActive]) VALUES ('Administrador', 1);
INSERT INTO [dbo].[Tb_Role] ([Name],[IsActive]) VALUES ('Personal', 1);
INSERT INTO [dbo].[Tb_Role] ([Name],[IsActive]) VALUES ('Vendedor', 1);

INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('User.Create', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('User.View', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('User.Update', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('User.Delete', 1);

INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Product.Create', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Product.View', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Product.Update', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Product.Delete', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Product.Report', 1);

INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Order.Create', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Order.View', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Order.Update', 1);
INSERT INTO [dbo].[Tb_Permission] ([Name], [IsActive]) VALUES ('Order.Delete', 1);

--Permisos para administrador
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (1, 1);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (1, 2);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (1, 3);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (1, 4);

--Permisos para Personal
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 5);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 6);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 7);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 8);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 9);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (2, 11);

--Permisos para Vendedor
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (3, 6);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (3, 10);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (3, 11);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (3, 12);
INSERT INTO [dbo].[Tb_RolePermission] ([RoleId], [PermissionId]) VALUES (3, 13);

SELECT* FROM Tb_Permission