-- Drop table

-- DROP TABLE AssessmentDB.dbo.Matches GO

CREATE TABLE AssessmentDB.dbo.Matches (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	CurrentRound int NOT NULL,
	CONSTRAINT PK_Matches PRIMARY KEY (Id)
) GO;
