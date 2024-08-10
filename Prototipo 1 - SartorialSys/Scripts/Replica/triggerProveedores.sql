CREATE OR REPLACE TRIGGER audit_prov_guayaquil
AFTER DELETE OR INSERT OR UPDATE ON proveedores_guayaquil
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='proveedores_guayaquil';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.ruc||'|'||:OLD.nombre||'|'||:OLD.direccion||'|'||:OLD.telefono||'|'||:OLD.email||'|'||:OLD.tipo_proveedor||'|'||:OLD.sucursal;
v_nuevo:= :NEW.ruc||'|'||:NEW.nombre||'|'||:NEW.direccion||'|'||:NEW.telefono||'|'||:NEW.email||'|'||:NEW.tipo_proveedor||'|'||:NEW.sucursal;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/