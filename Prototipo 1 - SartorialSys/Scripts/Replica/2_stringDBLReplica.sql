--Se crea el String de Conexión
-- Luego se crea el database link

drop database link dbl_master;
create database link dbl_master
connect to master identified by master
using 'master';