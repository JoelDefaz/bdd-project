--Script para crear la tabla de auditoria
Create table auditoria
(user_name varchar2(25),
fecha date,
tipo_operacion varchar2(1),
nombre_table varchar2(50),
anterior varchar2(1500),
nuevo varchar2(1500));