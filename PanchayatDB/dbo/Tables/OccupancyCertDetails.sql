CREATE TABLE [dbo].[OccupationCertDetails]
(
	[OccupationCertDetailsID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[OccupationCertificateID] INT NULL, 
    [FlatNo] VARCHAR(50) NULL, 
    [HouseNo] VARCHAR(50) NULL, 
    [HouseTax] DECIMAL(18, 2) NULL, 
    [GarbageTax] DECIMAL(18, 2) NULL, 
 
    [NameOfTheOwner] VARCHAR(100) NULL, 
    CONSTRAINT [FK_OccupancyCertDetails_occupancydetails] FOREIGN KEY ([OccupationCertificateID]) REFERENCES [OccupationCertificate]([OccupationCertificateID])
)
