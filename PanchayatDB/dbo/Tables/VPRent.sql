CREATE TABLE [dbo].[VPRent] (
    [VPRentID]           INT           IDENTITY (1, 1) NOT NULL,
    [RentYear]           INT           NOT NULL,
    [RentPayerName]      VARCHAR (100) NULL,
    [RentedPropertyName] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([VPRentID] ASC)
);

