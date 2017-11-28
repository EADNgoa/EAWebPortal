CREATE TABLE [dbo].[Building] (
    [BuildingID]          INT             IDENTITY (1, 1) NOT NULL,
    [WardNo]              VARCHAR (50)    NULL,
    [House No]            VARCHAR (10)    NULL,
    [OwnerName]           VARCHAR (100)   NULL,
    [NameOfConstructioin] VARCHAR (250)   NULL,
    [DateOfAppl]          DATE            NULL,
    [NoOfRes]             VARCHAR (50)    NULL,
    [DateOfRes]           DATE            NULL,
    [DateOfPermision]     DATE            NULL,
    [EstimatedCost]       DECIMAL (18, 2) NULL,
    [AmountPaid]          DECIMAL (15, 2) NULL,
    [DateOfCompletion]    DATE            NULL,
    [DateOfOcccp]         DATE            NULL,
    [DateOfAsses]         DATE            NULL,
    [HouseTax]            DECIMAL (15, 2) NULL,
    [Remarks]             VARCHAR (250)   NULL,
    [ReceiptNo]           INT             NULL,
    PRIMARY KEY CLUSTERED ([BuildingID] ASC),
    CONSTRAINT [FK_Building_ToForm4] FOREIGN KEY ([ReceiptNo]) REFERENCES [dbo].[Form4] ([RecieptNo])
);

