CREATE TABLE [dbo].[LedgerDetails] (
    [LedgerDetailID] INT           IDENTITY (1, 1) NOT NULL,
    [SubLedgerID]    INT           NULL,
    [LedgerDetail]   VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([LedgerDetailID] ASC),
    CONSTRAINT [FK_LedgerDetails_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

