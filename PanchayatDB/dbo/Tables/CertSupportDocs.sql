CREATE TABLE [dbo].[CertSupportDocs]
(
	[CertSupportDocsID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CertificateRequirementID] INT NULL, 
    [RegisterTypeID] INT NULL,
	[CertificateID] INT NULL, 
    [DocumentName] VARCHAR(50) NULL, 
)
