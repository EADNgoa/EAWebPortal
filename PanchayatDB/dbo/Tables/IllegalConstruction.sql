CREATE TABLE [dbo].[IllegalConstruction] (
    [IllegalConID]   INT           IDENTITY (1, 1) NOT NULL,
    [DateOfComp]     DATE          NULL,
    [NameOfPr]       VARCHAR (100) NULL,
    [AddressOfPr]    VARCHAR (250) NULL,
    [NatOfCon]       VARCHAR (300) NULL,
    [OccasOfCons]    VARCHAR (50)  NULL,
    [ActionTaken]    VARCHAR (350) NULL,
    [Remarks]        VARCHAR (350) NULL,
	[WEBstatusID]       INT NULL,
	[UserID]       NVARCHAR(128) NULL,

    [RegisterTypeID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IllegalConID] ASC),
    CONSTRAINT [FK_IllegalConstruction_RegisterTypes] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
	CONSTRAINT [FK_IllegalConstruction_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WEBstatusID]), 
    CONSTRAINT [FK_IllegalConstruction_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers]([Id])


);

