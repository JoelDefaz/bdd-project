CREATE OR REPLACE TRIGGER audit_empl_1
AFTER DELETE OR INSERT OR UPDATE ON empleados_1
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='empleados_1';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.cedula_empleado||'|'||:OLD.nombres||'|'||:OLD.apellidos||'|'||:OLD.dir_domiciliaria||'|'||:OLD.email||'|'||:OLD.salario||'|'||:OLD.hora_entrada||'|'||:OLD.hora_almuerzo||'|'||:OLD.hora_salida;
v_nuevo:= :NEW.cedula_empleado||'|'||:NEW.nombres||'|'||:NEW.apellidos||'|'||:NEW.dir_domiciliaria||'|'||:NEW.email||'|'||:NEW.salario||'|'||:NEW.hora_entrada||'|'||:NEW.hora_almuerzo||'|'||:NEW.hora_salida;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/