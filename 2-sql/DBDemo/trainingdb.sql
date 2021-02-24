--for sql server--
drop table batch;
drop table trainers;
drop table associates;
create table associates
(
	id int identity primary key,
	associateName nvarchar(100) not null,
	associateLocale varchar(2) not null,
	revaPoints int not null
);
create table trainers
(
	id int identity primary key,
	trainerName varchar(20) not null,
	campus varchar(3) not null,
	caffeineLevel int not null
);
create table batch
(
	id int identity primary key,
	associateID int references associates(id),
	trainerID int references trainers (id)
);