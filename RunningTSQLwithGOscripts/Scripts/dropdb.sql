if exists (select * from sys.databases where name = 'RunningTSQLwithGOscriptsDB')
drop database [RunningTSQLwithGOscriptsDB]
go