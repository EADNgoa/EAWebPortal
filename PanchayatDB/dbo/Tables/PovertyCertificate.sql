CREATE TABLE [dbo].[PovertyCertificate]
(
	[PovertyCertificateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RegisterTypeID] INT NULL, 
    [PersonName] VARCHAR(100) NULL,
	[OtherName] VARCHAR(100) NULL,
    [PersonAddress] VARCHAR(250) NULL, 
    [RequestedBy] VARCHAR(100) NULL, 
	[AddOfPerReqBy] VARCHAR(250) NULL,
	[UserID] NVARCHAR(128) NUll,
    [WEBstatusID] INT NULL, 
    CONSTRAINT [FK_PovertyCertificate_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [RegisterTypes]([RegisterTypeID]), 
    CONSTRAINT [FK_PovertyCertificate_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [WEBstatus]([WEBstatusID]), 
    CONSTRAINT [FK_PovertyCertificate_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
