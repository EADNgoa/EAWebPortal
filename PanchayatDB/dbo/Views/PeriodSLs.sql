CREATE VIEW [dbo].[PeriodSLs]
	AS SELECT Top 5 PeriodID, CONCAT(FromYr, ' to ', ToYr) as PeriodSL FROM Period
	ORDER BY ToYr DESC