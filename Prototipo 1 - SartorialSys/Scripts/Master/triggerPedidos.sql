CREATE OR REPLACE TRIGGER audit_pedidos
AFTER DELETE OR INSERT OR UPDATE ON pedidos
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='pedidos';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.codigo_ped||'|'||:OLD.cedula_cliente||'|'||:OLD.modelo||'|'||:OLD.total||'|'||:OLD.abonado||'|'||:OLD.saldo||'|'||:OLD.estado_pedido;
v_nuevo:= :NEW.codigo_ped||'|'||:NEW.cedula_cliente||'|'||:NEW.modelo||'|'||:NEW.total||'|'||:NEW.abonado||'|'||:NEW.saldo||'|'||:NEW.estado_pedido;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/