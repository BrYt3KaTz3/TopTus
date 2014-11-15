USE [master]
GO
/****** Object:  Database [TopTusDB]    Script Date: 11/15/2014 16:51:53 ******/
CREATE DATABASE [TopTusDB] ON  PRIMARY 
( NAME = N'TopTusDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.FERSQL\MSSQL\DATA\TopTusDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TopTusDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.FERSQL\MSSQL\DATA\TopTusDB_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TopTusDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TopTusDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TopTusDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TopTusDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TopTusDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TopTusDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TopTusDB] SET ARITHABORT OFF
GO
ALTER DATABASE [TopTusDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TopTusDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TopTusDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TopTusDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TopTusDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TopTusDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TopTusDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TopTusDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TopTusDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TopTusDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TopTusDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [TopTusDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TopTusDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TopTusDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TopTusDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TopTusDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TopTusDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TopTusDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TopTusDB] SET  READ_WRITE
GO
ALTER DATABASE [TopTusDB] SET RECOVERY FULL
GO
ALTER DATABASE [TopTusDB] SET  MULTI_USER
GO
ALTER DATABASE [TopTusDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TopTusDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'TopTusDB', N'ON'
GO
USE [TopTusDB]
GO
/****** Object:  User [feri]    Script Date: 11/15/2014 16:51:53 ******/
CREATE USER [feri] FOR LOGIN [feri] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Comprador]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprador](
	[comprador_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[apellido_m] [nvarchar](40) NOT NULL,
	[apellido_p] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[comprador_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[categoria_descr] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON
INSERT [dbo].[Categoria] ([categoria_id], [categoria_descr]) VALUES (1, N'Hogar')
INSERT [dbo].[Categoria] ([categoria_id], [categoria_descr]) VALUES (2, N'Deportes')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
/****** Object:  Table [dbo].[SuperAdmin]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperAdmin](
	[superadmin_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[apellido_m] [nvarchar](40) NOT NULL,
	[apellido_p] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[superadmin_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVendedor]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVendedor](
	[tipovendedor_id] [int] IDENTITY(1,1) NOT NULL,
	[tipovendedor_descr] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tipovendedor_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TipoVendedor] ON
INSERT [dbo].[TipoVendedor] ([tipovendedor_id], [tipovendedor_descr]) VALUES (1, N'oro')
INSERT [dbo].[TipoVendedor] ([tipovendedor_id], [tipovendedor_descr]) VALUES (2, N'plata')
INSERT [dbo].[TipoVendedor] ([tipovendedor_id], [tipovendedor_descr]) VALUES (3, N'bronce')
INSERT [dbo].[TipoVendedor] ([tipovendedor_id], [tipovendedor_descr]) VALUES (4, N'solicitud')
SET IDENTITY_INSERT [dbo].[TipoVendedor] OFF
/****** Object:  Table [dbo].[Vendedor]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[vendedor_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NOT NULL,
	[apellido_m] [nvarchar](40) NOT NULL,
	[apellido_p] [nvarchar](40) NOT NULL,
	[email] [nvarchar](max) NULL,
	[pass] [nvarchar](max) NULL,
	[fecha_solicitud] [date] NULL,
	[fecha_ingreso] [date] NULL,
	[tipovendedor_id] [int] NOT NULL,
 CONSTRAINT [PK__Vendedor__9FB265DE03317E3D] PRIMARY KEY CLUSTERED 
(
	[vendedor_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vendedor] ON
INSERT [dbo].[Vendedor] ([vendedor_id], [nombre], [apellido_m], [apellido_p], [email], [pass], [fecha_solicitud], [fecha_ingreso], [tipovendedor_id]) VALUES (1, N'Fernando', N'Hernández', N'Mañón', N'luisfernandomtv@hotmail.com', N'fer', NULL, NULL, 1)
INSERT [dbo].[Vendedor] ([vendedor_id], [nombre], [apellido_m], [apellido_p], [email], [pass], [fecha_solicitud], [fecha_ingreso], [tipovendedor_id]) VALUES (13, N'fernando', N'', N'hernandez', N'luisfernandomtv@hotmail.com', N'fercho.com', CAST(0x3B390B00 AS Date), NULL, 4)
SET IDENTITY_INSERT [dbo].[Vendedor] OFF
/****** Object:  Table [dbo].[Timeline]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timeline](
	[timeline_id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nvarchar](40) NOT NULL,
	[descripcion] [nvarchar](40) NOT NULL,
	[comprador_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timeline_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoria](
	[subcategoria_id] [int] IDENTITY(1,1) NOT NULL,
	[subcategoria_descr] [nvarchar](40) NOT NULL,
	[categoria_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[subcategoria_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SubCategoria] ON
INSERT [dbo].[SubCategoria] ([subcategoria_id], [subcategoria_descr], [categoria_id]) VALUES (1, N'Futbol', 2)
INSERT [dbo].[SubCategoria] ([subcategoria_id], [subcategoria_descr], [categoria_id]) VALUES (2, N'Basquetbol', 2)
INSERT [dbo].[SubCategoria] ([subcategoria_id], [subcategoria_descr], [categoria_id]) VALUES (3, N'Decoraciones', 1)
SET IDENTITY_INSERT [dbo].[SubCategoria] OFF
/****** Object:  Table [dbo].[Producto]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[producto_id] [int] IDENTITY(1,1) NOT NULL,
	[producto] [nvarchar](40) NOT NULL,
	[producto_descr] [nvarchar](40) NOT NULL,
	[foto] [nvarchar](40) NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[subcategoria_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[producto_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON
INSERT [dbo].[Producto] ([producto_id], [producto], [producto_descr], [foto], [vendedor_id], [subcategoria_id]) VALUES (2, N'Balón de fubtol', N'Balón profesional de futbol', N'balon.jpg', 1, 1)
INSERT [dbo].[Producto] ([producto_id], [producto], [producto_descr], [foto], [vendedor_id], [subcategoria_id]) VALUES (3, N'Anaqueles', N'Anaqueles para baño', N'anaquel.jpg', 1, 3)
SET IDENTITY_INSERT [dbo].[Producto] OFF
/****** Object:  Table [dbo].[Anuncio]    Script Date: 11/15/2014 16:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anuncio](
	[anuncio_id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nvarchar](40) NOT NULL,
	[descripcion] [nvarchar](40) NOT NULL,
	[vendedor_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[anuncio_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__Vendedor__tipove__0519C6AF]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK__Vendedor__tipove__0519C6AF] FOREIGN KEY([tipovendedor_id])
REFERENCES [dbo].[TipoVendedor] ([tipovendedor_id])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK__Vendedor__tipove__0519C6AF]
GO
/****** Object:  ForeignKey [FK__Timeline__compra__21B6055D]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Timeline]  WITH CHECK ADD FOREIGN KEY([comprador_id])
REFERENCES [dbo].[Comprador] ([comprador_id])
GO
/****** Object:  ForeignKey [FK__SubCatego__categ__0DAF0CB0]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([categoria_id])
GO
/****** Object:  ForeignKey [FK__Producto__subcat__1367E606]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([subcategoria_id])
REFERENCES [dbo].[SubCategoria] ([subcategoria_id])
GO
/****** Object:  ForeignKey [FK__Producto__vended__1273C1CD]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK__Producto__vended__1273C1CD] FOREIGN KEY([vendedor_id])
REFERENCES [dbo].[Vendedor] ([vendedor_id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK__Producto__vended__1273C1CD]
GO
/****** Object:  ForeignKey [FK__Anuncio__product__1CF15040]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Anuncio]  WITH CHECK ADD FOREIGN KEY([producto_id])
REFERENCES [dbo].[Producto] ([producto_id])
GO
/****** Object:  ForeignKey [FK__Anuncio__vendedo__1BFD2C07]    Script Date: 11/15/2014 16:51:54 ******/
ALTER TABLE [dbo].[Anuncio]  WITH CHECK ADD  CONSTRAINT [FK__Anuncio__vendedo__1BFD2C07] FOREIGN KEY([vendedor_id])
REFERENCES [dbo].[Vendedor] ([vendedor_id])
GO
ALTER TABLE [dbo].[Anuncio] CHECK CONSTRAINT [FK__Anuncio__vendedo__1BFD2C07]
GO
