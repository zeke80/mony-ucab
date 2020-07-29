---INSERTS DE ENTIDADES FIJAS---

--Estados generales:
--Estatus:
/*
1: activo
2: bloqueado - No puede realizar operaciones según su contexto
3: eliminado - No puede realizar operaciones ni ingresar a la plataforma según su contexto
4: inactivo - No se puede volver a usar
*/
select * from usuario;

--Estado Civil--
--Casado: C
--Soltero: S
DELETE FROM EstadoCivil CASCADE;
ALTER SEQUENCE EstadoCivil_idEstadoCivil_seq RESTART WITH 1;
INSERT INTO EstadoCivil (descripcion, codigo, estatus)
VALUES ('En relación matrimonial', 'C', 1),
('No está en una relación legal', 'S', 1);

DELETE FROM Banco CASCADE;
ALTER SEQUENCE Banco_idBanco_seq RESTART WITH 1;
INSERT INTO Banco (nombre, estatus)
VALUES ('Mercantil', 1),
('Banesco', 1),
('BBVA', 1),
('Banco del Tesoro', 1),
('Banco de Venezuela', 1),
('BDOE', 1),
('WEB', 1);

DELETE FROM TipoTarjeta CASCADE;
ALTER SEQUENCE TipoTarjeta_idTipoTarjeta_seq RESTART WITH 1;
INSERT INTO TipoTarjeta (descripcion, estatus)
VALUES ('Débito', 1),
('Crédito', 1),
('Débito-Electrónica', 1);

DELETE FROM TipoCuenta CASCADE;
ALTER SEQUENCE TipoCuenta_idTipoCuenta_seq RESTART WITH 1;
INSERT INTO TipoCuenta (descripcion, estatus)
VALUES ('Ahorro', 1),
('Corriente', 1),
('Monedero', 1);

--Tipos de parametro:
/*
-Monto Operacion: establece el límite del monto de cualquier operación.
-Monto Pago: establece el límite del monto para realizar un pago.
-Monto Recarga: establece el límite del monto para recargar el monedero.
-Monto Transferencia: establece el límite del monto para realizar transferencias entre sus medios.
-Cantidad Operaciones: establece el límite de operaciones generales que puede realizar.
-Recepción Monto: establece el límite de cantidad de monto que puede recibir en una sola operación.
-Recepción Transferencia: establece el límite de cantidad de transferencia que puede recibir en una sola operación
-Monto Acumulado: establece el límite de 
*/
DELETE FROM TipoParametro CASCADE;
ALTER SEQUENCE TipoParametro_idTipoParametro_seq RESTART WITH 1;
INSERT INTO TipoParametro (Descripcion, estatus)
VALUES ('Monto Pago', 1),
('Monto Recarga', 1),
('Monto Transferencia', 1),
('Cantidad Operaciones', 1),
('Recepción Monto', 1),
('Monto Acumulado', 1),
('Monto Acumulado Recepcion', 1);

DELETE FROM TipoUsuario CASCADE;
ALTER SEQUENCE TipoUsuario_idTipoUsuario_seq RESTART WITH 1;
INSERT INTO TipoUsuario (Descripcion, estatus)
VALUES ('Normal', 1);

DELETE FROM Frecuencia CASCADE;
ALTER SEQUENCE Frecuencia_idFrecuencia_seq RESTART WITH 1;
INSERT INTO Frecuencia (codigo, descripcion, estatus)
VALUES ('D','DAY', 1),
('S', 'WEEK', 1),
('M', 'MONTH', 1),
('A', 'YEAR', 1),
('H', 'HOUR', 1);

DELETE FROM Parametro CASCADE;
ALTER SEQUENCE Parametro_idParametro_seq RESTART WITH 1;
INSERT INTO Parametro(idFrecuencia, idTipoParametro, nombre, estatus)
VALUES (5,1,'Límite de pago por hora', 1),
(5,2,'Límite de recarga por hora', 1),
(5,3,'Límite de transferencia por hora', 1),
(1,4, 'Límite de operaciones durante un día', 1),
(2,4, 'Límite de operaciones durante una semana', 1),
(3,4, 'Límite de operaciones durante un mes', 1),
(4,4, 'Límite de operaciones durante un año', 1),
(5,4, 'Límite de operaciones durante una hora', 1),
(1,5, 'Límite de recepción de monto por hora', 1),
(1,7, 'Límite de recepción durante un día', 1),
(2,7, 'Límite de recepción durante una semana', 1),
(3,7, 'Límite de recepción durante un mes', 1),
(4,7, 'Límite de recepción durante un año', 1),
(5,7, 'Límite de recepcióndurante una hora', 1),
(1,6, 'Límite de recepción durante un día', 1),
(2,6, 'Límite de recepción durante una semana', 1),
(3,6, 'Límite de recepción durante un mes', 1),
(4,6, 'Límite de recepción durante un año', 1),
(5,6, 'Límite de recepcióndurante una hora', 1);

DELETE FROM TipoOperacion CASCADE;
ALTER SEQUENCE TipoOperacion_idTipoOperacion_seq RESTART WITH 1;
INSERT INTO TipoOperacion (descripcion, estatus)
VALUES ('Transferencia', 1),
('Recarga', 1),
('Retiro', 1),
('Cierre', 1);

--Estatus de Reintegro:
--'En Proceso': Se está ejecutando el pago. Si es fallido entonces vuelve a solicitado.
--'Consolidado': Se aprobó reintegro
--'Cancelado': No se aprobó reintegro
--'Caducado' : Cobro pro defecto
--'Solicitado': Se realizó la petición de reintegro.

--Estatus de Pago:
--'En Proceso'
--'Consolidado'
--'Cancelado'
--'Caducado' : Cobro por defecto.
--'Solicitado'

DELETE FROM Evento CASCADE;
ALTER SEQUENCE Evento_idEvento_seq RESTART WITH 1;
INSERT INTO Evento (codigo_evento, evento, estatus)
VALUES ('TRAT', 'Transferencia con tarjeta', 1),
('TRAC', 'Transferencia con Cuenta', 1),
('TRAM', 'Transferencia con Monedero', 1),
('PAGT', 'Pago con Tarjeta', 1),
('PAGC', 'Pago con Cuenta', 1),
('PAGM', 'Pago con Monedero', 1),
('RECC', 'Recarga con Cuenta', 1),
('RECT', 'Recarga con Tarjeta', 1),
('REIT', 'Reintegro Tarjeta', 1),
('REIC', 'Reintegro Cuenta',1 ),
('REIM', 'Reintegro Monedero', 1),
('ESTP', 'Establecer Parámetro', 1),
('INGU', 'Ingreso de Usuario', 1),
('CAMC', 'Cambio de contraseña', 1),
('REGU', 'Registro de usuario', 1),
('BLQU', 'Bloqueo de usuario', 2),
('REGT', 'Registro de Tarjeta', 1),
('REGC', 'Registro de Cuenta', 1),
('REGE', 'Registro de Empresa/Comercio', 1),
('REGP', 'Registro de Persona', 1),
('COBP', 'Cobro', 1),
('REIG', 'Reintegro', 1),
('COBC', 'Cobro cancelado', 1),
('REIC', 'Reintegro cancelado', 1),
('EJEC', 'Ejecución de Cierre', 1),
('MODU', 'Modificación de Usuario', 1),
('ELIT', 'Eliminar Tarjeta', 1),
('ELIC', 'Eliminar Cuenta', 1),
('ELIU', 'Eliminación de Usuario', 1),
('RETP', 'Retiro', 1);

DELETE FROM Aplicacion CASCADE;
ALTER SEQUENCE Aplicacion_idAplicacion_seq RESTART WITH 1;
INSERT INTO Aplicacion (nombre, descripcion, estatus)
VALUES ('Monedero', 'Medio para pagos rápidos', 1),
('Post Virtual', 'Medio para cobros por empresa', 1),
('Portal WEB', 'Combinación de Monedero y Post Virtual', 1);

DELETE FROM OpcionMenu CASCADE;
ALTER SEQUENCE OpcionMenu_idOpcionMenu_seq RESTART WITH 1;
--INSERT INTO OpcionMenu (idAplicacion, nombre, descripcion, url, posicion, estatus)

DELETE FROM TipoIdentificacion CASCADE;
ALTER SEQUENCE Tipoidentificacion_idTipoIdentificacion_seq RESTART WITH 1;
INSERT INTO TipoIdentificacion (codigo, descripcion, estatus)
VALUES ('J', 'Identificacion jurídica', 1),
('E', 'Identificacion Extranjera', 1),
('V', 'Identificacion Venezolana', 1),
('P', 'Identificacion Pasaporte', 1);