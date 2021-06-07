USE [Modulo3_BBDD]
GO

INSERT INTO [dbo].[PRODUCTO]
           ([NOMBRE]
           ,[PRECIO_COMPRA]
           ,[PRECIO_VENTA]
           ,[ID_CATEGORIA])
     VALUES
           ('Leche',50.06,93.35,1)
GO

INSERT INTO [dbo].[PRODUCTO]
           ([NOMBRE]
           ,[PRECIO_COMPRA]
           ,[PRECIO_VENTA]
           ,[ID_CATEGORIA])
     VALUES
           ('Lavarropa',35900,53500,2)
GO

INSERT INTO [dbo].[PRODUCTO]
           ([NOMBRE]
           ,[PRECIO_COMPRA]
           ,[PRECIO_VENTA]
           ,[ID_CATEGORIA])
     VALUES
           ('Lavandina',66.50,85.80,3)
GO

INSERT INTO [dbo].[PRODUCTO]
           ([NOMBRE]
           ,[PRECIO_COMPRA]
           ,[PRECIO_VENTA]
           ,[ID_CATEGORIA])
     VALUES
           ('Vino',240.15,460.20,4)
GO

INSERT INTO [dbo].[PRODUCTO]
           ([NOMBRE]
           ,[PRECIO_COMPRA]
           ,[PRECIO_VENTA]
           ,[ID_CATEGORIA])
     VALUES
           ('Gaseosa',61.70,80.35,5)
GO

SELECT* FROM P
