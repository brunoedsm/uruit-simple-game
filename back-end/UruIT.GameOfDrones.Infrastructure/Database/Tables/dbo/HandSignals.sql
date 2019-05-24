IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[HandSignals]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		 DROP TABLE AssessmentDB.dbo.HandSignals
	END
GO

CREATE TABLE AssessmentDB.dbo.HandSignals (
	Id bigint IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	Description nvarchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT PK_HandSignals PRIMARY KEY (Id)
) GO;
