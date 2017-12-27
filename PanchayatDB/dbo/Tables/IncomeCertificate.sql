CREATE TABLE [dbo].[IncomeCertificate]
(
	[IncomeCertificateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonName] VARCHAR(100) NULL, 
    [RelationName] VARCHAR(100) NULL, 
    [Address] VARCHAR(200) NULL, 
    [IncomeAmt] DECIMAL(18, 2) NULL, 
    [YearOf] VARCHAR(20) NULL, 
    [OfficeName] VARCHAR(100) NULL, 
    [PurposeOf] VARCHAR(150) NULL, 
    [Inquiry] VARCHAR(100) NULL, 
    [ReportNo] VARCHAR(50) NULL, 
    [InquiryDate] DATE NULL, 
    [Place] VARCHAR(50) NULL, 
    [PrintDate] DATE NULL,
	[UserID] NVARCHAR(128) NULL, 
    [RegisterTypeID] INT NULL, 
    [WEBstatusID] INT NULL,
	 CONSTRAINT [FK_Income_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_Income_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WebStatusID]),
    CONSTRAINT [FK_Income_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
)
