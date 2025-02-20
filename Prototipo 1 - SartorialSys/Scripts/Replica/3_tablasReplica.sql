--TABLA FRAGMENTADA
CREATE TABLE proveedores_guayaquil(
    ruc VARCHAR(13) PRIMARY KEY,
    nombre VARCHAR2(100) NOT NULL,
    direccion VARCHAR2(100) NOT NULL,
    telefono VARCHAR2(10) UNIQUE NOT NULL,
    email VARCHAR2(100) UNIQUE NOT NULL,
    tipo_proveedor VARCHAR2(20) NOT NULL,
    sucursal VARCHAR2(25) NOT NULL
);
alter table proveedores_guayaquil add constraint proveedores_guayaquil_ck check(sucursal='Guayaquil');

--VISTA MATERIALIZADA
CREATE MATERIALIZED VIEW PRODUCTOS_REP
REFRESH FAST ON DEMAND
START WITH TO_DATE('29-07-2023 11:28:00', 'DD-MM-YYYY HH24:MI:SS')
NEXT SYSDATE + 15/86400
AS
SELECT * FROM productos@dbl_master;

--TABLA FRAGMENTADA
CREATE TABLE clientes_guayaquil (
    cedula_cli VARCHAR(10) PRIMARY KEY,
    nombres VARCHAR2(100) NOT NULL,
    apellidos VARCHAR2(100) NOT NULL,
    dir_domiciliaria VARCHAR2(100) NOT NULL,
    email VARCHAR2(100) NOT NULL,
    telefono VARCHAR2(10) NOT NULL,
    canton VARCHAR2(25) NOT NULL
);
alter table clientes_guayaquil add constraint clientes_guayaquil_ck check(canton='Daule');

--VISTA MATERIALIZADA
CREATE MATERIALIZED VIEW PEDIDOS_REP
REFRESH FAST ON DEMAND
START WITH TO_DATE('29-07-2023 11:28:00', 'DD-MM-YYYY HH24:MI:SS')
NEXT SYSDATE + 15/86400
AS
SELECT * FROM pedidos@dbl_master;

--TABLA FRAGMENTADA
CREATE TABLE empleados_2 (
    cedula_empleado VARCHAR(10) PRIMARY KEY,
    nombres VARCHAR2(100) NOT NULL,
    apellidos VARCHAR2(100) NOT NULL,
    dir_domiciliaria VARCHAR2(100) NOT NULL,
    email VARCHAR2(100) UNIQUE NOT NULL,
    salario NUMBER(10, 2) NOT NULL,
    hora_entrada VARCHAR2(5) UNIQUE NOT NULL,
    hora_almuerzo VARCHAR2(5) UNIQUE NOT NULL,
    hora_salida VARCHAR2(5) UNIQUE NOT NULL
);
alter table empleados_2 add constraint empleados_2_ck check(salario<=450);

--VISTA MATERIALIZADA
CREATE MATERIALIZED VIEW credenciales_REP
REFRESH FAST ON DEMAND
START WITH TO_DATE('29-07-2023 11:28:00', 'DD-MM-YYYY HH24:MI:SS')
NEXT SYSDATE + 15/86400
AS
SELECT * FROM credenciales@dbl_master;

CREATE TABLE facturas(
    num_factura VARCHAR2(12) NOT NULL PRIMARY KEY,
    cedula_cliente VARCHAR2(10) NOT NULL,
    cedula_empleado VARCHAR2(10) NOT NULL,
    fecha_venta DATE NOT NULL,
    metodo_pago VARCHAR2(15) NOT NULL,
    estado_pago NUMBER NOT NULL,
    CONSTRAINT cedula_cliente_fk_facturas FOREIGN KEY (cedula_cliente) REFERENCES clientes_guayaquil(cedula_cli),
    CONSTRAINT cedula_empleado_fk_facturas FOREIGN KEY (cedula_empleado) REFERENCES empleados_2(cedula_empleado)
);

CREATE TABLE items(
    codigo_pedido VARCHAR(10),
    codigo_producto VARCHAR(10),
    num_factura VARCHAR2(12) NOT NULL,
    cantidad NUMBER NOT NULL,
    CONSTRAINT codigo_pedido_fk FOREIGN KEY (codigo_pedido) REFERENCES pedidos_rep(codigo_ped),
    CONSTRAINT codigo_producto_fk_items FOREIGN KEY (codigo_producto) REFERENCES productos_rep(codigo_producto),
    CONSTRAINT numero_factura_fk FOREIGN KEY (num_factura) REFERENCES facturas(num_factura)
);
