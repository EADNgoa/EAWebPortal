CREATE TABLE [dbo].[OccupationCertificate] (
    [OccupationCertificateID] INT            IDENTITY (1, 1) NOT NULL,
    [PersonName]              VARCHAR (100)  NULL,
    [PersonAddress]           VARCHAR (250)  NULL,
    [MeetingDated]            DATE           NULL,
    [ConstLicNo]              VARCHAR (100)  NULL,
    [BuildingDetails]         VARCHAR (MAX)  NULL,
	[ConstLicDate]                   DATE           NULL,

    [Tdate]                   DATE           NULL,
    [SurveyNo]                VARCHAR (100)  NULL,
    [PlotNumber]              VARCHAR (50)   NULL,
    [RefNo]                   VARCHAR (100)  NULL,
    [RefDate]                 DATE           NULL,
    [HSref]                   VARCHAR (100)  NULL,
    [HSrefdate]               DATE           NULL,
    [RegisterTypeID]          INT            NULL,
    [WEBstatusID]             INT            NULL,
    [UserID]                  NVARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([OccupationCertificateID] ASC),
    CONSTRAINT [FK_Occuoation_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Occuoation_RegisterType] FOREIGN KEY ([RegisterTypeID]) REFERENCES [dbo].[RegisterTypes] ([RegisterTypeID]),
    CONSTRAINT [FK_Occuoation_WEBstatus] FOREIGN KEY ([WEBstatusID]) REFERENCES [dbo].[WEBstatus] ([WebStatusID])
);

