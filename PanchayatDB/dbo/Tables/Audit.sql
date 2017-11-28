CREATE TABLE [dbo].[Audit] (
    [AuditID]              INT           IDENTITY (1, 1) NOT NULL,
    [AuditNo]              INT           NULL,
    [ListOfAuditObjection] VARCHAR (MAX) NULL,
    [ActionsTaken]         VARCHAR (MAX) NULL,
    [Year]                 INT           NULL,
    PRIMARY KEY CLUSTERED ([AuditID] ASC)
);

