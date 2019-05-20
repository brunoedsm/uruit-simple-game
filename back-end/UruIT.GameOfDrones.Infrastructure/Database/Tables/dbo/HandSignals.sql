-- Drop table

-- DROP TABLE AssessmentDB.dbo.HandSignals GO

CREATE TABLE AssessmentDB.dbo.HandSignals (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	Description nvarchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT PK_HandSignals PRIMARY KEY (Id)
) GO;
