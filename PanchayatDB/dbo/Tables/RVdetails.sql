CREATE TABLE [dbo].[RVdetails] (
    [RVdetailID]     INT           IDENTITY (1, 1) NOT NULL,
    [ReceiptNo]      INT           NULL,
    [VoucherID]      INT           NULL,
    [LedgerDetailID] INT           NOT NULL,
    [RVDetail]       VARCHAR (300) NULL,
    PRIMARY KEY CLUSTERED ([RVdetailID] ASC),
    CONSTRAINT [FK_RVDetails_LederDetail] FOREIGN KEY ([LedgerDetailID]) REFERENCES [dbo].[LedgerDetails] ([LedgerDetailID]),
    CONSTRAINT [FK_RVdetails_ToReceipt] FOREIGN KEY ([ReceiptNo]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_RVdetails_ToVoucher] FOREIGN KEY ([VoucherID]) REFERENCES [dbo].[Voucher] ([VoucherID])
);

