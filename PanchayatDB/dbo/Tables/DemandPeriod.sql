CREATE TABLE [dbo].[DemandPeriod] (
    [DDID]     INT             NOT NULL,
    [PeriodID] INT             NOT NULL,
    [Amount]   DECIMAL (15, 2) NULL,
    [SysAmt]   DECIMAL (15, 2) NULL,
    CONSTRAINT [PK_DemandPeriod] PRIMARY KEY CLUSTERED ([DDID] ASC, [PeriodID] ASC),
    CONSTRAINT [FK_DemandPeriod_ToDemandDetails] FOREIGN KEY ([DDID]) REFERENCES [dbo].[DemandDetails] ([DDID]),
    CONSTRAINT [FK_DemandPeriod_ToPeriod] FOREIGN KEY ([PeriodID]) REFERENCES [dbo].[Period] ([PeriodID])
);

