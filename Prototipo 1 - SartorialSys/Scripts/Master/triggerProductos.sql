CREATE OR REPLACE TRIGGER audit_productos
AFTER DELETE OR INSERT OR UPDATE ON productos
FOR EACH ROW
declare
v_op varchar2(1);
v_tabla varchar2(50);
v_anterior varchar2(1500);
v_nuevo varchar2(1500);
BEGIN
v_tabla :='productos';
if inserting then
v_op := 'I';
elsif updating then
v_op := 'U';
elsif deleting then
v_op := 'D';
end if;
v_anterior:=:OLD.codigo_producto||'|'||:OLD.RUC_proveedor_fk||'|'||:OLD.descripcion||'|'||:OLD.cantidad_inicial||'|'||:OLD.precio_compra||'|'||:OLD.precio_venta||'|'||:OLD.fecha_ingreso||'|'||:OLD.categoria||'|'||:OLD.color||'|'||:OLD.talla;
v_nuevo:= :NEW.codigo_producto||'|'||:NEW.RUC_proveedor_fk||'|'||:NEW.descripcion||'|'||:NEW.cantidad_inicial||'|'||:NEW.precio_compra||'|'||:NEW.precio_venta||'|'||:NEW.fecha_ingreso||'|'||:NEW.categoria||'|'||:NEW.color||'|'||:NEW.talla;
INSERT INTO auditoria(user_name, fecha, tipo_operacion, nombre_table, anterior, nuevo)
VALUES (USER, SYSDATE,v_op,v_tabla, v_anterior,v_nuevo);
END;
/