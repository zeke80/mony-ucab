--Operaciones de acción dentro de la plataforma
----Registro de usuario[x] Revisado e implementado
----Registro de usuario Persona[x] revisado e implementado
----Registro de usuario Comercio[x] revisado e implementado
----Registro Usuario_OpcionMenu[x] revisado e implementado
----Registro Cuenta[x] revisado e implementado
----Registro Tarjeta[x] revisado e implementado
----Extraer Datos fijos[X] revisado e implementado
----Extraer Datos dinámicos[x] revisado e implementado
----Establecer Parámetro[x]
----ExtraccionDatos[x]
-----DatosUsuario[x] revisado e implementado
------DatosComercio[x]
------DatosPersona[x]
------DatosTarjetas[x]
-----Tarjeta[x] revisado
-----Cuenta[x] revisado
-----HistorialOp[x]: revisado e implementado
------OperacionCuenta[x]
------OperacionesMonedero[x]
------OperacionTarjeta[x]
----ExigirCobro[x] revisado
----ExcigirReintegro[x] revisado
----OperaciónTarjeta revisado
-----Las operaciones de tarjeta son solo para pago y reintegro en conjunto con recarga. revisado

----------------PROCEDIMIENTOS Y FUNCIONES----------------
--Parametros: tipoUsuario, tipoIdentificacion, usuario, fecha_registro, nro_identificacion, email, telefono, direccion, estatus
--nombre/nombre_Representante
--apellido/apellido_representante
--contrasena
--'C': comercio
---razon_social default null
--'P': persona
---estadoCivil
---fecha_nacimiento

--Registros de usuario sobre items fijos para uso del usuario.
--//////Tarjeta, Cuenta, Usuario, Persona, Comercio, Parametro de usuario
--[x]
CREATE OR REPLACE FUNCTION Registro_Comercio(VARCHAR, VARCHAR, VARCHAR, INT, DOUBLE PRECISION)
										RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
entity_user_id text;
opcionMenuCurs CURSOR FOR SELECT A.* FROM OpcionMenu A JOIN Aplicacion B ON A.idAplicacion = B.idAplicacion WHERE (B.nombre = 'PostVirtual'
							OR B.nombre = 'PortalWeb') AND A.idOpcionMenu NOT IN (SELECT idOpcionMenu FROM Usuario_OpcionMenu WHERE idUsuario = $4);
BEGIN
		INSERT INTO Comercio (nombre_representante, apellido_representante, razon_social, idUsuario, comision)
				VALUES ($1,$2,$3,$4,$5);
		FOR opcion IN opcionMenuCurs LOOP
			INSERT INTO Usuario_OpcionMenu (idUsuario, idOpcionMenu, estatus) VALUES ($4, opcion.idOpcionMenu, 1);
		END LOOP;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (19, $4, CURRENT_DATE, CURRENT_TIME, 'Registro de razon social: ' || $3, '');
		RETURN TRUE;
END;
$$;
--[x]
CREATE OR REPLACE FUNCTION Registro_Persona(VARCHAR, VARCHAR, int, DATE, int)
										RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
entity_user_id text;
opcionMenuCurs CURSOR FOR SELECT A.* FROM OpcionMenu A JOIN Aplicacion B ON A.idAplicacion = B.idAplicacion WHERE (B.nombre = 'Monedero'
							OR B.nombre = 'PortalWeb') AND A.idOpcionMenu NOT IN (SELECT idOpcionMenu FROM Usuario_OpcionMenu WHERE Usuario_OpcionMenu.idUsuario = $5);
BEGIN
		INSERT INTO Persona (nombre, apellido,idEstadoCivil, fecha_nacimiento,idUsuario)
				VALUES ($1, $2, $3, $4, $5);
		FOR opcion IN opcionMenuCurs LOOP
			INSERT INTO Usuario_OpcionMenu (idUsuario, idOpcionMenu, estatus) VALUES ($5, opcion.idOpcionMenu, 1);
		END LOOP;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (20, $5, CURRENT_DATE, CURRENT_TIME, 'Registro de persona: ' || $1 || ' '||  $2 || ' ' || $4, '');
		RETURN TRUE;
END;
$$;
--[x]
--RegistroUsuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, @Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento)
CREATE OR REPLACE FUNCTION Registro_Usuario(INT, INT, VARCHAR, DATE, INT, VARCHAR, VARCHAR, VARCHAR, INT, CHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR DEFAULT NULL,
												INT DEFAULT NULL, DATE DEFAULT NULL, DOUBLE PRECISION DEFAULT NULL)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
response boolean;
entity_user_id text;
tipo_cuenta int;
numero_cuenta varchar:= $3 || 'MONEDERO';
numero_cuenta_P varchar:= $3 || 'PAYPAL';
numero_cuenta_S varchar:= $3 || 'STRIPE';
banco int;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE Usuario.email = $6 AND Usuario.estatus <> 1) THEN
		SELECT "Id" FROM "AspNetUsers" into entity_user_id WHERE "AspNetUsers"."UserName" = $3 or "AspNetUsers"."Email" = $6;
		IF entity_user_id IS NULL THEN
			RAISE EXCEPTION 'No existe el usuario registrado en Entity';
		END IF;
		INSERT INTO Usuario ("idEntity", idtipousuario,idtipoidentificacion,usuario,fecha_registro,nro_identificacion,email,telefono,direccion,estatus)
		VALUES (entity_user_id, $1, $2, $3, current_date, $5, $6, $7, $8, $9);
		SELECT IdUsuario FROM Usuario into usuario WHERE Usuario.usuario = $3;
		INSERT INTO CONTRASENA (idUsuario, contrasena, intentos_fallidos, estatus)
		VALUES
					(usuario, $13, 0, 1);
		IF ($10 = 'C') THEN
			SELECT Registro_Comercio($11,$12,$14,usuario, $17) INTO RESPONSE;
			IF NOT (RESPONSE) THEN
				RAISE EXCEPTION 'Error al intentar registrar el Comercio';
			END IF;
		ELSE
			SELECT Registro_Persona($11,$12,$15,$16,usuario) INTO RESPONSE;
			IF NOT (RESPONSE) THEN
				RAISE EXCEPTION 'Error al intentar registrar a la persona';
			END IF;
		END IF;
		SELECT idBanco FROM Banco into banco WHERE nombre = 'WEB';
		SELECT idTipoCuenta FROM TipoCuenta into tipo_cuenta WHERE TipoCuenta.descripcion = 'Monedero';
		SELECT Registro_Cuenta(usuario, tipo_cuenta, banco, numero_cuenta) INTO RESPONSE;
		IF NOT (RESPONSE) THEN
			RAISE EXCEPTION 'Error al intentar registrar el monedero';
		END IF;
		SELECT idTipoCuenta FROM TipoCuenta into tipo_cuenta WHERE TipoCuenta.descripcion = 'Paypal';
		SELECT Registro_Cuenta(usuario, tipo_cuenta, banco, numero_cuenta_P) INTO RESPONSE;
		IF NOT (RESPONSE) THEN
			RAISE EXCEPTION 'Error al intentar registrar el método pago PayPal';
		END IF;
		SELECT idTipoCuenta FROM TipoCuenta into tipo_cuenta WHERE TipoCuenta.descripcion = 'Stripe';
		SELECT Registro_Cuenta(usuario, tipo_cuenta, banco, numero_cuenta_S) INTO RESPONSE;
		IF NOT (RESPONSE) THEN
			RAISE EXCEPTION 'Error al intentar registrar el método pago Stripe';
		END IF;
	ELSE
			SELECT "Id" FROM "AspNetUsers" into entity_user_id WHERE "AspNetUsers"."UserName" = $3 or "AspNetUsers"."Email" = $6;
			UPDATE Usuario SET estatus = 1 and "idEntity" = entity_user_id WHERE Usuario.email = $6;
	END IF;
	INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (15, usuario, CURRENT_DATE, CURRENT_TIME, 'Registro de usuario: ' || $3 || ' '||  $6, '');
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Registro_Cuenta(INT, INT, INT, VARCHAR)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
		INSERT INTO Cuenta (idUsuario, idTipoCuenta, idBanco, numero) VALUES ($1, $2, $3, $4);
		RETURN TRUE;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (18, $1, CURRENT_DATE, CURRENT_TIME, 'Registro de cuenta: ' || $1 || ' ' ||$2|| ' ' ||$3|| ' ' ||$4, '');
END;
$$;
CREATE OR REPLACE FUNCTION Registro_Tarjeta(INT, INT, INT, BIGINT, DATE, INT, INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	numero_tarjeta int;
BEGIN
		SELECT Tarjeta.idTarjeta FROM Tarjeta into numero_tarjeta WHERE Tarjeta.numero = $4 AND Tarjeta.fecha_vencimiento = $5 AND Tarjeta.cvc = 6 AND Tarjeta.idBanco = $3;
		IF numero_tarjeta IS NOT NULL THEN
			UPDATE Tarjeta SET estatus = 1 WHERE Tarjeta.idTarjeta = numero_tarjeta;
		ELSE
			INSERT INTO Tarjeta (idUsuario, idTipoTarjeta, idBanco, numero, fecha_vencimiento, cvc, estatus) VALUES ($1, $2, $3, $4, $5, $6, $7);
		END IF;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (17, $1, CURRENT_DATE, CURRENT_TIME, 'Registro de cuenta: ' || $1|| ' ' ||$2|| ' ' ||$3|| ' ' ||$4, '');
		RETURN TRUE;
END;
$$;
CREATE OR REPLACE FUNCTION Establecer_Parametro(INT, INT, VARCHAR, INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
		IF NOT EXISTS (SELECT * FROM Usuario_Parametro A WHERE A.idUsuario = $1 AND A.idParametro = $2) THEN
			INSERT INTO Usuario_Parametro(idUsuario, idParametro, validacion, estatus) VALUES ($1, $2, $3, $4);
		ELSE
			UPDATE Usuario_Parametro SET Estatus = $4, Validacion = $3 WHERE idUsuario = $1 AND idParametro = $2;
		END IF;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (12, $1, CURRENT_DATE, CURRENT_TIME, 'Establecer parámetro: ' || $1|| ' ' ||$2|| ' ' ||$3|| ' ' ||$4, '');
		RETURN TRUE;
END;
$$;

--EXTRACCION DE DATOS FIJOS-- [x]
--Son los datos para llenar formularios por parte del usuario
CREATE OR REPLACE FUNCTION Estados_Civiles()
			RETURNS TABLE(idestadocivil int, descripcion varchar, codigo char, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM EstadoCivil;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Tarjeta()
			RETURNS TABLE(idtipotarjeta int, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoTarjeta;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Bancos()
			RETURNS TABLE(idbanco int, nombre varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Banco;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Cuentas()
			RETURNS TABLE(idtipocuenta int, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoCuenta;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Parametros()
			RETURNS TABLE(idtipoparametro int, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoParametro;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Frecuencias()
			RETURNS TABLE(idfrecuencia int, codigo char, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Frecuencia;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Parametros()
			RETURNS TABLE(idparametro int,idtipoparametro int,idfrecuencia_parametro int, nombre varchar, estatus_parametro int, limite varchar,
						  	idtipoparametro_tipo_parametro int, descripcion_tipo_parametro varchar, estatus_tipo_parametro int,
						  	idfrecuencia int, codigo_frecuencia char, descripcion_frecuencia varchar, estatus_frecuencia int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Parametro JOIN TipoParametro C ON C.IdTipoParametro = Parametro.idTipoParametro 
										  JOIN Frecuencia B ON B.IdFrecuencia = Parametro.idFrecuencia;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Operaciones()
			RETURNS TABLE(idtipooperacion int, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoOperacion;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Tipos_Identificaciones()
			RETURNS TABLE(idtipoidentificacion int, codigo char, descripcion varchar, estatus int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM TipoIdentificacion;
END
$BODY$
LANGUAGE plpgsql;
--////////////////////////////////////////////////////////////////////////////////////////////////

--//Extracción de datos sobre tablas dinámicas.
--//Todos los datos se exraen a través del parámetro de id de Usuario.
--//////////////////////////////////////////////////////////////////////////////////////////////////
--[x]
CREATE OR REPLACE FUNCTION Tarjetas(INT)
			RETURNS TABLE(idtarjeta int, idusuario int, idtipotarjeta_tarjeta int, idbanco_tarjeta int, numero bigint, fecha_vencimiento date, cvc int, estatus int, 
						 idbanco int, nombre_banco varchar, estatus_banco int,
						 idtipotarjeta int, descripcion_tipo_tarjeta varchar, estatus_tipo_tarjeta int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Tarjeta JOIN Banco ON Banco.idBanco = Tarjeta.idBanco 
										JOIN TipoTarjeta ON TipoTarjeta.idTipoTarjeta = Tarjeta.idTipoTarjeta WHERE Tarjeta.idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Historial_Operaciones_Tarjetas(INT)
			RETURNS TABLE(idoperaciontarjeta int, idtarjeta int, idusuarioreceptor int, fecha date, hora time, monto decimal, referencia varchar) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionTarjeta WHERE OperacionTarjeta.idTarjeta = $1 ORDER BY OperacionTarjeta.Fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Cuentas(INT)
			RETURNS TABLE(idcuenta int, idusuario int, idtipocuenta_cuenta int, idbanco_cuenta int, numero varchar, 
						 idbanco int, nombre_banco varchar, estatus_banco int,
						 idtipoCuenta int, descripcion_tipo_Cuenta varchar, estatus_tipo_Cuenta int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Cuenta JOIN Banco ON Banco.idBanco = Cuenta.idBanco
										JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta WHERE Cuenta.idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Historial_Operaciones_Cuenta(INT)
			RETURNS TABLE(idoperacionCuenta int, idCuenta int, idusuarioreceptor int, fecha date, hora time, monto decimal, referencia varchar) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionCuenta WHERE OperacionCuenta.idCuenta = $1 ORDER BY fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
CREATE OR REPLACE FUNCTION Historial_Operaciones_Monedero(INT)
			RETURNS TABLE(idoperacionesMonedero int, idusuario int, idtipoOperacion int, monto decimal, fecha date, hora time, referencia varchar,
						 idtipooperacion_tipo_operacion int, descripcion_tipo_operacion varchar, estatus_tipo_operacion int,
						 idoperaciontarjeta int, idtarjeta int, idusuarioreceptor_op_tarjeta int, fecha_op_tarjeta date, hora_op_tarjeta time, monto_op_tarjeta decimal, referencia_op_tarjeta varchar,
						 idoperacionCuenta int, idCuenta int, idusuarioreceptor_op_cuenta int, fecha_op_cuenta date, hora_op_cuenta time, monto_op_cuenta decimal, referencia_op_cuenta varchar) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM OperacionesMonedero JOIN TipoOperacion ON TipoOperacion.idTipoOperacion = OperacionesMonedero.idTipoOperacion
													LEFT JOIN OperacionTarjeta ON OperacionesMonedero.referencia = OperacionTarjeta.referencia
													LEFT JOIN OperacionCuenta ON OperacionesMonedero.referencia = OperacionCuenta.referencia
													WHERE OperacionesMonedero.idUsuario = $1 ORDER BY OperacionesMonedero.fecha DESC;
END
$BODY$
LANGUAGE plpgsql;
--REINTEGROS
--Segundo parámetro: 1 - Solicitante, 2 - Receptor
--[x]
CREATE OR REPLACE FUNCTION Reintegros_Activos(INT, INT)
			RETURNS TABLE(idreintegro int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, referencia_Reintegro varchar, referencia varchar, estatus varchar, monto varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud, 
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('En Proceso', 'Solicitado');
	ELSE 
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud,
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('En Proceso', 'Solicitado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Reintegros_Cancelados(INT, INT)
			RETURNS TABLE(idreintegro int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, referencia_Reintegro varchar, referencia varchar, estatus varchar, monto varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud, 
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('Cancelado', 'Caducado');
	ELSE
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud, 
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('Cancelado', 'Caducado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Reintegros_Exitosos(INT, INT)
			RETURNS TABLE(idreintegro int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, referencia_Reintegro varchar, referencia varchar, estatus varchar, monto varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud, 
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia  WHERE Reintegro.idUsuario_Solicitante = $1 AND Reintegro.estatus IN ('Consolidado');
	ELSE
		RETURN QUERY SELECT Reintegro.idReintegro, Reintegro.idusuario_solicitante, Reintegro.idusuario_receptor, Reintegro.fecha_solicitud,
							 COALESCE(Reintegro.referencia_reintegro, ''), COALESCE(Reintegro.referencia, ''), Reintegro.estatus , Pago.monto
							 FROM Reintegro JOIN Pago ON Pago.Referencia = Reintegro.Referencia WHERE Reintegro.idUsuario_Receptor = $1 AND Reintegro.estatus IN ('Consolidado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--Pago
--Segundo parámetro: 1 - Solicitante, 2 - Receptor
--[x]
CREATE OR REPLACE FUNCTION Cobros_Activos(INT, INT)
			RETURNS TABLE(idpago int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, monto varchar, estatus varchar, referencia varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('En Proceso', 'Solicitado');
	ELSE
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('En Proceso', 'Solicitado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Cobros_Cancelados(INT, INT)
			RETURNS TABLE(idpago int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, monto varchar, estatus varchar, referencia varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('Cancelado', 'Caducado');
	ELSE
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('Cancelado', 'Caducado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Cobros_Exitosos(INT, INT)
			RETURNS TABLE(idpago int, idusuario_solicitante int, idusuario_receptor int, fecha_solicitud date, monto varchar, estatus varchar, referencia varchar) AS $BODY$
DECLARE
BEGIN
	IF ($2 = 1) THEN
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Receptor = $1 AND Pago.estatus IN ('Consolidado');
	ELSE
		RETURN QUERY SELECT Pago.idPago, Pago.idusuario_solicitante, Pago.idusuario_receptor, Pago.fecha_solicitud, pago.monto,
							 	Pago.estatus, COALESCE(Pago.referencia, '')FROM Pago WHERE Pago.idUsuario_Solicitante = $1 AND Pago.estatus IN ('Consolidado');
	END IF;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Parametros_Usuario(INT)
			RETURNS TABLE(	idusuario int, idparametros int, validacion varchar, estatus int,
							idparametro int,idtipoparametro int,idfrecuencia_parametro int, nombre varchar, estatus_parametro int, limite varchar,
						  	idtipoparametro_tipo_parametro int, descripcion_tipo_parametro varchar, estatus_tipo_parametro int,
						  	idfrecuencia int, codigo_frecuencia char, descripcion_frecuencia varchar, estatus_frecuencia int) AS $BODY$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Usuario_Parametro A JOIN Parametro B ON B.idParametro = A.idParametro
													JOIN TipoParametro C ON C.idTipoParametro = B.idTipoParametro
													JOIN Frecuencia D ON D.idFrecuencia = B.idFrecuencia
													WHERE A.idUsuario = $1;
END
$BODY$
LANGUAGE plpgsql;

--Excepción de extracción de datos del usuario, se realiza por email.
--[x]
CREATE OR REPLACE FUNCTION Informacion_persona(VARCHAR)
			RETURNS TABLE(idusuario int, idtipousuario int, idtipoidentificacion_usuario int, "identity" text, usuario varchar, fecha_registro date, nro_identificacion int, email varchar, telefono varchar, direccion varchar, estatus int,idUsuarioF int,
						 	idusuario_persona int, idestadocivil int, nombre_persona varchar, apellido_persona varchar, fecha_nacimiento date,
						 	idusuario_comercio int, razon_social varchar, nombre_representante varchar, apellido_representante varchar, comision double precision,
						 	idtipoidentificacion int, codigo char, descripcion_tipo_identificacion varchar, estatus_tipo_identificacion int,
						 	idestadocivil_ec int, descripcion_ec varchar, codigo_ec char, estatus_ec int) AS $BODY$
DECLARE
	id_usuario int;
BEGIN
	BEGIN 
		SELECT cast($1 as int) INTO id_usuario;
	EXCEPTION
		WHEN Others THEN
			SELECT 0 into id_usuario;
	END;
	RETURN QUERY SELECT * FROM Usuario LEFT JOIN Persona ON Persona.idUsuario = Usuario.idUsuario
										LEFT JOIN Comercio ON Comercio.idUsuario = Usuario.idUsuario 
										LEFT JOIN TipoIdentificacion ON TipoIdentificacion.idTipoIdentificacion = Usuario.idTipoIdentificacion
										LEFT JOIN EstadoCivil ON EstadoCivil.idEstadoCivil = Persona.idEstadoCivil
										WHERE Usuario.email = $1 OR Usuario.usuario = $1 OR Usuario.idusuario = id_usuario;
END
$BODY$
LANGUAGE plpgsql;
--[x]
CREATE OR REPLACE FUNCTION Saldo_Monedero(INT)
			RETURNS DOUBLE PRECISION
LANGUAGE plpgsql		
AS $$
DECLARE
	Recargas decimal;
	Transferencias_Retiros decimal;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE Usuario.idUsuario = $1) THEN
			RAISE EXCEPTION 'No existe tal usuario';
	END IF;
	SELECT COALESCE(SUM(A.monto),0) FROM OperacionesMonedero A INTO Recargas JOIN TipoOperacion B ON B.idTipoOperacion = A.idTipoOperacion 
																		AND (B.descripcion = 'Recarga' OR B.descripcion = 'Recepción de transferencia')
																WHERE A.idUsuario = $1 AND A.referencia is not null;
	SELECT COALESCE(SUM(A.monto),0) FROM OperacionesMonedero A INTO Transferencias_Retiros JOIN TipoOperacion B ON B.idTipoOperacion = A.idTipoOperacion 
																		AND (B.descripcion = 'Transferencia' OR B.descripcion = 'Retiro') 
																WHERE A.idUsuario = $1 AND A.referencia is not null;
	RETURN Recargas - Transferencias_Retiros;
END;
$$;

--/////////PROCEDIMIENTOS DE LÓGICA//////////////////--
--Cobro de Comercio a Persona
--Parámetros: id del usuario que lo solicita, email del usuario que debe realizar el pago y el monto para realizar el procedimiento.
CREATE OR REPLACE FUNCTION Cobro(INT, VARCHAR, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Solicitante int;
BEGIN
		SELECT idUsuario FROM Usuario into idUsuario_Solicitante WHERE Usuario.email = $2 OR Usuario.usuario = $2;
		IF idUsuario_Solicitante IS NULL then
			RAISE EXCEPTION 'No existe ese usuario.';
		END IF;
		INSERT INTO Pago (idUsuario_Solicitante, idUsuario_Receptor, fecha_solicitud, monto, estatus, referencia)
		VALUES (idUsuario_Solicitante, $1, current_date, $3, 'Solicitado', NULL);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (21, $1, CURRENT_DATE, CURRENT_TIME, 'Cobrante: ' || $2 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (21, idUsuario_Solicitante, CURRENT_DATE, CURRENT_TIME, 'Siendo cobrado: ' || $2|| ' ' ||$3, '');
		RETURN TRUE;
END;
$$;
CREATE OR REPLACE FUNCTION Cancelar_Cobro(INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Solicitante_r int;
	idUsuario_Receptor_r int;
BEGIN
		IF NOT EXISTS (SELECT * FROM Pago WHERE Pago.idPago = $1) THEN
			RAISE EXCEPTION 'No existe tal usuario';
		END IF;
		SELECT idUsuario_Solicitante INTO idUsuario_Solicitante_r FROM Pago WHERE Pago.idPago = $1;
		SELECT idUsuario_Receptor INTO idUsuario_Receptor_r FROM Pago WHERE Pago.idPago = $1;
		UPDATE Pago SET estatus = 'Cancelado' WHERE idPago = $1;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (23, idUsuario_Solicitante_r, CURRENT_DATE, CURRENT_TIME, 'Cobro cancelado: ' || $1 , '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (23, idUsuario_Receptor_r, CURRENT_DATE, CURRENT_TIME, 'Cobro cancelado a recepcion: ' || $1 , '');
		RETURN TRUE;
END;
$$;

--Solicitud de reintegro a comercio
--Parámetros: id del usuario que solicita, email del usuario al que se le pide reintegro, referencia del proceso vinculado al pago.
CREATE OR REPLACE FUNCTION Reintegro(INT, VARCHAR, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Receptor int;
BEGIN
		SELECT idUsuario FROM Usuario into idUsuario_Receptor WHERE Usuario.email = $2 or Usuario.usuario= $2;
		IF idUsuario_Receptor IS NULL then
			RAISE EXCEPTION 'No existe ese usuario.';
		END IF;
		INSERT INTO Reintegro (idUsuario_Solicitante, idUsuario_Receptor, fecha_solicitud, estatus, referencia, referencia_reintegro)
		VALUES ($1, idUsuario_Receptor, current_date, 'Solicitado', $3, NULL);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (22, $1, CURRENT_DATE, CURRENT_TIME, 'Reintegro: ' || $2 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (22, idUsuario_Receptor, CURRENT_DATE, CURRENT_TIME, 'Ssiendo solicitado el reintegro: ' || $2 ||' ' ||$3, '');
		RETURN TRUE;
END;
$$;
CREATE OR REPLACE FUNCTION Cancelar_Reintegro(INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_Solicitante_r int;
	idUsuario_Receptor_r int;
BEGIN
		IF NOT EXISTS (SELECT * FROM Reintegro WHERE Reintegro.idReintegro = $1) THEN
			RAISE EXCEPTION 'No existe tal usuario';
		END IF;
		SELECT idUsuario_Solicitante INTO idUsuario_Solicitante_r FROM Reintegro WHERE Reintegro.idReintegro = $1;
		SELECT idUsuario_Receptor INTO idUsuario_Receptor_r FROM Reintegro WHERE Reintegro.idReintegro = $1;
		UPDATE Reintegro SET estatus = 'Cancelado' WHERE idReintegro = $1;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (24, idUsuario_Solicitante_r, CURRENT_DATE, CURRENT_TIME, 'Cobro cancelado: ' || $1 , '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (24, idUsuario_Receptor_r, CURRENT_DATE, CURRENT_TIME, 'Cobro cancelado a recepcion: ' || $1 , '');
		RETURN TRUE;
END;
$$;

-----------PAGOS---------------
--Estos pagos se realizan posterior a seleccionar un cobro generado por una empresa
--Pago con tarjeta
CREATE OR REPLACE FUNCTION Pago_Tarjeta(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	idUsuario_Pagante int;
	tipoOperacion int;
BEGIN
		referenciaValid:= ($1|| '' || current_date || '' || current_time || '' || $2);
		UPDATE Pago SET estatus = 'En proceso' WHERE Pago.idPago = $4;
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Tarjeta ON Tarjeta.idUsuario = Usuario.idUsuario AND Tarjeta.idTarjeta= $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		UPDATE Pago SET referencia = referenciaValid, estatus = 'Consolidado' WHERE idPago = $4;
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (4, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de pago' || $4 ||' ' ||$3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (4, idUsuario_Pagante, CURRENT_DATE, CURRENT_TIME, 'Pagador' || $4 ||' '|| $3 , '');
		RETURN TRUE;
END;
$$;
--Pago con cuenta
CREATE OR REPLACE FUNCTION Pago_Cuenta(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	idUsuario_Pagante int;
	tipoOperacion int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		UPDATE Pago SET estatus = 'En proceso' WHERE idPago = $4;
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Cuenta ON Cuenta.idUsuario = Usuario.idUsuario AND Cuenta.idCuenta = $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		UPDATE Pago SET referencia = referenciaValid, estatus = 'Consolidado' WHERE idPago = $4;
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (5, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de pago ' || $4|| ' ' ||$3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (5, idUsuario_Pagante, CURRENT_DATE, CURRENT_TIME, 'Pago realizado ' || $4 ||' ' ||$3 , '');
		RETURN TRUE;
END;
$$;
--Pago con Monedero
--Parámetros: IdUsuarioReceptor, IdUsuarioPago (el que realiza el pago), monto, idPago
CREATE OR REPLACE FUNCTION Pago_Monedero(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idCuentaMonedero int:= null;
	tipoOperacion int;
	referenciaValid varchar;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		UPDATE Pago SET estatus = 'En proceso' WHERE idPago = $4;
		SELECT Cuenta.idCuenta FROM Cuenta INTO idCuentaMonedero
							JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Monedero'
											WHERE Cuenta.idUsuario = $2;
		IF idCuentaMonedero IS NULL then
			RAISE EXCEPTION 'No existe esa cuenta.';
		END IF;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, idCuentaMonedero, current_date, current_time, $3, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($2, tipoOperacion, $3, current_date, current_time, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		UPDATE Pago SET referencia = referenciaValid, estatus = 'Consolidado' WHERE idPago = $4;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (6, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de pago ' || $4 ||' ' ||$3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (6, $2, CURRENT_DATE, CURRENT_TIME, 'Pago realizado por ' || $4 ||' ' ||$3 , '');
		RETURN TRUE;
END;
$$;

----------------------REINTEGROS--------------------------
CREATE OR REPLACE FUNCTION Reintegro_Tarjeta(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	idUsuario_Pagante int;
	tipoOperacion int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Tarjeta ON Tarjeta.idUsuario = Usuario.idUsuario AND Tarjeta.idTarjeta= $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		UPDATE Reintegro SET referencia_reintegro = referenciaValid, estatus = 'Consolidado' WHERE idReintegro = $4;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (9, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de pago ' || $4 ||' ' ||$3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (9, idUsuario_Pagante, CURRENT_DATE, CURRENT_TIME, 'Reintegro realizado ' || $4 ||' ' ||$3 , '');
		RETURN TRUE;
END;
$$;
--Pago con cuenta
CREATE OR REPLACE FUNCTION Reintegro_Cuenta(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	idUsuario_Pagante int;
	tipoOperacion int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Cuenta ON Cuenta.idUsuario = Usuario.idUsuario AND Cuenta.idCuenta = $2;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		UPDATE Reintegro SET referencia_reintegro = referenciaValid, estatus = 'Consolidado' WHERE idReintegro = $4;
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (10, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de reintegro ' || $4 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (10, idUsuario_Pagante, CURRENT_DATE, CURRENT_TIME, 'Reintegro realizado por ' || $4 ||' '|| $3 , '');
		RETURN TRUE;
END;
$$;
--Pago con Monedero
--Parámetros: IdUsuarioReceptor, IdUsuarioPago (el que realiza el pago), monto, idPago
CREATE OR REPLACE FUNCTION Reintegro_Monedero(INT, INT, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idCuentaMonedero int;
	referenciaValid varchar;
	tipoOperacion int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		UPDATE Reintegro SET estatus = 'En proceso' WHERE idReintegro = $4;
		SELECT Cuenta.idCuenta FROM Cuenta INTO idCuentaMonedero
							JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Monedero'
											WHERE Cuenta.idUsuario = $2;
		IF idCuentaMonedero IS NULL then
			RAISE EXCEPTION 'No existe esa cuenta.';
		END IF;
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, idCuentaMonedero, current_date, current_time, $3, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($2, tipoOperacion, $3, current_date, current_time, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		UPDATE Reintegro SET referencia_reintegro = referenciaValid, estatus = 'Consolidado' WHERE idReintegro = $4;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (11, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de reintegro ' || $4 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (11, $2, CURRENT_DATE, CURRENT_TIME, 'Reintegro realizado por' || $4 ||' '|| $3 , '');
		RETURN TRUE;
END;
$$;

--Recarga de Monedero por tarjeta
--IdUsuario, IdTarjeta, Monto
CREATE OR REPLACE FUNCTION Recarga_Monedero_Tarjeta(INT, INT, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	tipoOperacion int;
	idUsuario_Pagante int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Tarjeta ON Tarjeta.idUsuario = Usuario.idUsuario AND Tarjeta.idTarjeta= $2;
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recarga';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (7, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de recarga ' || $2 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (7, idUsuario_Pagante, CURRENT_DATE, CURRENT_TIME, 'Recarga realizada por ' || $2 ||' '|| $3 , '');
		RETURN TRUE;
END;
$$;

--Recarga de monedero por Cuenta
--IdUsuario, IdCuenta, Monto,
CREATE OR REPLACE FUNCTION Recarga_Monedero_Cuenta(INT, INT, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	tipoOperacion int;
	idUsuario_Pagante int;
BEGIN
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recarga';
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta(idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		SELECT Usuario.idUsuario INTO idUsuario_Pagante FROM Usuario JOIN Cuenta ON Cuenta.idUsuario = Usuario.idUsuario AND Cuenta.idCuenta = $2;
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (8, $1, CURRENT_DATE, CURRENT_TIME, 'Recepcion de recarga ' || $2 ||' '|| $3, '');
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (8, idUsuario_Pagante , CURRENT_DATE, CURRENT_TIME, 'Recarga realizada por ' || $2 ||' '|| $3 , '');
		RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Ejecutar_Cierre(INT)
												RETURNS TABLE(idoperacionesMonedero int, idusuario int, idtipoOperacion int, monto decimal, fecha date, hora time, referencia varchar,
						 idtipooperacion_tipo_operacion int, descripcion_tipo_operacion varchar, estatus_tipo_operacion int)
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	tarjetas CURSOR FOR SELECT *
						FROM Tarjeta A WHERE A.idUsuario = $1;
	cuentas CURSOR FOR SELECT *
						FROM Cuenta A WHERE A.idUsuario = $1;
	tipoOperacion int;
	Totalizacion_cuenta double precision;
	totalizacion_tarjeta double precision;
	op_limit_cuenta int;
	op_limit_tarjeta int;
	comision double precision;
BEGIN
		SELECT coalesce(Comercio.comision, 1) FROM Comercio into comision JOIN Usuario ON Usuario.idUsuario = Comercio.idUsuario WHERE Usuario.idUsuario = $1;
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '');
		FOR Tarjeta IN Tarjetas LOOP
			INSERT INTO OperacionTarjeta (idUsuarioReceptor, idTarjeta, fecha, hora, monto, referencia)
				VALUES ($1, Tarjeta.idTarjeta, current_date, current_time, 0, referenciaValid || 'TARJ' || Tarjeta.idTarjeta);
		END LOOP;
		FOR Cuenta IN Cuentas LOOP
			INSERT INTO OperacionCuenta(idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
				VALUES ($1, Cuenta.idCuenta, current_date, current_time, 0, referenciaValid || 'CUEN' || Cuenta.idCuenta);
		END LOOP;
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Cierre';
		SELECT COALESCE(OperacionCuenta.idOperacionCuenta,0) FROM OperacionCuenta into op_limit_cuenta
													JOIN OperacionesMonedero ON OperacionesMonedero.referencia = referenciaValid and OperacionCuenta.referencia = OperacionesMonedero.referencia || 'CUEN' ||OperacionCuenta.idCuenta
													WHERE OperacionesMonedero.idTipoOperacion = tipoOperacion ORDER BY OperacionCuenta.Fecha DESC LIMIT 1;
		SELECT COALESCE(OperacionTarjeta.idOperacionTarjeta, 0) FROM OperacionTarjeta into op_limit_tarjeta
													JOIN OperacionesMonedero ON OperacionesMonedero.referencia = referenciaValid and OperacionTarjeta.referencia = OperacionesMonedero.referencia || 'TARJ'||OperacionTarjeta.idTarjeta
													WHERE OperacionesMonedero.idTipoOperacion = tipoOperacion ORDER BY OperacionTarjeta.Fecha DESC LIMIT 1;
		SELECT SUM(COALESCE(OperacionCuenta.monto,0)) FROM OperacionCuenta INTO Totalizacion_Cuenta WHERE OperacionCuenta.idOperacionCuenta >COALESCE(op_limit_cuenta,0) AND OperacionCuenta.idUsuarioReceptor = $1;
		SELECT SUM(COALESCE(OperacionTarjeta.monto,0)) FROM OperacionTarjeta INTO Totalizacion_Tarjeta WHERE OperacionTarjeta.idOperacionTarjeta > COALESCE(op_limit_tarjeta,0) AND OperacionTarjeta.idUsuarioReceptor = $1;
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, COALESCE((Totalizacion_Cuenta + Totalizacion_Tarjeta)*comision/100, 0), current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (25, $1, CURRENT_DATE, CURRENT_TIME, 'Cierre Total: ' || coalesce((Totalizacion_Cuenta + Totalizacion_Tarjeta)*comision/100, 0), '');
		RETURN QUERY SELECT * FROM OperacionesMonedero JOIN TipoOperacion ON TipoOperacion.idTipoOperacion = OperacionesMonedero.idTipoOperacion
													WHERE OperacionesMonedero.referencia = referenciaValid ORDER BY OperacionesMonedero.fecha DESC;
END;
$$;

--/////////////////////////////////////////////Modificaciones y ediciones//////////////////////////////////////////////
--Modificación de datos perfil de usuario.
CREATE OR REPLACE FUNCTION Modificación_Usuario(VARCHAR , VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
response boolean;
entity_user_id text;
tipo_cuenta int;
banco int;
BEGIN
		IF NOT EXISTS (SELECT * FROM Usuario WHERE Usuario.idUsuario = $7) THEN
			RAISE EXCEPTION 'No existe tal usuario';
		END IF;
		UPDATE Usuario SET telefono=$3, direccion=$4 WHERE Usuario.idUsuario = $7;
		UPDATE Comercio SET nombre_representante = $1, apellido_representante = $2, Razon_Social = $5 WHERE Comercio.idUsuario = $7;
		UPDATE Persona SET nombre = $1, apellido = $2, idEstadoCivil=$6 WHERE Persona.idUsuario = $7;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (26, $7, CURRENT_DATE, CURRENT_TIME, 'Datos de modificación: ' || $1 ||' '|| $2 ||' '|| $3 ||' '|| $4 ||' '|| $5 ||' '|| $6, '');
		RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Eliminar_Tarjeta(INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_U int;
BEGIN
		IF NOT EXISTS (SELECT * FROM Tarjeta WHERE Tarjeta.idTarjeta = $1) THEN
			RAISE EXCEPTION 'No existe tal tarjeta';
		END IF;
		UPDATE Tarjeta SET estatus = 3 WHERE Tarjeta.idTarjeta = $1;
		SELECT Tarjeta.idUsuario INTO idUsuario_U FROM Tarjeta WHERE Tarjeta.idTarjeta = $1;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (27, idUsuario_U, CURRENT_DATE, CURRENT_TIME, 'Eliminacion de tarjeta: ' || $1, '');
		RETURN TRUE;
END;
$$;

--No válido
CREATE OR REPLACE FUNCTION Eliminar_Cuenta(INT)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	idUsuario_U int;
BEGIN
		IF NOT EXISTS (SELECT * FROM Cuenta WHERE Cuenta.idCuenta = $1) THEN
			RAISE EXCEPTION 'No existe tal cuenta';
		END IF;
		UPDATE Cuenta SET estatus = 3 WHERE Cuenta.idCuenta = $1;
		SELECT Cuenta.idUsuario INTO idUsuario_U FROM Cuenta WHERE Cuenta.idCuenta = $1;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (28, idUsuario_U, CURRENT_DATE, CURRENT_TIME, 'Eliminacion de Cuenta: ' || $1, '');
		RETURN TRUE;
END;
$$;

--Validación de lapso de DATE para los parámetros
--Parámetros: IdUsuario, idParámetro, 
CREATE OR REPLACE FUNCTION DATE_COMP(INT, INT, VARCHAR)
			RETURNS DATE
LANGUAGE plpgsql    
AS $$
DECLARE
	retorno DATE;
	parametrol text;
BEGIN
	SELECT coalesce(Usuario_Parametro.validacion, '0')|| ' ' || frecuencia.descripcion FROM Usuario_Parametro
			INTO parametrol
			JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
			JOIN Frecuencia ON Parametro.idFrecuencia = Frecuencia.idFrecuencia
			JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro AND TipoParametro.descripcion = $3
			WHERE Usuario_Parametro.idParametro = $2 AND USUARIO_PARAMETRO.idUsuario = $1;
	SELECT (current_date - cast(parametrol as interval)) FROM Usuario_Parametro
			INTO retorno
			JOIN Parametro ON Parametro.idParametro = Usuario_Parametro.idParametro
			JOIN Frecuencia ON Parametro.idFrecuencia = Frecuencia.idFrecuencia
			JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro AND TipoParametro.descripcion = $3
			WHERE Usuario_Parametro.idParametro = $2 AND USUARIO_PARAMETRO.idUsuario = $1;
	return retorno;
END;
$$;

CREATE OR REPLACE FUNCTION Comercio_Usuario(VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM Comercio JOIN Usuario ON Usuario.idUsuario = Comercio.idUsuario WHERE Usuario.Email = $1 OR Usuario.usuario = $1) THEN
		RETURN TRUE;
	END IF;
	RETURN FALSE;
END;
$$;

CREATE OR REPLACE FUNCTION Persona_Usuario(VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM Persona JOIN Usuario ON Usuario.idUsuario = Persona.idUsuario WHERE Usuario.Email = $1 OR Usuario.usuario = $1) THEN
		RETURN TRUE;
	END IF;
	RETURN FALSE;
END;
$$;

--Gestión de usuario
--Consulta de usuario
CREATE OR REPLACE FUNCTION Consultar_Usuarios(VARCHAR)
												RETURNS TABLE(idusuario int, idtipousuario int, idtipoidentificacion_usuario int, "identity" text, usuario varchar, fecha_registro date, nro_identificacion int, email varchar, telefono varchar, direccion varchar, estatus int, idusuariof int,
						 	idusuario_persona int, idestadocivil int, nombre_persona varchar, apellido_persona varchar, fecha_nacimiento date,
						 	idusuario_comercio int, razon_social varchar, nombre_representante varchar, apellido_representante varchar, comision double precision,
						 	idtipoidentificacion int, codigo char, descripcion_tipo_identificacion varchar, estatus_tipo_identificacion int,
						 	idestadocivil_ec int, descripcion_ec varchar, codigo_ec char, estatus_ec int)
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	RETURN QUERY execute format('SELECT * FROM Usuario LEFT JOIN Persona ON Persona.idUsuario = Usuario.idUsuario LEFT JOIN Comercio ON Comercio.idUsuario = Usuario.idUsuario LEFT JOIN TipoIdentificacion ON TipoIdentificacion.idTipoIdentificacion = Usuario.idTipoIdentificacion LEFT JOIN EstadoCivil ON EstadoCivil.idEstadoCivil = Persona.idEstadoCivil ' || $1);
END;
$$;

--Consulta de usuario familiar
CREATE OR REPLACE FUNCTION Consultar_Usuario_Familiar(INT)
												RETURNS TABLE(idusuario int, idtipousuario int, idtipoidentificacion_usuario int, "identity" text, usuario varchar, fecha_registro date, nro_identificacion int, email varchar, telefono varchar, direccion varchar, estatus int, idusuariof int,
						 	idusuario_persona int, idestadocivil int, nombre_persona varchar, apellido_persona varchar, fecha_nacimiento date,
						 	idusuario_comercio int, razon_social varchar, nombre_representante varchar, apellido_representante varchar, comision double precision,
						 	idtipoidentificacion int, codigo char, descripcion_tipo_identificacion varchar, estatus_tipo_identificacion int,
						 	idestadocivil_ec int, descripcion_ec varchar, codigo_ec char, estatus_ec int)
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	RETURN QUERY SELECT * FROM Usuario LEFT JOIN Persona ON Persona.idUsuario = Usuario.idUsuario
										LEFT JOIN Comercio ON Comercio.idUsuario = Usuario.idUsuario 
										LEFT JOIN TipoIdentificacion ON TipoIdentificacion.idTipoIdentificacion = Usuario.idTipoIdentificacion
										LEFT JOIN EstadoCivil ON EstadoCivil.idEstadoCivil = Persona.idEstadoCivil WHERE Usuario.idUsuarioF = $1;
END;
$$;

CREATE OR REPLACE FUNCTION Eliminar_Usuario(int)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	tipo_cuenta int;
	id_entity text;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE Usuario.idUsuario = $1) THEN
			RAISE EXCEPTION 'No existe tal usuario';
	END IF;
	SELECT Usuario.idEntity  into id_entity FROM Usuario WHERE Usuario.idUsuario = $1;
	SELECT idTipoCuenta FROM TipoCuenta into tipo_cuenta WHERE TipoCuenta.descripcion = 'Monedero';
	UPDATE Usuario SET estatus = 3 WHERE idUsuario = $1;
	UPDATE "AspNetUsers" SET lockoutEnd = date '2099-09-28' WHERE "Id" = id_entity;
	DELETE FROM Cuenta WHERE Cuenta.idTipoCuenta = tipo_cuenta and Cuenta.idUsuario = $1;
	INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (29, $1, CURRENT_DATE, CURRENT_TIME, 'Eliminacion de usuario: ' || $1, '');
	RETURN TRUE;
END;
$$;

--RegistroUsuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, @Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento)
CREATE OR REPLACE FUNCTION Registro_Usuario_F(INT, INT, VARCHAR, DATE, INT, VARCHAR, VARCHAR, VARCHAR, INT, CHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR,
												INT, DATE, INT, DOUBLE PRECISION)
												RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
usuario int;
response boolean;
entity_user_id text;
tipo_cuenta int;
numero_cuenta varchar:= $3 || 'MONEDERO';
banco int;
BEGIN
		SELECT "Id" FROM "AspNetUsers" into entity_user_id WHERE "AspNetUsers"."UserName" = $3 or "AspNetUsers"."Email" = $6;
		IF entity_user_id IS NULL THEN
			RAISE EXCEPTION 'No existe el usuario registrado en Entity';
		END IF;
		INSERT INTO Usuario ("idEntity", idtipousuario,idtipoidentificacion,usuario,fecha_registro,nro_identificacion,email,telefono,direccion,estatus, idUsuarioF)
		VALUES (entity_user_id, $1, $2, $3, current_date, $5, $6, $7, $8, $9, $17);
		SELECT IdUsuario FROM Usuario into usuario WHERE Usuario.usuario = $3;
		INSERT INTO CONTRASENA (idUsuario, contrasena, intentos_fallidos, estatus)
		VALUES
					(usuario, $13, 0, 1);
		IF ($10 = 'C') THEN
			SELECT Registro_Comercio($11,$12,$14,usuario, $18) INTO RESPONSE;
			IF NOT (RESPONSE) THEN
				RAISE EXCEPTION 'Error al intentar registrar el Comercio';
			END IF;
		ELSE
			SELECT Registro_Persona($11,$12,$15,$16,usuario) INTO RESPONSE;
			IF NOT (RESPONSE) THEN
				RAISE EXCEPTION 'Error al intentar registrar a la persona';
			END IF;
		END IF;
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (19, usuario, CURRENT_DATE, CURRENT_TIME, 'Registro de usuario: ' || $3, '');
		RETURN TRUE;
END;
$$;

--Establecer límite al parámetro
CREATE OR REPLACE FUNCTION Establecer_Límite_Parámetro(INT, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	UPDATE Parametro SET límite = $2 WHERE idParametro = $1;
	RETURN TRUE;
END;
$$;

--Definir porcentaje de comisión
CREATE OR REPLACE FUNCTION Establecer_Comision(INT, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	IF NOT EXISTS (SELECT * FROM Comercio WHERE Comercio.idUsuario = $1) THEN
			RAISE EXCEPTION 'No existe tal comercio';
	END IF;
	UPDATE Comercio SET comision = $2 WHERE idUsuario = $1;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION establecer_limite_parametro(integer, text)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	IF NOT EXISTS (SELECT * FROM Parametro WHERE Parametro.idParametro = $1) THEN
			RAISE EXCEPTION 'No existe tal parametro';
	END IF;
	UPDATE Parametro SET limite = $2 WHERE idParametro = $1;
	RETURN TRUE;
END;
$$;

--Retiro
CREATE OR REPLACE FUNCTION Retiro(INT, INT, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	referenciaValid varchar;
	tipoOperacion int;
BEGIN
		IF (NOT EXISTS (SELECT * FROM Comercio WHERE Comercio.idUsuario = $1)) THEN
			RAISE EXCEPTION 'No existe tal comercio';
		END IF;
		referenciaValid:= ($1 || '' || current_date || '' || current_time || '' ||$2);
		--Cuando se ejecuta el procedimiento de pago, se debe tener un numero de referencia por parte del e-commerce, por eso se cambia la referencia
		INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
			VALUES ($1, $2, current_date, current_time, $3, referenciaValid);
		SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Retiro';
		INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
			VALUES ($1, tipoOperacion, $3, current_date, current_time, referenciaValid);
		INSERT INTO Bitacora (idEvento, idUsuario, fecha, hora, datos_operacion, causa_error) VALUES (30, $1, CURRENT_DATE, CURRENT_TIME, 'Retiro con datos: ' || $2 ||' '|| $3, '');
		RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Boton_Pago_Cuenta(INT, VARCHAR, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	usuario int;
	cobro int;
	response bool;
BEGIN
	SELECT cobro($1,$2,$3) into response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el cobro';
	END IF;
	SELECT MAX(Pago.idPago) FROM Pago INTO cobro WHERE Pago.idUsuario_Receptor = $1;
	SELECT Usuario.idUsuario FROM Usuario INTO Usuario WHERE Usuario.usuario = $2 or Usuario.email = $2;
	SELECT Pago_Cuenta(usuario, $4, $3, cobro) into response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el pago';
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Boton_Pago_Tarjeta(INT, VARCHAR, DOUBLE PRECISION, INT)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	usuario int;
	cobro int;
	response bool;
BEGIN
	SELECT cobro($1,$2,$3) INTO response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el cobro';
	END IF;
	SELECT MAX(Pago.idPago) FROM Pago INTO cobro WHERE Pago.idUsuario_Receptor = $1;
	SELECT Usuario.idUsuario FROM Usuario INTO usuario WHERE Usuario.usuario = $2 or Usuario.email = $2;
	SELECT Pago_Tarjeta(usuario, $4, $3, cobro) INTO response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el pago';
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Boton_Pago_Monedero(INT, VARCHAR, DOUBLE PRECISION)
			RETURNS BOOLEAN
LANGUAGE plpgsql    
AS $$
DECLARE
	usuario int;
	cobro int;
	response bool;
BEGIN
	SELECT cobro($1,$2,$3) into response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el cobro';
	END IF;
	SELECT MAX(Pago.idPago) FROM Pago INTO cobro WHERE Pago.idUsuario_Receptor = $1;
	SELECT Usuario.idUsuario FROM Usuario INTO usuario WHERE Usuario.usuario = $2 or Usuario.email = $2;
	SELECT Pago_Monedero(usuario, $1, $3, cobro) into response;
	IF NOT (response) THEN
		RAISE EXCEPTION 'No se logró realizar el pago';
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Cambio_Estatus_Op (BOOLEAN, INT, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql
AS $$
DECLARE
	
BEGIN
	--Se realizó un pago
	IF ($1) THEN
		UPDATE Pago SET estatus = $3;
	--Se realizó un reintegro
	ELSE
		UPDATE Reintegro SET estatus = $3;
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Pago_Paypal (BOOLEAN, INT, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql
AS $$
DECLARE
	id_cuenta_paypal int;
	response bool;
	pago_reg Pago%rowtype;
	reintegro_reg Reintegro%rowtype;
	monto_reintegro double precision;
	tipoOperacion int;
BEGIN
	--Se realizó un pago
	IF ($1) THEN
		IF EXISTS (SELECT * FROM Pago WHERE Pago.idPago = $2) THEN
			SELECT * INTO pago_reg FROM Pago WHERE Pago.idPago = $2;
			SELECT Cuenta.idCuenta INTO id_cuenta_paypal FROM Cuenta JOIN Pago ON Pago.idUsuario_solicitante = Cuenta.idUsuario AND Pago.idPago = $2 JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Paypal';
			INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
				VALUES (pago_reg.idUsuario_Receptor, id_cuenta_paypal, current_date, current_time, cast(pago_reg.monto as DOUBLE PRECISION), $3);
			UPDATE Pago SET referencia = $3, estatus = 'Consolidado' WHERE idPago = $2;
			SELECT TipoOperacion.idTipoOperacion into tipoOperacion FROM TipoOperacion WHERE descripcion = 'Recepción de transferencia';
			INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
				VALUES (pago_reg.idUsuario_Receptor, tipoOperacion, cast(pago_reg.monto as DOUBLE PRECISION), current_date, current_time, $3);
		ELSE
			RAISE EXCEPTION 'No existe el pago indicado';
		END IF;
	--Se realizó un reintegro
	ELSE
		IF EXISTS (SELECT * FROM Reintegro WHERE Reintegro.idReintegro = $2) THEN
			SELECT * INTO reintegro_reg FROM Reintegro WHERE Reintegro.idReintegro = $2;
			SELECT coalesce(OperacionCuenta.monto,0) + coalesce(OperacionTarjeta.monto,0) into monto_reintegro FROM OperacionCuenta LEFT JOIN OperacionTarjeta ON OperacionTarjeta.referencia = reintegro_reg.referencia  WHERE OperacionCuenta.referencia = reintegro_reg.referencia;
			SELECT Cuenta.idCuenta INTO id_cuenta_paypal FROM Cuenta JOIN Reintegro ON Reintegro.idUsuario_solicitante = Cuenta.idUsuario AND Reintegro.idReintegro = $2 JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Paypal';
			INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
				VALUES (reintegro_reg.idUsuario_Receptor, id_cuenta_paypal, current_date, current_time, monto_reintegro , $3);
			UPDATE Reintegro SET referencia = $3, estatus = 'Consolidado' WHERE idReintegro = $2;
			SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
			INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
				VALUES (reintegro_reg.idUsuario_Receptor, tipoOperacion, cast(monto_reintegro as DOUBLE PRECISION), current_date, current_time, $3);
		ELSE
			RAISE EXCEPTION 'No existe el reintegro indicado';
		END IF;
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Pago_Stripe (BOOLEAN, INT, VARCHAR)
			RETURNS BOOLEAN
LANGUAGE plpgsql
AS $$
DECLARE
	id_cuenta_stripe int;
	response bool;
	pago_reg Pago%rowtype;
	reintegro_reg Reintegro%rowtype;
	monto_reintegro double precision;
	tipoOperacion int;
BEGIN
	--Se realizó un pago
	IF ($1) THEN
		IF EXISTS (SELECT * FROM Pago WHERE Pago.idPago = $2) THEN
			SELECT * INTO pago_reg FROM Pago WHERE Pago.idPago = $2;
			SELECT Cuenta.idCuenta INTO id_cuenta_stripe FROM Cuenta JOIN Pago ON Pago.idUsuario_solicitante = Cuenta.idUsuario AND Pago.idPago = $2 JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Stripe';
			INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
				VALUES (pago_reg.idUsuario_Receptor, id_cuenta_stripe, current_date, current_time, cast(pago_reg.monto as DOUBLE PRECISION), $3);
			UPDATE Pago SET referencia = $3, estatus = 'Consolidado' WHERE idPago = $2;
			SELECT TipoOperacion.idTipoOperacion into tipoOperacion FROM TipoOperacion WHERE descripcion = 'Recepción de transferencia';
			INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
				VALUES (pago_reg.idUsuario_Receptor, tipoOperacion, cast(pago_reg.monto as DOUBLE PRECISION), current_date, current_time, $3);
		ELSE
			RAISE EXCEPTION 'No existe el pago indicado';
		END IF;
	--Se realizó un reintegro
	ELSE
		IF EXISTS (SELECT * FROM Reintegro WHERE Reintegro.idReintegro = $2) THEN
			SELECT * INTO reintegro_reg FROM Reintegro WHERE Reintegro.idReintegro = $2;
			SELECT coalesce(OperacionCuenta.monto,0) + coalesce(OperacionTarjeta.monto,0) FROM OperacionCuenta into monto_reintegro LEFT JOIN OperacionTarjeta ON OperacionTarjeta.referencia = reintegro_reg.referencia  WHERE OperacionCuenta.referencia = reintegro_reg.referencia;
			SELECT Cuenta.idCuenta INTO id_cuenta_stripe FROM Cuenta JOIN Reintegro ON Reintegro.idUsuario_solicitante = Cuenta.idUsuario AND Reintegro.idReintegro = $2 JOIN TipoCuenta ON TipoCuenta.idTipoCuenta = Cuenta.idTipoCuenta AND TipoCuenta.descripcion = 'Stripe';
			INSERT INTO OperacionCuenta (idUsuarioReceptor, idCuenta, fecha, hora, monto, referencia)
				VALUES (reintegro_reg.idUsuario_Receptor, id_cuenta_stripe, current_date, current_time, cast(monto_reintegro as DECIMAL) , $3);
			UPDATE Reintegro SET referencia = $3, estatus = 'Consolidado' WHERE idReintegro = $2;
			SELECT TipoOperacion.idTipoOperacion FROM TipoOperacion into tipoOperacion WHERE descripcion = 'Recepción de transferencia';
			INSERT INTO OperacionesMonedero (idUsuario, idTipoOperacion, monto, fecha, hora, referencia)
				VALUES (reintegro_reg.idUsuario_Receptor, tipoOperacion, cast(monto_reintegro as DECIMAL), current_date, current_time, $3);
		ELSE
			RAISE EXCEPTION 'No existe el reintegro indicado';
		END IF;
	END IF;
	RETURN TRUE;
END;
$$;

CREATE OR REPLACE FUNCTION Opciones_Menu(INT)
												RETURNS TABLE(idOpcionMenu int, idAplicacion int, nombre varchar, descripcion varchar, url varchar, posicion int, estatus int)
LANGUAGE plpgsql    
AS $$
DECLARE
BEGIN
	RETURN QUERY SELECT A.* FROM OpcionMenu A JOIN Usuario_OpcionMenu B ON B.idUsuario = $1 AND A.idOpcionMenu = B.idOpcionMenu;
END;
$$;
