--Se crea el usuario para el lado de la replica

Create user replica1 identified by replica1
Default tablespace users
Temporary tablespace temp
Profile default;
Grant connect,resource to replica1;
Alter user replica1 quota unlimited on users;
Grant create database link to replica1;
Grant create any materialized view,query rewrite to replica1;