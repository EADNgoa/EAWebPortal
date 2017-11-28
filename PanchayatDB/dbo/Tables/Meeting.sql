CREATE TABLE [dbo].[Meeting] (
    [MeetingID]      INT           IDENTITY (1, 1) NOT NULL,
    [Subject]        VARCHAR (350) NULL,
    [ProposerName]   VARCHAR (100) NULL,
    [PropOrAmend]    BIT           NULL,
    [For]            INT           NULL,
    [Against]        INT           NULL,
    [MeetingDate]    DATE          NULL,
    [Resolution]     VARCHAR (MAX) NULL,
    [Remark]         VARCHAR (350) NULL,
    [RegisterTypeID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([MeetingID] ASC),
    CONSTRAINT [FK_Meeting_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

