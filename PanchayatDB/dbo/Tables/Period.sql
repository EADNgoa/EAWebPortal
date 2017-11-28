CREATE TABLE [dbo].[Period] (
    [PeriodID] INT IDENTITY (1, 1) NOT NULL,
    [FromYr]   INT NOT NULL,
    [ToYr]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([PeriodID] ASC)
);

