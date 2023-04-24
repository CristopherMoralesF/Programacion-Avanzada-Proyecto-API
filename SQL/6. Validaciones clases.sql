CREATE OR ALTER VIEW VALIDACIONES_RESUMEN AS 
	SELECT
		V.ID_TIPO_VALIDACION,
		V.ID_CLASE,
		V.DESCRIPCION_VALIDACION,
		C.DESCRIPCION_CLASE
	FROM TIPO_VALIDACION V
	INNER JOIN CLASE C ON C.ID_CLASE = V.ID_CLASE
GO

SELECT * FROM VALIDACIONES_RESUMEN
GO

CREATE OR ALTER VIEW RESUMEN_VALIDACIONES_COMPLETAS AS
	SELECT 
		A.ID_ACTIVO,
		A.ID_CLASE,
		A.DESCRIPCION_ACTIVO,
		TV.ID_TIPO_VALIDACION,
		TV.DESCRIPCION_VALIDACION,
		V.VALOR
	FROM ACTIVO A
	RIGHT OUTER JOIN TIPO_VALIDACION TV ON TV.ID_CLASE = A.ID_CLASE
	LEFT OUTER JOIN VALIDACION V ON V.ID_TIPO_VALIDACION = TV.ID_TIPO_VALIDACION AND V.ID_ACTIVO = A.ID_ACTIVO
GO


SELECT * FROM RESUMEN_VALIDACIONES_COMPLETAS WHERE ID_ACTIVO = 4
GO



CREATE OR ALTER PROCEDURE ACTUALIZAR_INFORMACION_VALIDACION
	@IN_ID_ACTIVO			INT,
	@IN_ID_TIPO_VALIDACION	INT,
	@IN_VALOR_VALIDACION	VARCHAR(255)
AS
	UPDATE VALIDACION SET
		VALOR = @IN_VALOR_VALIDACION
	WHERE
		ID_TIPO_VALIDACION = @IN_ID_TIPO_VALIDACION AND ID_ACTIVO = @IN_ID_ACTIVO

GO
