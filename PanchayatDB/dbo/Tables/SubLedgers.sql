CREATE TABLE [dbo].[SubLedgers] (
    [SubLedgerID]     INT          IDENTITY (1, 1) NOT NULL,
    [LedgerID]        INT          NULL,
    [SubLedgerTypeID] INT          NULL,
    [Ledger]          VARCHAR (70) NULL,
    [HasDemand]       BIT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([SubLedgerID] ASC),
    CONSTRAINT [FK_SubLedgers_Ledgers] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_SubLedgers_SubLedgerType] FOREIGN KEY ([SubLedgerTypeID]) REFERENCES [dbo].[SubLedgerType] ([SubLedgerTypeID])
);

