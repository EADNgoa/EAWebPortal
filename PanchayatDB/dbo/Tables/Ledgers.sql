CREATE TABLE [dbo].[Ledgers] (
    [LedgerID] INT          IDENTITY (1, 1) NOT NULL,
    [Ledger]   VARCHAR (70) NULL,
    [IsIncome] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([LedgerID] ASC)
);

