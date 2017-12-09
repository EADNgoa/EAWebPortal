CREATE TABLE [dbo].[MovementReg]
(
	[MovementRegID] INT NOT NULL PRIMARY KEY, 
    [NameAndDes] VARCHAR(150) NULL, 
    [TimeOfDeparture] DATETIME NULL, 
    [TimeOfReturn] DATETIME NULL, 
    [PlaceAndPurpose] VARCHAR(250) NULL

)
