CREATE TABLE [dbo].[LeaveBalance]
(
	[LeaveBalanceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NULL, 
    [LeaveTypeID] INT NULL, 
    [LeaveYear] INT NULL, 
    [LeaveDays] DECIMAL(10, 2) NULL, 
    [Attendance] INT NULL
)
