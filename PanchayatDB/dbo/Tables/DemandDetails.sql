CREATE TABLE [dbo].[DemandDetails] (
    [DDID]        INT IDENTITY (1, 1) NOT NULL,
    [DemandID]    INT NOT NULL,
    [SubLedgerID] INT NOT NULL,
    CONSTRAINT [PK_DemandDetails] PRIMARY KEY CLUSTERED ([DDID] ASC),
    CONSTRAINT [FK_DemandDetails_Demand] FOREIGN KEY ([DemandID]) REFERENCES [dbo].[Demand] ([DemandID]),
    CONSTRAINT [FK_DemandDetails_SubLedgerID] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

