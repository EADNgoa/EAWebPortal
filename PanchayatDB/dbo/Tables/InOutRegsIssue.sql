CREATE TABLE [dbo].[InOutRegsIssue] (
    [IOissueID]      INT             IDENTITY (1, 1) NOT NULL,
    [IORecptID]      INT             NULL,
    [RegisterTypeID] INT             NULL,
    [TDate]          DATE            NULL,
    [ItemID]         INT             NULL,
    [Qty]            INT             NULL,
    [Value]          DECIMAL (18, 2) NULL,
    [IssuedTo]       VARCHAR (350)   NULL,
    [Balance]        DECIMAL (18, 2) NULL,
    [Remarks]        VARCHAR (350)   NULL,
    [RVno]           INT             NULL,
    [RefundReason]   VARCHAR (250)   NULL,
    PRIMARY KEY CLUSTERED ([IOissueID] ASC),
    CONSTRAINT [FK_InOutRegsIssu_ToInvItems] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[InvItems] ([ItemID]),
    CONSTRAINT [FK_InOutRegsIssu_ToRegType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_InOutRegsIssue_ToIORecptID] FOREIGN KEY ([IORecptID]) REFERENCES [dbo].[InOutRegsRecpt] ([IORecptID])
);

