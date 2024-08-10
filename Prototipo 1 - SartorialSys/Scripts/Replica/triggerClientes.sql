CREATE OR REPLACE TRIGGER audit_cli_guay
AFTER DELETE OR INSERT OR UPDATE ON clientes_guayaquil
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='clientes_guayaquil';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.cedula_cli||'|'||:OLD.nombres||'|'||:OLD.apellidos||'|'||:OLD.dir_domiciliaria||'|'||:OLD.email||'|'||:OLD.telefono||'|'||:OLD.canton;
v_nuevo:= :NEW.cedula_cli||'|'||:NEW.nombres||'|'||:NEW.apellidos||'|'||:NEW.dir_domiciliaria||'|'||:NEW.email||'|'||:NEW.telefono||'|'||:NEW.canton;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/