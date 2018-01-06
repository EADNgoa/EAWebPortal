CREATE TABLE [dbo].[Notice]
(
	[NoticeID] INT NOT NULL PRIMARY KEY, 
    [Subject] VARCHAR(200) NULL, 
    [Body] VARCHAR(MAX) NULL, 
    [To] VARCHAR(100) NULL, 
    [ToAddress] VARCHAR(200) NULL, 
    [CopyTo] VARCHAR(100) NULL, 
    [CopyToAddress] VARCHAR(100) NULL, 
    [UserID] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_Notice_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
