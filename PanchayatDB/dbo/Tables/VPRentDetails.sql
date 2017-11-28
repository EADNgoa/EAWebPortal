CREATE TABLE [dbo].[VPRentDetails] (
    [VPRentID]       INT             NOT NULL,
    [Month]          INT             NOT NULL,
    [Arrears]        DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [Current]        DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [RecoveryAmt]    DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [RecoveryDate]   DATE            NOT NULL,
    [BalanceArrears] DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [BalanceCurrent] DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [ReceiptNo]      INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_VPRentDetails] PRIMARY KEY CLUSTERED ([VPRentID] ASC, [Month] ASC),
    CONSTRAINT [FK_VPRentDetails_ToForm4] FOREIGN KEY ([ReceiptNo]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_VPRentDetails_ToVPRent] FOREIGN KEY ([VPRentID]) REFERENCES [dbo].[VPRent] ([VPRentID])
);

