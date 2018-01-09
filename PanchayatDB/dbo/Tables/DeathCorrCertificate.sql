CREATE TABLE [dbo].[DeathCorrCertificate]
(
	[DeathCorrCertificateID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[BirthDeathName] VARCHAR(100) NULL, 

    [FromName] VARCHAR(100) NULL, 
    [FromAddress] VARCHAR(200) NULL, 
    [TDate] DATE NULL, 
    [BirthOf] VARCHAR(100) NULL, 
    [BornOn] DATE NULL, 
    [BirthPlace] VARCHAR(100) NULL, 
    [FromWrongName] VARCHAR(100) NULL, 
    [InsteadFWN] VARCHAR(100) NULL, 
    [NameOfFather] VARCHAR(100) NULL, 
    [InsteadNF] VARCHAR(100) NULL, 
    [NameOfMother] VARCHAR(100) NULL, 
    [InsteadNM] VARCHAR(100) NULL, 
    [NameOfGrandMother] VARCHAR(100) NULL, 
    [InsteadNGM] VARCHAR(100) NULL, 
    [NameOfGrandFather] VARCHAR(100) NULL, 
    [InsteadNGF] VARCHAR(50) NULL,
    [UserID] NVARCHAR(128) NULL, 
    [RegisterTypeID] INT NULL, 
    [WEBstatusID] INT NULL,
	 CONSTRAINT [FK_Death_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_Death_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WebStatusID]),
    CONSTRAINT [FK_Death_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
)
