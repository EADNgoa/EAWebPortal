CREATE TABLE [dbo].[Corrections] (
    [CorrectionID]   INT             IDENTITY (1, 1) NOT NULL,
    [CorrectionDate] DATE            NULL,
    [RecieptID]      INT             NULL,
    [VoucherID]      INT             NULL,
    [Amount]         DECIMAL (18, 2) NULL,
    [Remark]         VARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([CorrectionID] ASC),
    CONSTRAINT [FK_Corrections_Reciept] FOREIGN KEY ([RecieptID]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_Corrections_Voucher] FOREIGN KEY ([VoucherID]) REFERENCES [dbo].[Voucher] ([VoucherID])
);

