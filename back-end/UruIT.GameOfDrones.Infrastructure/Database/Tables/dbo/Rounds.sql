IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[Rounds]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE AssessmentDB.dbo.Rounds
	END
GO

CREATE TABLE AssessmentDB.dbo.Rounds (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	MatchId int NOT NULL,
	PlayerId int NOT NULL,
	HandSignalId int NOT NULL,
	CONSTRAINT PK_Rounds PRIMARY KEY (Id)
) GO;
