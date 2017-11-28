CREATE TABLE [dbo].[Voucher] (
    [VoucherID]    INT             IDENTITY (1, 1) NOT NULL,
    [PassedBy]     NVARCHAR (128)  NULL,
    [of]           VARCHAR (100)   NULL,
    [Amount]       DECIMAL (18, 2) NULL,
    [ActualAmount] DECIMAL (18, 2) NULL,
    [For]          VARCHAR (MAX)   NULL,
    [PayDate]      DATE            NULL,
    [CBfolio]      INT             NULL,
    [ResNo]        VARCHAR (50)    NULL,
    [HeldOn]       DATE            NULL,
    [Meeting]      VARCHAR (50)    NULL,
    [LedgerID]     INT             NULL,
    [SubLedgerID]  INT             NULL,
    PRIMARY KEY CLUSTERED ([VoucherID] ASC),
    CONSTRAINT [FK_Voucher_Ledger] FOREIGN KEY ([LedgerID]) REFERENCES [dbo].[Ledgers] ([LedgerID]),
    CONSTRAINT [FK_Voucher_SubLedger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

