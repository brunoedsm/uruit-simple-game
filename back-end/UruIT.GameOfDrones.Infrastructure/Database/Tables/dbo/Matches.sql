IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[Matches]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		 DROP TABLE AssessmentDB.dbo.Matches
	END
GO

CREATE TABLE AssessmentDB.dbo.Matches (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	CurrentRound int NOT NULL,
	CONSTRAINT PK_Matches PRIMARY KEY (Id)
) GO;
