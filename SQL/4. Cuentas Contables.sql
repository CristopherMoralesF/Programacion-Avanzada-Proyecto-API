USE ASSET_MANAGEMENT
GO

CREATE OR ALTER VIEW ACCOUNTS_RESUME 
AS
	SELECT
		CC.ID_CUENTA, 
		CC.DESCRIPCION_CUENTA,
		CC.ID_CATEGORIA
	FROM CUENTA_CONTABLE CC
GO

SELECT * FROM ACCOUNTS_RESUME
GO

CREATE OR ALTER VIEW ACCOUNTS_BALANCE_RESUME AS
	SELECT
		CC.ID_CUENTA,
		CC.DESCRIPCION_CUENTA,
		CC.NATURALEZA,
		CAT.DESCRIPCION_CATEGORIA,
		CC.TOTAL_DEBITOS,
		CC.TOTAL_CREDITOS,
		CC.BALANCE
	FROM CUENTA_CONTABLE CC
	INNER JOIN CATEGORIA_CUENTA CAT ON CAT.ID_CATEGORIA = CC.ID_CATEGORIA
GO

SELECT * FROM ACCOUNTS_BALANCE_RESUME
GO

SELECT * FROM CLASE_CUENTA;
SELECT * FROM CLASE_CUENTA WHERE ID_CUENTA = '1-1-1-101392'; 