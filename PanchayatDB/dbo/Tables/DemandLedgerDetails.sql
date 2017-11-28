CREATE TABLE [dbo].[DemandLedgerDetails] (
    [DemandLedgerDetailsID] INT          IDENTITY (1, 1) NOT NULL,
    [DDID]                  INT          NULL,
    [LedgerDetailID]        INT          NULL,
    [DemandLedgerDetail]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([DemandLedgerDetailsID] ASC),
    CONSTRAINT [FK_DemandLedgerDetails_Demand] FOREIGN KEY ([DDID]) REFERENCES [dbo].[DemandDetails] ([DDID]),
    CONSTRAINT [FK_DemandLedgerDetails_LederDetail] FOREIGN KEY ([LedgerDetailID]) REFERENCES [dbo].[LedgerDetails] ([LedgerDetailID])
);

