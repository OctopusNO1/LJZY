-- ������ռ䡢�û�
create tablespace LJZY_DATA datafile 'LJZY_DATA.dbf' size 1000m;
create user LJZY identified by 123456 default tablespace LJZY_DATA;
grant create session to LJZY;
alter user LJZY default tablespace LJZY_DATA quota 500 M on LJZY_DATA; -- Ȩ�ޣ�user��tablespace
grant dba to LJZY;

create tablespace KLRB datafile 'KLRB.dbf' size 1000m;
create user KLRB identified by 123456 default tablespace KLRB;
grant create session to KLRB;
alter user KLRB default tablespace KLRB quota 500 M on KLRB; -- Ȩ�ޣ�user��tablespace
grant dba to KLRB;

-- ע�⣺�˴���ռ���ΪKLLOG���û���ΪKLLOGT����Ϊ���ݿ��Ǵ�ǰ�����ﵼ������
create tablespace KLLOG datafile 'KLLOGT.dbf' size 1000m;
create user KLLOGT identified by 123456 default tablespace KLLOG;
grant create session to KLLOGT;
alter user KLLOGT default tablespace KLLOG quota 500 M on KLLOG; -- Ȩ�ޣ�user��tablespace
alter user KLRB default tablespace KLLOG quota 500 M on KLLOG; -- Ȩ�ޣ�user��tablespace

create tablespace KLSCZY datafile 'KLSCZY.dbf' size 1000m;
create user KLSCZY identified by 123456 default tablespace KLSCZY;
grant create session to KLSCZY;
alter user KLSCZY default tablespace KLSCZY quota 500 M on KLSCZY; -- Ȩ�ޣ�user��tablespace


