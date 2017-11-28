CREATE TABLE [dbo].[Outward] (
    [OutwardID]         INT             IDENTITY (1, 1) NOT NULL,
    [DateOfDisp]        DATE            NULL,
    [ToWhom]            VARCHAR (250)   NULL,
    [FileReferenceNo]   VARCHAR (30)    NULL,
    [FileReferenceDate] DATE            NULL,
    [SubjectMatter]     VARCHAR (350)   NULL,
    [PostageDrawn]      DECIMAL (10, 2) NULL,
    [PostageExtended]   DECIMAL (10, 2) NULL,
    [Remark]            VARCHAR (250)   NULL,
    [RegisterTypeID]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([OutwardID] ASC),
    CONSTRAINT [FK_Outward_ToTable] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID])
);

