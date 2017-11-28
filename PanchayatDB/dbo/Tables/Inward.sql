CREATE TABLE [dbo].[Inward] (
    [InwardID]       INT           IDENTITY (1, 1) NOT NULL,
    [DateOfReciept]  DATE          NULL,
    [FromWhereRec]   VARCHAR (150) NULL,
    [NoOfLett]       VARCHAR (30)  NULL,
    [DateOfLett]     DATE          NULL,
    [FileNo]         VARCHAR (100) NULL,
    [SubjectMatter]  VARCHAR (150) NULL,
    [ActionTaken]    DATE          NULL,
    [Remark]         VARCHAR (250) NULL,
    [RegisterTypeID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([InwardID] ASC),
    CONSTRAINT [FK_Inward_RegisterTypes] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

