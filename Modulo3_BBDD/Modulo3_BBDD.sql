USE [master]
GO
/****** Object:  Database [Modulo3_BBDD]    Script Date: 24/5/2021 20:35:10 ******/
CREATE DATABASE [Modulo3_BBDD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Modulo3_BBDD', FILENAME = N'D:\SQLServer\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Modulo3_BBDD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Modulo3_BBDD_log', FILENAME = N'D:\SQLServer\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Modulo3_BBDD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Modulo3_BBDD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Modulo3_BBDD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Modulo3_BBDD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET ARITHABORT OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Modulo3_BBDD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Modulo3_BBDD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Modulo3_BBDD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Modulo3_BBDD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Modulo3_BBDD] SET  MULTI_USER 
GO
ALTER DATABASE [Modulo3_BBDD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Modulo3_BBDD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Modulo3_BBDD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Modulo3_BBDD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Modulo3_BBDD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Modulo3_BBDD] SET QUERY_STORE = OFF
GO
USE [Modulo3_BBDD]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Id_Persona] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_De_Orden]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_De_Orden](
	[Id_DetalleOrden] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [varchar](50) NOT NULL,
	[Id_producto] [int] NOT NULL,
 CONSTRAINT [PK_Detalle de orden] PRIMARY KEY CLUSTERED 
(
	[Id_DetalleOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[Id_direccion] [int] IDENTITY(1,1) NOT NULL,
	[Altura] [varchar](50) NOT NULL,
	[Calle] [varchar](50) NOT NULL,
	[CodPostal] [varchar](50) NOT NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_direccion] PRIMARY KEY CLUSTERED 
(
	[Id_direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metodo de pago]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metodo de pago](
	[Id_MetodoDePago] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Metodo de pago] PRIMARY KEY CLUSTERED 
(
	[Id_MetodoDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[Id_Orden] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Id_DetalleOrden] [int] NOT NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[Id_Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenDe Venta]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDe Venta](
	[Id_OrdenVenta] [int] IDENTITY(1,1) NOT NULL,
	[Id_Orden] [int] NOT NULL,
	[Id_MetodoDePago] [int] NOT NULL,
 CONSTRAINT [PK_OrdenDe Venta] PRIMARY KEY CLUSTERED 
(
	[Id_OrdenVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id_Persona] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Dni] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Id_direccion] [int] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id_producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrecioCompra] [float] NOT NULL,
	[PrecioVenta] [float] NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 24/5/2021 20:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Id_Tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[CVC] [varchar](50) NOT NULL,
	[FechaVencimiento] [varchar](50) NOT NULL,
	[NombreDeTarjeta] [varchar](50) NOT NULL,
	[NroDeTarjeta] [int] NOT NULL,
	[Id_MetodoDePago] [int] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Cliente_Persona]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Cliente_Persona] ON [dbo].[Cliente]
(
	[Id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Detalle de orden_Producto]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Detalle de orden_Producto] ON [dbo].[Detalle_De_Orden]
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Orden_Detalle de orden]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Orden_Detalle de orden] ON [dbo].[Orden]
(
	[Id_DetalleOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_OrdenDe Venta_Metodo de pago]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_OrdenDe Venta_Metodo de pago] ON [dbo].[OrdenDe Venta]
(
	[Id_MetodoDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_OrdenDe Venta_Orden]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_OrdenDe Venta_Orden] ON [dbo].[OrdenDe Venta]
(
	[Id_Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Persona_direccion]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Persona_direccion] ON [dbo].[Persona]
(
	[Id_direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Producto_Categoria]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Producto_Categoria] ON [dbo].[Producto]
(
	[Id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IXFK_Tarjeta_Metodo de pago]    Script Date: 24/5/2021 20:35:10 ******/
CREATE NONCLUSTERED INDEX [IXFK_Tarjeta_Metodo de pago] ON [dbo].[Tarjeta]
(
	[Id_MetodoDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id_Persona])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Detalle_De_Orden]  WITH CHECK ADD  CONSTRAINT [FK_Detalle de orden_Producto] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([Id_producto])
GO
ALTER TABLE [dbo].[Detalle_De_Orden] CHECK CONSTRAINT [FK_Detalle de orden_Producto]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Detalle de orden] FOREIGN KEY([Id_DetalleOrden])
REFERENCES [dbo].[Detalle_De_Orden] ([Id_DetalleOrden])
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Detalle de orden]
GO
ALTER TABLE [dbo].[OrdenDe Venta]  WITH CHECK ADD  CONSTRAINT [FK_OrdenDe Venta_Metodo de pago] FOREIGN KEY([Id_MetodoDePago])
REFERENCES [dbo].[Metodo de pago] ([Id_MetodoDePago])
GO
ALTER TABLE [dbo].[OrdenDe Venta] CHECK CONSTRAINT [FK_OrdenDe Venta_Metodo de pago]
GO
ALTER TABLE [dbo].[OrdenDe Venta]  WITH CHECK ADD  CONSTRAINT [FK_OrdenDe Venta_Orden] FOREIGN KEY([Id_Orden])
REFERENCES [dbo].[Orden] ([Id_Orden])
GO
ALTER TABLE [dbo].[OrdenDe Venta] CHECK CONSTRAINT [FK_OrdenDe Venta_Orden]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_direccion] FOREIGN KEY([Id_direccion])
REFERENCES [dbo].[Direccion] ([Id_direccion])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_direccion]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id_Categoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Metodo de pago] FOREIGN KEY([Id_MetodoDePago])
REFERENCES [dbo].[Metodo de pago] ([Id_MetodoDePago])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Metodo de pago]
GO
USE [master]
GO
ALTER DATABASE [Modulo3_BBDD] SET  READ_WRITE 
GO
