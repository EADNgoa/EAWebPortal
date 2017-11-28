CREATE TABLE [dbo].[Citizen] (
    [CitizenID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (150) NULL,
    [Mobile]     VARCHAR (25)  NULL,
    [Email]      VARCHAR (30)  NULL,
    [ResAddress] VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([CitizenID] ASC)
);

