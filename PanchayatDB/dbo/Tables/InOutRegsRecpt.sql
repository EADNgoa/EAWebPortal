CREATE TABLE [dbo].[InOutRegsRecpt] (
    [IORecptID]              INT             IDENTITY (1, 1) NOT NULL,
    [RegisterTypeID]         INT             NULL,
    [TDate]                  DATE            NULL,
    [ItemID]                 INT             NULL,
    [Qty]                    INT             NULL,
    [Value]                  DECIMAL (18, 2) NULL,
    [RVno]                   INT             NULL,
    [PropertyParticulars]    VARCHAR (250)   NULL,
    [SituatedWhere]          VARCHAR (250)   NULL,
    [DepositPurpose]         VARCHAR (250)   NULL,
    [ValuationDetails]       VARCHAR (50)    NULL,
    [SanctionDateNo]         VARCHAR (50)    NULL,
    [SanctionByWhom]         VARCHAR (50)    NULL,
    [PeriodToSpendYrs]       TINYINT         NULL,
    [TreasureVoucherDetails] VARCHAR (250)   NULL,
    PRIMARY KEY CLUSTERED ([IORecptID] ASC),
    CONSTRAINT [FK_InOutRegsRecpt_ToInvItems] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[InvItems] ([ItemID]),
    CONSTRAINT [FK_InOutRegsRecpt_ToRegType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

