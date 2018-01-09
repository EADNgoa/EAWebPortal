CREATE TABLE [dbo].[Users]
(
	[UserID] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [UserName] VARCHAR(100) NULL, 
    [GtekID] INT NULL, 
    CONSTRAINT [FK_Users_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
