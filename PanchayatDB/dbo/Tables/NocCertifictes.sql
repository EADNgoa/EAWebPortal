CREATE TABLE [dbo].[NocCertifictes]
(
	[NocID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Hno] VARCHAR(50) NULL, 
    [No] VARCHAR(50) NULL, 
	[AprovedDate] DATE NULL,
    [PrintDate] DATE NULL,
    [Address] VARCHAR(200) NULL, 
    [PersonName] VARCHAR(100) NULL, 
    [ElectDeptAdd] VARCHAR(200) NULL, 
	[UserID] NVARCHAR(128) NUll,
    [WEBstatusID] INT NULL, 
    [RegisterTypeID] INT NULL, 
    CONSTRAINT [FK_NocCert_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [RegisterTypes]([RegisterTypeID]), 
    CONSTRAINT [FK_NocCert_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [WEBstatus]([WEBstatusID]), 
    CONSTRAINT [FK_NocCert_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])


)
