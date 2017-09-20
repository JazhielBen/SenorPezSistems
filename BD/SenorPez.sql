USE master
GO

IF EXISTS(SELECT * FROM DBO.SYSDATABASES WHERE NAME = 'BDPez') 
BEGIN
    USE MASTER 
	DROP DATABASE BDPez 
END
GO

CREATE DATABASE BDPez;
GO
USE BDPez
GO

/*MAE_PERSONA*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'MAE_PERSONA')
BEGIN
      DROP TABLE MAE_PERSONA
END

CREATE TABLE MAE_PERSONA
(
iCodPersona INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
vNombre VARCHAR (50) NOT NULL,
vApellido VARCHAR(50) NULL,
dtFechaNacimiento DATETIME NULL,
vTelefono VARCHAR(15) NULL,
vMail VARCHAR(100) NULL,
vDireccion VARCHAR(100) NULL,
vDocPersona VARCHAR(8) NULL UNIQUE,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE MAE_PERSONA'
GO

/*MAE_PRESENTACION*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'MAE_PRESENTACION')
BEGIN
      DROP TABLE MAE_PRESENTACION
END

CREATE TABLE MAE_PRESENTACION
(
iCodPresentacion INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
vNombrePresentacion VARCHAR(50) NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE MAE_PRESENTACION'
GO
  
/*MAE_PRODUCTO*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'MAE_PRODUCTO')
BEGIN
      DROP TABLE MAE_PRODUCTO
END

CREATE TABLE MAE_PRODUCTO
(
iCodProducto INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
vNombreProducto VARCHAR NOT NULL UNIQUE,
iCodPresentacion INTEGER REFERENCES MAE_PRESENTACION,
nPrecio NUMERIC(7,2) NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE MAE_PRODUCTO'
GO

/*MAE_PROVEEDOR*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'MAE_PROVEEDOR')
BEGIN
      DROP TABLE MAE_PROVEEDOR
END

CREATE TABLE MAE_PROVEEDOR
(
iCodProveedor INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
vRUC VARCHAR(11) NOT NULL UNIQUE,
vDireccion VARCHAR(100) NOT NULL,
vTelefono VARCHAR (15) NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE MAE_PROVEEDOR'
GO

/*MAE_CARGO*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'MAE_CARGO')
BEGIN
      DROP TABLE MAE_CARGO
END

CREATE TABLE MAE_CARGO
(
iCodCargo INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
vNombreCargo VARCHAR(200) NOT NULL,
vPassword VARCHAR(200) NOT NULL,
iAcceso INTEGER NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE MAE_CARGO'
GO

/*CLIENTE*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'CLIENTE')
BEGIN
      DROP TABLE CLIENTE
END

CREATE TABLE CLIENTE
(
iCodCliente INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
iCodPersona INTEGER NOT NULL REFERENCES MAE_PERSONA,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE CLIENTE'
GO

/*EMPLEADO*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'EMPLEADO')
BEGIN
      DROP TABLE EMPLEADO
END

CREATE TABLE EMPLEADO
(
iCodEmpleado INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
iCodPersona INTEGER NOT NULL REFERENCES MAE_PERSONA,
iCodCargo INTEGER NOT NULL REFERENCES MAE_CARGO,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE EMPLEADO'
GO

/*VENTA*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'VENTA')
BEGIN
      DROP TABLE VENTA
END

CREATE TABLE VENTA
(
iCodVenta INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
dtFechaVenta DATETIME NOT NULL,
iCodEmpleadoTrabajador INTEGER NOT NULL REFERENCES EMPLEADO,
iCodCliente INTEGER NOT NULL REFERENCES CLIENTE,
iTipoVenta INTEGER NOT NULL,
iIGV INTEGER NOT NULL,
nTotalVenta NUMERIC(7,2) NOT NULL,
bDescuento BIT NOT NULL,
bDescuentoCantidad BIT NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE VENTA'
GO

/*VENTA_DETALLE*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'VENTA_DETALLE')
BEGIN
      DROP TABLE VENTA_DETALLE
END

CREATE TABLE VENTA_DETALLE
(
iCodVentaDetalle INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
iCodVenta INTEGER NOT NULL REFERENCES VENTA,
iCodProducto INTEGER NOT NULL REFERENCES MAE_PRODUCTO,
iCantidad INTEGER NOT NULL,
nPrecio NUMERIC(7,2) NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE VENTA_DETALLE'
GO

/*COMPRA*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'COMPRA')
BEGIN
      DROP TABLE COMPRA
END

CREATE TABLE COMPRA
(
iCodCompra INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
iCodEmpleadoTrabajador INTEGER NOT NULL REFERENCES EMPLEADO,
dtFechaCompra DATETIME NOT NULL,
iCodProveedor INTEGER NOT NULL REFERENCES MAE_PROVEEDOR,
iTipoCompra INTEGER NOT NULL,
bDescuento BIT NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE COMPRA'
GO

/*COMPRA_DETALLE*/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME = 'COMPRA_DETALLE')
BEGIN
      DROP TABLE COMPRA_DETALLE
END

CREATE TABLE COMPRA_DETALLE
(
iCodDetalleCompra INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
iCodCompra INTEGER NOT NULL REFERENCES COMPRA,
iCodProducto INTEGER NOT NULL REFERENCES MAE_PRODUCTO,
iCantidad INTEGER NOT NULL,
nPrecio NUMERIC(7,2) NOT NULL,
iCodEmpleado INTEGER NOT NULL,
dtFechaRegistro DATETIME DEFAULT GETDATE(),
bActivo BIT DEFAULT 1
)
GO

PRINT 'TABLE COMPRA_DETALLE'
GO
----------------------------------------
PRINT 'INSERT DATA'
INSERT INTO [dbo].[MAE_PERSONA]([vNombre],[vApellido],[dtFechaNacimiento],[vTelefono],[vMail],[vDireccion],[vDocPersona],[iCodEmpleado],[dtFechaRegistro],[bActivo])
     VALUES('JERAL N.','BENITES GONZALES','1994-04-11 00:00:00','999900948','JeralBenites@gmail.com','luriwashintown','48610078',777,GETDATE(),1)

INSERT INTO [dbo].[MAE_CARGO](vNombreCargo,vPassword,iAcceso,iCodEmpleado)
	VALUES ('ADMIN1','ADMIN1',1,777)

INSERT INTO [dbo].[EMPLEADO](iCodPersona,iCodCargo)
	VALUES(1,1)
--------------------------------------------
PRINT 'PROCEDURE'
IF OBJECT_ID('[dbo].[SP_LOGIN]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[SP_LOGIN]
END
GO
CREATE PROCEDURE [dbo].[SP_LOGIN]
(
	@vUsuario VARCHAR(200),
	@vPassword VARCHAR(200)
)
AS
BEGIN
	DECLARE @iCount INTEGER
	SELECT 
		@iCount  = COUNT(iCodCargo)
	FROM
	[dbo].[MAE_CARGO]
	WHERE vNombreCargo =RTRIM(LTRIM(@vUsuario))
	AND  vPassword = RTRIM(LTRIM(@vPassword))
	IF(@iCount>0)
	BEGIN
		SELECT 1
	END
END
GO
PRINT 'PROCEDURE [dbo].[SP_LOGIN]' 
--------------------------------------------


--------------------------------------------
--CONSULTAS
--------------------------------------------
SELECT 
	EM.iCodEmpleado,
	PER.vNombre + ' ' +PER.vApellido [NombreApellido],
	CAR.vNombreCargo,
	CAR.vPassword
FROM [dbo].[EMPLEADO] EM
INNER JOIN [dbo].[MAE_PERSONA] PER
ON PER.iCodPersona = EM.iCodPersona
INNER JOIN  [dbo].[MAE_CARGO] CAR
ON CAR.iCodCargo = EM.iCodCargo
GO


