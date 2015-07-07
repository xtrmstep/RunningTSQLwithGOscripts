if exists (select * from sys.databases where name = 'RunningTSQLwithGOscriptsDB') return;

create database [RunningTSQLwithGOscriptsDB]
go

create table testTable1 (
	id int primary key,
	value varchar(128)
)
go