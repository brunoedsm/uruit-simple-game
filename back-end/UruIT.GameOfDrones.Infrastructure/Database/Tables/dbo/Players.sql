-- Drop table

-- DROP TABLE AssessmentDB.dbo.Players GO

CREATE TABLE AssessmentDB.dbo.Players (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	Name nvarchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT PK_Players PRIMARY KEY (Id)
) GO;
