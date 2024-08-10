CREATE OR REPLACE TRIGGER audit_credenciales
AFTER DELETE OR INSERT OR UPDATE ON credenciales
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='credenciales';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.usuario||'|'||:OLD.contrasenia||'|'||:OLD.cedula_empleado||'|'||:OLD.rol;
v_nuevo:= :NEW.usuario||'|'||:NEW.contrasenia||'|'||:NEW.cedula_empleado||'|'||:NEW.rol;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/