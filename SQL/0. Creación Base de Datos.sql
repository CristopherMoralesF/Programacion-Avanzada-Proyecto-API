USE MASTER
GO

DROP DATABASE IF EXISTS ASSET_MANAGEMENT
GO

CREATE DATABASE ASSET_MANAGEMENT
GO

USE ASSET_MANAGEMENT
GO

DROP TABLE IF EXISTS VALIDACION;
DROP TABLE IF EXISTS TIPO_VALIDACION; 
DROP TABLE IF EXISTS ASIENTO_LINEA; 
DROP TABLE IF EXISTS ASIENTO; 
DROP TABLE IF EXISTS ACTIVO; 
DROP TABLE IF EXISTS ESTADO; 
DROP TABLE IF EXISTS CLASE_CUENTA;
DROP TABLE IF EXISTS CUENTA_CONTABLE;
DROP TABLE IF EXISTS CATEGORIA_CUENTA;
DROP TABLE IF EXISTS CLASE;
DROP TABLE IF EXISTS USUARIO;
DROP TABLE IF EXISTS USUARIO_ROLE;
DROP TABLE IF EXISTS UBICACION;
DROP TABLE IF EXISTS EDIFICIO;
DROP TABLE IF EXISTS BITACORA_ERRORES
GO

CREATE TABLE EDIFICIO (
	ID_EDIFICIO				VARCHAR(20) CONSTRAINT PK_EDIFICIO PRIMARY KEY, 
	DESCRIPCION_EDIFICIO	VARCHAR(100) NOT NULL
)
GO

INSERT INTO EDIFICIO VALUES
	('CR-1','EDIFICIO PRINCIPAL'), 
	('CR-2','FABRICA PRINCIAL'), 
	('CR-3','BODEGAS')
GO

CREATE TABLE UBICACION(
	ID_UBICACION		INT IDENTITY CONSTRAINT PK_UBICACION PRIMARY KEY,
	ID_EDIFICIO			VARCHAR(20) NOT NULL,
	DESCRIPCION_SECCION	VARCHAR(50) NOT NULL,
	CONSTRAINT FK_EDIFICIO_UBICACION FOREIGN KEY (ID_EDIFICIO) REFERENCES EDIFICIO(ID_EDIFICIO)
); 

INSERT INTO UBICACION (ID_EDIFICIO,DESCRIPCION_SECCION) VALUES
	('CR-1','NOSSARA'),
	('CR-1','OCOTAL'),
	('CR-1','CONCHAL'),
	('CR-1','UVA'),
	('CR-1','ENSAMBLAJE'),
	('CR-1','PRUEBA'),
	('CR-1','BODEGA A'),
	('CR-1','BODEGA B'),
	('CR-1','BODEGA C')
GO

CREATE TABLE USUARIO_ROLE(
	ID_ROLE					INT IDENTITY CONSTRAINT PK_USUARIO_ROLE PRIMARY KEY, 
	NOMBRE_ROLE				VARCHAR(50), 
	DESCRIPCION_PERMISOS	VARCHAR(100)
); 
GO

INSERT INTO USUARIO_ROLE (NOMBRE_ROLE,DESCRIPCION_PERMISOS) VALUES
	('ADMIN','Permiso total'),
	('CONTADOR','Permiso solamente a editar informaci�n contable de activos existentes'),
	('TAGGER','Encargado de recopilar informaci�n cuantitativa del activo')
GO

CREATE TABLE USUARIO (
	ID_USUARIO			INT IDENTITY CONSTRAINT PK_USUARIO PRIMARY KEY, 
	NOMBRE				VARCHAR(50) NOT NULL, 
	CORREO				VARCHAR(50) NOT NULL, 
	CONTRASENNA			VARCHAR(50) NOT NULL, 
	ID_ROLE				INT NOT NULL,
	ESTADO				INT NOT NULL DEFAULT 1,
	ESTADO_CONTRASENNA	INT NOT NULL DEFAULT 1
	CONSTRAINT FK_ROLE_USUARIO FOREIGN KEY (ID_ROLE) REFERENCES USUARIO_ROLE(ID_ROLE)
)
GO

INSERT INTO USUARIO (NOMBRE,CORREO,CONTRASENNA,ID_ROLE) VALUES
	('Cristopher Morales','cmorale@asset_management.com','Cris123@',1),
	('Kimberly Morales','kmorale@asset_management.com','Cris123@',1),
	('Stephany Morales','smorale@asset_management.com','Cris123@',1),
	('Diego Lee','dlee@asset_management.com','Cris123@',1)
GO

CREATE TABLE CATEGORIA_CUENTA(
	ID_CATEGORIA			INT IDENTITY CONSTRAINT PK_CATEGORIA_CUENTA PRIMARY KEY, 
	DESCRIPCION_CATEGORIA	VARCHAR(50)
)
GO

INSERT INTO CATEGORIA_CUENTA (DESCRIPCION_CATEGORIA) VALUES
	('Activos'),
	('Pasivos'),
	('Capital'),
	('Ingresos'),
	('Gastos'),
	('Complementaria Activo')
GO

CREATE TABLE CUENTA_CONTABLE(
	ID_CUENTA			VARCHAR(15) NOT NULL CONSTRAINT PK_CUENTA_CONTABLE PRIMARY KEY, 
	DESCRIPCION_CUENTA	VARCHAR(50) NOT NULL,
	ID_CATEGORIA		INT NOT NULL, 
	TOTAL_DEBITOS		FLOAT DEFAULT 0, 
	TOTAL_CREDITOS		FLOAT DEFAULT 0, 
	BALANCE				FLOAT DEFAULT 0, 
	NATURALEZA			VARCHAR(1) NOT NULL, 
	CONSTRAINT FK_CUENTA_CATEGORIA FOREIGN KEY (ID_CATEGORIA) REFERENCES CATEGORIA_CUENTA(ID_CATEGORIA)
)
GO

INSERT INTO CUENTA_CONTABLE (ID_CUENTA,DESCRIPCION_CUENTA,ID_CATEGORIA,NATURALEZA) VALUES 
	/* Cuentas iniciales */
	('1-1-1-101392','Efectivo',1,'D'),
	('2-2-1-221105','Hipoteca por pagar LP',2,'D'),
	('3-1-1-100001','Capital Social',3,'D'),
	/* Cuentas de Activo Fijo */
	('1-2-2-167401','Activo Fijo - Vehiculos',1,'D'),
	('1-2-2-167402','Activo Fijo - Edificio',1,'D'),
	('1-2-2-167403','Activo Fijo - May y Equipo',1,'D'),
	('1-2-2-167404','Activo Fijo - Computadoras',1,'D'),
	('1-2-2-167405','Activo Fijo - Servidores',1,'D'),
	/* Depreciaci�n Acumulada */
	('6-2-3-167401','Dep Acumulada - Vehiculos',6,'D'),
	('6-2-3-167402','Dep Acumulada - Edificio',6,'D'),
	('6-2-3-167403','Dep Acumulada - May y Equipo',6,'D'),
	('6-2-3-167404','Dep Acumulada - Computadoras',6,'D'),
	('6-2-3-167405','Dep Acumulada - Servidores',6,'D'),
	/* Gasto por depreciaci�n */
	('5-2-2-167401','Gasto Depreciacion - Vehiculos',5,'D'),
	('5-2-2-167402','Gasto Depreciacion - Edificio',5,'D'),
	('5-2-2-167403','Gasto Depreciacion - May y Equipo',5,'D'),
	('5-2-2-167404','Gasto Depreciacion - Computadoras',5,'D')
GO

CREATE TABLE CLASE (
	ID_CLASE			INT IDENTITY CONSTRAINT PK_CLASE PRIMARY KEY,
	DESCRIPCION_CLASE	VARCHAR(50),
	VIDA_UTIL			INT
)
GO

INSERT INTO CLASE (DESCRIPCION_CLASE,VIDA_UTIL) VALUES
	('Vehiculos',10), 
	('Edificio',25),
	('Maquinaria y Equipo',5),
	('Computadoras',3)
GO

CREATE TABLE CLASE_CUENTA(
	ID_CLASE_CUENTA		INT IDENTITY CONSTRAINT PK_CLASE_CUENTA PRIMARY KEY, 
	ID_CLASE			INT NOT NULL, 
	ID_CUENTA			VARCHAR(15) NOT NULL, 
	ID_CATEGORIA_CUENTA	INT NOT NULL
	CONSTRAINT FK_CLASE_CLASECUENTA FOREIGN KEY (ID_CLASE) REFERENCES CLASE(ID_CLASE), 
	CONSTRAINT FK_CUENTA_CLASECUENTA FOREIGN KEY (ID_CUENTA) REFERENCES CUENTA_CONTABLE(ID_CUENTA), 
	CONSTRAINT FK_CATEGORIA_CLASECUENTA FOREIGN KEY (ID_CATEGORIA_CUENTA) REFERENCES CATEGORIA_CUENTA(ID_CATEGORIA)
)
GO

INSERT INTO CLASE_CUENTA (ID_CLASE,ID_CUENTA,ID_CATEGORIA_CUENTA) VALUES 
	/* Vehiculos */
	(1,'1-2-2-167401',1),
	(1,'5-2-2-167401',5),
	(1,'6-2-3-167401',6),
	/* Edificio */
	(2,'1-2-2-167402',1),
	(2,'5-2-2-167402',5),
	(2,'6-2-3-167402',6),
	/* Maquinaria y Equipo */
	(3,'1-2-2-167403',1),
	(3,'5-2-2-167403',5),
	(3,'6-2-3-167403',6),
	/* Computadoras */
	(4,'1-2-2-167404',1),
	(4,'5-2-2-167404',5),
	(4,'6-2-3-167404',6)
GO

CREATE TABLE ESTADO (
	ID_ESTADO			INT IDENTITY CONSTRAINT PK_ESTADO PRIMARY KEY, 
	DESCRIPCION_ESTADO	VARCHAR(50) NOT NULL
)
GO

INSERT INTO ESTADO (DESCRIPCION_ESTADO) VALUES 
	('Activo en Bodega'),
	('Activo en Construcci�n'),
	('Activo en Uso'),
	('Activo Deteriorado'),
	('Activo Donado')
GO

CREATE TABLE ACTIVO (
	ID_ACTIVO				INT IDENTITY CONSTRAINT PK_ACTIVO PRIMARY KEY, 
	ID_CLASE				INT NOT NULL,
	ID_UBICACION			INT NOT NULL,
	ID_DUENNO				INT NOT NULL,
	ID_ESTADO				INT NOT NULL,
	DESCRIPCION_ACTIVO		VARCHAR(50),
	VALOR_ADQUISICION		FLOAT NOT NULL, 
	FECHA_ADQUISICION		DATE, 
	PERIODOS_DEPRECIADOS	INT DEFAULT 0
	CONSTRAINT FK_ACTIVO_CLASE FOREIGN KEY (ID_CLASE) REFERENCES CLASE(ID_CLASE),
	CONSTRAINT FK_ACTIVO_UBICACION FOREIGN KEY (ID_UBICACION) REFERENCES UBICACION(ID_UBICACION),
	CONSTRAINT FK_ACTIVO_DUENNO FOREIGN KEY (ID_DUENNO) REFERENCES USUARIO (ID_USUARIO), 
	CONSTRAINT FK_ACTIVO_ESTADO FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO(ID_ESTADO)
)
GO

INSERT INTO ACTIVO (ID_CLASE,ID_UBICACION,ID_DUENNO,ID_ESTADO,DESCRIPCION_ACTIVO,VALOR_ADQUISICION,FECHA_ADQUISICION) VALUES
	(1,1,2,5,'Vehiculo de Carga',2500000,'2021-11-26'),
	(1,4,1,4,'Vehiculo de Carga',2500000,'2022-8-12'),
	(1,3,2,2,'Vehiculo de Transporte',8500000,'2020-7-19'),
	(1,4,3,4,'Vehiculo de Carga',2500000,'2021-3-5'),
	(1,6,2,2,'Vehiculo de Transporte',8500000,'2021-4-13'),
	(1,8,3,1,'Vehiculo de Transporte',8500000,'2021-12-10'),
	(1,6,3,4,'Vehiculo de Carga',2500000,'2021-10-23'),
	(1,3,3,3,'Camioneta Carga Pesada',15000000,'2022-9-4'),
	(1,9,3,1,'Vehiculo de Carga',2500000,'2021-12-3'),
	(1,2,3,5,'Camioneta Carga Pesada',15000000,'2021-6-16'),
	(2,7,3,1,'Edificio CR1',80000000,'2021-3-6'),
	(2,9,3,1,'Edificio CR2',12000000,'2020-3-25'),
	(2,3,2,4,'Edificio CR3',50000000,'2021-3-6'),
	(3,6,3,5,'Conector de Puertos',1927828,'2021-2-21'),
	(3,2,2,5,'Estacion de Trabajo',2495562,'2020-7-8'),
	(3,7,2,1,'Unidad de Disco Duro',2539884,'2022-7-19'),
	(3,3,3,5,'Servidor',341002,'2021-1-13'),
	(3,9,2,1,'Computadora de Escritorio',465271,'2022-1-19'),
	(3,6,1,2,'Equipo de Respaldo',1045209,'2021-8-2'),
	(3,8,1,1,'Fotocopiadora',1262467,'2020-5-23'),
	(3,1,1,3,'Equipo Almacen',1998602,'2021-5-26'),
	(3,6,1,4,'Equipo Informatico',1155408,'2020-9-9'),
	(3,3,3,5,'Osciloscopio',703717,'2021-1-11'),
	(4,6,3,3,'DELL i5570-5235SVL',450000,'2021-8-19'),
	(4,3,2,5,'DELL INSPIRON 13',550000,'2020-12-29'),
	(4,3,2,3,'DEL i5570-7117SVL',750000,'2022-9-20'),
	(4,3,2,2,'ASUS ROG STRIX',800000,'2021-6-4'),
	(4,8,1,1,'HP 15-DA0015LA',125000,'2020-10-10'),
	(4,2,2,2,'DELL i5570-5235SVL',450000,'2022-8-19'),
	(4,6,3,5,'DELL INSPIRON 13',550000,'2021-4-23'),
	(4,2,3,3,'DEL i5570-7117SVL',750000,'2020-7-3'),
	(4,2,1,4,'ASUS ROG STRIX',800000,'2022-6-10'),
	(4,7,3,1,'HP 15-DA0015LA',125000,'2020-2-11'),
	(4,2,1,4,'LENOVO THINKPAD',950000,'2022-6-10'),
	(4,7,3,1,'LENOVO LEGION',780000,'2020-2-11')
GO

DROP TABLE IF EXISTS ASIENTO_LINEA; 
DROP TABLE IF EXISTS ASIENTO; 
GO

CREATE TABLE ASIENTO (
	ID_ASIENTO		INT IDENTITY CONSTRAINT PK_ASIENTO PRIMARY KEY, 
	ID_CLASE		INT, 
	FECHA			DATE NOT NULL, 
	DESCRIPCION		VARCHAR(225) NOT NULL, 
	CONSTRAINT PK_ASIENTO_ACTIVO FOREIGN KEY (ID_CLASE) REFERENCES CLASE(ID_CLASE)
)
GO

CREATE TABLE ASIENTO_LINEA (
	ID_ASIENTO_LINEA		INT IDENTITY NOT NULL CONSTRAINT PK_ASIENTO_LINEA PRIMARY KEY, 
	ID_ASIENTO				INT NOT NULL, 
	ID_CUENTA_CONTABLE		VARCHAR(15) NOT NULL, 
	DESCRIPCION_LINEA		VARCHAR(255) NOT NULL, 
	DEBITO					FLOAT NOT NULL, 
	CREDITO					FLOAT NOT NULL,
	CONSTRAINT FK_ASIENTO_LINEA FOREIGN KEY (ID_ASIENTO) REFERENCES ASIENTO(ID_ASIENTO), 
	CONSTRAINT FK_ASIENTO_CUENTA FOREIGN KEY (ID_CUENTA_CONTABLE) REFERENCES CUENTA_CONTABLE(ID_CUENTA)
)
GO

------------------- Creaci�n Asiento de Capital ------------------- 
INSERT INTO ASIENTO (FECHA,DESCRIPCION) VALUES
	('2022-01-01','Adquisici�n de Capital de Trabajo'); 
GO

INSERT INTO ASIENTO_LINEA(ID_ASIENTO,ID_CUENTA_CONTABLE,DESCRIPCION_LINEA,DEBITO,CREDITO) VALUES
	(1,'1-1-1-101392','Aporte en efectivo socios',100000000,0),
	(1,'3-1-1-100001','Aporte en efectivo socios',0,100000000)
GO

/* Update account balances */
UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 100000000 WHERE ID_CUENTA = '1-1-1-101392';
UPDATE CUENTA_CONTABLE SET BALANCE = 100000000 WHERE ID_CUENTA = '1-1-1-101392'; 
UPDATE CUENTA_CONTABLE SET TOTAL_CREDITOS = 100000000 WHERE ID_CUENTA = '3-1-1-100001'; 
UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 100000000 WHERE ID_CUENTA = '3-1-1-100001'; 
GO

------------------- Creaci�n de Asiento de Adquisici�n ------------------- 
INSERT INTO ASIENTO (ID_CLASE,FECHA,DESCRIPCION) VALUES (4,'2022-01-02','Adquisici�n Inicial de Activos'); 

INSERT INTO ASIENTO_LINEA (ID_ASIENTO,ID_CUENTA_CONTABLE,DESCRIPCION_LINEA,DEBITO,CREDITO) VALUES 
	(2,'1-2-2-167404','Compra computadoras',7080000,0),
	(2,'1-2-2-167403','Compra maquinaria y equipo',13934950,0),
	(2,'1-2-2-167401','Compra Vehiculos',68000000,0),
	(2,'1-2-2-167402','Compra Edificios',142000000,0),
	(2,'1-1-1-101392','Compra Inicial de Activos',0,89014950),
	(2,'2-2-1-221105','Hipoteca - Compra Inicial Terrenos',0,142000000)
GO

UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 7080000 WHERE ID_CUENTA = '1-2-2-167404';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_DEBITOS - TOTAL_CREDITOS  WHERE ID_CUENTA = '1-2-2-167404';

UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 13934950 WHERE ID_CUENTA = '1-2-2-167403';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_DEBITOS - TOTAL_CREDITOS  WHERE ID_CUENTA = '1-2-2-167403';

UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 68000000 WHERE ID_CUENTA = '1-2-2-167401';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_DEBITOS - TOTAL_CREDITOS  WHERE ID_CUENTA = '1-2-2-167401';

UPDATE CUENTA_CONTABLE SET TOTAL_DEBITOS = 142000000 WHERE ID_CUENTA = '1-2-2-167402';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_DEBITOS - TOTAL_CREDITOS  WHERE ID_CUENTA = '1-2-2-167402';

UPDATE CUENTA_CONTABLE SET TOTAL_CREDITOS = 89014950 WHERE ID_CUENTA = '1-1-1-101392';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_DEBITOS - TOTAL_CREDITOS  WHERE ID_CUENTA = '1-1-1-101392';

UPDATE CUENTA_CONTABLE SET TOTAL_CREDITOS = 142000000 WHERE ID_CUENTA = '2-2-1-221105';
UPDATE CUENTA_CONTABLE SET BALANCE = TOTAL_CREDITOS - TOTAL_DEBITOS WHERE ID_CUENTA = '2-2-1-221105';
GO

CREATE TABLE TIPO_VALIDACION (
	ID_TIPO_VALIDACION			INT IDENTITY CONSTRAINT PK_VALIDACION PRIMARY KEY, 
	ID_CLASE					INT NOT NULL, 
	DESCRIPCION_VALIDACION		VARCHAR(60) NOT NULL, 
	CONSTRAINT FK_CLASE_VALIDACION FOREIGN KEY (ID_CLASE) REFERENCES CLASE (ID_CLASE)
)
GO

INSERT INTO TIPO_VALIDACION(ID_CLASE,DESCRIPCION_VALIDACION) VALUES 
	(1,'Placa Vehiculo'),
	(1,'Modelo Vehiculo'),
	(1,'Marcha Vehiculo'),
	(1,'Descripcion Ingles'),
	(1,'A�o Vehiculo'),
	(2,'Numero Documento'),
	(3,'Placa'),
	(3,'Factura'),
	(4,'Placa'),
	(4,'Factura')
GO

CREATE TABLE VALIDACION (
	ID_VALIDACION		INT IDENTITY NOT NULL CONSTRAINT PK_VALIDACION_ACTIVO PRIMARY KEY, 
	ID_TIPO_VALIDACION	INT NOT NULL, 
	ID_ACTIVO			INT NOT NULL, 
	VALOR				VARCHAR(255)
	CONSTRAINT FK_VALIDACION_TIPO FOREIGN KEY (ID_TIPO_VALIDACION) REFERENCES TIPO_VALIDACION(ID_TIPO_VALIDACION),
	CONSTRAINT FK_VALIDACION_ACTIVO FOREIGN KEY (ID_ACTIVO) REFERENCES ACTIVO (ID_ACTIVO)
)
GO

INSERT INTO VALIDACION (ID_TIPO_VALIDACION,ID_ACTIVO,VALOR) VALUES 
	(1,4,'CMF-024'),
	(2,4,'Ertiga'),
	(3,4,'Suzuki'),
	(4,4,'Car Suzuki Ertiga'),
	(5,4,'2022'),
	(1,5,'SMF-010'),
	(2,5,'Versa'),
	(3,5,'Nissan'),
	(4,5,'Car Nissan Versa'),
	(5,5,'2019')
GO

CREATE TABLE BITACORA_ERRORES(
	ID_ERROR		INT IDENTITY NOT NULL CONSTRAINT PK_BITACORA_ERRORES PRIMARY KEY, 
	PANTALLA		VARCHAR(255) NOT NULL, 
	ERROR			VARCHAR(255) NOT NULL,
	FECHA			DATETIME DEFAULT GETDATE(),
)

SELECT * FROM BITACORA_ERRORES; 

INSERT INTO BITACORA_ERRORES (PANTALLA, ERROR) VALUES ('Home','Test')

