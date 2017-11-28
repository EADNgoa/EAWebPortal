CREATE TABLE [dbo].[IllegalConstruction] (
    [IllegalConID]   INT           IDENTITY (1, 1) NOT NULL,
    [DateOfComp]     DATE          NULL,
    [NameOfPr]       VARCHAR (100) NULL,
    [AddressOfPr]    VARCHAR (250) NULL,
    [NatOfCon]       VARCHAR (300) NULL,
    [OccasOfCons]    VARCHAR (50)  NULL,
    [ActionTaken]    VARCHAR (350) NULL,
    [Remarks]        VARCHAR (350) NULL,
    [RegisterTypeID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IllegalConID] ASC),
    CONSTRAINT [FK_IllegalConstruction_RegisterTypes] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

