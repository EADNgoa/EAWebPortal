CREATE TABLE [dbo].[Config] (
    [ConfigID]      INT          IDENTITY (1, 1) NOT NULL,
    [VP]            VARCHAR (50) NULL,
    [DemandIncPerc] DECIMAL (18) NULL,
    [ArrearsPerc]   DECIMAL (18) NULL,
    [RowsPerPage]   INT          NULL,
    PRIMARY KEY CLUSTERED ([ConfigID] ASC)
);

