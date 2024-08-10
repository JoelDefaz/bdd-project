Create user master identified by master
Default tablespace users
Temporary tablespace temp
Profile default;
Grant connect, resource to master;
alter user master quota unlimited on users;