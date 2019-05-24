IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[Players]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		DROP TABLE AssessmentDB.dbo.Players
	END
GO

CREATE TABLE AssessmentDB.dbo.Players (
	Id int IDENTITY(1,1) NOT NULL,
	DataRegister datetime2(7) NOT NULL,
	Name nvarchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT PK_Players PRIMARY KEY (Id)
) GO;
