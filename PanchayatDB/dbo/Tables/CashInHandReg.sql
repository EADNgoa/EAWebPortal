CREATE TABLE [dbo].[CashInHandReg]
(
	[CashInHandRegID] INT NOT NULL PRIMARY KEY, 
    [Tdate] DATETIME NULL, 
    [NameAndDesg] VARCHAR(150) NULL, 
    [CashToDeclareStart] DECIMAL(18, 2) NULL, 
    [DetailsOfCashExp] VARCHAR(250) NULL, 
    [CashToDeclareEnd] DECIMAL(18, 2) NULL, 
    [Remarks] VARCHAR(300) NULL
)
