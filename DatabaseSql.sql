use RentACar
create table Cars
(Id int primary key,
BrandId int,
colorId int,
ModelYear datetime,
DailyPrice decimal,
Description varchar(250))


create table Brands
(Id int primary key,
Name varchar(100))

create table Colors
(Id int primary key,
Name varchar(50))