create database TiendaComics;
use TiendaComics;

create table Comic(
id int primary key, 
numepisodio int,
nombre varchar(30),
tipocomic varchar (30),
costo decimal,
editorial varchar(30),
foto varchar(30)
);

insert into Comic values (1,3,'Venom Carnage','Pasta Blanda',29.00,'MarvelCOMICSMX','venomcarnage.jpg');
insert into Comic values (2,1,'Venomverse','Pasta Dura',300.00,'MarvelCOMICSMX','venomverse.jpg');
insert into Comic values (3,6,'Batman: La broma asesina','Pasta Blanda',30.00,'MarvelCOMICSMX','bromaasesina.jpg');
insert into Comic values (4,2,'Batman Who Laughs','Pasta Blanda',40.50,'MarvelCOMICSMX','batman.jpg');
insert into Comic values (5,4,'Infinity Gauntlet','Pasta Dura',350.00,'Caligrama Editores','infinity.jpg');
insert into Comic values (6,9,'Spider-Verse','Pasta Dura',320,'MarvelCOMICSMX','spideverse.jpg');
insert into Comic values (7,3,'Crisis en Tierras Infinitas','Pasta Blanda',29.00,'MarvelCOMICSMX','crisis.jpg');
insert into Comic values (8,2,'Flashpoint','Pasta Blanda',29.00,'MarvelCOMICSMX','flashpoint.jpg');
insert into Comic values (9,1,'Old Man Logan','Pasta Dura',300.00,'MarvelCOMICSMX','logan.jpg');
insert into Comic values (10,5,'The Killing Joke','Pasta Blanda',29.50,'La Caja de Cerillos','joke.jpg');
