USE [dbTecProg]
GO

/****** Object:  StoredProcedure [dbo].[sp_almacenar_detalle]    Script Date: 15/6/2021 22:36:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_almacenar_detalle]
@cantidad int,
@idOrden int,
@idProducto int
AS
BEGIN
INSERT INTO [dbo].[detalle_orden]
           ([cantidad]
           ,[id_orden]
           ,[id_producto])
     VALUES
           (@cantidad
		   ,@idOrden
		   ,@idProducto);

UPDATE stock
   SET cantidad = cantidad - @cantidad
 WHERE id_producto = @idProducto;

RETURN @@ROWCOUNT
END
GO


