CREATE TABLE [dbo].[LeaveApplication]
(
	[LeaveApplicationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ApplicationDate] DATE NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [LeaveTypeID] INT NULL, 
    [LeaveStartDate] DATE NULL, 
    [NoOfDays] INT NULL, 
    [Status] INT NULL, 
    [StatusBy] INT NULL, 
    [StatusDate] DATE NULL, 
    CONSTRAINT [FK_LeaveApplication_LeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [LeaveType]([LeaveTypeID])
)
