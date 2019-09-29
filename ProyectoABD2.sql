CREATE DATABASE Proyecto;
USE Proyecto;

CREATE SCHEMA Transaccion;
CREATE SCHEMA Almacen;

CREATE TABLE Almacen.Vendedor
(
	IdVendedor BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Domicilio VARCHAR(100) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaNac DATE NOT NULL,
	Edad INT NULL,
	CONSTRAINT PK_VENDEDOR PRIMARY KEY(IdVendedor)
)

CREATE TABLE Transaccion.Cliente 
(
	IdCliente BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Domicilio VARCHAR(100) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaNac DATE NOT NULL,
	Edad INT NULL,
	CONSTRAINT PK_CLIENTE PRIMARY KEY(IdCliente)
)

CREATE TABLE Almacen.TipoProducto
(
	IdTipoProducto BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(500) NOT NULL,
	CONSTRAINT PK_TIPOPRODUCTO PRIMARY KEY(IdTipoProducto)
)

CREATE TABLE Almacen.Producto
(
	IdProducto  BIGINT IDENTITY NOT NULL,
	IdTipoProducto BIGINT NOT NULL,
	Stock INT NOT NULL,
	Tamaño VARCHAR(50) NOT NULL,
	Precio FLOAT NOT NULL,
	CONSTRAINT PK_PRODUCTO1 PRIMARY KEY(IdProducto),
	CONSTRAINT FK_TIPOPRODUCTO FOREIGN KEY(IdTipoProducto) REFERENCES Almacen.TipoProducto(IdTipoProducto)
)
CREATE TABLE Transaccion.Venta 
(
	IdVenta BIGINT IDENTITY(1,1) NOT NULL,
	IdCliente BIGINT NOT NULL,
	IdVendedor BIGINT NOT NULL,
	Fecha DATE NOT NULL,
	TOTAL FLOAT NULL,
	CONSTRAINT PK_VENTA1 PRIMARY KEY(IdVenta),
	CONSTRAINT FK_CLIENTE FOREIGN KEY(IdCliente) REFERENCES Transaccion.Cliente(IdCliente),
	CONSTRAINT FK_VENDEDOR FOREIGN KEY (IdVendedor) REFERENCES Almacen.Vendedor(IdVendedor) 
)

CREATE TABLE Transaccion.DetalleVenta
(
	IdVenta BIGINT NOT NULL,
	IdProducto BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal FLOAT NULL,
	CONSTRAINT FK_VENTA2 FOREIGN KEY(IdVenta) REFERENCES Transaccion.Venta(IdVenta),
	CONSTRAINT FK_PRODUCTO2 FOREIGN KEY(IdProducto) REFERENCES Almacen.Producto(IdProducto)
)

CREATE TABLE Almacen.Devolucion
 (
	IdDevolucion BIGINT IDENTITY(1,1) NOT NULL,
	IdVenta BIGINT NOT NULL,
	Motivo VARCHAR(400) NOT NULL,
	Fecha DATE NOT NULL,
	Total FLOAT NULL,
	CONSTRAINT PK_DEVOLUCION PRIMARY KEY(IdDevolucion),
	CONSTRAINT FK_VENTA3 FOREIGN KEY(IdVenta) REFERENCES Transaccion.Venta(IdVenta)
 )


 CREATE TABLE Almacen.DetalleDevolucion
 (
	IdDevolucion BIGINT NOT NULL,
	IdProducto BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal FLOAT NULL,
	CONSTRAINT FK_DEVOLUCCION FOREIGN KEY(IdDevolucion) REFERENCES Almacen.Devolucion(IdDevolucion),
	CONSTRAINT FK_VENTA4 FOREIGN KEY(IdProducto) REFERENCES Almacen.Producto
 )
 ---TRIGGERS
 --				EDAD VENDEDOR
 CREATE TRIGGER Almacen.calculaEdad ON Almacen.Vendedor AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID = IdVendedor FROM inserted UPDATE Almacen.Vendedor
SET Edad = CAST(DATEDIFF(dd,FechaNac,GETDATE()) / 365.25 as int) WHERE IdVendedor=@ID END
----		EDAD CLIENTE
CREATE TRIGGER Transaccion.calculaEdad ON Transaccion.Cliente AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID=IdCliente FROM inserted UPDATE Transaccion.Cliente
SET Edad = CAST(DATEDIFF(dd,FechaNac,GETDATE()) / 365.25 as int) WHERE IdCliente=@ID END

--Triger de ventas de productos descontar stock 

CREATE TRIGGER Transaccion.calculaStock ON Transaccion.DetalleVenta AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID = IdVenta FROM inserted UPDATE Almacen.Producto
SET Stock = Stock -(SELECT Cantidad FROM Transaccion.DetalleVenta WHERE IdVenta = @ID ) WHERE IdProducto = (SELECT IdProducto FROM 
Transaccion.DetalleVenta WHERE IdVenta = @ID)  END
--		TRIGGER DE DEVOLUCION DE PRODUCTOS AUMENTO DE STOCK
CREATE TRIGGER Almacen.RegresaProducto ON Almacen.DetalleDevolucion AFTER INSERT AS BEGIN SET NOCOUNT ON DECLARE
@ID AS BIGINT SELECT @ID = IdDevolucion FROM inserted UPDATE Almacen.Producto
SET Stock = Stock + (SELECT Cantidad FROM Almacen.DetalleDevolucion WHERE IdDevolucion = @ID ) WHERE IdProducto = (SELECT IdProducto FROM 
Almacen.DetalleDevolucion WHERE IdDevolucion = @ID) END

--		TRIGGER PARA SUBSTOTAL
CREATE TRIGGER Transaccion.calculaSubtotal ON Transaccion.DetalleVenta FOR INSERT
AS
	DECLARE @IDPRODUCTO BIGINT
	DECLARE @IDVENTA BIGINT
	DECLARE @CANTIDAD  INT
	DECLARE @SUBTOTAL FLOAT
	DECLARE @PRECIO FLOAT
	DECLARE @SUMASUBT FLOAT

	SELECT @IDPRODUCTO = IdProducto, @IDVENTA = IdVenta FROM inserted
BEGIN
--obtener el precio delporducto
	SELECT @PRECIO = Precio FROM Almacen.Producto WHERE @IDPRODUCTO = IdProducto
--actualizar subtotal
	UPDATE Transaccion.DetalleVenta SET @SUBTOTAL = Subtotal =(Cantidad*@PRECIO) WHERE IdVenta = @IDVENTA
--Suma de los subtotales de detalle de venta
	SELECT @SUMASUBT = SUM(Subtotal) FROM Transaccion.DetalleVenta WHERE IdVenta = @IDVENTA

	UPDATE Transaccion.Venta SET TOTAL = @SUMASUBT WHERE IdVenta =  @IDVENTA
END;



CREATE TRIGGER Almacen.calculaSubtotal ON Almacen.DetalleDevolucion FOR INSERT
AS
	DECLARE @IDPRODUCTO BIGINT
	DECLARE @IDDEVOLUCION BIGINT
	DECLARE @CANTIDAD  INT
	DECLARE @SUBTOTAL FLOAT
	DECLARE @PRECIO FLOAT
	DECLARE @SUMASUBT FLOAT

	SELECT @IDPRODUCTO = IdProducto, @IDDEVOLUCION = IdDevolucion FROM inserted
BEGIN
--obtener el precio delporducto
	SELECT @PRECIO = Precio FROM Almacen.Producto WHERE @IDPRODUCTO = IdProducto
--actualizar subtotal
	UPDATE Almacen.DetalleDevolucion SET @SUBTOTAL = Subtotal =(Cantidad*@PRECIO) WHERE IdDevolucion = @IDDEVOLUCION
--Suma de los subtotales de detalle de venta
	SELECT @SUMASUBT = SUM(Subtotal) FROM Almacen.DetalleDevolucion WHERE IdDevolucion = @IDDEVOLUCION

	UPDATE Almacen.Devolucion SET TOTAL = @SUMASUBT WHERE IdDevolucion =  @IDDEVOLUCION
END;

--- REGLAS
CREATE RULE R_Tipo AS @Nombre IN ('Individual','Matrimonial','Quenn Size') 
EXEC sp_bindrule 'R_Tipo','Almacen.Producto.Tamaño' -- SE APLICA UNA REGLA A UN ATRIBUTO EN ESPECIFICO

CREATE RULE R_PrecioProducto AS @PrecioProducto >= 100 AND @PrecioProducto <= 5000
EXEC sp_bindrule 'R_PrecioProducto', 'Almacen.Producto.Precio';

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
INSERT INTO Transaccion.DetalleVenta (IdVenta,IdProducto,Cantidad,Subtotal)VALUES (1,2,2,NULL)

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
