CREATE TABLE [dbo].[Property] (
    [PropertyID]   INT           IDENTITY (1, 1) NOT NULL,
    [PropertyName] VARCHAR (100) NOT NULL,
    [Remarks]      VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([PropertyID] ASC)
);

