CREATE DATABASE cdem

use cdem

CREATE TABLE documentos(
id int IDENTITY PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
extension varchar(5) NOT NULL,
fecha DATETIME NOT NULL,
users varchar(11) NOT NULL,
idcarpetas int NOT NULL,
FOREIGN KEY (users) REFERENCES usuarios(username),
FOREIGN KEY(idcarpetas) REFERENCES carpetas(idCarpeta)
);

select * from documentos
DELETE FROM documentos
select * from carpetas

ALTER TABLE documentos
DROP COLUMN tamano; 

CREATE TABLE usuarios(
username varchar(11) PRIMARY KEY NOT NULL,
contrasena varchar(30) NOT NULL
);

CREATE TABLE carpetas(
idCarpeta int IDENTITY PRIMARY KEY NOT NULL,
tipoCarpeta varchar(30) NOT NULL,
);

INSERT INTO usuarios(username,contrasena) values(1036865745,'banano12')
--cedula, cuentas de cobros, registro civil, factura
select * from usuarios

--PROC CARPETAS
INSERT INTO carpetas(tipoCarpeta) values('CEDUAL DE CIUDADANIA')

UPDATE carpetas SET tipoCarpeta='CEDULA DE CIUDADANIA' WHERE idCarpeta = 1

INSERT INTO carpetas(tipoCarpeta) values('CUENTA DE COBRO')
INSERT INTO carpetas(tipoCarpeta) values('FACTURA')
INSERT INTO carpetas(tipoCarpeta) values('OTROS')
INSERT INTO carpetas(tipoCarpeta) values('REGISTRO CIVIL')

--PROCEDIMIENTOS ALMACENADOS
CREATE PROC sp_ValidarUsuario
@user varchar(11),
@pass varchar(30)
as
begin
SELECT * FROM usuarios where username=@user and contrasena=@pass 
end

select * from documentos


EXECUTE spInsertar 'ejemplocedula','.pdf','1036865745','cedula'

CREATE PROC spInsertar
@nombreDocumento varchar(30),
@extension varchar(5),
@usuario varchar(12),
@idCarpeta int
AS
INSERT INTO documentos(nombre,extension,fecha,users,idcarpetas) VALUES(@nombreDocumento,@extension,GETDATE(),@usuario,@idCarpeta);

CREATE PROC spMostrarHistorial
AS
SELECT d.nombre NOMBRE_DOCUMENTO, d.fecha FECHA, u.username USUARIO, c.tipoCarpeta CARPETA
FROM ((documentos d
INNER JOIN usuarios u ON d.users = u.username)
INNER JOIN carpetas c ON d.idcarpetas = idCarpeta);