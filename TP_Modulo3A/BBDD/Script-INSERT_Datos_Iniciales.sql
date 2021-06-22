USE [dbTecProg]
GO

INSERT INTO [dbo].[categoria]
       ([descripcion]
       ,[habilitado])
     VALUES
          ('Bebida sin alcohol'
          ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Bebida con alcohol'
           ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Electrodomesticos'
           ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Almacen'
           ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Carniceria'
           ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Limpieza'
           ,null)
GO
INSERT INTO [dbo].[categoria]
           ([descripcion]
           ,[habilitado])
     VALUES
           ('Golosinas'
           ,null)
GO

INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Gaseosa'
           ,80
           ,90
           ,1)
GO

INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Vino'
           ,110
           ,150
           ,2)
GO


INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Ventilador'
           ,1200
           ,1800
           ,3)
GO

INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Pan'
           ,75
           ,120
           ,4)
GO


INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Paleta'
           ,450
           ,600
           ,5)
GO

INSERT INTO [dbo].[producto]
           ([nombre]
           ,[precio_compra]
           ,[precio_venta]
           ,[id_categoria])
     VALUES
           ('Lavandina'
           ,55
           ,70
           ,6)
GO

USE [dbTecProg]
GO

INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (1
           ,2200
           ,'2021/04/03')
GO
INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (2
           ,1500
           ,'2021/02/06')
GO
INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (3
           ,560
           ,'2021/04/03')
GO
INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (4
           ,50
           ,'2021/08/03')
GO
INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (5
           ,1300
           ,'2021/03/05')
GO

INSERT INTO [dbo].[stock]
           ([id_producto]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (6
           ,2200
           ,'2021/04/03')
GO

INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
     VALUES
           ('Rosales'
           ,'1823'
           ,'Esteban Etcheverria'
           ,'1838' 
           ,'Buenos Aires')
GO
INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
     VALUES
           ('Martinez'
           ,'453'
           ,'CABA'
           ,'1807' 
           ,'Buenos Aires')
GO
INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
     VALUES
           ('Fader'
           ,'4673'
           ,'Alte. Brouwn'
           ,'1846' 
           ,'Buenos Aires')
GO
INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
     VALUES
           ('Reconquista'
           ,'176'
           ,'Esteban Etcheverria'
           ,'1838' 
           ,'Buenos Aires')
GO
INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[prov
           ('Cochabamba'
           ,'3356'incia])
     VALUES
           ,'Lanus'
           ,'1807' 
           ,'Buenos Aires')
GO

INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
           ,[id_direccion])
     VALUES
           ('Perez'
           ,'Damian'
           ,38567566 
           ,1)
GO
INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
           ,[id_direccion])
     VALUES
           ('Juarez'
           ,'Jorge'
           ,38564567 
           ,2)
GO
INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
           ,[id_direccion])
     VALUES
           ('Sotello'
           ,'Andres'
           ,45564567 
           ,3)
GO
INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
           ,[id_direccion])
     VALUES
           ('Polar'
           ,'Jose'
           ,23564500 
           ,4)
GO
INSERT INTO [dbo].[persona]
           ([apellido]
           ,[nombre]
           ,[dni]
           ,[id_direccion])
     VALUES
           ('Taranto'
           ,'Adrian'
           ,22464657 
           ,5)
GO

INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (1)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (2)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (3)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (4)
GO
INSERT INTO [dbo].[cliente]
           ([id_persona])
     VALUES
           (5)
GO

USE [dbTecProg]
GO

INSERT INTO [dbo].[rol]
           ([descripcion])
     VALUES
           ('Administrador')
GO
INSERT INTO [dbo].[rol]
           ([descripcion])
     VALUES
           ('Encargado de Inventario y Logistica')
GO
INSERT INTO [dbo].[rol]
           ([descripcion])
     VALUES
           ('Vendedor')
GO
INSERT INTO [dbo].[rol]
           ([descripcion])
     VALUES
           ('Gerente')
GO


INSERT INTO [dbo].[usuario]
           ([id_persona]
           ,[id_rol]
           ,[password]
           ,[legajo]
           ,[deshabilitado])
     VALUES
           (1
           ,1
           ,'tarea123'
           ,15
           ,'2021/04/07')
GO
INSERT INTO [dbo].[usuario]
           ([id_persona]
           ,[id_rol]
           ,[password]
           ,[legajo]
           ,[deshabilitado])
     VALUES
           (2
           ,2
           ,'casa321'
           ,16
           ,'2021/07/09')
GO
INSERT INTO [dbo].[usuario]
           ([id_persona]
           ,[id_rol]
           ,[password]
           ,[legajo]
           ,[deshabilitado])
     VALUES
           (3
           ,3
           ,'hola432'
           ,17
           ,'2021/03/01')
GO
INSERT INTO [dbo].[usuario]
           ([id_persona]
           ,[id_rol]
           ,[password]
           ,[legajo]
           ,[deshabilitado])
     VALUES
           (4
           ,4
           ,'silla555'
           ,18
           ,'2021/04/07')
GO

INSERT INTO [dbo].[metodo_pago]
           ([TIPO])
     VALUES
           ('Efectivo')
GO
INSERT INTO [dbo].[metodo_pago]
           ([TIPO])
     VALUES
           ('Tarjeta')
GO
