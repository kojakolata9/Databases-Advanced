
USE MinionsDB

CREATE TABLE Countries(
	Id int PRIMARY KEY NOT NULL,
	CountryName nvarchar(30) NOT NULL
)

CREATE TABLE Towns(
	Id int PRIMARY KEY NOT NULL,
	TownName nvarchar(30) NOT NULL,
	CountryId int,
	CONSTRAINT FK_CountryId FOREIGN KEY(CountryId) REFERENCES Countries(Id) 
)

CREATE TABLE Minions(
	Id int PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL,
	Age int,
	TownId int,
	CONSTRAINT FK_TownId FOREIGN KEY(TownId) REFERENCES Towns(Id)
)

CREATE TABLE Villains(
	Id int PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL,
	EvilnessFactor varchar(30) CHECK(EvilnessFactor IN('good','bad','evil','super evil'))
)

CREATE TABLE MinionsVillains(
	MinionId int NOT NULL,
	VillainId int NOT NULL,
	CONSTRAINT PK_MinionId_VillainId PRIMARY KEY(MinionId,VillainId),
	CONSTRAINT FK_MinionId FOREIGN KEY(MinionId) REFERENCES Minions(Id),
	CONSTRAINT FK_VillainId FOREIGN KEY(VillainId) REFERENCES Villains(Id)

)
INSERT INTO Countries
VALUES (1,'Bulgaria'),
(2,'Germany'),
(3,'England'),
(4,'Russia'),
(5,'Denmark')

INSERT INTO Towns
VALUES (1,'Sofia',1),
(2,'London',3),
(3,'Moscow',4),
(4,'Copenhagen',5),
(5,'Berlin',2)

INSERT INTO Minions
VALUES (1,'Gosho',12,3),
(2,'Pesho',17,1),
(3,'Tosho',16,5),
(4,'Misho',19,3),
(5,'Gisho',10,4)

INSERT INTO Villains
VALUES (1,'kaka','bad'),
(2,'tati','evil'),
(3,'mama','evil'),
(4,'bati','good'),
(5,'syseda','super evil')

INSERT INTO MinionsVillains
VALUES (1,3),
(2,5),
(3,4),
(5,1),
(4,2),
(5, 5),(3, 5),(4, 5),(2,3),(3,3)

