--Drop sequence for tables
drop table superpowers;
drop table heroes;
drop table elementTypes;

--creating tables
create table elementTypes
(
    id int identity primary key,
    elementType varchar(20) not null
);

create table heroes
(
    id int identity primary key,
    heroName varchar(100) not null,
    hp int not null,
    elementType int references elementTypes(id)
);

create table superpowers
(
    id int identity primary key,
    name varchar(50) not null,
    description varchar(100) not null,
	damage int not null,
    hero int unique not null references heroes(id) on delete cascade
);

--Adding seed data
insert into elementTypes (elementType) values 
('Water'), ('Earth'), ('Air'), ('Fire');

insert into heroes (heroName, hp, elementType) values
('Spiderman', 100, 2), ('Thor', 1000, 4);

insert into superpowers (name, description, damage, hero) values
('Spidey senses', 'Anything a spider can', 10, 1),
('Lightning control', 'Using a hammer as a conduit he controls lightning', 100, 2);

select * from heroes inner join superpowers on heroes.id = superpowers.hero;