CREATE TABLE [dbo].[Form1] (
    [Form1ID]     INT             IDENTITY (1, 1) NOT NULL,
    [LedgerID]    INT             NULL,
    [SubLedgerID] INT             NULL,
    [EntryDate]   DATE            NULL,
    [Particulars] VARCHAR (50)    NULL,
    [Amount]      DECIMAL (18, 2) NULL,
    [Progressive] DECIMAL (18, 2) NULL,
    [Total]       DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Form1ID] ASC),
    CONSTRAINT [FK_Form1_Ledger] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_Form1_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

