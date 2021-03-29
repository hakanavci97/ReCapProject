create database RentACar
 
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


Create Table Users(
Id int primary Key,
FirstName varchar(50),
LastName varchar(50),
Email varchar(50),
Password char(10)
)

Create Table Customers(
Id int primary key,
UserId int ,
CompanyName varchar(50)
)

Create Table Rentals(
Id int primary key,
CarId int,
CustomerId int,
RentDate datetime,
ReturnDate datetime
)
