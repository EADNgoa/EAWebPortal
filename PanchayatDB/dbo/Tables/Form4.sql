CREATE TABLE [dbo].[Form4] (
    [RecieptNo]   INT             IDENTITY (1, 1) NOT NULL,
    [CitizenID]   INT             NULL,
    [Amount]      DECIMAL (18, 2) NULL,
    [PayDate]     DATE            NULL,
    [LedgerID]    INT             NULL,
    [SubLedgerID] INT             NULL,
    [RecvdFrom]   VARCHAR (150)   NULL,
    [HouseNo]     VARCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([RecieptNo] ASC),
    CONSTRAINT [FK_Form4_Citizen] FOREIGN KEY ([CitizenID]) REFERENCES [dbo].[Citizen] ([CitizenID]),
    CONSTRAINT [FK_Form4_Ledger] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_Form4_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

