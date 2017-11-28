CREATE TABLE [dbo].[Form2] (
    [Form2ID]           INT             IDENTITY (1, 1) NOT NULL,
    [Month]             INT             NULL,
    [Year]              INT             NULL,
    [LedgerID]          INT             NULL,
    [SubLedgerID]       INT             NULL,
    [ShortParticaulars] VARCHAR (50)    NULL,
    [Amount]            DECIMAL (18, 2) NULL,
    [Progressive]       DECIMAL (18, 2) NULL,
    [Total]             DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Form2ID] ASC),
    CONSTRAINT [FK_Form2_Ledger] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_Form2_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

