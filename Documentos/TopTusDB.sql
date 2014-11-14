USE master;
GO
IF EXISTS(SELECT * FROM sysdatabases WHERE NAME='TopTusDB')
BEGIN
     RAISERROR('TopTusDB',0,1)
     DROP DATABASE TopTusDB;
END
GO
CREATE DATABASE TopTusDB;
GO
 
USE TopTusDB;
GO
IF db_name()<>'TopTusDB'
BEGIN
     RAISERROR('Error to create TopTusDB database',22,127) WITH LOG
     DROP DATABASE TopTusDB;
END
GO
 
--ALTER DATABASE TopTusDB COLLATE Modern_Spanish_CS_AS;
--GO
 
USE TopTusDB;
--------------------------------------------------TipoVendedor
CREATE TABLE TipoVendedor(
	tipovendedor_id INT PRIMARY KEY IDENTITY NOT NULL,
	tipovendedor_descr NVARCHAR(40) NOT NULL,
);
GO
-------------------------------------------------Vendedor
CREATE TABLE Vendedor(
	vendedor_id INT PRIMARY KEY IDENTITY NOT NULL,
	nombre NVARCHAR(40) NOT NULL,
	apellido_m NVARCHAR(40) NOT NULL,
	apellido_p NVARCHAR(40) NOT NULL,
	tipovendedor_id INT NOT NULL REFERENCES TipoVendedor(tipovendedor_id)
);
GO
-------------------------------------------------Categoria
CREATE TABLE Categoria(
	categoria_id INT PRIMARY KEY IDENTITY NOT NULL,
	categoria_descr NVARCHAR(40) NOT NULL
);
GO
-------------------------------------------------SubCategoria
CREATE TABLE SubCategoria(
	subcategoria_id INT PRIMARY KEY IDENTITY NOT NULL,
	subcategoria_descr NVARCHAR(40) NOT NULL,
	categoria_id INT NOT NULL REFERENCES Categoria(categoria_id)
);
GO
-------------------------------------------------Producto
CREATE TABLE Producto(
	producto_id INT PRIMARY KEY IDENTITY NOT NULL,
	producto NVARCHAR(40) NOT NULL,
	producto_descr NVARCHAR(40) NOT NULL,
	foto NVARCHAR(40) NOT NULL,
	vendedor_id INT NOT NULL REFERENCES Vendedor(vendedor_id),
	subcategoria_id INT NOT NULL REFERENCES SubCategoria(subcategoria_id)
);
GO
-------------------------------------------------Comprador
CREATE TABLE Comprador(
	comprador_id INT PRIMARY KEY IDENTITY NOT NULL,
	nombre NVARCHAR(40) NOT NULL,
	apellido_m NVARCHAR(40) NOT NULL,
	apellido_p NVARCHAR(40) NOT NULL,
);
GO
-------------------------------------------------Anuncio
CREATE TABLE Anuncio(
	anuncio_id INT PRIMARY KEY IDENTITY NOT NULL,
	titulo NVARCHAR(40) NOT NULL,
	descripcion NVARCHAR(40) NOT NULL,
	vendedor_id INT NOT NULL REFERENCES Vendedor(vendedor_id),
	producto_id INT NOT NULL REFERENCES Producto(producto_id)
);
GO
-------------------------------------------------Timeline
CREATE TABLE Timeline(
	timeline_id INT PRIMARY KEY IDENTITY NOT NULL,
	titulo NVARCHAR(40) NOT NULL,
	descripcion NVARCHAR(40) NOT NULL,
	comprador_id INT NOT NULL REFERENCES Comprador(comprador_id)
);
GO
-------------------------------------------------SuperAdmin
CREATE TABLE SuperAdmin(
	superadmin_id INT PRIMARY KEY IDENTITY NOT NULL,
	nombre NVARCHAR(40) NOT NULL,
	apellido_m NVARCHAR(40) NOT NULL,
	apellido_p NVARCHAR(40) NOT NULL,
);
GO