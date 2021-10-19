--create database BookStoreDB
--use BookStoreDB

create table Category
(
categoryId int identity,
categoryName varchar(30) not null,
categoryDesc varchar(100),
categoryImg varbinary(MAX),
categoryStatus bit not null,
categoryPosition int not null,
categoryCreatedAt datetime not null

constraint UK_categoryposition unique(categoryPosition),
constraint PK_Category primary key(categoryId)
);

create table Books(
   bookId int identity,
   categoryId int,
   title varchar(50) not null,
   ISBN int not null,
   [year] int not null,
   bookPrice float not null,
   bookDescription varch