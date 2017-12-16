CREATE TABLE [dbo].[CharacterCertificate]
(
	[CharacterID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonName] VARCHAR(100) NULL, 
    [Age] INT NULL, 
		 [Tdate] DATE NULL, 

    [FatherName] VARCHAR(100) NULL, 
    [MotherName] VARCHAR(100) NULL, 
    [Address] VARCHAR(200) NULL, 
    [WardOf] VARCHAR(100) NULL, 
    [KnownYears] INT NULL,
    [PurposeOf] VARCHAR(200) NULL, 

	[UserID] NVARCHAR(128) NUll,
    [WEBstatusID] INT NULL, 
    [RegisterTypeID] INT NULL, 
    CONSTRAINT [FK_Character_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [RegisterTypes]([RegisterTypeID]), 
    CONSTRAINT [FK_Character_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [WEBstatus]([WEBstatusID]), 
    CONSTRAINT [FK_character_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
