CREATE db_TwitterPOC

CREATE TABLE tb_Users
(
ID_User int primary key identity,
Name nvarchar(50) not null,
Gender bit not null,
Username nvarchar(20) not null unique,
Pass nvarchar(100) not null,
Creation datetime not null,
LastAccess datetime not null,
Active bit not null
)

CREATE TABLE tb_Tweets
(
ID_Tweet int primary key identity,
ID_User int foreign key references tb_Users(ID_user),
Tweet nvarchar(150) not null,
Data datetime not null,
Active bit not null
)

CREATE TABLE tb_Follow (
 ID_Follow INT,
 ID_Follower INT,
 CONSTRAINT PK_Following PRIMARY KEY (ID_Follow, ID_Follower)
)
