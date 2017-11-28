CREATE TABLE [dbo].[Noc] (
    [NocID]             INT           IDENTITY (1, 1) NOT NULL,
    [DateOfReciept]     DATE          NULL,
    [NameAndAdressAppl] VARCHAR (350) NULL,
    [NatOfNoc]          VARCHAR (350) NULL,
    [DateOfVp]          DATE          NULL,
    [NoOfResolution]    INT           NULL,
    [IssueOrReject]     BIT           NULL,
    [RejectedReason]    VARCHAR (250) NULL,
    [DateOfComm]        DATE          NULL,
    [Remarks]           VARCHAR (250) NULL,
    [RegisterTypeID]    INT           NULL,
    PRIMARY KEY CLUSTERED ([NocID] ASC),
    CONSTRAINT [FK_Noc_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

