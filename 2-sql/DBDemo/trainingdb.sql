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

insert into associates (associateName, associateLocale, revaPoints) values 
('Joaquin', 'PA', -10), ('Madeline', 'WA', 10), ('Jacob', 'FL', 0), ('Michael', 'AZ', 20), ('Janel', 'AZ', 50), ('Angeleen', 'TX', 30), ('Warren', 'NH', 40);
insert into trainers (trainerName, campus, caffeineLevel) values
('Marielle', 'USF', 5), ('Pushpinder', 'UTA', 50), ('Nick', 'UTA', 75), ('Mark', 'WVU', 16), ('Fred', 'UTA', 25);
insert into batch (associateID, trainerID) values
(3,3), (1,1), (2,1), (4,1), (6,1), (7,1);