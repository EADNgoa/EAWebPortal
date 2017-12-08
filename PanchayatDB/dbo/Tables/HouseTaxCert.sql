CREATE TABLE [dbo].[HouseTaxCert]
(
	[HouseTaxCertID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonName] VARCHAR(100) NULL, 
    [WardNo] VARCHAR(50) NULL, 
    [PersonAddress] VARCHAR(250) NULL, 
    [Tdate] DATE NULL, 
    [MeetingDate] DATE NULL, 
    [PrevPersonName] VARCHAR(100) NULL, 
    [Fees] INT NULL, 
    [DeveloperName] VARCHAR(100) NULL, 
    [DeveloperAddress] VARCHAR(250) NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [RegisterTypeID] INT NULL, 
    [WEBstatusID] INT NULL,
	 CONSTRAINT [FK_HouseTax_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_HouseTax_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WebStatusID]),
    CONSTRAINT [FK_HouseTax_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])

)
