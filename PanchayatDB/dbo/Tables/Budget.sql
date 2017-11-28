CREATE TABLE [dbo].[Budget] (
    [BudgetID]       INT             IDENTITY (1, 1) NOT NULL,
    [BudgtFY]        INT             NULL,
    [SubLedgerID]    INT             NOT NULL,
    [BudgetAmount]   DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    [ActualAmount]   DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    [OpeningBalance] DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([BudgetID] ASC),
    CONSTRAINT [FK_Budget_ToSubledger] FOREIGN KEY ([SubLedgerID]) REFERENCES [dbo].[SubLedgers] ([SubLedgerID])
);

