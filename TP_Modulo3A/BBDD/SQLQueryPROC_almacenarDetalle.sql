USE [dbTecProg]
GO

/****** Object:  StoredProcedure [dbo].[sp_almacenar_detalle]    Script Date: 14/6/2021 15:54:47 ******/
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
		   ,@idProducto)
RETURN @@ROWCOUNT
END
GO


