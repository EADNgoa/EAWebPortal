CREATE TABLE [dbo].[LeaveEntitlement] (
    [LeaveEntitlementID] INT             IDENTITY (1, 1) NOT NULL,
    [LeaveYear]          INT             NOT NULL,
    [LeaveTypeID]        INT             NOT NULL,
    [LeaveDays]          DECIMAL (10, 2) NULL,
    [Attendance]         INT             NULL,
    CONSTRAINT [FK_LeaveEntitlement_LeaveType] FOREIGN KEY ([LeaveTypeID]) REFERENCES [dbo].[LeaveType] ([LeaveTypeID]), 
    CONSTRAINT [PK_LeaveEntitlement] PRIMARY KEY ([LeaveEntitlementID])
);

