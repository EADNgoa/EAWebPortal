CREATE TABLE [dbo].[LeaveApplication]
(
	[LeaveApplicationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ApplicationDate] DATE NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [LeaveTypeID] INT NULL, 
    [LeaveStartDate] DATE NULL, 
    [NoOfDays] INT NULL, 
    [StatusID] INT NULL, 
    [StatusBy] NVARCHAR(128) NULL, 
    [StatusDate] DATE NULL, 
    CONSTRAINT [FK_LeaveApplication_LeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [LeaveType]([LeaveTypeID]), 
    CONSTRAINT [FK_LeaveApplication_Status] FOREIGN KEY ([StatusID]) REFERENCES [Status]([StatusID])
)
