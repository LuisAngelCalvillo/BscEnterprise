CREATE NONCLUSTERED INDEX IX01_Tb_Role_Name ON Tb_Role([Name] ASC);
CREATE NONCLUSTERED INDEX IX01_Tb_Permission_Name ON Tb_Permission([Name] ASC);
CREATE NONCLUSTERED INDEX IX01_Tb_User_Email ON Tb_User(Email ASC);
CREATE NONCLUSTERED INDEX IX01_Tb_Product_ProductKey ON Tb_Product(ProductKey ASC);
CREATE NONCLUSTERED INDEX IX02_Tb_Product_Name ON Tb_Product([Name] ASC);
CREATE NONCLUSTERED INDEX IX01_Tb_Order_OrderNumber ON Tb_Order([OrderNumber] ASC);
CREATE NONCLUSTERED INDEX IX01_Tb_DetailOrder_Product ON Tb_DetailOrder(ProductId ASC);
CREATE NONCLUSTERED INDEX IX02_Tb_DetailOrder_Order ON Tb_DetailOrder(OrderId ASC);