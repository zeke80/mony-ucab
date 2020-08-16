--Procedimientos de acciones principales
--A continuación se realizará la jerarquía de procedimientos o funciones.
--.................--
---.Registro Usuario
-----.Trigger validacion de registro
-----.Registro Comercio
-----.Registro Persona
-----.Registro de contacto dentro del comercio
--Validación de registro de comercio
DROP TRIGGER IF EXISTS validar_comercioT ON Comercio CASCADE;
CREATE OR REPLACE FUNCTION validar_comercio()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	/*IF NOT EXISTS (SELECT * FROM Persona WHERE idUsuario = new.idUsuario) THEN
		
		RAISE EXCEPTION 'El usuario no está registrado como persona para poder realizar el registro';
		RETURN NULL;
	END IF;*/
	IF EXISTS (SELECT * FROM Comercio WHERE razon_social = new.razon_social) THEN
		
		RAISE EXCEPTION 'Ya hay un comercio con la misma razón social';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Comercio WHERE idUsuario = new.idUsuario) THEN
		
		RAISE EXCEPTION 'Ya hay un registro de comercio para el usuario';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_comercioT
BEFORE INSERT
   ON Comercio
       FOR EACH ROW EXECUTE PROCEDURE validar_comercio();
	   
--Validación de registro de persona
DROP TRIGGER IF EXISTS validar_personaT ON Persona CASCADE;
CREATE OR REPLACE FUNCTION validar_persona()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM Persona WHERE idUsuario = new.idUsuario) THEN
		
		RAISE EXCEPTION 'Ya hay un registro de persona asignado al usuario';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_personaT
BEFORE INSERT
   ON Persona
       FOR EACH ROW EXECUTE PROCEDURE validar_persona();

--Validación de usuario
--Validación de registro de persona
DROP TRIGGER IF EXISTS validar_usuarioT ON Usuario CASCADE;
CREATE OR REPLACE FUNCTION validar_usuario()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM Usuario WHERE Usuario.email = new.email or Usuario.usuario = new.usuario ) THEN
		
		RAISE EXCEPTION 'Ya hay un registro de persona asignado al usuario';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_usuarioT
BEFORE INSERT
   ON Usuario
       FOR EACH ROW EXECUTE PROCEDURE validar_usuario();
	   
DROP TRIGGER IF EXISTS validar_usuario_opcionesT ON Usuario CASCADE;
CREATE OR REPLACE FUNCTION validar_usuario_opciones()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	opcionMenuCurs CURSOR FOR SELECT A.* FROM OpcionMenu A JOIN Aplicacion B ON A.idAplicacion = B.idAplicacion WHERE (B.nombre = 'Admin') 
								AND A.idOpcionMenu NOT IN (SELECT idOpcionMenu FROM Usuario_OpcionMenu WHERE Usuario_OpcionMenu.idUsuario = new.idUsuario);
BEGIN
	IF (new.idTipoUsuario = 2) THEN
		FOR opcion IN opcionMenuCurs LOOP
			INSERT INTO Usuario_OpcionMenu (idUsuario, idOpcionMenu, estatus) VALUES (new.idUsuario, opcion.idOpcionMenu, 1);
		END LOOP;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_usuario_opcionesT
BEFORE UPDATE
   ON Usuario
       FOR EACH ROW EXECUTE PROCEDURE validar_usuario_opciones();
	   
--Validación de registro de Tarjeta
DROP TRIGGER IF EXISTS validar_tarjetaT ON tarjeta CASCADE;
CREATE OR REPLACE FUNCTION validar_tarjeta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM tarjeta WHERE numero = new.numero and idBanco = new.idBanco and idTipoTarjeta = new.idTipoTarjeta and idUsuario = new.idUsuario) THEN
		
		RAISE EXCEPTION 'No puede registrar una tarjeta duplicada';
		RETURN NULL;
	END IF;
	IF current_date >= new.fecha_vencimiento THEN
		
		RAISE EXCEPTION 'No puede registrar una tarjeta vencida';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Banco WHERE new.idBanco = Banco.idBanco and Banco.estatus > 1) THEN
		
		RAISE EXCEPTION 'No puede registrar una tarjeta en un banco con estatus inválido';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_tarjetaT
BEFORE INSERT
   ON tarjeta
       FOR EACH ROW EXECUTE PROCEDURE validar_tarjeta();
	   
--Validación de registro de Cuenta
DROP TRIGGER IF EXISTS validar_cuentaT ON cuenta CASCADE;
CREATE OR REPLACE FUNCTION validar_cuenta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
BEGIN
	IF EXISTS (SELECT * FROM cuenta WHERE cuenta.numero = new.numero and cuenta.idBanco = new.idBanco and cuenta.idTipoCuenta = new.idTipoCuenta and cuenta.idUsuario = new.idUsuario) THEN
		
		RAISE EXCEPTION 'No puede registrar una cuenta duplicada';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Banco WHERE new.idBanco = Banco.idBanco and Banco.estatus > 1) THEN
		
		RAISE EXCEPTION 'No puede registrar una tarjeta en un banco de estatus inválido';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_cuentaT
BEFORE INSERT
   ON cuenta
       FOR EACH ROW EXECUTE PROCEDURE validar_cuenta();

--//////////////////////////////////////////////////////////////////////////////
--Validación de transaccion Tarjeta
DROP TRIGGER IF EXISTS validar_transaccionTarjetaT ON OperacionTarjeta CASCADE;
CREATE OR REPLACE FUNCTION validar_transaccionTarjeta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	fecha_límite DATE;
	cantidad int;
	monto_acum DECIMAL;
	parametros CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = A.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Frecuencia ON Frecuencia.idFrecuencia = Parametro.idFrecuencia
						JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta AND A.idUsuario = Tarjeta.idUsuario;
	parametros_destino CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = A.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Frecuencia ON Frecuencia.idFrecuencia = Parametro.idFrecuencia
						WHERE A.idUsuario = new.idUsuarioReceptor;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE idUsuario = new.idUsuarioReceptor) THEN
		
		RAISE EXCEPTION 'No hay un registro de usuario destino';
		RETURN NULL;
	END IF;
	IF NOT EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta) THEN
		
		RAISE EXCEPTION 'No hay un registro de tarjeta origen';
		RETURN NULL;
	END IF;
	IF NOT EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta and (estatus > 1 OR fecha_vencimiento >= current_date)) THEN
		IF EXISTS (SELECT * FROM Tarjeta WHERE idTarjeta = new.idTarjeta and (fecha_vencimiento >= current_date)) THEN
			UPDATE Tarjeta SET estatus = 4 WHERE idTarjeta = new.idTarjeta;
		END IF;
		
		RAISE EXCEPTION 'No hay estatus válido para la realización de operación o tarjeta vencida.';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Banco JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta AND Banco.idBanco = Tarjeta.idBanco
				  								WHERE Banco.estatus > 1) THEN
		UPDATE Tarjeta SET estatus = 4 WHERE idTarjeta = new.idTarjeta;
		
		RAISE EXCEPTION 'Banco en estatus inválido para permitir transacciones';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Usuario JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta AND Tarjeta.idUsuario = Usuario.idUsuario WHERE Usuario.estatus > 1)THEN
		
		RAISE EXCEPTION 'El usuario tiene un estatus inválido para realizar dichos procedimientos.';
		RETURN NULL;
	END IF;
	FOR parametro IN parametros LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Monto Transferencia') THEN
				IF new.monto > parametro.validacion THEN
					
					RAISE EXCEPTION 'Error de parámetro, monto de transferencia';
					RETURN NULL;
				END IF;
				
			END IF;
			IF (parametro.tipo_parametro = 'Cantidad Operaciones') THEN
				SELECT COUNT(OperacionTarjeta.*) FROM OperacionTarjeta into cantidad 
					JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta
					WHERE OperacionTarjeta.fecha >= fecha_límite;
				IF cantidad >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de operaciones';
					RETURN NULL;
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado') THEN
				SELECT SUM(OperacionTarjeta.monto) FROM OperacionTarjeta into monto_acum 
					JOIN Tarjeta ON Tarjeta.idTarjeta = new.idTarjeta
					WHERE OperacionTarjeta.fecha >= fecha_límite;
				IF monto_acum >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de monto acumulado';
					RETURN NULL;
				END IF;
			END IF;
		END IF;
	END LOOP;
	FOR parametro IN parametros_destino LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Recepción Monto') THEN
				IF new.monto > parametro.validacion THEN
					
					RAISE EXCEPTION 'Error de parámetro, recepción de monto';
					RETURN NULL;
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado Recepcion') THEN
				SELECT SUM(OperacionTarjeta.monto) FROM OperacionTarjeta into monto_acum
					WHERE OperacionTarjeta.fecha >= fecha_límite AND OperacionTarjeta.idUsuarioReceptor = new.idUsuarioReceptor;
				IF monto_acum >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de monto acumulado recibido';
					RETURN NULL;
				END IF;
			END IF;
		END IF;
	END LOOP;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_transaccionTarjetaT
BEFORE INSERT
   ON OperacionTarjeta
       FOR EACH ROW EXECUTE PROCEDURE validar_transaccionTarjeta();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de transaccion Cuenta
DROP TRIGGER IF EXISTS validar_transaccionCuentaT ON OperacionCuenta CASCADE;
CREATE OR REPLACE FUNCTION validar_transaccionCuenta()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	fecha_límite DATE;
	cantidad int;
	monto_acum DECIMAL;
	id_usuario int;
	tipo_cuenta varchar;
	parametros CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = A.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Frecuencia ON Frecuencia.idFrecuencia = Parametro.idFrecuencia
						JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta AND A.idUsuario = Cuenta.idUsuario;
	parametros_destino CURSOR FOR SELECT A.validacion as validacion, A.estatus as estatus, TipoParametro.descripcion as tipo_parametro, Frecuencia.descripcion as frecuencia,
						A.idUsuario as idUsuario, A.idParametro as idParametro
						FROM Usuario_Parametro A
						JOIN Parametro ON Parametro.idParametro = A.idParametro
						JOIN TipoParametro ON TipoParametro.idTipoParametro = Parametro.idTipoParametro
						JOIN Frecuencia ON Frecuencia.idFrecuencia = Parametro.idFrecuencia
						WHERE A.idUsuario = new.idUsuarioReceptor;
BEGIN
	IF NOT EXISTS (SELECT * FROM Usuario WHERE idUsuario = new.idUsuarioReceptor) THEN
		
		RAISE EXCEPTION 'No hay un registro de usuario destino';
		RETURN NULL;
	END IF;
	IF NOT EXISTS (SELECT * FROM Cuenta WHERE idCuenta = new.idCuenta) THEN
		
		RAISE EXCEPTION 'No hay un registro de cuenta origen';
	END IF;
	IF EXISTS (SELECT * FROM Banco JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta AND Banco.idBanco = Cuenta.idBanco
				  								WHERE Banco.estatus > 1) THEN
		UPDATE Cuenta SET estatus = 4 WHERE idCuenta = new.idCuenta;
		
		RAISE EXCEPTION 'Banco en estatus inválido para permitir transacciones';
		RETURN NULL;
	END IF;
	IF EXISTS (SELECT * FROM Usuario JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta AND Cuenta.idUsuario = Usuario.idUsuario WHERE Usuario.estatus > 1)THEN
		
		RAISE EXCEPTION 'El usuario tiene un estatus inválido para realizar dichos procedimientos.';
		RETURN NULL;
	END IF;
	SELECT idUsuario FROM Cuenta into id_usuario WHERE Cuenta.idCuenta = new.idCuenta;
	SELECT Saldo_Monedero(id_usuario) into monto_acum;
	SELECT descripcion FROM TipoCuenta into tipo_cuenta
		JOIN Cuenta ON TipoCuenta.idTipoCuenta= Cuenta.idTipoCuenta
		WHERE Cuenta.idCuenta = new.idCuenta AND Descripcion = 'Monedero';
	IF (new.monto > monto_acum AND tipo_cuenta = 'Monedero') THEN
		
		RAISE EXCEPTION 'Monto excede cantidad disponible, no se puede realizar el pago.';
		RETURN NULL;
	END IF;
	FOR parametro IN parametros LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Monto Transferencia') THEN
				IF new.monto > parametro.validacion THEN
					
					RAISE EXCEPTION 'Error de parámetro, monto de transferencia';
					RETURN NULL;
				END IF;
				
			END IF;
			IF (parametro.tipo_parametro = 'Cantidad Operaciones') THEN
				SELECT COUNT(OperacionCuenta.*) FROM OperacionCuenta into cantidad 
					JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta
					WHERE OperacionCuenta.fecha >= fecha_límite;
				IF cantidad >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de operaciones';
					RETURN NULL;
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado') THEN
				SELECT SUM(OperacionCuenta.monto) FROM OperacionCuenta into monto_acum 
					JOIN Cuenta ON Cuenta.idCuenta = new.idCuenta
					WHERE OperacionCuenta.fecha >= fecha_límite;
				IF monto_acum >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de monto acumulado';
					RETURN NULL;
				END IF;
			END IF;
		END IF;
	END LOOP;
	FOR parametro IN parametros_destino LOOP
    	IF (parametro.estatus = 1) THEN
			SELECT date_comp(parametro.idUsuario, parametro.idParametro, parametro.tipo_parametro) INTO fecha_límite;
			IF (parametro.tipo_parametro = 'Recepción Monto') THEN
				IF new.monto > parametro.validacion THEN
					
					RAISE EXCEPTION 'Error de parámetro, recepción de monto';
					RETURN NULL;
				END IF;
			END IF;
			IF (parametro.tipo_parametro = 'Monto Acumulado Recepcion') THEN
				SELECT SUM(OperacionCuenta.monto) FROM OperacionCuenta into monto_acum
					WHERE OperacionCuenta.fecha >= fecha_límite AND OperacionCuenta.idUsuarioReceptor = new.idUsuarioReceptor;
				IF monto_acum >= parametro.validacion THEN
					
					RAISE EXCEPTION 'Exceso de monto acumulado recibido';
					RETURN NULL;
				END IF;
			END IF;
		END IF;
	END LOOP;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_transaccionCuentaT
BEFORE INSERT
   ON OperacionCuenta
       FOR EACH ROW EXECUTE PROCEDURE validar_transaccionCuenta();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de Reintegro
DROP TRIGGER IF EXISTS validar_ReintegroT ON Reintegro CASCADE;
CREATE OR REPLACE FUNCTION validar_Reintegro()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	
BEGIN
	IF NOT EXISTS (SELECT * FROM OperacionCuenta WHERE referencia = new.referencia_reintegro) AND  
		NOT EXISTS (SELECT * FROM OperacionTarjeta WHERE referencia = new.referencia_reintegro) AND new.estatus = 'Consolidado' THEN
		
		RAISE EXCEPTION 'No hay referencia indicada para una operación';
		RETURN NULL;
	END IF;
	IF new.estatus = 'Solicitado' and new.referencia_reintegro is not null THEN
		RAISE EXCEPTION 'Reintegro inválido';
		RETURN NULL;
	END IF;
	IF new.estatus = 'Cancelado' and old.referencia_reintegro is not null THEN
		
		RAISE EXCEPTION 'Reintegro de pago inválido';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_ReintegroT
BEFORE INSERT OR UPDATE
   ON Reintegro
       FOR EACH ROW EXECUTE PROCEDURE validar_Reintegro();
	   
--//////////////////////////////////////////////////////////////////////////////
--Validación de Pago
DROP TRIGGER IF EXISTS validar_PagoT ON Pago CASCADE;
CREATE OR REPLACE FUNCTION validar_Pago()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	
BEGIN
	IF (NOT EXISTS (SELECT * FROM OperacionCuenta WHERE referencia = new.referencia) AND  
		NOT EXISTS (SELECT * FROM OperacionTarjeta WHERE referencia = new.referencia) ) AND new.estatus = 'Consolidado' THEN
		
		RAISE EXCEPTION 'No hay referencia indicada para una operación';
		RETURN NULL;
	END IF;
	IF new.estatus = 'Solicitado' and new.referencia is not null THEN
		
		RAISE EXCEPTION 'Pago inválido';
		RETURN NULL;
	END IF;
	IF new.estatus = 'Cancelado' and old.referencia is not null THEN
		
		RAISE EXCEPTION 'Cancelación de pago inválido';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_PagoT
BEFORE INSERT
   ON Pago
       FOR EACH ROW EXECUTE PROCEDURE validar_Pago();
	   
--//////////////////////////////////////////////////////////////////////
--Trigger de parámetros validación.
DROP TRIGGER IF EXISTS validar_ParametroT ON Usuario_Parametro CASCADE;
CREATE OR REPLACE FUNCTION validar_Parametro()
										RETURNS trigger
LANGUAGE plpgsql
AS $BODY$
DECLARE
	
BEGIN
	IF (new.validacion == '') THEN
		RAISE EXCEPTION 'Validación de parámetro inválido';
		RETURN NULL;
	END IF;
	RETURN NEW;
END;
$BODY$;

CREATE TRIGGER validar_ParametroT
BEFORE INSERT
   ON Usuario_Parametro
       FOR EACH ROW EXECUTE PROCEDURE validar_Parametro();

