CREATE TABLE [dbo].[CertificateRequirements]
(
	[CertificateRequirementID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RegisterTypeID] INT NULL, 
    [CertificateName] VARCHAR(150) NULL
)
