CREATE TABLE [dbo].[Form3] (
    [CashBookID]  INT             IDENTITY (1, 1) NOT NULL,
    [PayDate]     DATE            NULL,
    [Amount]      DECIMAL (18, 2) NULL,
    [LedgerID]    INT             NULL,
    [SubLedgerID] INT             NULL,
    [TransNo]     INT             NULL,
    [TransPerson] VARCHAR (150)   NULL,
    PRIMARY KEY CLUSTERED ([CashBookID] ASC),
    CONSTRAINT [FK_Form3_Ledger] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_Form3_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

