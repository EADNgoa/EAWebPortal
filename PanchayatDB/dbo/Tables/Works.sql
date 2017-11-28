﻿CREATE TABLE [dbo].[Works] (
    [WorksID]                INT           IDENTITY (1, 1) NOT NULL,
    [NameOfWork]             VARCHAR (300) NOT NULL,
    [TechSanctionNo]         VARCHAR (300) NULL,
    [ContractorName]         VARCHAR (100) NULL,
    [PercentageAccepted]     VARCHAR (50)  NULL,
    [EMDIOrecptID]           INT           NULL,
    [SDIOrecptID]            INT           NULL,
    [ITrecptNo]              INT           NULL,
    [RoyaltyDeposit]         INT           NULL,
    [TimeLimit]              VARCHAR (50)  NULL,
    [ExtentionTime]          VARCHAR (50)  NULL,
    [EstimatedCost]          DECIMAL (18)  NULL,
    [TenderedCost]           DECIMAL (18)  NULL,
    [FinalValue]             DECIMAL (18)  NULL,
    [NetPaymentToContractor] DECIMAL (18)  NULL,
    [CommenceDate]           DATE          NULL,
    [CompletionDate]         DATE          NULL,
    [GrantsRecieved]         DECIMAL (18)  NULL,
    [GrantsUtilized]         DECIMAL (18)  NULL,
    [MBNo]                   VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([WorksID] ASC),
    CONSTRAINT [FK_Works_ToIOregRecptEMD] FOREIGN KEY ([EMDIOrecptID]) REFERENCES [dbo].[InOutRegsRecpt] ([IORecptID]),
    CONSTRAINT [FK_Works_ToIOregRecptIT] FOREIGN KEY ([ITrecptNo]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_Works_ToIOregRecptRD] FOREIGN KEY ([RoyaltyDeposit]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_Works_ToIOregRecptSD] FOREIGN KEY ([SDIOrecptID]) REFERENCES [dbo].[InOutRegsRecpt] ([IORecptID])
);

