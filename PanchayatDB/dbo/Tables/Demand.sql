CREATE TABLE [dbo].[Demand] (
    [DemandID]  INT           IDENTITY (1, 1) NOT NULL,
    [CitizenID] INT           NULL,
    [HouseNo]   VARCHAR (10)  NULL,
    [CreatedOn] DATE          DEFAULT ('01-04-2016') NOT NULL,
    [StopDate]  DATE          DEFAULT ('31-03-3999') NOT NULL,
    [Remarks]   VARCHAR (300) NULL,
    CONSTRAINT [PK_Demand] PRIMARY KEY CLUSTERED ([DemandID] ASC),
    CONSTRAINT [FK_Demand_CitizenID] FOREIGN KEY ([CitizenID]) REFERENCES [dbo].[Citizen] ([CitizenID])
);

