CREATE TABLE [dbo].[InvItems] (
    [ItemID]         INT           IDENTITY (1, 1) NOT NULL,
    [Item]           VARCHAR (350) NULL,
    [RegisterTypeID] INT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_InvItems_ToRegisterTypes] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

