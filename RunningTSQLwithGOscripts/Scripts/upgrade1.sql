alter table testTable1
	add value2 varchar(255)
go

create table testTable2 (
	id int primary key,
	value varchar(255)
)
go

alter table testTable2
	add value2 text
go
