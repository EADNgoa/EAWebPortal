CREATE TABLE [dbo].[CBRunning] (
    [EntryDate]    DATE            NOT NULL,
    [TotalInflow]  DECIMAL (18, 2) NULL,
    [TotalOutflow] DECIMAL (18, 2) NULL,
    [CBTotal]      DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([EntryDate] ASC)
);

