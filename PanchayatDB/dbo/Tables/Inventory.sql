CREATE TABLE [dbo].[Inventory] (
    [ItemID] INT             NOT NULL,
    [Qty]    DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_Inventory_ToInvItems] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[InvItems] ([ItemID])
);

