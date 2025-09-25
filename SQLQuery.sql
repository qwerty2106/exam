create database Пробник_Асессорова;
use Пробник_Асессорова;

create table History(
	IDHistory int identity(1, 1) primary key,
	ServiceType nvarchar(255) not null,
	PartnerName nvarchar(255) not null,
	Count int not null,
	Date datetime  not null
);

create table Material(
	IDMaterial int identity(1, 1) primary key,
	Type nvarchar(255) not null,
	PartnerName nvarchar(255) not null,
	Outlay float not null,
);

create table Partners(
	IDPartner int identity(1, 1) primary key,
	PartnerType nvarchar(255) foreign key references PartnerTypes(Type),
	Name nvarchar(255) not null,
	Director nvarchar(255) not null,
	Email nvarchar(255) not null,
	Phone nvarchar(10) not null,
	Address nvarchar(255) not null,
	Inn nvarchar(10),
	Rating int not null,
);

create table PartnerTypes(
	Type nvarchar(255) primary key,
);

create table Services(
	ServiceType nvarchar(255) foreign key references ServiceTypes(Type),
	Name nvarchar(255) primary key,
	Code nvarchar(7) not null,
	Price float not null
);

create table ServiceTypes(
	Type nvarchar(255) primary key,
	Difficulty float not null 
);