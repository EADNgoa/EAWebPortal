﻿CREATE TABLE [dbo].[RegisterTypes] (
    [RegisterTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [RegisterType]   VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([RegisterTypeID] ASC),
	    CONSTRAINT [FK_CertificateRequirements_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [RegisterTypes]([RegisterTypeID])

);

