CREATE TABLE [dbo].[DemandYear] (
    [DemandYear] INT             NOT NULL,
    [DDID]       INT             NOT NULL,
    [PeriodID]   INT             NOT NULL,
    [Arrears]    DECIMAL (18, 2) NULL,
    [RecieptNo]  INT             NULL,
    [RecptAmt]   DECIMAL (18, 2) NULL,
    [RecptDate]  DATE            NULL,
    CONSTRAINT [PK_DemandYear] PRIMARY KEY CLUSTERED ([DemandYear] ASC, [DDID] ASC, [PeriodID] ASC),
    CONSTRAINT [FK_DemandYear_ToDemandDetails] FOREIGN KEY ([DDID]) REFERENCES [dbo].[DemandDetails] ([DDID]),
    CONSTRAINT [FK_DemandYear_ToForm4] FOREIGN KEY ([RecieptNo]) REFERENCES [dbo].[Form4] ([RecieptNo]),
    CONSTRAINT [FK_DemandYear_ToPeriod] FOREIGN KEY ([PeriodID]) REFERENCES [dbo].[Period] ([PeriodID])
);

