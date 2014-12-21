USE TopTusDB;
GO

IF OBJECT_ID('dbo.Producto', 'U') IS NOT NULL
	DROP TABLE Producto;

IF OBJECT_ID('dbo.prod-cate', 'U') IS NOT NULL
	DROP TABLE prod_cate;

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