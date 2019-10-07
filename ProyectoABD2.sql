--DROP DATABASE Proyecto

CREATE DATABASE Proyecto;
USE Proyecto

CREATE SCHEMA Transaccion
CREATE SCHEMA Almacen

CREATE TABLE Almacen.Vendedor
(
	idVendedor BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Domicilio VARCHAR(100) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaNac DATE NOT NULL,
	Edad INT NULL,
	CONSTRAINT PK_VENDEDOR PRIMARY KEY(idVendedor)
)

CREATE TABLE Transaccion.Cliente 
(
	idCliente BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Domicilio VARCHAR(100) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaNac DATE NOT NULL,
	Edad INT NULL,
	CONSTRAINT PK_CLIENTE PRIMARY KEY(idCliente)
)

CREATE TABLE Almacen.TipoProducto
(
	idTipoProducto BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(500) NOT NULL,
	CONSTRAINT PK_TIPOPRODUCTO PRIMARY KEY(idTipoProducto)
)

CREATE TABLE Almacen.Producto
(
	idProducto  BIGINT IDENTITY NOT NULL,
	idTipoProducto BIGINT NOT NULL,
	Stock INT NOT NULL,
	Tamaño VARCHAR(50) NOT NULL,
	Precio FLOAT NOT NULL,
	CONSTRAINT PK_PRODUCTO1 PRIMARY KEY(idProducto),
	CONSTRAINT FK_TIPOPRODUCTO FOREIGN KEY(idTipoProducto) REFERENCES Almacen.TipoProducto(idTipoProducto)
)

CREATE TABLE Transaccion.Venta 
(
	idVenta BIGINT IDENTITY(1,1) NOT NULL,
	idCliente BIGINT NOT NULL,
	idVendedor BIGINT NOT NULL,
	Fecha DATE NOT NULL,
	TOTAL FLOAT NULL,
	CONSTRAINT PK_VENTA1 PRIMARY KEY(idVenta),
	CONSTRAINT FK_CLIENTE FOREIGN KEY(idCliente) REFERENCES Transaccion.Cliente(idCliente),
	CONSTRAINT FK_VENDEDOR FOREIGN KEY (idVendedor) REFERENCES Almacen.Vendedor(idVendedor) 
)

CREATE TABLE Transaccion.DetalleVenta
(
	idVenta BIGINT NOT NULL,
	idProducto BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal FLOAT NULL,
	CONSTRAINT FK_VENTA2 FOREIGN KEY(idVenta) REFERENCES Transaccion.Venta(idVenta),
	CONSTRAINT FK_PRODUCTO2 FOREIGN KEY(idProducto) REFERENCES Almacen.Producto(idProducto)
)

CREATE TABLE Almacen.Devolucion
 (
	idDevolucion BIGINT IDENTITY(1,1) NOT NULL,
	idVenta BIGINT NOT NULL,
	Motivo VARCHAR(400) NOT NULL,
	Fecha DATE NOT NULL,
	Total INT NULL,
	CONSTRAINT PK_DEVOLUCION PRIMARY KEY(idDevolucion),
	CONSTRAINT FK_VENTA3 FOREIGN KEY(idVenta) REFERENCES Transaccion.Venta(idVenta)
 )

 CREATE TABLE Almacen.DetalleDevolucion
 (
	idDevolucion BIGINT NOT NULL,
	idProducto BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal INT NULL,
	CONSTRAINT FK_DEVOLUCCION FOREIGN KEY(idDevolucion) REFERENCES Almacen.Devolucion(idDevolucion),
	CONSTRAINT FK_VENTA4 FOREIGN KEY(idProducto) REFERENCES Almacen.Producto
 )

 ---TRIGGERS
 --				EDAD VENDEDOR
 CREATE TRIGGER Almacen.calculaEdad ON Almacen.Vendedor AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID=idVendedor FROM inserted UPDATE Almacen.Vendedor
SET Edad = CAST(DATEDIFF(dd,FechaNac,GETDATE()) / 365.25 as int) WHERE idVendedor=@ID END


----		EDAD CLIENTE
CREATE TRIGGER Transaccion.calculaEdad ON Transaccion.Cliente AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID=idCliente FROM inserted UPDATE Transaccion.Cliente
SET Edad = CAST(DATEDIFF(dd,FechaNac,GETDATE()) / 365.25 as int) WHERE idCliente=@ID END

INSERT INTO Almacen.Vendedor(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Diego','B. Anaya','diego_pilcar@hotmail.com',
'866-132-62-79','1996-10-03',NULL)
INSERT INTO Almacen.Vendedor(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Aldo','B. Anaya','aldopilcar@hotmail.com',
'866-123-45-78','1999-08-23',NULL)
INSERT INTO Transaccion.Cliente(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Jose','Roma','hotmail@hotmail.com',
'123-456-78-90','1996-08-03',NULL)
INSERT INTO Transaccion.Cliente(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Ivonne','en mi casa','hotmail@hotmail.com',
'123-456-78-90','1997-08-30',NULL)
SELECT * FROM Almacen.Vendedor
SELECT * FROM Transaccion.Cliente


INSERT INTO Almacen.TipoProducto(Nombre,Descripcion) VALUES ('COLCHA REGINA','JGIJHVJHVGCGCGCGCGJCJ')
SELECT * FROM Almacen.TipoProducto
INSERT INTO Almacen.Producto (idTipoProducto,Stock,Tamaño,Precio) VALUES(1,50,'MATRIMONIAL',18.45)
INSERT INTO Almacen.Producto (idTipoProducto,Stock,Tamaño,Precio) VALUES(1,50,'INDIVIDUAL',20.50)
SELECT * FROM Almacen.Producto
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
SELECT * FROM  Transaccion.DetalleVenta WHERE idVenta=1
SELECT * FROM Transaccion.Cliente
INSERT INTO Transaccion.Venta(idCliente,idVendedor,Fecha,TOTAL) VALUES(1,1,'2019-09-16',NULL)
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
INSERT INTO Transaccion.DetalleVenta (idVenta,idProducto,Cantidad,Subtotal)VALUES (2,1,2,NULL)

DELETE FROM Transaccion.DetalleVenta
--		TRIGGER DE DEVOLUCION DE PRODUCTOS AUMENTO DE STOCK
CREATE TRIGGER Almacen.calculaStock ON Almacen.DetalleDevolucion AFTER INSERT AS
			DECLARE @ID AS BIGINT 
			DECLARE @idProducto AS INT
			DECLARE @cantidad AS INT
			SELECT @idProducto = idProducto, @cantidad = Cantidad FROM inserted

BEGIN
   	UPDATE Almacen.Producto SET Stock = Stock+@cantidad WHERE idProducto=@idProducto
END

CREATE TRIGGER Almacen.calculaStockUPDATEB ON Almacen.DetalleDevolucion AFTER UPDATE AS
			DECLARE @ID AS BIGINT 
			DECLARE @idProducto AS INT
			DECLARE @cantidad AS INT
			SELECT @idProducto = idProducto, @cantidad = Cantidad FROM inserted

BEGIN
   	UPDATE Almacen.Producto SET Stock = Stock-@cantidad WHERE idProducto=@idProducto
END

SELECT idProducto FROM Almacen.Producto WHERE idProducto=(SELECT idProducto FROM Transaccion.DetalleVenta  
WHERE idVenta=(SELECT idVenta FROM Almacen.DetalleDevolucion WHERE idDevolucion=1))
INSERT INTO Almacen.Devolucion(idVenta,Motivo,Fecha,Total) VALUES (2,'Daño en el material','2019-08-15',NULL)
SELECT * FROM Almacen.Devolucion
SELECT * FROM Almacen.DetalleDevolucion
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
SELECT *FROM Almacen.Producto
INSERT INTO Almacen.DetalleDevolucion (idDevolucion,idProducto,Cantidad,Subtotal) VALUES (1,2,50,NULL)
SELECT * FROM Almacen.Producto
INSERT INTO Transaccion.DetalleVenta (idVenta,idProducto,Cantidad,Subtotal)VALUES (6,2,2,NULL)

--Triger de ventas de productos descontar stock 

CREATE TRIGGER Transaccion.calculaStock ON Transaccion.DetalleVenta AFTER INSERT AS
			DECLARE @ID AS BIGINT 
			DECLARE @idProducto AS INT
			DECLARE @cantidad AS INT
			SELECT @idProducto = idProducto, @cantidad = Cantidad FROM inserted

BEGIN
   	UPDATE Almacen.Producto SET Stock = Stock-@cantidad WHERE idProducto=@idProducto
END


CREATE TRIGGER Transaccion.calculaStockUPDATE ON Transaccion.DetalleVenta AFTER UPDATE AS
			DECLARE @ID AS BIGINT 
			DECLARE @idProducto AS INT
			DECLARE @cantidad AS INT
			SELECT @idProducto = idProducto, @cantidad = Cantidad FROM inserted

BEGIN
   	UPDATE Almacen.Producto SET Stock = Stock-@cantidad WHERE idProducto=@idProducto
END


CREATE TRIGGER Transaccion.calculaSubtotal ON Transaccion.DetalleVenta FOR INSERT
AS
	DECLARE @IDPRODUCTO BIGINT
	DECLARE @IDVENTA BIGINT
	DECLARE @CANTIDAD  INT
	DECLARE @SUBTOTAL FLOAT
	DECLARE @PRECIO FLOAT
	DECLARE @SUMASUBT FLOAT

	SELECT @IDPRODUCTO=idProducto,@IDVENTA=idVenta FROM inserted
BEGIN
--obtener el precio delporducto
	SELECT @PRECIO=Precio FROM Almacen.Producto WHERE @IDPRODUCTO=idProducto
--actualizar subtotal
	UPDATE Transaccion.DetalleVenta SET @SUBTOTAL = Subtotal =(Cantidad*@PRECIO) WHERE idVenta=@IDVENTA
--Suma de los subtotales de detalle de venta
	SELECT @SUMASUBT = SUM(Subtotal) FROM Transaccion.DetalleVenta WHERE idVenta = @IDVENTA

	UPDATE Transaccion.Venta SET TOTAL = @SUMASUBT WHERE idVenta =  @IDVENTA
END


select * from Transaccion.Venta

CREATE TRIGGER Almacen.calculaSubtotal  ON Almacen.DetalleDevolucion FOR INSERT
AS
	DECLARE @IDPRODUCTO BIGINT
	DECLARE @IDDEVOLUCION BIGINT
	DECLARE @CANTIDAD  INT
	DECLARE @SUBTOTAL FLOAT
	DECLARE @PRECIO FLOAT
	DECLARE @SUMASUBT FLOAT

	SELECT @IDPRODUCTO=IdProducto,@IDDEVOLUCION=IdDevolucion FROM inserted
BEGIN
--obtener el precio delporducto
	SELECT @PRECIO=Precio FROM Almacen.Producto WHERE @IDPRODUCTO=idProducto
--actualizar subtotal
	UPDATE Almacen.DetalleDevolucion SET @SUBTOTAL = Subtotal =(Cantidad*@PRECIO) WHERE IdDevolucion=@IDDEVOLUCION
--Suma de los subtotales de detalle de venta
	SELECT @SUMASUBT = SUM(Subtotal) FROM Transaccion.DetalleVenta WHERE idVenta = @IDDEVOLUCION

	UPDATE Alamacen.devolucion SET Total = @SUMASUBT WHERE idDevolucion =  @IDDEVOLUCION
END

CREATE TRIGGER Almacen.calculaSubtotal ON Almacen.DetalleDevolucion AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID=idProducto FROM inserted UPDATE Almacen.DetalleDevolucion 
SET Subtotal =Cantidad * (SELECT Precio FROM Almacen.Producto WHERE idProducto=@ID)  WHERE idDevolucion=(SELECT idProducto FROM 
Almacen.Producto WHERE idProducto=@ID) END


--- REGLAS
CREATE RULE R_Tipo AS @Nombre IN ('Individual','Matrimonial','Queen Size') 
EXEC sp_bindrule 'R_Tipo','Almacen.Producto.Tamaño' -- SE APLICA UNA REGLA A UN ATRIBUTO EN ESPECIFICO

CREATE RULE R_PrecioProducto AS @PrecioProducto >= 100 AND @PrecioProducto <= 5000
EXEC sp_bindrule 'R_PrecioProducto', 'Almacen.Producto.Precio';
-----

INSERT INTO Almacen.Vendedor(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Diego','B. Anaya','diego_pilcar@hotmail.com',
'866-132-62-79','1996-10-03',NULL)
INSERT INTO Almacen.Vendedor(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Aldo','B. Anaya','aldopilcar@hotmail.com',
'866-123-45-78','1999-08-23',NULL)
INSERT INTO Transaccion.Cliente(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Jose','Roma','hotmail@hotmail.com',
'123-456-78-90','1996-08-03',NULL)
INSERT INTO Transaccion.Cliente(Nombre,Domicilio,Email,Telefono,FechaNac,Edad)VALUES ('Ivonne','en mi casa','hotmail@hotmail.com',
'123-456-78-90','1997-08-30',NULL)
SELECT * FROM Almacen.Vendedor
SELECT * FROM Transaccion.Cliente


INSERT INTO Almacen.TipoProducto(Nombre,Descripcion) VALUES ('REGINA','JGIJHVJHVGCGCGCGCGJCJ')
SELECT * FROM Almacen.TipoProducto
INSERT INTO Almacen.Producto (IdTipoProducto,Stock,Tamaño,Precio) VALUES(1,50,'Individual',101)
INSERT INTO Almacen.Producto (IdTipoProducto,Stock,Tamaño,Precio) VALUES(1,50,'Matrimonial',101)
INSERT INTO Almacen.Producto (IdTipoProducto,Stock,Tamaño,Precio) VALUES(1,50,'Quenn Size',101)
SELECT * FROM Almacen.Producto
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
SELECT * FROM  Transaccion.DetalleVenta WHERE idVenta=1
SELECT * FROM Transaccion.Cliente
INSERT INTO Transaccion.Venta(IdCliente,IdVendedor,Fecha,TOTAL) VALUES(1,2,'2019-09-16',NULL)
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
INSERT INTO Transaccion.DetalleVenta (IdVenta,IdProducto,Cantidad,Subtotal)VALUES (2,1,2,NULL)

SELECT IdProducto FROM Almacen.Producto WHERE IdProducto = (SELECT IdProducto FROM Transaccion.DetalleVenta  
WHERE IdVenta = (SELECT IdVenta FROM Almacen.DetalleDevolucion WHERE IdDevolucion=1))
INSERT INTO Almacen.Devolucion(IdVenta,Motivo,Fecha,Total) VALUES (1,'Daño en el material','2019-08-15',NULL)
SELECT * FROM Almacen.Devolucion
SELECT * FROM Almacen.DetalleDevolucion
SELECT * FROM Transaccion.Venta
SELECT * FROM Transaccion.DetalleVenta
SELECT *FROM Almacen.Producto
INSERT INTO Almacen.DetalleDevolucion (IdDevolucion,IdProducto,Cantidad,Subtotal) VALUES (2,1,101,NULL)
SELECT * FROM Almacen.Producto
