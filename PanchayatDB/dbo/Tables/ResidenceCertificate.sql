CREATE TABLE [dbo].[ResidenceCertificate]
(
	[ResidenceCertificateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonName] VARCHAR(100) NULL, 
    [BirthDate] DATE NULL, 
    [BirthPlace] VARCHAR(250) NULL, 
    [NameOfMother] VARCHAR(100) NULL, 
    [NameOfFather] VARCHAR(100) NULL, 
	[Since]                  int           NULL,

    [Address] VARCHAR(100) NULL, 
    [TDate] DATE NULL, 
    [FromDate] DATE NULL, 
    [TillDate] DATE NULL, 
    [IsDead] BIT NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [RegisterTypeID] INT NULL, 
    [WebStatusID] INT NULL, 
    CONSTRAINT [FK_ResidenceCertificate_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id]), 
    CONSTRAINT [FK_ResidenceCertificate_RegisterTypes] FOREIGN KEY ([RegisterTypeID]) REFERENCES [RegisterTypes]([RegisterTypeID]), 
    CONSTRAINT [FK_ResidenceCertificate_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [WEBstatus]([WEBstatusID])


)
