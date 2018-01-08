CREATE TABLE [dbo].[LeaveEntitlement]
(
	[LeaveEntitlementID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LeaveYear] INT NULL, 
    [LeaveTypeID] INT NULL, 
    [LeaveDays] DECIMAL(10, 2) NULL,
 CONSTRAINT [FK_LeaveEntitlement_LeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [LeaveType]([LeaveTypeID])

)
