CREATE TABLE [dbo].[ConstLicenseCert]
(
	[ConstLicenseID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OwnersOfHouse] VARCHAR(160) NULL, 
    [OwnwersAddress] VARCHAR(250) NULL, 

    [MeetingDated] DATE NULL, 
    [BuildingType ] VARCHAR(100) NULL, 
    [PropertyZone] VARCHAR(100) NULL, 
    [SurveyNo] VARCHAR(100) NULL, 
	[SubDivision] VARCHAR(50) NULL, 

    [OrderNo] VARCHAR(100) NULL, 
    [Tdate] DATE NULL, 
    [RefNo] VARCHAR(100) NULL, 
    [RefDate] DATE NULL, 
    [ValidUpTo] DATE NULL, 
    [RecieptNo] VARCHAR(100) NULL, 
    [RecieptDate] DATE NULL, 
	[DeveloperName] VARCHAR(100) NULL, 
    [DeveloperAddress] VARCHAR(250) NULL, 
    [ConstFees] DECIMAL(18, 2) NULL, 
    [SanitationFees] DECIMAL(18, 2) NULL,
	 [RegisterTypeID] INT NULL, 
    [WEBstatusID] INT NULL, 
    [UserID] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_ConstLicense_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_ConstLicense_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WebStatusID]),
    CONSTRAINT [FK_ConstLicense_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])

)
