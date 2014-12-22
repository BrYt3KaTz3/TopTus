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
-------------------------------------------------SuperAdmin
CREATE TABLE SuperAdmin(
	superadmin_id INT PRIMARY KEY IDENTITY NOT NULL,
	nombre NVARCHAR(40) NOT NULL,
	apellido_m NVARCHAR(40) NOT NULL,
	apellido_p NVARCHAR(40) NOT NULL,
	usuario NVARCHAR(30) NOT NULL,
	pass NVARCHAR(30) NOT NULL
);
GO
INSERT INTO SuperAdmin VALUES ('Luis', 'Hernández', 'Mañón', 'fer', 'fer');
INSERT INTO SuperAdmin VALUES ('Sergio', 'Amaya', 'Montoya', 'Sergio', 'qwerty12');
GO
--------------------------------------------------TipoVendedor
CREATE TABLE TipoVendedor(
	tipovendedor_id INT PRIMARY KEY IDENTITY NOT NULL,
	tipovendedor_descr NVARCHAR(40) NOT NULL,
);
GO
INSERT INTO TipoVendedor VALUES ('Premium');
INSERT INTO TipoVendedor VALUES ('Light');
INSERT INTO TipoVendedor VALUES ('Libre');
INSERT INTO TipoVendedor VALUES ('Solicitud');
GO
-------------------------------------------------Vendedor
CREATE TABLE Vendedor(
	vendedor_id INT PRIMARY KEY IDENTITY NOT NULL,
	nombre NVARCHAR(40) NOT NULL,
	apellido_m NVARCHAR(40) NOT NULL,
	apellido_p NVARCHAR(40) NOT NULL,
	email NVARCHAR(60) NOT NULL,
	pass NVARCHAR(30) NOT NULL,
	fecha_solicitud DATE NOT NULL,
	fecha_ingreso DATE,
	tipovendedor_id INT NOT NULL REFERENCES TipoVendedor(tipovendedor_id),
	rfc NVARCHAR(14) NOT NULL,
	empresa NVARCHAR(100) NOT NULL,
	pais_id INT NOT NULL,
	estado_id INT NOT NULL,
	ciudad NVARCHAR(60) NOT NULL,
	colonia NVARCHAR(60) NOT NULL,
	calle NVARCHAR(60) NOT NULL,
	calle_num NVARCHAR(10),
	calle_num_int NVARCHAR(10),
	lada_pais INT,
	lada_ciudad INT,
	telefono NVARCHAR(15),
	extension INT,
	imagen NVARCHAR(40)
);
GO
INSERT INTO Vendedor VALUES ('Fernando', 'Hernandez', 'Mañon', 'luisfernandomtv@hotmail.com', 'fer', '2014-08-01', '2014-08-10', 1, 'ASDF121212DE4', 'Fercho', 1, 1, 'Celaya', 'Centro', 'Calle', '105', 'A', 52, 461, '1231231', NULL, NULL);
INSERT INTO Vendedor VALUES ('Sergio', 'Amaya', 'Montoya', 'sa.amayamontoya@gmail.com', 'qwerty12', '2014-09-01', '2014-09-10', 2, 'AAMS121212WE3', 'Serch', 1, 1, 'Celaya', 'Centro', 'Calle', '106', 'B', 52, 461, '2342342', NULL, NULL);
INSERT INTO Vendedor VALUES ('Carlos', 'Peinado', 'Buenrrostro', 'carlitos@hotmail.com', 'carlos', '2014-08-01', '2014-09-01', 3, 'QWER123456DE3', 'Carlos', 1, 1, 'Celaya', 'Centro', 'Calle', '105', 'A', 52, 461, '1231231', NULL, NULL);
INSERT INTO Vendedor VALUES ('Pedro', 'Velez', 'Del Campo', 'pedrovelez@hotmail.com', 'pedro', '2014-09-01', '2014-09-2', 3, 'GHJK785689FR5', 'Pedro', 1, 1, 'Celaya', 'Centro', 'Calle', '105', 'A', 52, 461, '1231231', NULL, NULL);
INSERT INTO Vendedor VALUES ('Alberto', 'Materno', 'Paterno', 'alberto123@hotmail.com', 'alberto', '2014-08-01', NULL, 4, 'ZXCV121212JU7', 'Alberto', 1, 1, 'Celaya', 'Centro', 'Calle', '105', 'A', 52, 461, '1231231', NULL, NULL);
GO
-------------------------------------------------Categoria
CREATE TABLE Categoria(
	categoria_id INT PRIMARY KEY IDENTITY NOT NULL,
	categoria_descr NVARCHAR(40) NOT NULL
);
GO
INSERT INTO Categoria VALUES ('Hogar');
INSERT INTO Categoria VALUES ('Deportes');
INSERT INTO Categoria VALUES ('Electronica');
GO
-------------------------------------------------SubCategoria
CREATE TABLE SubCategoria(
	subcategoria_id INT PRIMARY KEY IDENTITY NOT NULL,
	subcategoria_descr NVARCHAR(40) NOT NULL,
	categoria_id INT NOT NULL REFERENCES Categoria(categoria_id)
);
GO
INSERT INTO SubCategoria VALUES ('Decoraciones', 1);
INSERT INTO SubCategoria VALUES ('Plantas', 1);
INSERT INTO SubCategoria VALUES ('Soccer', 2);
INSERT INTO SubCategoria VALUES ('Beisbol', 2);
INSERT INTO SubCategoria VALUES ('Futbol', 2);
INSERT INTO SubCategoria VALUES ('Electrodomesticos', 3);
INSERT INTO SubCategoria VALUES ('Computacion', 3);
INSERT INTO SubCategoria VALUES ('Audio', 3);
GO
-------------------------------------------------Producto
CREATE TABLE Producto(
	producto_id INT PRIMARY KEY IDENTITY NOT NULL,
	producto NVARCHAR(40) NOT NULL,
	producto_descr NVARCHAR(40) NOT NULL,
	foto NVARCHAR(40) NOT NULL,
	vendedor_id INT NOT NULL REFERENCES Vendedor(vendedor_id),
	precio MONEY NOT NULL,
	oferta BIT NOT NULL,
	porcentaje_oferta INT NOT NULL DEFAULT 0,
	precio_oferta MONEY,
	disponible BIT NOT NULL,
);
GO
-- nombre de foto = [vendedor_id]_[prodducto_id].extension
-- Eatmos en Oferta todoa a $99.99 XD
INSERT INTO Producto VALUES ('Cortina', 'Cortina de tela 3m x 4m', '1_1.jpg', 1,  $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Balon Soccer', 'Balon Soccer', '2_2.jpg', 2, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Balon Futbol', 'Balon Futbol', '2_3.jpg', 2, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Bat', 'Bat', '2_4.jpg', 2, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Lavadora', 'Lavadora', '3_5.jpg', 3, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Disco Duro', 'Disco duro Serial ATA 7200', '4_6.jpg', 4, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Teclado', 'Razer Rainbow blanco', '4_7.jpg', 4, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Monitor', 'Monitor 19 pulgadas LED', '4_8.jpg', 4, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Bocina 6x9', 'Bocinas Sony con tweter integrado', '5_9.jpg', 4, $99.99, 0, 0, NULL, 1);
INSERT INTO Producto VALUES ('Amplificador 1000W', 'Amplificador 2 canales 1000W RMS', '5_10.jpg', 4, $99.99, 0, 0, NULL, 1);
GO
-------------------------------------------------Producto-Categorias
CREATE TABLE prod_cate(
	producto_id INT NOT NULL REFERENCES Producto(producto_id),
	categoria_id INT NOT NULL REFERENCES Categoria(categoria_id),
	subcategoria_id INT REFERENCES SubCategoria(subcategoria_id),
	PRIMARY KEY	(producto_id, categoria_id)
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
	fecha_creacion DATE NOT NULL,
	titulo NVARCHAR(40) NOT NULL,
	descripcion NVARCHAR(40) NOT NULL,
	vendedor_id INT NOT NULL REFERENCES Vendedor(vendedor_id),
	producto_id INT NOT NULL REFERENCES Producto(producto_id)
);
GO
-------------------------------------------------Timeline
CREATE TABLE Timeline(
	timeline_id INT PRIMARY KEY IDENTITY NOT NULL,
	fecha_creacion DATE NOT NULL,
	titulo NVARCHAR(100) NOT NULL,
	descripcion NVARCHAR(300) NOT NULL,
	comprador_id INT NOT NULL REFERENCES Comprador(comprador_id)
);
GO

-- Nombre completo de vendedor debe calcularse
-- Afecta el hacer una linking table para poner varias categorias a un producto o una subcategoria en varias categorias?