-- Drop table

-- DROP TABLE AssessmentDB.dbo.Rounds GO

CREATE TABLE AssessmentDB.dbo.Rounds (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	MatchId int NOT NULL,
	PlayerId int NOT NULL,
	HandSignalId int NOT NULL,
	CONSTRAINT PK_Rounds PRIMARY KEY (Id)
) GO;
